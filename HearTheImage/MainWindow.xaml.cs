using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using HearTheImage.Implementations;

namespace HearTheImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            doSomething();
        }

        public async void doSomething()
        {
            var azure = new AzureBlobStorage();
            Debug.WriteLine(await
                azure.GetImageUrlFromFile(new FileInfo("C:\\Users\\marce\\Pictures\\Camera Roll\\WIN_20150605_10_12_34_Pro.jpg")));

        }
    }
}
