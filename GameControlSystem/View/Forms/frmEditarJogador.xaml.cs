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
    /// Lógica interna para frmEditarJogador.xaml
    /// </summary>
    public partial class frmEditarJogador : Window {
        TimeController timeController = new TimeController();
        int jogadorId;
        int timeId;

        public frmEditarJogador(Jogador obj) {
            InitializeComponent();
            CarregarTimes();

            jogadorId = obj.JogadorId;
            timeId = obj.TimeId;
            txtNome.Text = obj.Nome;
            txtNascimento.Text = obj.Nascimento;
            txtAltura.Text = obj.Altura.ToString();
            cbGenero.Text = obj.Genero;
            chkCapitao.IsChecked = obj.Capitao;
            cbTimes.SelectedValue = obj.TimeId;

        }

        private void btnConfirma_Click(object sender, RoutedEventArgs e) {
            try {
                String nome = ValidarCampos(txtNome.Text, "nome");
                String nasc = ValidarCampos(txtNascimento.Text, "nascimento");
                Double altura = Double.Parse(ValidarCampos(txtAltura.Text, "altura"));
                String genero = cbGenero.Text;
                Time timeSelecionado = cbTimes.SelectedItem as Time;
                if (timeSelecionado == null) {
                    throw new Exception("Selecione um time");
                }
                Boolean cap = false;
                if (chkCapitao.IsChecked.Value) {
                    cap = true;
                }

                Jogador jogador = new Jogador();
                jogador.JogadorId = jogadorId;
                jogador.Nome = nome;
                jogador.Nascimento = nasc;
                jogador.Genero = genero;
                jogador.Altura = altura;
                jogador.Capitao = cap;
                jogador.TimeId = timeSelecionado.TimeId;
                JogadorController jc = new JogadorController();
                jc.AtualizarJogador(jogador);
                MessageBox.Show("Jogador atualizado com sucesso!");
                this.Close();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void CarregarTimes() {
            try {
                IList<Time> lista = timeController.ListarTimes();
                if (lista != null) {
                    cbTimes.ItemsSource = lista;
                    cbTimes.DisplayMemberPath = "Nome";
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private static String ValidarCampos(String value, String field) {
            if (value.Equals("")) {
                throw new Exception("Preencha: " + field);
            }
            return value;
        }
    }
}
