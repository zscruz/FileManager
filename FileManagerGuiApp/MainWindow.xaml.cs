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

namespace FileManagerGuiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            OrganizerModel model = new OrganizerModel();
            viewModel = new MainWindowViewModel(model);
            this.DataContext = viewModel;
        }

        private void SourceButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SelectSource();
        }

        private void DestinationButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SelectDestination();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SortFiles();
        }

        private void ClearLogButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ClearLog();
        }
    }
}
