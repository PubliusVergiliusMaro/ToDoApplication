using Newtonsoft.Json;
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

namespace ToDoApplication
{
    /// <summary>
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public Tasks ReturnObj { get; set; }
        public NewWindow()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameTxtBox.Text) || String.IsNullOrEmpty(DescriprionTxtBox.Text))
            {
                if (String.IsNullOrEmpty(NameTxtBox.Text) && String.IsNullOrEmpty(DescriprionTxtBox.Text))
                {
                    NameTxtBox.BorderBrush = Brushes.Red;
                    DescriprionTxtBox.BorderBrush = Brushes.Red;
                    MessageBox.Show("Заповніть всі поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    

                }
                else if (String.IsNullOrEmpty(NameTxtBox.Text))
                {
                    NameTxtBox.BorderBrush = Brushes.Red;

                    MessageBox.Show("Заповніть поле назви", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                  
                    DescriprionTxtBox.BorderBrush = Brushes.Red;
                    MessageBox.Show("Заповніть поле опису", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                
                ReturnObj = new Tasks(NameTxtBox.Text, DescriprionTxtBox.Text);
                ReturnObj.isCompleted = CompleteCheckBx.IsChecked.Value;


                DialogResult = true;
            }
        }
        
        

        private void CnslBtn_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
            //this.Close();
        }

        private void NameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameTxtBox.BorderBrush = Brushes.Black;
        }

        private void DescriprionTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescriprionTxtBox.BorderBrush = Brushes.Red;
        }
    }
}
