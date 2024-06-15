using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;

namespace NoteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<Note> myNotes = new List<Note>();
        public JSONNote jsonNoteManager;
        public MainWindow()
        {
            InitializeComponent();
            jsonNoteManager = new JSONNote();
            LoadNotes();

        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Title.Visibility = Visibility.Visible;
            Description.Visibility = Visibility.Visible;
        }
        private void Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "Title")
            {
                Title.Text = "";
                Title.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Title_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Title.Text))
            {
                Title.Text = "Title";
                Title.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Description_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Description.Text == "Description")
            {
                Description.Text = "";
                Description.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Description.Text))
            {
                Description.Text = "Description";
                Description.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note(Title.Text, Description.Text);
            jsonNoteManager.JsonNotes.Add(note);
            var json = JsonSerializer.Serialize(jsonNoteManager.JsonNotes);
            File.WriteAllText("C:\\Users\\User\\Documents\\My_Notes.json", json);
            MessageBox.Show("Notes saved successfully!");
        }
        private void LoadNotes()
        {
            try
            {
                string fileName = "C:\\Users\\User\\Documents\\My_Notes.json";
                jsonNoteManager.ReadFromFile(fileName);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No previous notes found, starting with an empty list.");
            }
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}