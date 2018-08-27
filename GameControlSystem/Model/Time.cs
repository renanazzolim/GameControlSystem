using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("TIME")]
    public class Time {

        public int TimeId { get; set; }

        public String Nome { get; set; }

        public int Vitorias { get; set; }

        public int Derrotas { get; set; }

        public int Empates { get; set; }

        public int EstadioId { get; set; }

        public virtual Estadio _Estadio { get; set; }

    }
}
