using CarService.Classes;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReports.xaml
    /// </summary>
    public partial class PageReports : Page
    {
        public PageReports()
        {
            InitializeComponent();
            LTVReport.ItemsSource = CarServiceEntities.GetContext().Reports.OrderBy(x => x.DateStart).ToList();
        }

        private void BTNServices_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageServices());
        }
    }
}
