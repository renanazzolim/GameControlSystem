using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Jogador {

        [Key]
        public int JogadorId { get; set; }

        public String Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public String Genero { get; set; }

        public Double Altura { get; set; }

        public int TimeId { get; set; }

        public virtual Time _Time { get; set; }

    }
}
