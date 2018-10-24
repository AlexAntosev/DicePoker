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
    /// Interaction logic for DiceControl.xaml
    /// </summary>
    public partial class DiceControl : UserControl
    {
        DiceControlViewModel viewModel;

        public Dice DiceHandSource
        {
            get { return (Dice)GetValue(DiceHandSourceProperty); }
            set { SetValue(DiceHandSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiceHandSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiceHandSourceProperty =
            DependencyProperty.Register("DiceHandSource", typeof(Dice), typeof(DiceControl), new PropertyMetadata(default(Dice)));

        public DiceControl()
        {
            InitializeComponent();
            viewModel = new DiceControlViewModel();
            DataContext = viewModel;
            ChangeImageSource();
        }

        public void ChangeImageSource()
        {
            if(viewModel.DiceImageSource != null)
            viewModel.DiceImageSource = DiceHandSource.DiceImagePath;
        }
    }
}
