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

namespace DiplomARM
{
    /// <summary>
    /// Логика взаимодействия для WorkingWondowSpisokSotrud.xaml
    /// </summary>
    public partial class WorkingWondowSpisokSotrud : Window
    {
        public WorkingWondowSpisokSotrud()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(TextBoxName.Text) && string.IsNullOrWhiteSpace(TextBoxName.Text)
              && string.IsNullOrEmpty(TextBoxFamile.Text) && string.IsNullOrWhiteSpace(TextBoxFamile.Text)
              && string.IsNullOrEmpty(TextBoxOtec.Text) && string.IsNullOrWhiteSpace(TextBoxOtec.Text)
              && string.IsNullOrEmpty(TextBoxINN.Text) && string.IsNullOrWhiteSpace(TextBoxINN.Text)
              && string.IsNullOrEmpty(TextBoxSAndNP.Text) && string.IsNullOrWhiteSpace(TextBoxSAndNP.Text)
              && string.IsNullOrEmpty(TextBoxAge.Text) && string.IsNullOrWhiteSpace(TextBoxAge.Text)
              && string.IsNullOrEmpty(TextBoxIDOt.Text) && string.IsNullOrWhiteSpace(TextBoxIDOt.Text)
              && string.IsNullOrEmpty(TextBoxRang.Text) && string.IsNullOrWhiteSpace(TextBoxRang.Text))
            {
                MessageBox.Show("Данные небыли введены. Введите данные!", "Ошибка при вводе данных", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var helper = new WordHelper("blancWord.docx");

                var items = new Dictionary<string, string>
            {
                {"<inn>", TextBoxINN.Text},
                {"<name>", TextBoxName.Text },
                {"<famil>", TextBoxFamile.Text },
                {"<otec>", TextBoxOtec.Text },
                {"<sandp>", TextBoxSAndNP.Text },
                {"<age>", TextBoxAge.Text },
                {"<idotdela>", TextBoxIDOt.Text },
                {"<rang>", TextBoxRang.Text },
            };

                helper.Process(items);

                this.DialogResult = true;

                MessageBox.Show("Данные успешно внесены в документ", "Операция завершина", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }         
        }
    }
}
