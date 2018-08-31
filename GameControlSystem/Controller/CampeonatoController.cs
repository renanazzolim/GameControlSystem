using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class CampeonatoController {

        public static void SalvarCampeonato(Campeonato obj) {
            try {
                validarInputs(obj.AnoCampeonato, obj.TituloCampeonato);

                if (!IsCampeonatoValido(obj)) {
                    throw new Exception("Campeonato já existe, verifique!");
                }

                Campeonato.Salvar(obj);
                
            } catch (Exception exp) {
                throw new Exception(exp.Message);
            }
        }

        private static Boolean IsCampeonatoValido(Campeonato obj) {
            Boolean result = true;
            foreach (Campeonato campeonato in Campeonato.ListarCampeonatos()) {
                if (campeonato.AnoCampeonato.Equals(obj.AnoCampeonato) && campeonato.TituloCampeonato.Equals(obj.TituloCampeonato)) {
                    result = false;
                }
            }
            return result;
        }

        private static void validarInputs(int ano, string texto) {
            if ((ano < 2018 && ano > 2030) || ano.Equals("")) {
                throw new Exception("Ano inválido");
            }
            if (texto.Equals("")) {
                throw new Exception("Não é permitido campos vazios");
            }
        }

    }
}
