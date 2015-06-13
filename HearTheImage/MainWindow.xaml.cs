using System;
using System.Collections.Generic;
using System.Windows;


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
}
