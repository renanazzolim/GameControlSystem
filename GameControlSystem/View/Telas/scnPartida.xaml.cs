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
    /// Interação lógica para scnPartida.xam
    /// </summary>
    public partial class scnPartida : UserControl {
        public scnPartida() {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e) {
            frmCriarPartidas frm = new frmCriarPartidas();
            frm.Show();
        }
    }
}
