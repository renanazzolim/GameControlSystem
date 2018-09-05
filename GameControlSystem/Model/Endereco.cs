using Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("ENDERECO")]
    public class Endereco {

        [Key]
        public int EnderecoId { get; set; }

        public String Logradouro { get; set; }

        public int Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public static void Salvar(Endereco obj) {
            Contexto contexto = new Contexto();
            contexto.Enderecos.Add(obj);
            contexto.SaveChanges();
        }

        public static List<Endereco> ListarEnderecos() {
            Contexto contexto = new Contexto();
            return contexto.Enderecos.ToList();
        }

        public static void Remove(int id) {
            Contexto contexto = new Contexto();
            //Endereco endereco = (Endereco)contexto.Enderecos.Where(e => e.EnderecoId == id).First();
            contexto.Enderecos.Remove((Endereco)contexto.Enderecos.Where(e => e.EnderecoId == id).First());
            //contexto.Entry(endereco).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }

    }

}
