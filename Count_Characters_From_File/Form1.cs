using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace Count_Characters_From_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private int CountCharacters()
        {
            int count = 0;

            using (StreamReader reader = new StreamReader(@"C:\Example\data.txt"))
            {
                string content = reader.ReadToEnd(); // reading files to the end of the stream

                count = content.Length;

               Thread.Sleep(5000);
            }

            return count;
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            labelCount.Text = "Processing....... Please wait...";

            int count = await task; // Waiting for the task to complete;

            labelCount.Text  = count.ToString() + " characters in our file.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}