using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class TimeController {

        public void Salvar(Time obj) {
            Contexto contexto = new Contexto();
            contexto.Times.Add(obj);
            contexto.SaveChanges();
        }
    }
}
