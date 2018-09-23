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
    /// Lógica interna para frmCriarPartidas.xaml
    /// </summary>
    public partial class frmCriarPartidas : Window {
        CampeonatoController campCont = new CampeonatoController();
        TimeController timeController = new TimeController();
        public frmCriarPartidas() {
            InitializeComponent();
            CarregarCampeonatos();
        }

        private void CarregarCampeonatos() {
            try {
                IList<Campeonato> lista = campCont.ListarCampeonatos();
                cbCampeonatos.ItemsSource = lista;
                cbCampeonatos.DisplayMemberPath = "TituloCampeonato";
            } catch (Exception exp) {
                throw exp;
            }
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e) {
            try {
                Campeonato campSelected = cbCampeonatos.SelectedItem as Campeonato;
                if (campSelected != null) {
                    PartidaController partidaController = new PartidaController();
                    partidaController.CriarPartidas(timeController.ListarTimes(), campSelected.CampeonatoId);
                    MessageBox.Show("Partidas criadas para " + campSelected.TituloCampeonato + ". Acesse o menu 'partidas' para visualizar.");
                    this.Close();
                } else {
                    throw new Exception("Informe um campeonato");
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
