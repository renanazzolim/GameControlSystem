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
using System.Windows.Navigation;
using System.Windows.Shapes;
using View.Forms;

namespace View.Telas {
    /// <summary>
    /// Interação lógica para scnJogador.xam
    /// </summary>
    public partial class scnJogador : UserControl {

        JogadorController jogController = new JogadorController();

        public scnJogador() {
            InitializeComponent();
            CarregarJogadores();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e) {
            try {
                frmCadastrarJogador frm = new frmCadastrarJogador();
                frm.Closed += (s, args) => CarregarJogadores();
                frm.Show();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void CarregarJogadores() {
            try {
                IList<Jogador> lista = jogController.ListarJogadores();
                if (lista != null) {
                    dbGridJogadores.ItemsSource = lista;
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnEditarJogador_Click(object sender, RoutedEventArgs e) {
            try {
                Jogador jogador = ((FrameworkElement)sender).DataContext as Jogador;
                frmEditarJogador frm = new frmEditarJogador(jogador);
                frm.Closed += (s, args) => CarregarJogadores();
                frm.Show();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnExcluirJogador_Click(object sender, RoutedEventArgs e) {
            Jogador jogador = ((FrameworkElement)sender).DataContext as Jogador;
            try {
                if (Util.Utils.OnConfirma("Deseja mesmo excluir?", "Excluir")) {
                    jogController.DeletarJogador(jogador.JogadorId);
                    Util.Utils.OnInforma("Jogador excluído com sucesso!");
                    CarregarJogadores();
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
