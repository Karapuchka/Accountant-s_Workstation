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
    /// Логика взаимодействия для WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        public WorkingWindow()
        {
            InitializeComponent();
           
        }
        object b = new PageFrameWorkingWindowMain();
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            FrameWorkingWindow.Content = b;
            LabelFrameName.Content = "Сисок сотрудников";
            LabelFrameEror.Content = "На данной вкладке нет возможности добавить данные в Excel";
            ButtonExcel.IsEnabled = false;
            LabelFrameEror.Visibility = Visibility;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Отображение текущего времени
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { LabelTime.Content = DateTime.Now.ToString(); };
            timer.Start();
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            if (FrameWorkingWindow.Content == b)
            {
                WorkingWondowSpisokSotrud spisokSotrud = new WorkingWondowSpisokSotrud();

                if (spisokSotrud.ShowDialog() == true)
                {

                }
            }
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(FrameWorkingWindow, "Печать");
            }
        }
    }
}
