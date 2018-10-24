using DicePoker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.ViewModel
{
    class DiceHolderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dice _dice1 { get; set; }
        public Dice Dice1 { get
            {
                return _dice1;
            }
            set
            {
                _dice1 = value;
                OnPropertyChanged();
            }
        }

        private Dice _dice2 { get; set; }
        public Dice Dice2
        {
            get
            {
                return _dice2;
            }
            set
            {
                _dice2 = value;
                OnPropertyChanged();
            }
        }

        private Dice _dice3 { get; set; }
        public Dice Dice3
        {
            get
            {
                return _dice3;
            }
            set
            {
                _dice3 = value;
                OnPropertyChanged();
            }
        }

        private Dice _dice4 { get; set; }
        public Dice Dice4
        {
            get
            {
                return _dice4;
            }
            set
            {
                _dice4 = value;
                OnPropertyChanged();
            }
        }

        private Dice _dice5 { get; set; }
        public Dice Dice5
        {
            get
            {
                return _dice5;
            }
            set
            {
                _dice5 = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
