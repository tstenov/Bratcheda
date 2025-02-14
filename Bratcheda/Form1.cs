using System.Collections.Generic;

namespace Bratcheda
{
  
    public partial class Form1 : Form
    {
        List<int> myList = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             LoadList();
            myList.Sort();
            listBox1.DataSource = myList;
        }
       void LoadList()
        {
            for (int i = 0; i < 100; i++)
            {
                var rand = new Random();
                int value = rand.Next(1, 10000);
                myList.Add(value);
            }
        }
    }
}
