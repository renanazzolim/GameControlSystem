using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("PARTIDA")]
    public class Partida {

        [Key]
        public int PartidaId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int EstadioId { get; set; }

        [Required]
        public int VisitanteId { get; set; }

        [Required]
        public int AnfitriaoId { get; set; }

        [Required]
        public int CampeonatoId { get; set; }

        public virtual Time _Time { get; set; }

        public virtual Campeonato _Campeonato { get; set; }

    }
}
