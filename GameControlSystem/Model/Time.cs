using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("TIME")]
    public class Time {

        private int TimeId { get; set; }

        private String Nome { get; set; }

        private int Vitorias { get; set; }

        private int Derrotas { get; set; }

        private int Empates { get; set; }

        private int EstadioId { get; set; }

        public virtual Estadio _Estadio { get; set; }

    }
}
