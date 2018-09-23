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
    /// Lógica interna para frmJogosPorCampeonato.xaml
    /// </summary>
    public partial class frmJogosPorCampeonato : Window {

        PartidaController partController = new PartidaController();

        public frmJogosPorCampeonato(Campeonato obj) {
            try {
                InitializeComponent();
                CarregarPartidas(obj.CampeonatoId);
                lblTitulo.Content = obj.TituloCampeonato;
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void CarregarPartidas(int id) {
            try {
                IList<Partida> lista = partController.ListarPartidasPorCampeonato(id);
                if (lista != null) {
                    dbGridPartidas.ItemsSource = lista;
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

    }
}
