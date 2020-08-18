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

namespace SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(idtxt.Text, first_Nametxt.Text, last_Nametxt.Text, emailtxt.Text);
            idtxt.Clear();
            first_Nametxt.Clear();
            last_Nametxt.Clear();
            emailtxt.Clear();
        }
        private void Showdatabtn_Click(object sender, RoutedEventArgs e)
        {
            string Showalldata = "";
            foreach(string i in DataAccess.GetData())
            {
                Showalldata = Showalldata + i + "\n";
            }

            MessageBox.Show(Showalldata);
        }
    }
}
