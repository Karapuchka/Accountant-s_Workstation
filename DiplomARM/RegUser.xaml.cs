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
using System.Data;
using System.Data.SqlClient;

namespace DiplomARM
{
    /// <summary>
    /// Логика взаимодействия для RegUser.xaml
    /// </summary>
    public partial class RegUser : Window
    {
        //подключение к базе данных
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7BH8O6D\SQLEXPRESS02;Initial Catalog=DiplomARM;Integrated Security=True");
        //Инструкция для базы данных
        SqlCommand cmd;
        public RegUser()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Открытие соединения с базой данных
            await con.OpenAsync();

            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter diplomARMDataSetUserTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter();
            diplomARMDataSetUserTableAdapter.Fill(diplomARMDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
        //Переход на панель авторизации
        private void ButtonBreak_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f = new MainWindow();
            f.Show();
        }
        //Переход на рабочюю панель
        private void ButtonWorkingWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WorkingWindow f = new WorkingWindow();
            f.Show();
        }
        //Изменение данных в базе данных
        private async void ButtonUPDate_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [User] WHERE id = '" + TextBoxUPDateID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (string.IsNullOrEmpty(TextBoxUPDateID.Text) && string.IsNullOrWhiteSpace(TextBoxUPDateID.Text))
            {
                MessageBox.Show("Введите ID пользователя для редактирования данных", "Ошибка при попытке редактирования данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if ((!string.IsNullOrEmpty(TextBoxUPDateLogin.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateLogin.Text))
                || (!string.IsNullOrEmpty(TextBoxUPDatePassword.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDatePassword.Text))
                || (!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
                || (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
                || (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
                || (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text))
                || ComboBoxUPDateStatus.Text == "Пользователь" || ComboBoxUPDateStatus.Text == "Администратор")
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данные пользователя?", "Процесс редактирования данных", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            if (!string.IsNullOrEmpty(TextBoxUPDateLogin.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateLogin.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Login] = @log WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@log", TextBoxUPDateLogin.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }

                            if (!string.IsNullOrEmpty(TextBoxUPDatePassword.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDatePassword.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Password] = @pas WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@pas", TextBoxUPDatePassword.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }

                            if (!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Имя] = @name WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@name", TextBoxUPDateName.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Фамилия] = @fam WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@fam", TextBoxUPDateFamile.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Отчество] = @otec WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@otec", TextBoxUPDateOtec.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text))
                            {

                                cmd = new SqlCommand("UPDATE [User] SET [Должность] = @rang WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@rang", TextBoxUPDateRang.Text);

                                await cmd.ExecuteNonQueryAsync();

                            }
                            if (ComboBoxUPDateStatus.Text == "Пользователь" || ComboBoxUPDateStatus.Text == "Администратор")
                            {
                                cmd = new SqlCommand("UPDATE [User] SET [СтатусАккаунта] = @status WHERE [id] = @id", con);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                cmd.Parameters.AddWithValue("@status", ComboBoxUPDateStatus.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким ID нет в базе данных", "Ошибка при попытке редактировать данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные для редактирования", "Ошибка при редактировании данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter diplomARMDataSetUserTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter();
            diplomARMDataSetUserTableAdapter.Fill(diplomARMDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
        //Очищает поля для ввода данных при замене
        private void ButtonClearUpDate_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(TextBoxUPDateLogin.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateLogin.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDatePassword.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDatePassword.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text))
               || ComboBoxUPDateStatus.Text == "Пользователь" || ComboBoxUPDateStatus.Text == "Администратор")
            {
                TextBoxUPDateID.Clear();

                TextBoxUPDateLogin.Clear();

                TextBoxUPDatePassword.Clear();

                TextBoxUPDateName.Clear();

                TextBoxUPDateFamile.Clear();

                TextBoxUPDateOtec.Clear();

                TextBoxUPDateRang.Clear();

                ComboBoxAddStatus.Text = "Не менять";
            }
            else
            {
                MessageBox.Show("Поля для ввода данных уже пусты", "Ошибка при очистке полей для ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Добавление данных
        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Инструкция для базы данных
            cmd = new SqlCommand("INSERT INTO [User] (Login, Password, [Имя], [Фамилия], [Отчество], [Должность], [СтатусАккаунта])values (@log, @pas, @name, @fam, @otec, @rang, @status)", con);
            //Проверка на наличие пробелов и пустых полей
            if (string.IsNullOrEmpty(TextBoxAddLogin.Text) && string.IsNullOrWhiteSpace(TextBoxAddLogin.Text)
                && string.IsNullOrEmpty(TextBoxAddPassword.Text) && string.IsNullOrWhiteSpace(TextBoxAddPassword.Text)
                && string.IsNullOrEmpty(TextBoxAddName.Text) && string.IsNullOrWhiteSpace(TextBoxAddName.Text)
                && string.IsNullOrEmpty(TextBoxAddFamile.Text) && string.IsNullOrWhiteSpace(TextBoxAddFamile.Text)
                && string.IsNullOrEmpty(TextBoxAddOtec.Text) && string.IsNullOrWhiteSpace(TextBoxAddOtec.Text)
                && string.IsNullOrEmpty(TextBoxAddRang.Text) && string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
            {
                MessageBox.Show("Данные небыли введены", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (string.IsNullOrEmpty(TextBoxAddLogin.Text) || string.IsNullOrWhiteSpace(TextBoxAddLogin.Text)
                || string.IsNullOrEmpty(TextBoxAddPassword.Text) || string.IsNullOrWhiteSpace(TextBoxAddPassword.Text)
                || string.IsNullOrEmpty(TextBoxAddName.Text) || string.IsNullOrWhiteSpace(TextBoxAddName.Text)
                || string.IsNullOrEmpty(TextBoxAddFamile.Text) || string.IsNullOrWhiteSpace(TextBoxAddFamile.Text)
                || string.IsNullOrEmpty(TextBoxAddOtec.Text) || string.IsNullOrWhiteSpace(TextBoxAddOtec.Text)
                || string.IsNullOrEmpty(TextBoxAddRang.Text) || string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
            {
                if (string.IsNullOrEmpty(TextBoxAddLogin.Text) && string.IsNullOrWhiteSpace(TextBoxAddLogin.Text))
                {
                    MessageBox.Show("Поле \"Логин\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxAddPassword.Text) && string.IsNullOrWhiteSpace(TextBoxAddPassword.Text))
                {
                    MessageBox.Show("Поле \"Пароль\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxAddName.Text) && string.IsNullOrWhiteSpace(TextBoxAddName.Text))
                {
                    MessageBox.Show("Поле \"Имя\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxAddFamile.Text) && string.IsNullOrWhiteSpace(TextBoxAddFamile.Text))
                {
                    MessageBox.Show("Поле \"Фамилия\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxAddOtec.Text) && string.IsNullOrWhiteSpace(TextBoxAddOtec.Text))
                {
                    MessageBox.Show("Поле \"Отчество\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (string.IsNullOrEmpty(TextBoxAddRang.Text) && string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
                {
                    MessageBox.Show("Поле \"Должность\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else //Добавление данных в базу данных
            {

                //Прием данных из TextBox
                cmd.Parameters.AddWithValue("@log", TextBoxAddLogin.Text);

                cmd.Parameters.AddWithValue("@pas", TextBoxAddPassword.Text);

                cmd.Parameters.AddWithValue("@name", TextBoxAddName.Text);

                cmd.Parameters.AddWithValue("@fam", TextBoxAddFamile.Text);

                cmd.Parameters.AddWithValue("@otec", TextBoxAddOtec.Text);

                cmd.Parameters.AddWithValue("@rang", TextBoxAddRang.Text);

                cmd.Parameters.AddWithValue("@status", ComboBoxAddStatus.Text);

                await cmd.ExecuteNonQueryAsync();

                MessageBox.Show("Добавлен новый пользователь", "Операция прошла успешка");

            }

            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter diplomARMDataSetUserTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter();
            diplomARMDataSetUserTableAdapter.Fill(diplomARMDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
        //Удаление данных
        private async void ButtonDelet_Click(object sender, RoutedEventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [User] WHERE id = '" + TextBoxDeletID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (string.IsNullOrEmpty(TextBoxDeletID.Text) && string.IsNullOrWhiteSpace(TextBoxDeletID.Text))
            {
                MessageBox.Show("Введите ID пользователя", "Ошибка при удалении данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Процесс удаления пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        cmd = new SqlCommand("DELETE FROM [User] WHERE [id] = @id", con);

                        cmd.Parameters.AddWithValue("@id", TextBoxDeletID.Text);

                        await cmd.ExecuteNonQueryAsync();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователя с таким ID нет в базе данных", "Ошибка при удалении данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу User. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter diplomARMDataSetUserTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.UserTableAdapter();
            diplomARMDataSetUserTableAdapter.Fill(diplomARMDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
        //Очищает поля для ввода данных при добавлении
        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(TextBoxAddLogin.Text) && !string.IsNullOrWhiteSpace(TextBoxAddLogin.Text))
                || (!string.IsNullOrEmpty(TextBoxAddPassword.Text) && !string.IsNullOrWhiteSpace(TextBoxAddPassword.Text))
                || (!string.IsNullOrEmpty(TextBoxAddName.Text) && !string.IsNullOrWhiteSpace(TextBoxAddName.Text))
                || (!string.IsNullOrEmpty(TextBoxAddFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxAddFamile.Text))
                || (!string.IsNullOrEmpty(TextBoxAddOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxAddOtec.Text))
                || (!string.IsNullOrEmpty(TextBoxAddRang.Text) && !string.IsNullOrWhiteSpace(TextBoxAddRang.Text)))
            {
                TextBoxAddLogin.Clear();

                TextBoxAddPassword.Clear();

                TextBoxAddName.Clear();

                TextBoxAddFamile.Clear();

                TextBoxAddOtec.Clear();

                TextBoxAddRang.Clear();
            }
            else
            {
                MessageBox.Show("Поля для ввода данных уже пусты", "Ошибка при очистке полей для ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Событие при закрытии формы
        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
