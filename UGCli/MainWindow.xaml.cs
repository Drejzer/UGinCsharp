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

namespace UGCli
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
        {
        public MainWindow()
            {
            InitializeComponent();
            EquippedWeapon.Visibility=Visibility.Hidden;
            ItemSlot1.Visibility=Visibility.Hidden;
            ItemSlot2.Visibility=Visibility.Hidden;
            ItemSlot3.Visibility=Visibility.Hidden;
            ItemSlot4.Visibility=Visibility.Hidden;
            ItemSlot5.Visibility=Visibility.Hidden;
            ShowStatusButton.Visibility=Visibility.Hidden;
            }
        private void NewGameButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.StartNewGame();
            EquippedWeapon.Visibility=Visibility.Visible;
            ItemSlot1.Visibility=Visibility.Visible;
            ItemSlot2.Visibility=Visibility.Visible;
            ItemSlot3.Visibility=Visibility.Visible;
            ItemSlot4.Visibility=Visibility.Visible;
            ItemSlot5.Visibility=Visibility.Visible;
            ShowStatusButton.Visibility=Visibility.Visible;
            ExpositionDevice.Text=GameHandler.State._Room.Layout.ToString();

            }

        private void LoadGameButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.LoadSavedGame();
            }

        private void ShowStatusButton_Click(object sender,RoutedEventArgs e)
            {

            }
        }
    }
