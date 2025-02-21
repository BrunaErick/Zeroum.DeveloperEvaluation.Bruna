namespace Zeroum.DTO.Bruna.Request
{
    public class ClientesPJCreateRequest
    {
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string email { get; set; }
        public DateTime dataAbertura { get; set; }
    }
}
