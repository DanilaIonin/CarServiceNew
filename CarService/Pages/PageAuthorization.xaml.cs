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
using CarService.Classes;
using CarService.Pages;

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void BTNEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text.Trim();
            string pass = PBPass.Password.Trim();

            if (login.Length < 4)
            {
                TBLogin.ToolTip = "Поле введено не корректно!";
                TBLogin.BorderBrush = Brushes.Red;
            }
            else if (pass.Length < 4)
            {
                PBPass.ToolTip = "Поле введено не корректно!";
                PBPass.BorderBrush = Brushes.Red;
            }
            else
            {
                TBLogin.ToolTip = "";
                TBLogin.BorderBrush = Brushes.Transparent;
                PBPass.ToolTip = "";
                PBPass.BorderBrush = Brushes.Transparent;

                Employees employee = null;
                using (ConnectHelper db = new ConnectHelper())
                {
                    employee = CarServiceEntities.GetContext().Employees.Where(x => x.Login == login && x.Password == pass).FirstOrDefault();
                }

                if (employee != null)
                {
                    MessageBox.Show("Авторизация прошла успешно");
                    Classes.ClassFrame.frmObj.Navigate(new PageServices());
                }
                else
                    MessageBox.Show("Пользователь не авторизован");

            }
        }
    }
}
