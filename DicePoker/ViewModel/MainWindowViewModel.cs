using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DicePoker.Model;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;
using DicePoker.Controls;
using System.Windows;
using DicePoker.Command;
using System.Collections.ObjectModel;
using System.Threading;

namespace DicePoker.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private Table _table;

        private string _playerName;
        public string PlayerName {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                OnPropertyChanged();
            } }

        private int _playerMoney;
        public int PlayerMoney
        {
            get
            {
                return _playerMoney;
            }
            set
            {
                _playerMoney = value;
                OnPropertyChanged();
            }
        }

        private Combinations _playerCombination;
        public Combinations PlayerCombination
        {
            get
            {
                return _playerCombination;
            }
            set
            {
                _playerCombination = value;
                OnPropertyChanged();
            }
        }

        private string _computerName;
        public string ComputerName
        {
            get
            {
                return _computerName;
            }
            set
            {
                _computerName = value;
                OnPropertyChanged();
            }
        }

        private int _computerMoney;
        public int ComputerMoney
        {
            get
            {
                return _computerMoney;
            }
            set
            {
                _computerMoney = value;
                OnPropertyChanged();
            }
        }

        private Combinations _computerCombination;
        public Combinations ComputerCombination
        {
            get
            {
                return _computerCombination;
            }
            set
            {
                _computerCombination = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Dice> _playerHand;
        public ObservableCollection<Dice> PlayerHand {
            get
            {
                return _playerHand;
            }
            set
            {
                //if(_playerHand != null)
                //{
                //    foreach(Dice dice in _playerHand)
                //    {
                //        dice.PropertyChanged -= PropertyChanged;
                //    }
                //}
                //if (value != null)
                //{
                //    foreach (Dice dice in value)
                //    {
                //        dice.PropertyChanged += PropertyChanged;
                //    }
                //}
                _playerHand = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Dice> _computerHand;
        public ObservableCollection<Dice> ComputerHand
        {
            get
            {
                return _computerHand;
            }
            set
            {
                _computerHand = value;
                OnPropertyChanged();
            }
        }

        private int _minBet;
        public int MinBet
        {
            get
            {
                return _minBet;
            }
            set
            {
                _minBet = value;
                OnPropertyChanged();
            }
        }

        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                OnPropertyChanged();
            }
        }

        private int _playerBet;
        public int PlayerBet
        {
            get
            {
                return _playerBet;
            }
            set
            {
                _playerBet = value;
                OnPropertyChanged();
            }
        }

        private int _computerBet;
        public int ComputerBet
        {
            get
            {
                return _computerBet;
            }
            set
            {
                _computerBet = value;
                OnPropertyChanged();
            }
        }

        private Dice _selectedDice;
        public Dice SelectedDice
        {
            get
            {
                return _selectedDice;
            }
            set
            {
                _selectedDice = value;
                OnPropertyChanged();
            }
        }

        private Visibility _gridMakingBetVisibility;
        public Visibility GridMakingBetVisibility
        {
            get
            {
                return _gridMakingBetVisibility;
            }
            set
            {
                _gridMakingBetVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmBetCommand { get; set; }
        public ICommand PassCommand { get; set; }
        public ICommand SelectDiceCommand { get; set; }
        public ICommand OpenBetControlCommand { get; set; }

        public MainWindowViewModel()
        {
            _table = new Table();
            PlayerName = _table.p1.Name;
            PlayerMoney = _table.p1.Money;
            ComputerName = _table.p2.Name;
            ComputerMoney = _table.p2.Money;
            PlayerHand = _table.p1.Hand;
            ComputerHand = _table.p2.Hand;
            MinBet = 0;
            PassCommand = new Command.Command(Pass);
            ConfirmBetCommand = new Command.Command(ConfirmBet);
            OpenBetControlCommand = new Command.Command(OpenBetControl);
            SelectDiceCommand = new Command.Command(() =>
            {
                SelectDice(SelectedDice);
            });
            GridMakingBetVisibility = Visibility.Visible;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ThrowDices()
        {
            _table.ActivePlayer.MakeCombination();
            Random r = new Random();
            foreach (Dice dice in _table.ActivePlayer.Hand)
            {
                if(!dice.IsThrown)
                {
                    dice.Value = r.Next(1, 6);
                    dice.IsThrown = true;
                    dice.RefreshImage();
                }                
            }          
        }

        private void OpenBetControl()
        {
            GridMakingBetVisibility = Visibility.Visible;
        }

        private void CloseBetControl()
        {
            GridMakingBetVisibility = Visibility.Hidden;
        }

        private void Pass()
        {
            MessageBox.Show("PASS");
        }
        
        private void ConfirmBet()
        {
            PlayerMoney -= CurrentBet;
            _table.p1.Money = PlayerMoney;
            PlayerBet += CurrentBet;
            CloseBetControl();
            //Thread.Sleep(3000);
            ComputerMoney -= PlayerBet;
            _table.p2.Money = ComputerMoney;
            ComputerBet += PlayerBet;            
            //Thread.Sleep(3000);
            ThrowDices();
            _table.SwitchPlayer();
            _table.p2.AutoChooseDicesToThrowAgain();
            ThrowDices();
            _table.SwitchPlayer();

        }

        public void SelectDice(Dice dice)
        {
            if (dice.IsThrown)
            {
                dice.DiceImagePath = "C:/Users/sasha/OneDrive/Документи/Visual Studio 2015/Projects/DicePoker/DicePoker/Assets/Images/selected_dice" + dice.Value.ToString() + ".png";
                dice.IsThrown = false;
            }
            else
            {
                dice.DiceImagePath = "C:/Users/sasha/OneDrive/Документи/Visual Studio 2015/Projects/DicePoker/DicePoker/Assets/Images/dice" + dice.Value.ToString() + ".png";
                dice.IsThrown = true;
            }
        }
    }
}