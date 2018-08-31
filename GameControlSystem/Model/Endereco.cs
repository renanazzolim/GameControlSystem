using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("ENDERECO")]
    public class Endereco {

        [Key]
        public int EnderecoId { get; set; }

        public String Logradouro { get; set; }

        public int Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

    }
}
