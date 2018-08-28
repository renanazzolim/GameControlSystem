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
        private int EnderecoId { get; set; }

        private String Logradouro { get; set; }

        private int Numero { get; set; }

        private String Complemento { get; set; }

        private String Bairro { get; set; }

    }
}
