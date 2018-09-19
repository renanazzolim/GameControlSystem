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

        public static Campeonato GetById(int id) {
            Contexto contexto = new Contexto();
            return contexto.Campeonatos.Find(id);
        }

        public static void Remove(int id) {
            Contexto contexto = new Contexto();
            contexto.Campeonatos.Remove((Campeonato)contexto.Campeonatos.Where(c => c.CampeonatoId == id).First());
            contexto.Entry((Campeonato)contexto.Campeonatos.Where(c => c.CampeonatoId == id).First()).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }

        public static void Atualizar(int id, int ano, String titulo) {
            Contexto contexto = new Contexto();
            Campeonato camp = contexto.Campeonatos.Find(id);
            camp.AnoCampeonato = ano;
            camp.TituloCampeonato = titulo;

            contexto.Entry(camp).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

    }
}
