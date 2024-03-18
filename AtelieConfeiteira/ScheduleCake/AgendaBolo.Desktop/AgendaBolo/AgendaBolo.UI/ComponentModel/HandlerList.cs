using System.Runtime.InteropServices;

namespace AgendaBolo.UI.ComponentModel
{    
    public sealed class HandlerList : IDisposable
    {
        private ListEntry head;


        private sealed class ListEntry
        {
            internal Delegate handler;
            internal object key;
            internal HandlerList.ListEntry next;

            public ListEntry(object key, Delegate handler, HandlerList.ListEntry next)
            {
                this.key = key;
                this.handler = handler;
                this.next = next;
            }
        }



        public Delegate this[object key]
        {
            get
            {
                ListEntry entry = this.Find(key);

                if (entry != null)
                {
                    return entry.handler;
                }

                return null;
            }
            set
            {
                ListEntry entry = this.Find(key);

                if (entry != null)
                {
                    entry.handler = value;
                }
                else
                {
                    this.head = new ListEntry(key, value, this.head);
                }
            }
        }

        public void AddHandler(object key, Delegate value)
        {
            ListEntry entry = this.Find(key);

            if (entry != null)
            {
                entry.handler = Delegate.Combine(entry.handler, value);
            }
            else
            {
                this.head = new ListEntry(key, value, this.head);
            }
        }

        public void RemoveHandler(object key, Delegate value)
        {
            ListEntry entry = this.Find(key);

            if (entry != null)
            {
                entry.handler = Delegate.Remove(entry.handler, value);
            }
        }

        private ListEntry Find(object key)
        {
            ListEntry head = this.head;

            while (head != null)
            {
                if (head.key.Equals(key))
                {
                    return head;
                }

                head = head.next;
            }

            return head;
        }


        public HandlerList()
        {
        }

        public void Dispose()
        {
            this.head = null;
        }
    }

}
