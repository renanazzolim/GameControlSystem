using Model.DAL;
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

        public String TituloCampeonato { get; set; }

        public static void Salvar(Campeonato obj) {
            Contexto contexto = new Contexto();
            contexto.Campeonatos.Add(obj);
            contexto.SaveChanges();
        }

        public static List<Campeonato> ListarCampeonatos() {
            Contexto contexto = new Contexto();
            return contexto.Campeonatos.ToList();
        }

    }
}
