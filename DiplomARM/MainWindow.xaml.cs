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
using System.Data;
using System.Data.SqlClient;

namespace DiplomARM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7BH8O6D\SQLEXPRESS02;Initial Catalog=DiplomARM;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [User] WHERE Login ='" + TextBoxLogin.Text + "' AND Password = '" + TextBoxPassword.Password + "' AND [СтатусАккаунта] = '" + ComboBoxStatus.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if ((string.IsNullOrEmpty(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxLogin.Text))
                || (string.IsNullOrEmpty(TextBoxPassword.Password) && string.IsNullOrWhiteSpace(TextBoxPassword.Password))
                || string.IsNullOrEmpty(ComboBoxStatus.Text))
            {
                if (string.IsNullOrEmpty(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxLogin.Text)
                && string.IsNullOrEmpty(TextBoxPassword.Password) && string.IsNullOrWhiteSpace(TextBoxPassword.Password)
                && string.IsNullOrEmpty(ComboBoxStatus.Text))
                {
                    MessageBox.Show("Введите логин, пароль и укажите статус аккаунта", "Ошибка при вводе данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxLogin.Text))
                {
                    MessageBox.Show("Веедите логин", "Ошибка при вводе данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxPassword.Password) && string.IsNullOrWhiteSpace(TextBoxPassword.Password))
                {
                    MessageBox.Show("Введите пароль", "Ошибка при вводе данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(ComboBoxStatus.Text))
                {
                    MessageBox.Show("Укажите статус аккаунта", "Ошибка указании статуса аккаунта", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (ComboBoxStatus.Text == "Администратор")
                    {
                        this.Hide();
                        RegUser f = new RegUser();
                        f.Show();
                    }
                    else if (ComboBoxStatus.Text == "Пользователь")
                    {
                        this.Hide();
                        WorkingWindow f = new WorkingWindow();
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет в базе данных", "Ошибка при вводе данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
