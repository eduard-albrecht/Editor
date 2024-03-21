using System;
using System.Collections.Generic;
using System.IO;
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

namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                if (!File.Exists("File.txt"))
                {
                    File.Create("File.txt");
                }
                else
                {
                    Editor.Text = File.ReadAllText("File.txt");
                }
            }
            catch
            {
                if (MessageBox.Show("Failed to read from file\nWRITING WILL OVERWRITE THE ORIGINAL TEXT\ndo you want to continue", "", MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    Environment.Exit(0);
                }
            }

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Editor.Text += $"\n{DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss")}\n";
            try
            {
                if (!File.Exists("File.txt"))
                {
                    File.Create("File.txt");
                }
                File.WriteAllText("File.txt", Editor.Text);
            }
            catch
            {
                MessageBox.Show("Failed to write to file");
            }

        }
    }
}
