using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class JogadorController {

        public void SalvarJogador(Jogador obj) {
            try {
                ValidarJogador(obj);
                Jogador.Salvar(obj);
            } catch (Exception exp) {
                throw exp;
            }
        }

        public IList<Jogador> ListarJogadores() {
            IList<Jogador> lista;
            try {
                lista = Jogador.ListarJogadores();
            } catch (Exception exp) {
                throw exp;
            }
            return lista;
        }

        public void DeletarJogador(int id) {
            try {
                Jogador jogador = Jogador.GetById(id);
                if (jogador != null) {
                    Jogador.Remove(id);
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        public void AtualizarJogador(Jogador obj) {
            try {
                Jogador jogAntigo = Jogador.GetById(obj.JogadorId);
                if (jogAntigo != null) {
                    ValidarSeJogadorEhCapitao(obj);
                    Jogador.Atualizar(obj.JogadorId, obj.Nome, obj.Nascimento,
                        obj.Genero, obj.Altura, obj.Capitao, obj.TimeId);
                } else {
                    throw new Exception("Erro ao procurar o jogador pelo Id selecionado");
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        private void ValidarJogador(Jogador obj) {
            foreach(Jogador jog in Jogador.ListarJogadores()) {
                if ((obj.Nome.Equals(jog.Nome)) && (obj.Nascimento.Equals(jog.Nascimento)) && (obj.Altura.Equals(jog.Altura))) {
                    throw new Exception("Jogador já existe, verifique");
                }
                if ((obj.TimeId.Equals(jog.TimeId) && (obj.Capitao.Equals(true)))) {
                    throw new Exception("Já existe capitão para este time, verifique");
                }
            }
        }

        private void ValidarSeJogadorEhCapitao(Jogador obj) {
            foreach (Jogador jog in Jogador.ListarJogadores()) {
                if ((obj.TimeId.Equals(jog.TimeId) && (obj.Capitao.Equals(true)))) {
                    throw new Exception("Já existe capitão para este time, verifique");
                }
            }
        }

    }
}
