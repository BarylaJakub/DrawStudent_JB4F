using System;
using System.IO;

namespace DrawStudent
{
    public partial class MainPage : ContentPage
    {
        Random rand = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        string GetFilePath(string className)
        {
            return Path.Combine(FileSystem.AppDataDirectory, className + ".txt");
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            string className = classEntry.Text;
            string students = studentsEditor.Text;

            if (string.IsNullOrWhiteSpace(className))
            {
                resultLabel.Text = "Podaj nazwę klasy!";
                return;
            }

            if (string.IsNullOrWhiteSpace(students))
            {
                resultLabel.Text = "Podaj co najmniej 1 ucznia!";
                return;
            }

            string path = GetFilePath(className);

            File.WriteAllText(path, students);

            resultLabel.Text = "Zapisano!";
        }

        private void OnLoadClicked(object sender, EventArgs e)
        {
            string className = classEntry.Text;

            if (string.IsNullOrWhiteSpace(className))
            {
                resultLabel.Text = "Podaj nazwę klasy!";
                return;
            }

            string path = GetFilePath(className);

            if (File.Exists(path))
            {
                studentsEditor.Text = File.ReadAllText(path);
                resultLabel.Text = "Wczytano!";
            }
            else
            {
                resultLabel.Text = "Nie ma takiej klasy!";
            }
        }

        private void OnDrawClicked(object sender, EventArgs e)
        {
            string text = studentsEditor.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                resultLabel.Text = "Brak uczniów!";
                return;
            }

            string[] students = text
                .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);


            int index = rand.Next(students.Length);
            resultLabel.Text = "Wylosowano: " + students[index];
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            classEntry.Text = "";
            studentsEditor.Text = "";
            resultLabel.Text = "";
        }
    }
}