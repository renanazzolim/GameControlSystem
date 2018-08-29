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
using View.Telas;

namespace View {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch(index) {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnInicio());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnPartida());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnJogador());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                   GridPrincipal.Children.Add(new scnTime());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnCampeonato());
                    break;
                case 5:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnRelatorios());
                    break;
                default:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new scnInicio());
                    break;
            }
        }

        private void MoveCursorMenu(int index) {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
    }
}
