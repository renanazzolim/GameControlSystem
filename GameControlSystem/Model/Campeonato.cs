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
        public int CampeonatoId { get; set; }

        public int AnoCampeonato { get; set; }

    }
}
