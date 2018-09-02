using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class EnderecoController {

        public void SalvarEndereco(Endereco obj) {
            try {
                ValidarEndereco(obj);
                Endereco.Salvar(obj);             
            } catch (Exception exp) {
                throw new Exception(exp.Message);
            }
        }

        private void ValidarEndereco(Endereco obj) {
            foreach(Endereco end in Endereco.ListarEnderecos()) {
                if ((obj.Logradouro.Equals(end.Logradouro)) && (obj.Numero.Equals(end.Numero)) && (obj.Bairro.Equals(end.Bairro))) {
                    throw new Exception("Endereço já existe, verifique");
                }
            }
        }

    }
}
