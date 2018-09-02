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

        private void ValidarTime(Time obj) {
            foreach (Time time in Time.ListarTimes()) {
                if (obj.Nome.Equals(time.Nome)) {
                    throw new Exception("Time já existe, verifique");
                }
            }
        }
    }
}
