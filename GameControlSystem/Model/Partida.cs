using Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
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

            /*var partidas = contexto.Partidas.ToList();
            var times = Time.ListarTimes();
            var estadios = Estadio.ListarEstadios();
            var campeonatos = Campeonato.ListarCampeonatos();
            var retorno = from p in contexto.Partidas.ToList()
                          join anf in Time.ListarTimes() on p.AnfitriaoId equals anf.TimeId
                          join vis in Time.ListarTimes() on p.VisitanteId equals vis.TimeId
                          join e in Estadio.ListarEstadios() on p.EstadioId equals e.EstadioId
                          join c in Campeonato.ListarCampeonatos() on p.CampeonatoId equals c.CampeonatoId
                          where (p.CampeonatoId == id)
                          select new {Partida = p.PartidaId, Data = p.Data, Anfitriao = anf.Nome,
                              Visitante = vis.Nome, Estadio = e.Nome, Titulo = c.TituloCampeonato };
            return retorno.ToArray();*/
        }

    }
}
