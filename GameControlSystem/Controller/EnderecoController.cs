using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class EnderecoController {

        public void Salvar(Endereco end) {
            Contexto contexto = new Contexto();
            contexto.Enderecos.Add(end);
            contexto.SaveChanges();
        }

    }
}
