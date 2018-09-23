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
                Time time = Time.GetById(obj.TimeId);
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

        public void AtualizarTime(int id, Time obj) {
            try {
                Time timeAntigo = Time.GetById(id);
                if (timeAntigo != null) {
                    Time.Atualizar(id, obj.Nome);
                } else {
                    throw new Exception("Id time não localizado para atualização");
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        public Time GetTimeById(int id) {
            Time obj = new Time();
            try {
                obj = Time.GetById(id);
                if (obj == null) {
                    throw new Exception("Time não encontrado ao tentar procurar pelo ID: " + id);
                }
            } catch (Exception exp) {
                throw exp;
            }
            return obj;
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
