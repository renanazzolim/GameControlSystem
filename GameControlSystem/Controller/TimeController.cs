using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class TimeController {

        public void SalvarTime(Time obj) {
            try {
                ValidarTime(obj);
                Time.Salvar(obj);
            } catch (Exception exp) {
                throw new Exception(exp.Message);
            }
        }

        public IList<Time> ListarTimes() {
            return Time.ListarTimes();
        }

        public void DeletarTime(Time obj) {
            try {
                Time time = Time.Find(obj.TimeId);
                if (time != null) {
                    Endereco.Remove(time._Estadio.EnderecoId);
                    //Estadio.Remove(time.EstadioId);
                    //Time.Remove(time.TimeId);
                } else {
                    throw new ArgumentNullException("Impossível deletar time com ID inexistente.");
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        private void ValidarTime(Time obj) {
            foreach (Time time in Time.ListarTimes()) {
                if (obj.Nome.Equals(time.Nome)) {
                    throw new Exception("Time já existe, verifique");
                }
            }
        }

    }
}
