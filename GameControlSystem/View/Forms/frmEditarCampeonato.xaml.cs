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
    /// Lógica interna para frmEditarCampeonato.xaml
    /// </summary>
    public partial class frmEditarCampeonato : Window {

        int CampeonatoId;

        public frmEditarCampeonato(Campeonato camp) {
            InitializeComponent();
            CampeonatoId = camp.CampeonatoId;
            txtAno.Text = camp.AnoCampeonato.ToString();
            txtTituloCamp.Text = camp.TituloCampeonato;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void btnConfirma_Click(object sender, RoutedEventArgs e) {
            try {
                ValidarCampos(txtAno.Text, txtTituloCamp.Text);
                SalvarCampeonato(CampeonatoId, Convert.ToInt32(txtAno.Text), txtTituloCamp.Text);
                MessageBox.Show("Editado com sucesso!");
                this.Close();
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
            }
        }

        private void ValidarCampos(String Ano, String titulo) {

            if (!Char.IsDigit(Ano, 0)) {
                throw new Exception("Caracter inválido para o campo Ano");
            } else if (String.IsNullOrEmpty(Ano)) {
                throw new Exception("Ano não pode estar vazio");
            } else if (Convert.ToInt32(Ano) > 2030) {
                throw new Exception("Ano inválido, maior que 2030");
            } else if (Convert.ToInt32(Ano) < 1999) {
                throw new Exception("Ano inválido, menor que 1999");
            } else if (String.IsNullOrEmpty(titulo)) {
                throw new Exception("Título não pode estar vazio");
            }
        }

        private void SalvarCampeonato(int id, int Ano, String titulo) {
            Campeonato camp = new Campeonato();
            camp.AnoCampeonato = Ano;
            camp.TituloCampeonato = titulo;

            CampeonatoController campCont = new CampeonatoController();
            campCont.AtualizarCampeonato(id, camp);

        }
    }
}
