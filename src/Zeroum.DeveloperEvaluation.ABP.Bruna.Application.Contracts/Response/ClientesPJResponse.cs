using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeroum.DeveloperEvaluation.ABP.Bruna.Response
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
