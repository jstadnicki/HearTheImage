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
        }
    }


    public interface IImageAnalyzer
    {
        Dictionary<StoryImage, List<string>> GetWords(IEnumerable<StoryImage> images);
    }

    public class StoryImage
    {
        public FileInfo ImageFile { get; set; }
    }

    public interface ISynonymGenerator
    {
        StoryWord GetSynonyms(string word);
    }

    public class StoryWord
    {
        public string Word { get; set; }
        public List<string> Synonyms { get; set; }
    }

    public interface ISoundsProvider
    {
        StorySound GetSoundForWord(string word);
    }

    public class StorySound
    {
        public FileInfo SoundFile { get; set; } 
    }
}
