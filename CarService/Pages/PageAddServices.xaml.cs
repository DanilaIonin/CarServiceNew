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
    /// Логика взаимодействия для PageAddServices.xaml
    /// </summary>
    public partial class PageAddServices : Page
    {
        private Services _currentServices = new Services();
        public PageAddServices(Services selectedService)
        {
            InitializeComponent();
            if (selectedService != null)
            {
                _currentServices = selectedService;
                BtnAddService.Content = "Изменить";
            }
            DataContext = _currentServices;
            CMBImg.ItemsSource = CarServiceEntities.GetContext().Services.ToList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentServices.Title)) error.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentServices.Time))) error.AppendLine("Укажите длительность работы");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentServices.Price))) error.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentServices.Discount))) error.AppendLine("Укажите скидку");
            if (_currentServices.Discount < 0) error.AppendLine("Скидка не может быть отрицательной");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentServices.IDService == 0)
            {
                CarServiceEntities.GetContext().Services.Add(_currentServices);
                try
                {
                    CarServiceEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageServices());
                    MessageBox.Show("Новая услуга успешно добавлена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    CarServiceEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageServices());
                    MessageBox.Show("Услуга успешно изменена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnCancelService_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageServices());
        }
    }
}
