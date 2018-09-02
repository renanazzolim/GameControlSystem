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

namespace View.Forms
{
    /// <summary>
    /// Lógica interna para frmCadastrarTime.xaml
    /// </summary>
    public partial class frmCadastrarTime : Window {
        public frmCadastrarTime() {
            InitializeComponent();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e) {

            try {
                Endereco end = new Endereco();
                end.Logradouro = txtLogradouro.Text;
                end.Numero = Convert.ToInt32(txtNumero);
                end.Complemento = txtComplemento.Text;
                end.Bairro = txtBairro.Text;

                EnderecoController endController = new EnderecoController();
                endController.SalvarEndereco(end);
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
            
        }
    }
}
