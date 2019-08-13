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
using System.IO;
using System.Windows.Forms;

namespace PersonalinformationFinder
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Selectfolder = "";
       
        
        public MainWindow()
        {
            InitializeComponent();
        }
        

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        private void open(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderopen = new FolderBrowserDialog();
            folderopen.Description = "검색할 폴더";
            folderopen.ShowDialog();

            // 선택한 폴더의 경로
            Selectfolder = folderopen.SelectedPath;
        }

        private void Search(object sender, RoutedEventArgs e)
        {

        }

        public int DetectPhoneNumber(string input, ref string values)
        {
            String[] patterns =
            {
                @"(^|\W)01[01]\d{7,8}(\W|$)",
                @"(^|\W)01[01]-\d{3,4}-\d{4}(\W|$)"
            };
            int count = 0;
           
            foreach (String pattern in patterns)
            {
                System.Text.RegularExpressions.MatchCollection matchs = 
                    System.Text.RegularExpressions.Regex.Matches(input, pattern);

                foreach (System.Text.RegularExpressions.Match m in matchs)
                {
                    ++count;
                }

            }
        }
    }
}
