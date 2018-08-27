using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("GOL")]
    public class Gol {

        [Key]
        public int GolId { get; set; }

        public int PartidaId { get; set; }

        public int Quantidade { get; set; }

        public int JogadorId { get; set; }

        public virtual Partida _Partida { get; set; }

        public virtual Jogador _Jogador { get; set; }
    }
}
