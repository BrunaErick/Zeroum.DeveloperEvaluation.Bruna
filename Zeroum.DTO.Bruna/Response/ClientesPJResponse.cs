namespace Zeroum.DTO.Bruna.Response
{
    public class ClientesPJResponse
    {
        public int Id { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string email { get; set; }
        public DateTime dataAbertura { get; set; }
    }
}
