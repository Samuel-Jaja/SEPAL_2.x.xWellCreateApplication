using SEPAL_2.x.xWellCreateApplication.ViewModel;
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
using System.Windows.Shapes;

namespace SEPAL_2.x.xWellCreateApplication
{
    /// <summary>
    /// Interaction logic for WellCreation.xaml
    /// </summary>
    public partial class WellCreation : Window
    {
        public WellCreation()
        {
            InitializeComponent();
            DataContext = new WellCreationViewModel();
        }
    }
}
