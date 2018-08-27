using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View.Telas {
    /// <summary>
    /// Lógica interna para Cadastrar.xaml
    /// </summary>
    public partial class Cadastrar : Window {
        public Cadastrar() {
            InitializeComponent();
        }

        private void Confirma_Btn_Click(object sender, RoutedEventArgs e) {
            String logradouro = edtLogradouro.Text;
            int numero = Convert.ToInt32(edtNumero.Text);
            String complemento = edtComplemento.Text;
            String bairro = edtBairro.Text;

            try {
                Endereco end = new Endereco();
                end.Logradouro = logradouro;
                end.Numero = numero;
                end.Complemento = complemento;
                end.Bairro = bairro;

                EnderecoController eController = new EnderecoController();
                eController.Salvar(end);
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
