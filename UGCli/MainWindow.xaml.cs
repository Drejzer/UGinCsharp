using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            WeaponBoostButton.Visibility=Visibility.Hidden;
            XPBoostButton.Visibility=Visibility.Hidden;
            EnergyRechargeButton.Visibility=Visibility.Hidden;
            HealthRechargeButton.Visibility=Visibility.Hidden;
            ItemUseButton.Visibility=Visibility.Hidden;
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
            HPBar.Visibility=Visibility.Hidden;
            EBar.Visibility=Visibility.Hidden;
            InventoryPreview.Visibility=Visibility.Hidden;
            CommentBox.Text="...";
            string kappa = "\n";
            for (int i=0;i<50;++i)
                {
                kappa+="\\"+new string('/',49)+'\n';
                }
            ExpositionDevice.Text=kappa;
            }
        private void NewGameButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.StartNewGame();
            ExpositionDevice.Text=GameHandler.State._Room.ToString();
            GameHandler.State.Player.OnHealthChanged+=Player_OnHealthChanged;
            GameHandler.State.Player.OnEnergyChanged+=Player_OnEnergyChanged;
            GameHandler.State.Player.OnFinishedMove+=Player_OnFinishedMove;
            GameHandler.State.Player.OnStartingMove+=Player_OnStartingMove;
            Player_OnHealthChanged(this,EventArgs.Empty);
            Player_OnEnergyChanged(this,EventArgs.Empty);
            GameHandler.TurnPassed+=UpdateDisplay;
            InventoryPreview.ItemsSource=GameHandler.State.Player.Inventory;
            InventoryPreview.DisplayMemberPath="Name";
            GameHandler.State.Player.Inventory.Add(new Weapon(null));
            GameHandler.State.Player.Inventory.Add(new Weapon(null));
            GameHandler.TurnPassed+=ProcesDisplayChanges;
            MakeVisible();
            }

        private void ProcesDisplayChanges(object sender,EventArgs e)
            {
            UpdateDisplay(sender,e);
            }

        private void Player_OnStartingMove(object sender,MoveDirData e)
            {
            UpdateDisplay(sender,e);
            }

        private void Player_OnFinishedMove(object sender,MoveDirData e)
            {
            UpdateDisplay(sender,e);
            }

        private void Player_OnEnergyChanged(object sender,EventArgs e)
            {
            Eblack.Offset=GameHandler.State.Player.MaxEnergy/GameHandler.State.Player.Energy;
            Egreen.Offset=Eblack.Offset;
            }

        private void Player_OnHealthChanged(object sender,EventArgs e)
            {
            HPblack.Offset=GameHandler.State.Player.MaxHealth/GameHandler.State.Player.Health;
            HPred.Offset=HPblack.Offset;
            }

        private void UpdateDisplay(object sender,EventArgs e)
            {
            ExpositionDevice.Text=GameHandler.State._Room.ToString();
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

        
        private void LoadGameButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Load Game: resumes a preivously saved game.";
            }

      
        private void MakeVisible()
            {
            WeaponBoostButton.Visibility=Visibility.Visible;
            XPBoostButton.Visibility=Visibility.Visible;
            EnergyRechargeButton.Visibility=Visibility.Visible;
            HealthRechargeButton.Visibility=Visibility.Visible;
            ItemUseButton.Visibility=Visibility.Visible;
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
            HPBar.Visibility=Visibility.Visible;
            EBar.Visibility=Visibility.Visible;
            InventoryPreview.Visibility=Visibility.Visible;
            }

        private void HPBar_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Your health\n"+"("+GameHandler.State.Player.Health+"/"+GameHandler.State.Player.MaxHealth+")";
            }

       
        private void MoveUpButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move Up.";
            }

       
        private void MoveRightButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move Right";
            }

       
        private void MoveDownButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move Down";
            }

       
        private void MoveLeftButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move Left";
            }

       
        private void MoveLeftDownButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move diaggonaly Down and Left";
            }

        private void MoveRightDownBtton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move diaggonaly Down and Right";
            }

       
        private void MoveRightUpBtton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move diaggonaly Up and Right";
            }

       
        private void MoveLeftUpBtton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Move diaggonaly UP and Left";
            }

        private void StayButton_MouseEnter(object sender,MouseEventArgs e)
            { 
            CommentBox.Text="Stay in place";
            }

        private void ResetCommentBox(object sender,MouseEventArgs e)
            {
            CommentBox.Text="...";
            }

        private void ExpositionDevice_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Map of the level.\n '#' - wall | '@' - you | ' '  '.'  ','  '*' - empty spaces\n oter things are most likely enemies, good luck";
            }

        private void MoveLeftUpBtton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(8);
            }

        private void MoveUpButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(1);
            }

        private void MoveRightUpBtton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(2);
            }

        private void MoveRightButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(3);
            }

        private void MoveRightDownBtton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(4);
            }

        private void MoveDownButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(5);
            }

        private void MoveLeftDownButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(6);
            }

        private void MoveLeftButton_Click(object sender,RoutedEventArgs e)
            {
            GameHandler.State.Player.Move(7);
            }

        private void EBar_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Your energy\n"+"("+GameHandler.State.Player.Energy+"/"+GameHandler.State.Player.MaxEnergy+")";
            }

        private void EnergyRechargeButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Turns the selected item into 1 point of Energy on the next turn";
            }

        private void XPBoostButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Turns the selected item into some Experience";
            }

        private void HealthRechargeButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Turns the selected item into 1 point of Health on the next turn";
            }

        private void ItemUseButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Activates the item, possibly granting temporary empowerment to you, depending on the Item in question";
            }

        private void WeaponBoostButton_MouseEnter(object sender,MouseEventArgs e)
            {
            CommentBox.Text="Empowers (or not - it depends) your trusty pickaxe by sacificing the Item.";
            }

        private void SelectedItem_SelectionChanged(object sender,SelectionChangedEventArgs e)
            {

            }
        }
    }
