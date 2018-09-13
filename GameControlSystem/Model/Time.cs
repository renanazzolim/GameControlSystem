using Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("TIME")]
    public class Time {

        public int TimeId { get; set; }

        public String Nome { get; set; }

        public int Vitorias { get; set; }

        public int Derrotas { get; set; }

        public int Empates { get; set; }

        public int EstadioId { get; set; }

        public virtual Estadio _Estadio { get; set; }

        public Time() {
            this.Vitorias = 0;
            this.Derrotas = 0;
            this.Empates = 0;
        }
        
        public static void Salvar(Time obj) {
            Contexto contexto = new Contexto();
            contexto.Times.Add(obj);
            contexto.SaveChanges();
        }

        public static List<Time> ListarTimes() {
            Contexto contexto = new Contexto();
            return contexto.Times.ToList();
        }

        public static Time GetById(int id) {
            Contexto contexto = new Contexto();
            return contexto.Times.Find(id);
        }

        public static void Remove(int id) {
            Contexto contexto = new Contexto();
            contexto.Times.Remove((Time)contexto.Times.Where(t => t.TimeId == id).First());
            contexto.Entry((Time)contexto.Times.Where(t => t.TimeId == id).First()).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }

        public static void Atualizar(int id, String nome) {
            Contexto contexto = new Contexto();
            Time time = contexto.Times.Find(id);
            time.Nome = nome;
            contexto.Entry(time).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

    }
}
