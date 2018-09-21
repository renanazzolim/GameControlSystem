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
    /// Lógica interna para frmCadastrarCampeonato.xaml
    /// </summary>
    public partial class frmCadastrarCampeonato : Window {
        public frmCadastrarCampeonato() {
            InitializeComponent();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e) {
            try {
                ValidarCampos(txtAno.Text, txtTituloCamp.Text);
                Campeonato campeonato = new Campeonato();
                campeonato.AnoCampeonato = Convert.ToInt32(txtAno.Text);
                campeonato.TituloCampeonato = txtTituloCamp.Text;

                CampeonatoController campController = new CampeonatoController();
                campController.SalvarCampeonato(campeonato);
                MessageBox.Show("Cadastrado com sucesso!");
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
            } else if (Ano.Equals("")) {
                throw new Exception("Ano não pode estar vazio");
            } else if (Convert.ToInt32(Ano) > 2030) {
                throw new Exception("Ano inválido, maior que 2030");
            } else if (Convert.ToInt32(Ano) < 1999) {
                throw new Exception("Ano inválido, menor que 1999");
            } else if (String.IsNullOrEmpty(titulo)) {
                throw new Exception("Título não pode estar vazio");
            }
        }
    }
}
