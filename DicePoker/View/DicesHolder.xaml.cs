using DicePoker.Model;
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

namespace DicePoker.View
{
    /// <summary>
    /// Interaction logic for DicesHolder.xaml
    /// </summary>
    public partial class DicesHolder : UserControl
    {
        private DiceHolderViewModel viewModel;        
        
        public List<Dice> DiceHandSource
        {
            get { return (List<Dice>)GetValue(DiceHandSourceProperty); }
            set { SetValue(DiceHandSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiceHandSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiceHandSourceProperty =
            DependencyProperty.Register("DiceHandSource", typeof(List<Dice>), typeof(DicesHolder), new PropertyMetadata(default(List<Dice>)));

        public DicesHolder()
        {
            InitializeComponent();
            viewModel = new DiceHolderViewModel();
            DataContext = viewModel;
            SetDiceHand();
        }

        public void SetDiceHand()
        {
            if (DiceHandSource != null)
            {
                viewModel.Dice1 = DiceHandSource[0];
                viewModel.Dice2 = DiceHandSource[1];
                viewModel.Dice3 = DiceHandSource[2];
                viewModel.Dice4 = DiceHandSource[3];
                viewModel.Dice5 = DiceHandSource[4];
            }                
        }
    }
}
