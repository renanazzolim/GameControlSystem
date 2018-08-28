using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("ESTADIO")]
    public class Estadio {

        [Key]
        private int EstadioId { get; set; }

        private String Nome { get; set; }

        private int EnderecoId { get; set; }

        public virtual Endereco _Endereco { get; set; }

    }
}
