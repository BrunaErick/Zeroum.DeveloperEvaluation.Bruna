namespace Zeroum.DTO.Bruna.Request
{
    public class ClientesPFCreateRequest
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime nascimento { get; set; }
    }
}
