using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using MeAndMySpace;

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
            listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            LoadList();

        }
        void LoadList()
        {
            for (int i = 0; i < 100; i++)
            {
                var rand = new Random();
                int value = rand.Next(1, 10000);
                myList.Add(value);
            }
            myList.Sort();
            listBox1.DataSource = myList;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastSelectedIndex = (int)typeof(ListBox).GetProperty("FocusedIndex", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(listBox1, null);
            var mySelectedItem = listBox1.Items[lastSelectedIndex];
            //label2.Text = mySelectedItem.ToString;
            CalculateMe makeCalc = new CalculateMe();
            //listBox1.Text = makeCalc.FindSumFromNumberDigits(mySelectedItem);
         
        }
        private void ListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string s = listBox1.Items[listBox1.IndexFromPoint(e.Location)].ToString();

            label2.Text = s;
        }

        private void bntClaculate_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                //Console.WriteLine(((DataRowView)item).Row["Value-member-name-here"].ToString());
                Console.WriteLine(listBox1.SelectedItem.ToString());
            }
        }
    }
}
