using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class CampeonatoController {

        public void SalvarCampeonato(Campeonato obj) {
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

        public IList<Campeonato> ListarCampeonatos() {
            return Campeonato.ListarCampeonatos();
        }

        public void ExcluirCampeonato(Campeonato obj) {
            try {
                Campeonato camp = Campeonato.GetById(obj.CampeonatoId);
                if (camp != null) {
                    Campeonato.Remove(camp.CampeonatoId);
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        public void AtualizarCampeonato(int id, Campeonato camp) {
            try {
                Campeonato campAntigo = Campeonato.GetById(id);
                if (campAntigo != null) {
                    Campeonato.Atualizar(id, camp.AnoCampeonato, camp.TituloCampeonato);
                } else {
                    throw new Exception("Id Campeonato não localizado para atualização");
                }
            } catch (Exception exp) {
                throw exp;
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

        private void validarInputs(int ano, string texto) {
            if ((ano < 2018 && ano > 2030) || ano.Equals("")) {
                throw new Exception("Ano inválido");
            }
            if (texto.Equals("")) {
                throw new Exception("Não é permitido campos vazios");
            }
        }

    }
}
