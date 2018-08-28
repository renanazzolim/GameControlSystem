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
        private int PartidaId { get; set; }

        [Required]
        private DateTime Data { get; set; }

        [Required]
        private int EstadioId { get; set; }

        [Required]
        private int VisitanteId { get; set; }

        [Required]
        private int AnfitriaoId { get; set; }

        [Required]
        private int CampeonatoId { get; set; }

        public virtual Time _Time { get; set; }

        public virtual Campeonato _Campeonato { get; set; }

    }
}
