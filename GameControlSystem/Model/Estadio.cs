using Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Table("ESTADIO")]
    public class Estadio {

        [Key]
        public int EstadioId { get; set; }

        public String Nome { get; set; }

        public int EnderecoId { get; set; }

        public virtual Endereco _Endereco { get; set; }

        public static void Salvar(Estadio obj) {
            Contexto contexto = new Contexto();
            contexto.Estadios.Add(obj);
            contexto.SaveChanges();
        }

        public static List<Estadio> ListarEstadios() {
            Contexto contexto = new Contexto();
            return contexto.Estadios.ToList();
        }
    }

}
