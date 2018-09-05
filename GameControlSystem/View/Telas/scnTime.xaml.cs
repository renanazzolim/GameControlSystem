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
    /// Interação lógica para scnTime.xam
    /// </summary>
    public partial class scnTime : UserControl {

        TimeController timeController = new TimeController();

        public scnTime() {
            InitializeComponent();
            CarregarTimes();
        }

        private void btnNovoTime_Click(object sender, RoutedEventArgs e) {
            frmCadastrarTime frm = new frmCadastrarTime();
            frm.Closed += (s, args) => CarregarTimes();
            frm.Show();
        }

        private void CarregarTimes() {
            IList<Time> lista = timeController.ListarTimes();
            if (lista != null) {
                dbGridTimes.ItemsSource = lista;
            }
        }

        private void btnExcluirTime_Click(object sender, RoutedEventArgs e) {
            Time time = ((FrameworkElement)sender).DataContext as Time;
            try {
                if (Util.Utils.OnConfirma("Deseja mesmo excluir?", "Excluir")) {
                    timeController.DeletarTime(time);
                    Util.Utils.OnInforma("Time excluído com sucesso!");
                    CarregarTimes();
                }
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnEditarTime_Click(object sender, RoutedEventArgs e) {
            //
        }
    }
}
