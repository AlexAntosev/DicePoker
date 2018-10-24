using DicePoker.ViewModel;
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
using DicePoker.Model;

namespace DicePoker.Controls
{
    /// <summary>
    /// Interaction logic for BetControl.xaml
    /// </summary>
    public partial class BetControl : UserControl
    {
        BetControlViewModel vm;

        public BetControl()
        {            
            InitializeComponent();
            vm = new BetControlViewModel();
            DataContext = vm;
            vm.MinBet = 10;
            vm.MaxBet = 100;
        }        
    }
}
