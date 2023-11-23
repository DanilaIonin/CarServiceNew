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
    /// Логика взаимодействия для PageServices.xaml
    /// </summary>
    public partial class PageServices : UserControl
    {
        public PageServices()
        {
            InitializeComponent();
            LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
        }

        private void TXBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXBSearch.Text.Count() != 0)
            {
                List<Services> services = (List<Services>)LTVService.ItemsSource;
                LTVService.ItemsSource = services.Where(x => x.Title.ToLower().Contains(TXBSearch.Text.ToLower())).ToList();
            }
            if (TXBSearch.Text.Count() == 0)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
            }
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            LTVService.ItemsSource = CarServiceEntities.GetContext().Services.OrderBy(x => x.Title).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            LTVService.ItemsSource = CarServiceEntities.GetContext().Services.OrderByDescending(x => x.Title).ToList();
        }

        private void RbDefault_Checked(object sender, RoutedEventArgs e)
        {
            LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
        }

        private void CMBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CMBFilter.SelectedIndex == 0)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.Where(x => x.Discount >= 0 && x.Discount < 5).ToList();
            }
            else if (CMBFilter.SelectedIndex == 1)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.Where(x => x.Discount >= 5 && x.Discount < 15).ToList();
            }
            else if (CMBFilter.SelectedIndex == 2)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.Where(x => x.Discount >= 15 && x.Discount < 25).ToList();
            }
            else if (CMBFilter.SelectedIndex == 3)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.Where(x => x.Discount >= 25 && x.Discount < 50).ToList();
            }
            else if (CMBFilter.SelectedIndex == 4)
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.Where(x => x.Discount >= 50 && x.Discount < 100).ToList();
            }
            else
            {
                LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
            }
        }

        private void TxtSearch_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TXBSearch.Focus();
        }

        private void BTNEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddServices((Services)LTVService.SelectedItem));
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Services serviceForDelete = LTVService.SelectedItem as Services;
                    CarServiceEntities.GetContext().Services.Remove(serviceForDelete);
                    CarServiceEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Услуга не удалена");
                }
            }
            LTVService.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
        }

        private void BTNAddService_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddServices(null));
        }

        private void BTNReports_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageReports());
        }

        private void BTNAutorization_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAuthorization());
        }
    }
}
