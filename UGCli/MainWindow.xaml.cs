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
            MovementLabel.Visibility=Visibility.Hidden;
            MoveDownButton.Visibility=Visibility.Hidden;
            MoveLeftButton.Visibility=Visibility.Hidden;
            MoveLeftDownButton.Visibility=Visibility.Hidden;
            MoveLeftUpBtton.Visibility=Visibility.Hidden;
            MoveRightButton.Visibility=Visibility.Hidden;
            MoveRightDownBtton.Visibility=Visibility.Hidden;
            MoveRightUpBtton.Visibility=Visibility.Hidden;
            MoveUpButton.Visibility=Visibility.Hidden;
            StayButton.Visibility=Visibility.Hidden;
            CommentBox.Text="...";
            }
        private void NewGameButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.StartNewGame();
            ExpositionDevice.Text=GameHandler.State._Room.ToString();
            MakeVisible();
            }

        private void LoadGameButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.LoadSavedGame();
            }

        private void ShowStatusButton_Click(object sender,RoutedEventArgs e)
            {

            }

        private void NewGameButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="New Game: Begins a new game.";
            }

        private void NewGameButton_MouseLeave(object sender,MouseEventArgs e)
            {
            CommentBox.Text="...";
            }

        private void LoadGameButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="New Game: Begins a new game.";
            }

        private void LoadGameButton_MouseLeave(object sender,MouseEventArgs e)
            {
            CommentBox.Text="...";
            }
        private void MakeVisible()
            {
            EquippedWeapon.Visibility=Visibility.Visible;
            ItemSlot1.Visibility=Visibility.Visible;
            ItemSlot2.Visibility=Visibility.Visible;
            ItemSlot3.Visibility=Visibility.Visible;
            ItemSlot4.Visibility=Visibility.Visible;
            ItemSlot5.Visibility=Visibility.Visible;
            ShowStatusButton.Visibility=Visibility.Visible;
            MoveDownButton.Visibility=Visibility.Visible;
            MoveLeftButton.Visibility=Visibility.Visible;
            MoveLeftDownButton.Visibility=Visibility.Visible;
            MoveLeftUpBtton.Visibility=Visibility.Visible;
            MoveRightButton.Visibility=Visibility.Visible;
            MoveRightDownBtton.Visibility=Visibility.Visible;
            MoveRightUpBtton.Visibility=Visibility.Visible;
            MoveUpButton.Visibility=Visibility.Visible;
            MovementLabel.Visibility=Visibility.Visible;
            StayButton.Visibility=Visibility.Visible;
            }

        private void ComboBox_SelectionChanged(object sender,SelectionChangedEventArgs e)
            {
            
            }
        }
    }
