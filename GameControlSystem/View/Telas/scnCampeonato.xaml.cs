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
    /// Interação lógica para scnCampeonato.xam
    /// </summary>
    public partial class scnCampeonato : UserControl {

        CampeonatoController campController = new CampeonatoController();

        public scnCampeonato() {
            InitializeComponent();
            CarregarCampeonatos();
        }

        private void btnNovoCampeonato_Click(object sender, RoutedEventArgs e) {
            frmCadastrarCampeonato frm = new frmCadastrarCampeonato();
            frm.Closed += (s, args) => CarregarCampeonatos();
            frm.Show();
        }

        private void btnEditarCampeonato_Click(object sender, RoutedEventArgs e) {
            try {
                Campeonato camp = ((FrameworkElement)sender).DataContext as Campeonato;
                frmEditarCampeonato frm = new frmEditarCampeonato(camp);
                frm.Closed += (s, args) => CarregarCampeonatos();
                frm.Show();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnExcluirCampeonato_Click(object sender, RoutedEventArgs e) {
            Campeonato campeonato = ((FrameworkElement)sender).DataContext as Campeonato;
            try {
                if (Util.Utils.OnConfirma("Deseja mesmo excluir?", "Excluir")) {
                    campController.ExcluirCampeonato(campeonato);
                    Util.Utils.OnInforma("Campeonato excluído com sucesso!");
                    CarregarCampeonatos();
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void CarregarCampeonatos() {
            try {
                IList<Campeonato> lista = campController.ListarCampeonatos();
                if (lista != null) {
                    dbGridCampeonatos.ItemsSource = lista;
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnPartidas_Click(object sender, RoutedEventArgs e) {
            Campeonato campeonato = ((FrameworkElement)sender).DataContext as Campeonato;
            frmJogosPorCampeonato frm = new frmJogosPorCampeonato(campeonato);
            frm.Show();
        }
    }
}
