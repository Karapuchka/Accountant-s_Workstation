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
using System.Data.SqlClient;
using System.Data;

namespace DiplomARM
{
    /// <summary>
    /// Логика взаимодействия для PageFrameWorkingWindowMain.xaml
    /// </summary>
    public partial class PageFrameWorkingWindowMain : Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7BH8O6D\SQLEXPRESS02;Initial Catalog=DiplomARM;Integrated Security=True");
        SqlCommand cmd;
        public PageFrameWorkingWindowMain()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Открытие соединения с базой данных
            await con.OpenAsync();

            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу Сотрудники. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter diplomARMDataSetСотрудникиTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter();
            diplomARMDataSetСотрудникиTableAdapter.Fill(diplomARMDataSet.Сотрудники);
            System.Windows.Data.CollectionViewSource сотрудникиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("сотрудникиViewSource")));
            сотрудникиViewSource.View.MoveCurrentToFirst();

           
        }
        //Редактирование данных
        private async void ButtonUPDate_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [Сотрудники] WHERE id = '" + TextBoxUPDateID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (string.IsNullOrEmpty(TextBoxUPDateID.Text) && string.IsNullOrWhiteSpace(TextBoxUPDateID.Text))
            {
                MessageBox.Show("Введите ID пользователя для редактирования данных", "Ошибка при попытке редактирования данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if ((!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateINN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateINN.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateSAndN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateSAndN.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateAge.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateAge.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateIDOtdela.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateIDOtdela.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text)))
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                   MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить данные пользователя?", "Процесс редактирования данных", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            if (!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [Имя] = @name WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@name", TextBoxUPDateName.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [Фамилия] = @fam WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@fam", TextBoxUPDateFamile.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [Отчество] = @otec WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@otec", TextBoxUPDateOtec.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateINN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateINN.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [ИНН] = @inn WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@inn", TextBoxUPDateINN.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateSAndN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateSAndN.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [СерияИНомерПаспорта] = @SAndP WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@SAndP", TextBoxUPDateSAndN.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateAge.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateAge.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [Возраст] = @age WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@age", TextBoxUPDateAge.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateIDOtdela.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateIDOtdela.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [id_Отдела] = @idOt WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@idOt", TextBoxUPDateIDOtdela.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            if (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text))
                            {
                                cmd = new SqlCommand("UPDATE [Сотрудники] SET [Должность] = @rang WHERE id = @id", con);

                                cmd.Parameters.AddWithValue("@rang", TextBoxUPDateRang.Text);

                                cmd.Parameters.AddWithValue("@id", TextBoxUPDateID.Text);

                                await cmd.ExecuteNonQueryAsync();
                            }
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Сотрудника с таким ID нет в базе данных", "Ошибка при попытке редактировать данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите данные для редактирования", "Ошибка при редактировании данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу Сотрудники. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter diplomARMDataSetСотрудникиTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter();
            diplomARMDataSetСотрудникиTableAdapter.Fill(diplomARMDataSet.Сотрудники);
            System.Windows.Data.CollectionViewSource сотрудникиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("сотрудникиViewSource")));
            сотрудникиViewSource.View.MoveCurrentToFirst();
        }
        //Удаленеи данных
        private async void ButtonDelet_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM [Сотрудники] WHERE id = '" + TextBoxDeletID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (string.IsNullOrEmpty(TextBoxDeletID.Text) && string.IsNullOrWhiteSpace(TextBoxDeletID.Text))
            {
                MessageBox.Show("Сотрудника с таким ID нет в базе данных", "Ошибка при удалении данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(dt.Rows[0][0].ToString() == "1")
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить данные этого сотрудника?", "Процесс удаления данных", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        cmd = new SqlCommand("DELETE FROM [Сотрудники] WHERE id = @id", con);

                        cmd.Parameters.AddWithValue("@id", TextBoxDeletID.Text);

                        await cmd.ExecuteNonQueryAsync();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        //Очищение поей для редактирования данных
        private void ButtonClearUpDate_Click(object sender, RoutedEventArgs e)
        {
             if ((!string.IsNullOrEmpty(TextBoxUPDateName.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateName.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateFamile.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateOtec.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateINN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateINN.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateSAndN.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateSAndN.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateAge.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateAge.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateIDOtdela.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateIDOtdela.Text))
               || (!string.IsNullOrEmpty(TextBoxUPDateRang.Text) && !string.IsNullOrWhiteSpace(TextBoxUPDateRang.Text)))
            {
                TextBoxUPDateName.Clear();

                TextBoxUPDateFamile.Clear();

                TextBoxUPDateOtec.Clear();

                TextBoxUPDateINN.Clear();

                TextBoxUPDateSAndN.Clear();

                TextBoxUPDateAge.Clear();

                TextBoxUPDateIDOtdela.Clear();

                TextBoxUPDateRang.Clear();
            }
            else
            {
                MessageBox.Show("Поля для ввода данных уже пусты", "Ошибка при очистке полей для ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Ощистка полей для добавление данных
        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(TextBoxAddName.Text) && !string.IsNullOrWhiteSpace(TextBoxAddName.Text))
                && (!string.IsNullOrEmpty(TextBoxAddFamile.Text) && !string.IsNullOrWhiteSpace(TextBoxAddFamile.Text))
                && (!string.IsNullOrEmpty(TextBoxAddOtec.Text) && !string.IsNullOrWhiteSpace(TextBoxAddOtec.Text))
                && (!string.IsNullOrEmpty(TextBoxAddINN.Text) && !string.IsNullOrWhiteSpace(TextBoxAddINN.Text))
                && (!string.IsNullOrEmpty(TextBoxAddSAndN.Text) && !string.IsNullOrWhiteSpace(TextBoxAddSAndN.Text))
                && (!string.IsNullOrEmpty(TextBoxAddAge.Text) && !string.IsNullOrWhiteSpace(TextBoxAddAge.Text))
                && (!string.IsNullOrEmpty(TextBoxAddIDOtdela.Text) && !string.IsNullOrWhiteSpace(TextBoxAddIDOtdela.Text))
                && (!string.IsNullOrEmpty(TextBoxAddRang.Text) && !string.IsNullOrWhiteSpace(TextBoxAddRang.Text)))
            {
                TextBoxAddName.Clear();

                TextBoxAddFamile.Clear();

                TextBoxAddOtec.Clear();

                TextBoxAddINN.Clear();

                TextBoxAddSAndN.Clear();

                TextBoxAddAge.Clear();

                TextBoxAddIDOtdela.Clear();

                TextBoxAddRang.Clear();
            }
            else
            {
                MessageBox.Show("Поля для ввода данных уже пусты", "Ошибка при очистке полей для ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Добавление данных
        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO [Сотрудники] ([Имя], [Фамилия], [Отчество], [ИНН], [СерияИНомерПаспорта], [Возраст], [id_Отдела], [Должность]) VALUES (@name, @fam, @otec, @inn, @SAndP, @age, @idOt)", con);

            if (string.IsNullOrEmpty(TextBoxAddName.Text) && string.IsNullOrWhiteSpace(TextBoxAddName.Text)
              && string.IsNullOrEmpty(TextBoxAddFamile.Text) && string.IsNullOrWhiteSpace(TextBoxAddFamile.Text)
              && string.IsNullOrEmpty(TextBoxAddOtec.Text) && string.IsNullOrWhiteSpace(TextBoxAddOtec.Text)
              && string.IsNullOrEmpty(TextBoxAddINN.Text) && string.IsNullOrWhiteSpace(TextBoxAddINN.Text)
              && string.IsNullOrEmpty(TextBoxAddSAndN.Text) && string.IsNullOrWhiteSpace(TextBoxAddSAndN.Text)
              && string.IsNullOrEmpty(TextBoxAddAge.Text) && string.IsNullOrWhiteSpace(TextBoxAddAge.Text)
              && string.IsNullOrEmpty(TextBoxAddIDOtdela.Text) && string.IsNullOrWhiteSpace(TextBoxAddIDOtdela.Text)
              && string.IsNullOrEmpty(TextBoxAddRang.Text) && string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
            {
                MessageBox.Show("Данные небыли введены", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (string.IsNullOrEmpty(TextBoxAddName.Text) || string.IsNullOrWhiteSpace(TextBoxAddName.Text)
              || string.IsNullOrEmpty(TextBoxAddFamile.Text) || string.IsNullOrWhiteSpace(TextBoxAddFamile.Text)
              || string.IsNullOrEmpty(TextBoxAddOtec.Text) || string.IsNullOrWhiteSpace(TextBoxAddOtec.Text)
              || string.IsNullOrEmpty(TextBoxAddINN.Text) || string.IsNullOrWhiteSpace(TextBoxAddINN.Text)
              || string.IsNullOrEmpty(TextBoxAddSAndN.Text) || string.IsNullOrWhiteSpace(TextBoxAddSAndN.Text)
              || string.IsNullOrEmpty(TextBoxAddAge.Text) || string.IsNullOrWhiteSpace(TextBoxAddAge.Text)
              || string.IsNullOrEmpty(TextBoxAddIDOtdela.Text) || string.IsNullOrWhiteSpace(TextBoxAddIDOtdela.Text)
              || string.IsNullOrEmpty(TextBoxAddRang.Text) || string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
            {
                if (string.IsNullOrEmpty(TextBoxAddName.Text) && string.IsNullOrWhiteSpace(TextBoxAddName.Text))
                {
                    MessageBox.Show("Поле \"Имя\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddFamile.Text) && string.IsNullOrWhiteSpace(TextBoxAddFamile.Text))
                {
                    MessageBox.Show("Поле \"Фамилия\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddOtec.Text) && string.IsNullOrWhiteSpace(TextBoxAddOtec.Text))
                {
                    MessageBox.Show("Поле \"Отчество\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddINN.Text) && string.IsNullOrWhiteSpace(TextBoxAddINN.Text))
                {
                    MessageBox.Show("Поле \"ИНН\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddSAndN.Text) && string.IsNullOrWhiteSpace(TextBoxAddSAndN.Text))
                {
                    MessageBox.Show("Поле \"Серия и номер паспорта\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddAge.Text) && string.IsNullOrWhiteSpace(TextBoxAddAge.Text))
                {
                    MessageBox.Show("Поле \"Возраст\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddIDOtdela.Text) && string.IsNullOrWhiteSpace(TextBoxAddIDOtdela.Text))
                {
                    MessageBox.Show("Поле \"ID отдела\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (string.IsNullOrEmpty(TextBoxAddRang.Text) && string.IsNullOrWhiteSpace(TextBoxAddRang.Text))
                {
                    MessageBox.Show("Поле \"Должность\" не заполнено или данные были введены не корректно, введите данные", "Ошибка при попытке добавить пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", TextBoxAddName.Text);
                cmd.Parameters.AddWithValue("@fam", TextBoxAddFamile.Text);
                cmd.Parameters.AddWithValue("@otec", TextBoxAddOtec.Text);
                cmd.Parameters.AddWithValue("@inn", TextBoxAddINN.Text);
                cmd.Parameters.AddWithValue("@SAndP", TextBoxAddSAndN.Text);
                cmd.Parameters.AddWithValue("@age", TextBoxAddAge.Text);
                cmd.Parameters.AddWithValue("@IdOt", TextBoxAddIDOtdela.Text);

                await cmd.ExecuteNonQueryAsync();
            }
            DiplomARM.DiplomARMDataSet diplomARMDataSet = ((DiplomARM.DiplomARMDataSet)(this.FindResource("diplomARMDataSet")));
            // Загрузить данные в таблицу Сотрудники. Можно изменить этот код как требуется.
            DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter diplomARMDataSetСотрудникиTableAdapter = new DiplomARM.DiplomARMDataSetTableAdapters.СотрудникиTableAdapter();
            diplomARMDataSetСотрудникиTableAdapter.Fill(diplomARMDataSet.Сотрудники);
            System.Windows.Data.CollectionViewSource сотрудникиViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("сотрудникиViewSource")));
            сотрудникиViewSource.View.MoveCurrentToFirst();
        }
    }
}
