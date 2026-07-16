namespace ScreenSound.Web.Response
{
    public class GeneroResponse        
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return $"{this.Nome}";
        }
    }
}
