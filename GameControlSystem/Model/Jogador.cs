using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Jogador {

        [Key]
        private int JogadorId { get; set; }

        private String Nome { get; set; }

        private DateTime Nascimento { get; set; }

        private String Genero { get; set; }

        private Double Altura { get; set; }

        private Boolean Capitao { get; set; }

        private int TimeId { get; set; }

        public virtual Time _Time { get; set; }

    }
}
