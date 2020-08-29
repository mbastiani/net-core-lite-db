namespace NetCoreLiteDB.Models
{
    public class Telefone
    {
        public string Prefixo { get; set; }
        public string Numero { get; set; }
        public TelefoneTipos Tipo { get; set; }
    }
}