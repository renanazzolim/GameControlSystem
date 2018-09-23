using Model.DAL;
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
        public String Data { get; set; }

        [Required]
        public int EstadioId { get; set; }

        [Required]
        public int VisitanteId { get; set; }

        [Required]
        public int AnfitriaoId { get; set; }

        [Required]
        public int CampeonatoId { get; set; }

        public virtual Campeonato _Campeonato { get; set; }

        public virtual IList<Time> _Time { get; set; }

        public static void Salvar(Partida obj) {
            Contexto contexto = new Contexto();
            contexto.Partidas.Add(obj);
            contexto.SaveChanges();
        }

        public static IList<Partida> GetPartidasByCampeonato(int id) {
            Contexto contexto = new Contexto();
            var partidas = contexto.Partidas.ToList();
            var retorno = from p in partidas where p.CampeonatoId == id select p;
            return retorno.ToList();
        }

    }
}
