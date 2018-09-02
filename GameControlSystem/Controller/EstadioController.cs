using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class EstadioController {

        public void SalvarEstadio(Estadio obj) {
            try {
                ValidarEstadio(obj);
                Estadio.Salvar(obj);
            } catch (Exception exp) {
                throw new Exception(exp.Message);
            }            
        }

        private void ValidarEstadio(Estadio obj) {
            foreach (Estadio est in Estadio.ListarEstadios()) {
                if (obj.Nome.Equals(est.Nome)) {
                    throw new Exception("Estádio já existe, verifique");
                }
            }
        }
    }
}
