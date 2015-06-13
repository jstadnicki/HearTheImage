using System;
using System.Collections.Generic;
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

    public interface ISynonymGenerator
    {
        StoryWord GetSynonyms(string word);
    }

    public interface ISoundsProvider
    {
        StorySound GetSoundForWord(string word);
    }

    public interface ISoundMixer
    {
        StorySoundMix MixSounds(List<StorySound> sounds);
    }

    public interface IPlayer
    {
        void Play(Story story);
    }

    public class Story
    {
        List<StoryImage> Images { get; set; }
        List<StorySoundMix> Mixes { get; set; }
    }
}
