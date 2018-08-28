using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class EstadioController {

        public void Salvar(Estadio obj) {
            Contexto contexto = new Contexto();
            contexto.Estadios.Add(obj);
            contexto.SaveChanges();
        }
    }
}
