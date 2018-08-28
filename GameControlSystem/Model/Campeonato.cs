using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("CAMPEONATO")]
    public class Campeonato {

        [Key]
        private int CampeonatoId { get; set; }

        private int AnoCampeonato { get; set; }

    }
}
