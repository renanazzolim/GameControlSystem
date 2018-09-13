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
    /// Lógica interna para frmEditarTime.xaml
    /// </summary>
    public partial class frmEditarTime : Window {
        int TimeId;
        int EstadioId;
        int EnderecoId;

        public frmEditarTime(Time time) {
            InitializeComponent();
            TimeId = time.TimeId;
            EstadioId = time.EstadioId;
            EnderecoId = time._Estadio.EnderecoId;
            txtNome.Text = time.Nome;
            txtEstadio.Text = time._Estadio.Nome;
            txtLogradouro.Text = time._Estadio._Endereco.Logradouro;
            txtNumero.Text = time._Estadio._Endereco.Numero.ToString();
            txtComplemento.Text = time._Estadio._Endereco.Complemento;
            txtBairro.Text = time._Estadio._Endereco.Bairro;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e) {
            try {
                ValidarCamposEndereco(txtLogradouro.Text, txtNumero.Text, txtBairro.Text);
                ValidarNome(txtNome.Text, "time");
                ValidarNome(txtEstadio.Text, "estádio");
                SalvarEndereco(txtLogradouro.Text, Convert.ToInt32(txtNumero.Text), txtComplemento.Text, txtBairro.Text, this.EnderecoId);
                SalvarEstadio(txtEstadio.Text, this.EstadioId, this.EnderecoId);
                SalvarTime(TimeId, txtNome.Text, this.EstadioId);
                MessageBox.Show("Time editado com sucesso!");
                this.Close();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void ValidarCamposEndereco(String log, String num, String bairro) {
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

        private static void SalvarEndereco(String logradouro, int numero, String complemento, String bairro, int endId) {
            try {
                Endereco end = new Endereco();
                end.Logradouro = logradouro;
                end.Numero = numero;
                end.Complemento = complemento;
                end.Bairro = bairro;
                EnderecoController endCont = new EnderecoController();
                endCont.AtualizarEndereco(endId, end);
            } catch (Exception exp) {
                throw exp;
            }
        }

        private static void SalvarEstadio(String pEstadio, int estId, int endId) {
            try {
                Estadio estadio = new Estadio();
                estadio.Nome = pEstadio;
                estadio.EnderecoId = endId;
                EstadioController estCont = new EstadioController();
                estCont.AtualizarEstadio(estId, estadio);
            } catch (Exception exp) {
                throw exp;
            }
        }

        private static void SalvarTime(int id, String pTime, int estId) {
            try {
                Time time = new Time();
                time.Nome = pTime;
                time.EstadioId = estId;
                TimeController timeCont = new TimeController();
                timeCont.AtualizarTime(id, time);
            } catch (Exception exp) {
                throw exp;
            }
        }
    }
}
