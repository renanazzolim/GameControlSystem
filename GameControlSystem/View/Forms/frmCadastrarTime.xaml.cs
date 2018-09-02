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

namespace View.Forms {
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
                ValidarEndereco(txtLogradouro.Text, txtNumero.Text, txtBairro.Text);
                ValidarNome(txtNome.Text, "time");
                ValidarNome(txtEstadio.Text, "estádio");                

                Endereco end = new Endereco();
                end.Logradouro = txtLogradouro.Text;
                end.Numero = Convert.ToInt32(txtNumero.Text);
                end.Complemento = txtComplemento.Text;
                end.Bairro = txtBairro.Text;
                EnderecoController endController = new EnderecoController();
                endController.SalvarEndereco(end);

                Estadio est = new Estadio();
                est.Nome = txtEstadio.Text;
                est.EnderecoId = end.EnderecoId;
                EstadioController estController = new EstadioController();
                estController.SalvarEstadio(est);

                Time time = new Time();
                time.Nome = txtNome.Text;
                time.EstadioId = est.EstadioId;
                TimeController timeController = new TimeController();
                timeController.SalvarTime(time);

                MessageBox.Show("Time cadastrado com sucesso!");
                this.Close();

            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void ValidarEndereco(String log, String num, String bairro) {
            if (log.Equals("")) {
                throw new Exception("Logradouro não pode estar vazio");
            } else if (num.Equals("")) {
                throw new Exception("Número não pode estar vazio");
            } else if (!Char.IsDigit(num, 0)) {
                throw new Exception("Caracter inválido para o campo número");
            } else if (bairro.Equals("")) {
                throw new Exception("Bairro não pode estar vazio");
            }
        }

        private void ValidarNome(String estadio, string ent) {
            if (estadio.Equals("")) {
                throw new Exception("Não é permitido nome do " + ent + " estar vazio");
            } else if (Char.IsDigit(estadio, 0)) {
                throw new Exception("Não é permitido número no campo nome do " + ent);
            } else if (String.IsNullOrEmpty(estadio)) {
                throw new Exception("Não é permitido cadastrar nome do " + ent + " vazio");
            }
        }

    }
}
