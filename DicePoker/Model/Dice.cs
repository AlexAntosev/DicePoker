using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DicePoker.Model
{
    public class Dice : DependencyObject, INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private bool _isThrown;
        public bool IsThrown
        {
            get
            {
                return _isThrown;
            }
            set
            {
                _isThrown = value;
                OnPropertyChanged();
            }
        }

        private string _diceImagePath;
        public string DiceImagePath
        {
            get
            {
                return _diceImagePath;
            }
            set
            {
                _diceImagePath = value;
                OnPropertyChanged();
            }
        }

        public Dice()
        {
            Value = 1;
            IsThrown = false;
            RefreshImage();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RefreshImage()
        {
            DiceImagePath = "C:/Users/sasha/OneDrive/Документи/Visual Studio 2015/Projects/DicePoker/DicePoker/Assets/Images/dice" + Value.ToString() + ".png";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
