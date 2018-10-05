using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TestTaskForGlobalLogic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send_Path(object sender, RoutedEventArgs e)
        {
            JSOInfoFolder jSOInfoFolder = null;
            FileAttributes attr = new FileAttributes();

            string inputPath = IntroducedPath.Text;
            ShowJSON(attr, inputPath, jSOInfoFolder);
        }

        private void ShowJSON(FileAttributes attr, string inputPath, JSOInfoFolder jSOInfoFolder)
        {
            try
            {
                attr = File.GetAttributes(inputPath);
                DirectoryInfo info = new DirectoryInfo(inputPath);
                CheckPath(attr, inputPath, jSOInfoFolder, info);
            }
            catch
            {
                OutputWindow.Text = "Sorry, but you input incorrect path to directory";
            }
        }

        private void CheckPath(FileAttributes attr, string inputPath, JSOInfoFolder jSOInfoFolder, DirectoryInfo info)
        {
            if (attr.HasFlag(FileAttributes.Directory)
                    && info.Attributes.ToString() == FileAttributes.Directory.ToString()
                    || info.Attributes.ToString() == "ReadOnly, Directory")
            {
                jSOInfoFolder = new JSOInfoFolder(new DirectoryInfo(inputPath));
                string result = jSOInfoFolder.JsonToTree();
                OutputWindow.Text = result;
            }
        }
    }
}
