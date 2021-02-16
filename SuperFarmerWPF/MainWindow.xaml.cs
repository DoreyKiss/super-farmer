using SuperFarmer.PlayArea;
using SuperFarmer.WPF.views;
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

namespace SuperFarmer.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameGod gameGod;
        private MainViewModel gameViewModel;

        public MainWindow()
        {
            gameViewModel = new MainViewModel();
            gameGod = new GameGod();
            InitializeComponent();
            Main.Content = new WellcomePageView(gameGod, gameViewModel);
        }

        private void BtnClickStartGamePg(object sender, RoutedEventArgs e)
        {

            Main.Content = new GamePageView(gameGod, gameViewModel);
        }
        private void BtnClickWellcomePg(object sender, RoutedEventArgs e)
        {
            Main.Content = new WellcomePageView(gameGod, gameViewModel);
        }
        

    }
}
