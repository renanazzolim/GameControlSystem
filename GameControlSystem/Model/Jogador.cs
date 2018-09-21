using Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("JOGADOR")]
    public class Jogador {

        [Key]
        public int JogadorId { get; set; }

        public String Nome { get; set; }

        public String Nascimento { get; set; }

        public String Genero { get; set; }

        public Double Altura { get; set; }

        public Boolean Capitao { get; set; }

        public int TimeId { get; set; }

        public virtual Time _Time { get; set; }

        public static void Salvar(Jogador obj) {
            Contexto contexto = new Contexto();
            contexto.Jogador.Add(obj);
            contexto.SaveChanges();
        }

        public static void Remove(int id) {
            Contexto contexto = new Contexto();
            contexto.Jogador.Remove((Jogador)contexto.Jogador.Where(j => j.JogadorId == id).First());
            contexto.SaveChanges();
        }

        public static Jogador GetById(int id) {
            Contexto contexto = new Contexto();
            return contexto.Jogador.Find(id);
        }

        public static IList<Jogador> ListarJogadores() {
            Contexto contexto = new Contexto();
            return contexto.Jogador.ToList();
        }

        public static void Atualizar(int id, String nome, String nascimento,
            String genero, Double altura, Boolean capitao, int timeId) {
            Contexto contexto = new Contexto();
            Jogador jogador = contexto.Jogador.Find(id);
            jogador.Nome = nome;
            jogador.Nascimento = nascimento;
            jogador.Genero = genero;
            jogador.Altura = altura;
            jogador.Capitao = capitao;
            jogador.TimeId = timeId;
            contexto.Entry(jogador).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

    }
}
