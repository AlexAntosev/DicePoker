using DicePoker.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DicePoker.ViewModel
{
    public class BetControlViewModel : INotifyPropertyChanged
    {
        private Table _table;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private int _maxBet;
        public int MaxBet
        {
            get
            {
                return _maxBet;
            }
            set
            {
                _maxBet = value;
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

        private ICommand ConfirmBetCommand { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        public BetControlViewModel()
        {
            ConfirmBetCommand = new DelegateCommand(ConfirmBet);
        }

        public void ConfirmBet()
        {
            CurrentBet = 15;
        }
    }
}
