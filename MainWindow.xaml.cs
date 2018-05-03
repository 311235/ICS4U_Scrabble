using Microsoft.Win32;
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


namespace Scrabble
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    /// COlin JOnes
    /// April 28, 2018
    /// ICS4U
    /// Gets random letters and compares them to all known english dictionary words
    public partial class MainWindow : Window
    {
        List<string> ApprovedWords = new List<string>();
        List<string> ListOfLetters = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            ScrabbleGame sg = new ScrabbleGame();
            char[] ArrayOfLetters = sg.drawInitialTiles().ToCharArray();

            for (int i = 0; i < 7; i++)
            {
                ListOfLetters.Add(ArrayOfLetters[i].ToString());
                Console.WriteLine(ListOfLetters[i]);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            System.IO.StreamReader streamReader = new System.IO.StreamReader(openFileDialog.FileName);

            while (!streamReader.EndOfStream)
            {
                string word = streamReader.ReadLine();
                if (WordAllowed(word) == true)
                {
                    ApprovedWords.Add(word);

                }
            }
            for (int i = 0; i < ApprovedWords.Count; i++)
            {
                Console.WriteLine(ApprovedWords[i]);
            }

        }

        public bool WordAllowed(string word)
        {
            if (word.Contains("E" + "C" + "K" + "S" + "O" + "I" + "H") == true)
            {
                System.Windows.MessageBox.Show("Approved Words");


            }


            return false;
        }

    }
}