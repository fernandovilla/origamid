using AgendaBolo.UI.ComponentModel;
using AgendaBolo.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaBolo.UI.Windows.Forms
{    
    [TypeConverter(typeof(TextBoxFormatConverter))]
    [DebuggerNonUserCode()]
    public abstract class TextBoxFormat
    {
        private Dictionary<TextBox, TextBoxMessageHandle> textBoxes;
        private bool enabled;

        protected delegate void WndProcDelegate(ref Message m);

        public event CharacterValidationEventHandler CharacterValidation;


        [DebuggerNonUserCode()]
        protected class TextBoxMessageHandle : NativeWindow, IDisposable
        {
            private HandlerList handlers;
            private TextBox textBox;



            public void Subscribe(int message, WndProcDelegate handler)
            {
                this.handlers.AddHandler(message, handler);
            }

            public void Unsubscribe(int message, WndProcDelegate handler)
            {
                this.handlers.RemoveHandler(message, handler);
            }


            private void WmDestroy(ref Message m)
            {
                this.ReleaseHandle();

                base.WndProc(ref m);
            }

            protected override void WndProc(ref Message m)
            {
                WndProcDelegate handler;

                if (m.Msg == NativeMethods.WM_DESTROY)
                {
                    this.WmDestroy(ref m);
                }
                else if ((handler = (WndProcDelegate)handlers[m.Msg]) != null)
                {
                    handler(ref m);
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            private void TextBox_HandleCreated(object sender, EventArgs e)
            {
                this.AssignHandle(this.textBox.Handle);
            }

            public TextBoxMessageHandle(TextBox textBox)
            {
                this.handlers = new HandlerList();
                this.textBox = textBox;

                if (this.textBox.IsHandleCreated)
                {
                    this.AssignHandle(this.textBox.Handle);
                }

                this.textBox.HandleCreated += this.TextBox_HandleCreated;
            }

            ~TextBoxMessageHandle()
            {
                this.Dispose(false);
            }

            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                this.ReleaseHandle();

                this.textBox.HandleCreated -= this.TextBox_HandleCreated;
            }
        }


        [Browsable(false)]
        public abstract string Name { get; }


        [Browsable(false)]
        public IEnumerable<TextBox> TextBoxes
        {
            get
            {
                return this.textBoxes.Keys;
            }
        }


        [DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }


        public bool Validate(ref char c, TextContext context)
        {
            return this.Validate(ref c, context, false);
        }

        protected virtual bool Validate(ref char c, TextContext context, bool cancel)
        {
            CharacterValidationEventArgs args = new CharacterValidationEventArgs(c, context, cancel);

            this.OnCharacterValidation(args);

            c = args.Character;

            return !args.Cancel;
        }

        public virtual string Validate(string text, TextContext context)
        {
            TextContext ctx = context;

            StringBuilder buffer = new StringBuilder(text.Length);

            foreach (char c in text)
            {
                char x = c;

                if (this.Validate(ref x, ctx) && x != '\0')
                {
                    buffer.Append(x);

                    ctx = new TextContext(ctx.Method, ctx.Text.Insert(ctx.Position, x.ToString()), ctx.Position + 1, ctx.Multiline);
                }
            }

            return buffer.ToString();
        }

        protected void SetText(TextBox textBox, string text)
        {
            bool enabled = this.Enabled;

            this.Enabled = false;

            try
            {
                textBox.Text = text;
            }
            finally
            {
                this.Enabled = enabled;
            }
        }

        protected TextContext GetTextContext(TextBox textBox, TextContextMethod method)
        {
            string text = string.Empty;
            int position = 0;

            if (method == TextContextMethod.Paste || method == TextContextMethod.Typing)
            {
                text = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
                position = textBox.SelectionStart;
            }

            return new TextContext(method, text, position, textBox.Multiline);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Enabled && !e.Handled && !((Control.ModifierKeys & Keys.Control) == Keys.Control || (Control.ModifierKeys & Keys.Alt) == Keys.Alt || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter))
            {
                TextBox textBox = (TextBox)sender;

                TextContext context = this.GetTextContext(textBox, TextContextMethod.Typing);

                char c = e.KeyChar;

                if (this.Validate(ref c, context))
                {
                    e.KeyChar = c;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        protected virtual void WmSetText(ref Message m)
        {
            TextBox textBox = (TextBox)Control.FromHandle(m.HWnd);

            if (!this.Enabled || textBox == null)
            {
                this.WndProc(ref m);
            }
            else
            {
                string text = Marshal.PtrToStringAuto(m.LParam);

                TextContext context = this.GetTextContext(textBox, TextContextMethod.Set);

                string valid = this.Validate(text, context);

                m.LParam = Marshal.StringToHGlobalAuto(valid);

                this.WndProc(ref m);

                Marshal.FreeHGlobal(m.LParam);
            }
        }

        protected virtual void WmPaste(ref Message m)
        {
            TextBox textBox = (TextBox)Control.FromHandle(m.HWnd);

            if (!this.Enabled || textBox == null)
            {
                this.WndProc(ref m);
            }
            else
            {
                string text = Clipboard.GetText();

                TextContext context = this.GetTextContext(textBox, TextContextMethod.Paste);

                string valid = this.Validate(text, context);

                if (string.IsNullOrEmpty(valid)) Clipboard.Clear(); else Clipboard.SetText(valid);

                this.WndProc(ref m);

                #region Marcio André 18/01/2022
                //A linha a seguir dá erro caso 'text' esteja vazio ("")
                //Clipboard.SetText(text);
                #endregion
                if (string.IsNullOrEmpty(valid)) Clipboard.Clear(); else Clipboard.SetText(text);
            }
        }

        protected void WndProc(ref Message m)
        {
            TextBox textBox = (TextBox)Control.FromHandle(m.HWnd);

            TextBoxMessageHandle messages = this.textBoxes[textBox];

            messages.DefWndProc(ref m);
        }


        public void Assign(TextBox textBox)
        {
            if (!this.textBoxes.ContainsKey(textBox))
            {
                TextBoxMessageHandle messages = new TextBoxMessageHandle(textBox);

                this.textBoxes.Add(textBox, messages);

                this.Assign(textBox, messages);
            }
        }

        protected virtual void Assign(TextBox textBox, TextBoxMessageHandle messages)
        {
            textBox.KeyPress += this.TextBox_KeyPress;

            messages.Subscribe(NativeMethods.WM_SETTEXT, this.WmSetText);
            messages.Subscribe(NativeMethods.WM_PASTE, this.WmPaste);
        }

        public void ReleaseAll()
        {
            while (this.textBoxes.Keys.Any())
            {
                TextBox textBox = this.textBoxes.Keys.First();

                this.Release(textBox);
            }
        }

        public void Release(TextBox textBox)
        {
            if (this.textBoxes.ContainsKey(textBox))
            {
                TextBoxMessageHandle messages = this.textBoxes[textBox];

                this.Release(textBox, messages);

                this.textBoxes.Remove(textBox);

                messages.Dispose();
            }
        }

        protected virtual void Release(TextBox textBox, TextBoxMessageHandle messages)
        {
            textBox.KeyPress -= this.TextBox_KeyPress;

            messages.Unsubscribe(NativeMethods.WM_SETTEXT, this.WmSetText);
            messages.Unsubscribe(NativeMethods.WM_PASTE, this.WmPaste);
        }

        protected virtual void OnCharacterValidation(CharacterValidationEventArgs e)
        {
            this.CharacterValidation?.Invoke(this, e);
        }

        public TextBoxFormat()
        {
            this.textBoxes = new Dictionary<TextBox, TextBoxMessageHandle>();
            this.enabled = true;
        }
    }

    [ToolboxBitmap(typeof(TextBoxFormatText), "TextBoxFormatText.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatText : TextBoxFormat
    {
        private bool allowAscent;
        private CharacterCasing casing;

        private const string WrongCharsMultiline = "'ÁÉÍÓÚÂÊÎÔÛÃÕÄËÏÖÜÀÈÌÒÙÇÝŸÑ'´`~^¨\a\b\f";
        private const string ValidCharsMultiline = " AEIOUAEIOUAOAEIOUAEIOUCYYN         ";

        private const string WrongCharsSingleLine = TextBoxFormatText.WrongCharsMultiline + "\n\r\t\v";
        private const string ValidCharsSingleLine = TextBoxFormatText.ValidCharsMultiline + "    ";


        public override string Name
        {
            get
            {
                return "Text";
            }
        }

        [DefaultValue(false)]
        public bool AllowAscent
        {
            get
            {
                return this.allowAscent;
            }
            set
            {
                this.allowAscent = value;
            }
        }

        [DefaultValue(typeof(CharacterCasing), nameof(CharacterCasing.Upper))]
        public CharacterCasing Casing
        {
            get
            {
                return this.casing;
            }
            set
            {
                this.casing = value;
            }
        }

        #region Marcio André 15/09/2023
        //Alterado para remover caracteres especiais que são inseridos no TextBox quando se copia e cola o texto, conforme protocolos #180016 e #180018 do Versões.
        //protected override bool Validate(ref char c, TextContext context, bool cancel)
        //{
        //    if (this.Enabled && !cancel)
        //    {
        //        char x = char.ToUpper(c);

        //        if (!this.allowAscent)
        //        {
        //            int index = TextBoxFormatText.WrongCharsMultiline.IndexOf(x);

        //            if (index >= 0)
        //            {
        //                x = TextBoxFormatText.ValidCharsMultiline[index];
        //            }
        //        }

        //        if (this.casing == CharacterCasing.Lower || (this.casing == CharacterCasing.Normal && char.IsLower(c)))
        //        {
        //            c = char.ToLower(x);
        //        }
        //        else
        //        {
        //            c = x;
        //        }
        //    }

        //    return base.Validate(ref c, context, cancel);
        //}
        #endregion

        protected override bool Validate(ref char c, TextContext context, bool cancel)
        {
            if (this.Enabled && !cancel)
            {
                char x = char.ToUpper(c);

                if (!this.allowAscent)
                {
                    string wrongChars, validChars;

                    if (context.Multiline)
                    {
                        wrongChars = TextBoxFormatText.WrongCharsMultiline;
                        validChars = TextBoxFormatText.ValidCharsMultiline;
                    }
                    else
                    {
                        wrongChars = TextBoxFormatText.WrongCharsSingleLine;
                        validChars = TextBoxFormatText.ValidCharsSingleLine;
                    }

                    int index = wrongChars.IndexOf(x);

                    if (index >= 0)
                    {
                        x = validChars[index];
                    }
                }

                if (this.casing == CharacterCasing.Lower || (this.casing == CharacterCasing.Normal && char.IsLower(c)))
                {
                    c = char.ToLower(x);
                }
                else
                {
                    c = x;
                }
            }

            return base.Validate(ref c, context, cancel);
        }


        public TextBoxFormatText()
        {
            this.allowAscent = false;
            this.casing = CharacterCasing.Upper;
        }
    }
    
    [ToolboxBitmap(typeof(TextBoxFormatEmail), "TextBoxFormatEmail.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatEmail : TextBoxFormat
    {
        private Color linkColor;

        private static Dictionary<TextBox, State> states = new Dictionary<TextBox, State>();

        private static readonly MethodInfo OnFontChangedMethod = typeof(Control).GetMethod("OnFontChanged", BindingFlags.Instance | BindingFlags.NonPublic);


        private enum Status
        {
            Normal,
            Email
        }

        [DebuggerNonUserCode()]
        private sealed class State : IDisposable
        {
            internal Color defaultForeColor;
            internal Status status;
            internal bool mouseHoverLink;
            internal Font font;
            internal bool configuringAppearance;

            public static State FromTextBox(TextBox textBox)
            {
                State state = new State()
                {
                    defaultForeColor = textBox.ForeColor,
                    status = Status.Normal,
                    mouseHoverLink = false,
                    font = null,
                    configuringAppearance = false,
                };

                return state;
            }

            ~State()
            {
                this.Dispose();
            }

            public void Dispose()
            {
                if (this.font != null)
                {
                    this.font.Dispose();
                    this.font = null;
                }
            }
        }


        public override string Name
        {
            get
            {
                return "E-mail";
            }
        }


        [DefaultValue(typeof(Color), nameof(Color.Blue))]
        public Color LinkColor
        {
            get
            {
                return this.linkColor;
            }
            set
            {
                this.linkColor = value;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ConfigureAppearance(textBox);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ConfigureCursor(textBox);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ConfigureCursor(textBox);
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ConfigureCursor(textBox);
        }

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ProcessLink(textBox);
        }

        private void TextBox_FontChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            this.ConfigureAppearance(textBox, true);
        }

        private void WmSetFont(ref Message m)
        {
            TextBox textBox = (TextBox)Control.FromHandle(m.HWnd);

            if (textBox != null)
            {
                State state = TextBoxFormatEmail.states[textBox];

                if (state.font != null)
                {
                    m.WParam = state.font.ToHfont();
                }
            }

            this.WndProc(ref m);
        }

        //private void ConfigureAppearance(TextBox textBox)
        //{
        //    bool valid = this.IsValidEmail(textBox.Text);

        //    Status status = valid ? Status.Email : Status.Normal;

        //    State state = TextBoxFormatEmail.states[textBox];

        //    if (status != state.status)
        //    {
        //        if (valid)
        //        {
        //            textBox.Font = new Font(textBox.Font, FontStyle.Underline);
        //            textBox.ForeColor = this.LinkColor;
        //        }
        //        else
        //        {
        //            textBox.Font = new Font(textBox.Font, FontStyle.Regular);
        //            textBox.ForeColor = state.defaultForeColor;
        //        }

        //        state.status = status;
        //    }
        //}

        private void ConfigureAppearance(TextBox textBox, bool update = false)
        {
            State state = TextBoxFormatEmail.states[textBox];

            if (state.configuringAppearance) return;

            try
            {
                state.configuringAppearance = true;

                bool valid = this.IsValidEmail(textBox.Text);

                Status status = valid ? Status.Email : Status.Normal;

                if (status != state.status || update)
                {
                    Font font;

                    if (valid)
                    {
                        font = new Font(textBox.Font, FontStyle.Underline);
                        textBox.ForeColor = this.LinkColor;
                    }
                    else
                    {
                        font = new Font(textBox.Font, FontStyle.Regular);
                        textBox.ForeColor = state.defaultForeColor;
                    }

                    if (!font.Equals(state.font))
                    {
                        using (state.font)
                        {
                            state.font = font;

                            TextBoxFormatEmail.OnFontChangedMethod.Invoke(textBox, new object[] { EventArgs.Empty });
                        }
                    }

                    state.status = status;
                }
            }
            finally
            {
                state.configuringAppearance = false;
            }
        }

        private void ConfigureCursor(TextBox textBox)
        {
            State state = TextBoxFormatEmail.states[textBox];

            if (Control.ModifierKeys == Keys.Control && state.status == Status.Email && this.MouseHoverText(textBox))
            {
                state.mouseHoverLink = true;
                textBox.Cursor = Cursors.Hand;
            }
            else if (state.mouseHoverLink == true)
            {
                state.mouseHoverLink = false;
                textBox.Cursor = Cursors.IBeam;
            }
        }

        protected virtual void ProcessLink(TextBox textBox)
        {
            State state = TextBoxFormatEmail.states[textBox];

            if (state.mouseHoverLink)
            {
                string link = (this.IsValidEmail(textBox.Text) ? "mailto:" : string.Empty) + textBox.Text;

                try
                {
                    System.Diagnostics.Process.Start(link);
                }
                catch
                {
                }
            }
        }

        private bool MouseHoverText(TextBox textBox)
        {
            Point pt = textBox.PointToClient(Control.MousePosition);

            return this.MouseHoverText(textBox, pt);
        }

        private bool MouseHoverText(TextBox textBox, Point point)
        {
            int lparam = NativeMethods.MakeLong(point.X, point.Y);

            int pos = (int)NativeMethods.SendMessage(textBox.Handle, NativeMethods.EM_CHARFROMPOS, 0, lparam);

            return pos >= 0 && pos < textBox.Text.Length;
        }

        /// <summary>
        /// Pattern conforme artigo: "How to find or validate an email", tópico: The Official Standard: RFC 2822, em http://www.regular-expressions.info/email.html 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected virtual bool IsValidEmail(string text)
        {
            return Regex.IsMatch(text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }

        protected override void Assign(TextBox textBox, TextBoxMessageHandle messages)
        {
            TextBoxFormatEmail.states.Add(textBox, State.FromTextBox(textBox));

            textBox.TextChanged += this.TextBox_TextChanged;
            textBox.KeyDown += this.TextBox_KeyDown;
            textBox.KeyUp += this.TextBox_KeyUp;
            textBox.MouseMove += this.TextBox_MouseMove;
            textBox.MouseUp += this.TextBox_MouseUp;
            textBox.FontChanged += this.TextBox_FontChanged;

            messages.Subscribe(NativeMethods.WM_SETFONT, this.WmSetFont);

            base.Assign(textBox, messages);
        }

        protected override void Release(TextBox textBox, TextBoxMessageHandle messages)
        {
            TextBoxFormatEmail.states.Remove(textBox);

            textBox.TextChanged -= this.TextBox_TextChanged;
            textBox.KeyDown -= this.TextBox_KeyDown;
            textBox.KeyUp -= this.TextBox_KeyUp;
            textBox.MouseMove -= this.TextBox_MouseMove;
            textBox.MouseUp -= this.TextBox_MouseUp;
            textBox.FontChanged -= this.TextBox_FontChanged;

            messages.Unsubscribe(NativeMethods.WM_SETFONT, this.WmSetFont);

            base.Release(textBox, messages);
        }

        public TextBoxFormatEmail()
        {
            this.linkColor = Color.Blue;
        }
    }
    
    [ToolboxBitmap(typeof(TextBoxFormatNumeric), "TextBoxFormatNumeric.bmp")]
    [DebuggerNonUserCode()]
    public abstract class TextBoxFormatNumeric : TextBoxFormat
    {
        private bool allowNegative;
        private Emptiness emptiness;


        [DefaultValue(true)]
        public virtual bool AllowNegative
        {
            get
            {
                return this.allowNegative;
            }
            set
            {
                this.allowNegative = value;
            }
        }

        [DefaultValue(typeof(Emptiness), nameof(Emptiness.Blank))]
        public virtual Emptiness Emptiness
        {
            get
            {
                return this.emptiness;
            }
            set
            {
                this.emptiness = value;
            }
        }

        protected override bool Validate(ref char c, TextContext context, bool cancel)
        {
            if (this.Enabled && !cancel)
            {
                if (char.IsNumber(c))
                {
                    cancel = false;
                }
                else if (c == '.' || c == ',')
                {
                    c = ',';

                    cancel = context.Text.Contains(c);
                }
                else if (c == '-')
                {
                    bool allowNegative = this.AllowNegative;

                    if (allowNegative && context.Method == TextContextMethod.Paste)
                    {
                        allowNegative = !context.Text.Contains(c);
                    }

                    cancel = !allowNegative;
                }
                else
                {
                    cancel = true;
                }
            }

            return base.Validate(ref c, context, cancel);
        }

        protected virtual void Parse(string text, out string integer, out string fraction, out string sign)
        {
            sign = string.Empty;

            StringBuilder buffer = new StringBuilder(text.Length);
            bool decimalSeparator = false;

            foreach (char c in text)
            {
                if (char.IsNumber(c))
                {
                    buffer.Append(c);
                }
                else if (!decimalSeparator && (c == ',' || c == '.'))
                {
                    buffer.Append(',');
                    decimalSeparator = true;
                }
                else if (sign == string.Empty && (c == '-' || c == '+'))
                {
                    sign = c.ToString();
                }
            }

            string value = buffer.ToString();

            int index = value.IndexOf(",");
            if (index == -1) index = value.Length;




            buffer = new StringBuilder();
            bool allowZero = false;

            for (int i = 0; i < index; i++)
            {
                if (value[i] != '0')
                {
                    buffer.Append(value[i]);
                    allowZero = char.IsNumber(value[i]);
                }
                else if (allowZero)
                {
                    buffer.Append(value[i]);
                }
            }

            integer = buffer.ToString();




            buffer = new StringBuilder();
            allowZero = false;

            for (int i = value.Length - 1; i > index; i--)
            {
                if (value[i] != '0')
                {
                    buffer.Insert(0, value[i]);
                    allowZero = true;
                }
                else if (allowZero)
                {
                    buffer.Insert(0, value[i]);
                }
            }

            fraction = buffer.ToString();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.Handled && this.AllowNegative && e.KeyChar == '-')
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.Text.Contains('-'))
                {
                    this.UnsignNegativeValue(textBox);
                }
                else
                {
                    this.SignNegativeValue(textBox);
                }

                e.Handled = true;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (this.Enabled)
            {
                this.SetText(textBox, this.GetValue(textBox.Text));
            }

            Action align = () =>
            {
                if (!this.TextBoxes.Contains(textBox)) return;

                textBox.Enter -= this.TextBox_Enter;
                textBox.Leave -= this.TextBox_Leave;

                try
                {
                    textBox.TextAlign = HorizontalAlignment.Left;
                }
                finally
                {
                    textBox.Enter += this.TextBox_Enter;
                    textBox.Leave += this.TextBox_Leave;
                }
            };

            textBox.BeginInvoke(align);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (this.Enabled)
            {
                this.SetText(textBox, this.GetFormattedValue(textBox.Text));
            }

            Action align = () =>
            {
                if (!this.TextBoxes.Contains(textBox)) return;

                textBox.Enter -= this.TextBox_Enter;
                textBox.Leave -= this.TextBox_Leave;

                try
                {
                    textBox.TextAlign = HorizontalAlignment.Right;
                }
                finally
                {
                    textBox.Enter += this.TextBox_Enter;
                    textBox.Leave += this.TextBox_Leave;
                }
            };

            textBox.BeginInvoke(align);
        }




        protected virtual void UnsignNegativeValue(TextBox textBox)
        {
            int index = textBox.Text.IndexOf('-');
            int start = textBox.SelectionStart;
            int length = textBox.SelectionLength;

            if (index >= 0)
            {
                string text = textBox.Text.Remove(index, 1);

                this.SetText(textBox, text);

                textBox.SelectionStart = Math.Max(--start, 0);
                textBox.SelectionLength = start < 0 ? length - 1 : length;
            }
        }

        protected virtual void SignNegativeValue(TextBox textBox)
        {
            int index = textBox.Text.IndexOf('-');
            int start = textBox.SelectionStart;
            int length = textBox.SelectionLength;

            if (index < 0)
            {
                string text = '-' + textBox.Text;

                this.SetText(textBox, text);

                textBox.SelectionStart = ++start;
                textBox.SelectionLength = length;
            }
        }


        protected virtual string GetValue(string text)
        {
            return text;
        }

        protected virtual string GetFormattedValue(string text)
        {
            return text;
        }

        protected override void Assign(TextBox textBox, TextBoxMessageHandle messages)
        {
            base.Assign(textBox, messages);

            if (this.Enabled)
            {
                this.SetText(textBox, this.GetFormattedValue(textBox.Text));
            }

            textBox.TextAlign = HorizontalAlignment.Right;

            textBox.KeyPress += this.TextBox_KeyPress;
            textBox.Enter += this.TextBox_Enter;
            textBox.Leave += this.TextBox_Leave;
        }

        protected override void Release(TextBox textBox, TextBoxMessageHandle messages)
        {
            base.Release(textBox, messages);

            textBox.TextAlign = HorizontalAlignment.Left;

            textBox.KeyPress -= this.TextBox_KeyPress;
            textBox.Enter -= this.TextBox_Enter;
            textBox.Leave -= this.TextBox_Leave;
        }

        public TextBoxFormatNumeric()
        {
            this.allowNegative = true;
            this.emptiness = Emptiness.Blank;
        }
    }

    
    [ToolboxBitmap(typeof(TextBoxFormatInteger), "TextBoxFormatInteger.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatInteger : TextBoxFormatNumeric
    {
        private int leadingZeros;

        public override string Name
        {
            get
            {
                return "Integer";
            }
        }

        [DefaultValue(0)]
        public int LeadingZeros
        {
            get
            {
                return this.leadingZeros;
            }
            set
            {
                this.leadingZeros = Math.Max(value, 0);
            }
        }

        protected override bool Validate(ref char c, TextContext context, bool cancel)
        {
            if (this.Enabled && !cancel)
            {
                if (c == '.' || c == ',')
                {
                    cancel = true;
                }
            }

            return base.Validate(ref c, context, cancel);
        }

        protected override string GetValue(string text)
        {
            string integer, fraction, sign;

            this.Parse(text, out integer, out fraction, out sign);

            if (integer.Length > 0)
            {
                return string.Format("{0}{1}", sign, integer);
            }

            if (this.Emptiness == Emptiness.Blank)
            {
                return "";
            }

            return "0";
        }

        protected override string GetFormattedValue(string text)
        {
            string integer, fraction, sign;

            this.Parse(text, out integer, out fraction, out sign);

            if (integer.Length == 0 && this.Emptiness == Emptiness.Blank)
            {
                return "";
            }

            while (integer.Length < this.LeadingZeros)
            {
                integer = integer.Insert(0, "0");
            }

            if (integer.Length > 0)
            {
                return $"{sign}{integer}";
            }

            return "0";
        }

        public TextBoxFormatInteger()
        {
            this.leadingZeros = 0;
        }
    }

    
    [ToolboxBitmap(typeof(TextBoxFormatDecimal), "TextBoxFormatDecimal.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatDecimal : TextBoxFormatNumeric
    {
        private int decimals;
        private int trailingZeros;

        public override string Name
        {
            get
            {
                return "Decimal";
            }
        }

        [DefaultValue(2)]
        public virtual int Decimals
        {
            get
            {
                return this.decimals;
            }
            set
            {
                this.decimals = Math.Max(value, 0);
            }
        }

        [DefaultValue(0)]
        public virtual int TrailingZeros
        {
            get
            {
                return this.trailingZeros;
            }
            set
            {
                this.trailingZeros = Math.Max(value, 0);
            }
        }

        public override string Validate(string text, TextContext context)
        {
            string valor = base.Validate(text, context);

            if (!string.IsNullOrEmpty(valor) && valor != "-" && valor != "+")
            {
                valor = this.GetFormattedValue(valor);
            }

            return valor;
        }

        protected override string GetValue(string text)
        {
            string integer, fraction, sign;

            this.Parse(text, out integer, out fraction, out sign);

            string result;

            if (integer.Length > 0 && fraction.Length > 0)
            {
                result = $"{sign}{integer}{CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}{fraction}";
            }
            else if (integer.Length > 0)
            {
                result = $"{sign}{integer}";
            }
            else if (fraction.Length > 0)
            {
                result = $"{sign}0{CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}{fraction}";
            }
            else if (this.Emptiness == Emptiness.Zero)
            {
                result = "0";
            }
            else
            {
                result = "";
            }


            return result;
        }

        protected override string GetFormattedValue(string text)
        {
            string integer, fraction, sign;

            this.Parse(text, out integer, out fraction, out sign);

            string result = "0";

            if (integer.Length > 0 && fraction.Length > 0)
            {
                result = $"{sign}{integer}{CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}{fraction}";
            }
            else if (integer.Length > 0)
            {
                result = $"{sign}{integer}";
            }
            else if (fraction.Length > 0)
            {
                result = $"{sign}0{CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}{fraction}";
            }
            else if (this.Emptiness == Emptiness.Blank)
            {
                return "";
            }


            decimal valor;

            if (this.decimals > 0 && decimal.TryParse(result, out valor))
            {
                int zeros = 0;

                if (this.trailingZeros > this.decimals)
                {
                    zeros = this.trailingZeros;
                }
                else if (fraction.Length > this.decimals)
                {
                    zeros = this.decimals;
                }
                else if (this.trailingZeros > fraction.Length)
                {
                    zeros = this.trailingZeros;
                }
                else
                {
                    zeros = fraction.Length;
                }

                string format = $"F{zeros}";

                result = decimal.Round(valor, this.decimals).ToString(format);
            }


            return result;
        }

        public TextBoxFormatDecimal()
        {
            this.decimals = 2;
            this.trailingZeros = 0;
        }
    }

    
    [ToolboxBitmap(typeof(TextBoxFormatCurrency), "TextBoxFormatCurrency.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatCurrency : TextBoxFormatDecimal
    {
        private string symbol;

        public override string Name
        {
            get
            {
                return "Currency";
            }
        }

        public string Symbol
        {
            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }
        }

        [DefaultValue(2)]
        public override int TrailingZeros
        {
            get
            {
                return base.TrailingZeros;
            }

            set
            {
                base.TrailingZeros = value;
            }
        }

        private bool ShouldSerializeSymbol()
        {
            return this.symbol != CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        }

        protected override string GetFormattedValue(string text)
        {
            string result = base.GetFormattedValue(text);

            if (!string.IsNullOrEmpty(result))
            {
                result = $"{this.Symbol} {result}";
            }

            return result;
        }

        public TextBoxFormatCurrency()
        {
            this.symbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            base.TrailingZeros = 2;
        }
    }


    
    [ToolboxBitmap(typeof(TextBoxFormatCurrency), "TextBoxFormatNumber.bmp")]
    [DebuggerNonUserCode()]
    public class TextBoxFormatNumber : TextBoxFormat
    {
        public override string Name
        {
            get
            {
                return "Number";
            }
        }

        protected override bool Validate(ref char c, TextContext context, bool cancel)
        {
            if (this.Enabled && !cancel)
            {
                cancel = !char.IsNumber(c);
            }

            return base.Validate(ref c, context, cancel);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            Action align = () =>
            {
                textBox.Enter -= this.TextBox_Enter;
                textBox.Leave -= this.TextBox_Leave;

                try
                {
                    textBox.TextAlign = HorizontalAlignment.Left;
                }
                finally
                {
                    textBox.Enter += this.TextBox_Enter;
                    textBox.Leave += this.TextBox_Leave;
                }
            };

            textBox.BeginInvoke(align);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            Action align = () =>
            {
                textBox.Enter -= this.TextBox_Enter;
                textBox.Leave -= this.TextBox_Leave;

                try
                {
                    textBox.TextAlign = HorizontalAlignment.Right;
                }
                finally
                {
                    textBox.Enter += this.TextBox_Enter;
                    textBox.Leave += this.TextBox_Leave;
                }
            };

            textBox.BeginInvoke(align);
        }

        protected override void Assign(TextBox textBox, TextBoxMessageHandle messages)
        {
            base.Assign(textBox, messages);

            textBox.TextAlign = HorizontalAlignment.Right;

            textBox.Enter += this.TextBox_Enter;
            textBox.Leave += this.TextBox_Leave;
        }

        protected override void Release(TextBox textBox, TextBoxMessageHandle messages)
        {
            base.Release(textBox, messages);

            textBox.TextAlign = HorizontalAlignment.Left;

            textBox.Enter -= this.TextBox_Enter;
            textBox.Leave -= this.TextBox_Leave;
        }

        public TextBoxFormatNumber()
        {
        }
    }


    
    [DebuggerNonUserCode()]
    public class TextBoxFormatConverter : TypeConverter
    {
        private static string none = "(none)";

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            if (destinationType != typeof(string))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            if (value == null)
            {
                return none;
            }

            TextBoxFormat format = value as TextBoxFormat;

            if (format != null)
            {
                return format.Name;
            }


            return value.ToString();
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value, attributes);
        }
    }

    
    public delegate void CharacterValidationEventHandler(object sender, CharacterValidationEventArgs e);
    
    public class CharacterValidationEventArgs : CancelEventArgs
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private char character;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TextContext context;

        public char Character
        {
            get
            {
                return this.character;
            }
            set
            {
                this.character = value;
            }
        }

        public TextContext Context
        {
            get
            {
                return this.context;
            }
        }

        public CharacterValidationEventArgs(char character, TextContext context, bool cancel)
            : base(cancel)
        {
            this.character = character;
            this.context = context;
        }

    }

    
    [DebuggerNonUserCode()]
    public struct TextContext
    {
        public static readonly TextContext Paste = new TextContext(TextContextMethod.Paste, string.Empty, 0);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TextContextMethod method;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string text;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int position;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool multiline;

        public TextContextMethod Method
        {
            get { return this.method; }
        }

        public string Text
        {
            get { return this.text; }
        }

        public int Position
        {
            get { return this.position; }
        }

        public bool Multiline
        {
            get { return this.multiline; }
        }

        public TextContext(TextContextMethod method, string text, int position)
            : this(method, text, position, false)
        {
        }

        public TextContext(TextContextMethod method, string text, int position, bool multiline)
        {
            this.method = method;
            this.text = text;
            this.position = position;
            this.multiline = multiline;
        }
    }

    
    public enum TextContextMethod
    {
        Set = 0,
        Paste,
        Typing,
    }

    
    public enum Emptiness
    {
        Blank,
        Zero
    }
}
