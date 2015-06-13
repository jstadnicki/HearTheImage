using System;
using System.Collections.Generic;
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
            var images = new ImageAnalyzer();
            
            AzureBlobStorage azure = new AzureBlobStorage();
            var x =
                await
                    images.GetWords(new List<string>()
                    {
                        await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Dog.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/duck.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Elephant.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Hog.jpg")),
                        await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Lion.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Monkey.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Mosquito.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/MountainLion.jpeg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Owl.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Pig.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Tiger.jpg")),await
                            azure.GetImageUrlFromFile(
                                new FileInfo("../../content/Images/Woodpecker.jpg")),

                    });
            foreach (var k in x)
            {
                Debug.WriteLine(k.Key);
                foreach (var z in k.Value)
                {
                    Debug.WriteLine(z);
                }
            }


        }
    }
}
