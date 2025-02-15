using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using MeAndMySpace;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bratcheda
{

    public partial class Form1 : Form
    {
        List<int> myList = new List<int>();
        List<SlectedNumber> selectedNumbersProssesed = new List<SlectedNumber>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            LoadList();
            listBox1.SelectedIndex = -1;
            bntClaculate.Visible = false;
            bntClear.Visible = false;
            LoadComboListEdit();
        }
        void LoadComboListEdit()
        {
            //Build a list
            var dataSource = new List<ComboOptions>();
            dataSource.Add(new ComboOptions() { Name = "List Add value", Value = "AddVal" });
            dataSource.Add(new ComboOptions() { Name = "List Remove selected", Value = "remove" });
            dataSource.Add(new ComboOptions() { Name = "List Find", Value = "find" });
            dataSource.Add(new ComboOptions() { Name = "List Clear", Value = "clear" });
            dataSource.Add(new ComboOptions() { Name = "List Load new values", Value = "load" });
            dataSource.Add(new ComboOptions() { Name = "List Export", Value = "export" });
            dataSource.Add(new ComboOptions() { Name = "List Import", Value = "import" });
            dataSource.Add(new ComboOptions() { Name = "List Select all", Value = "selectall" });


            //Setup data binding
            this.comboBox1.DataSource = dataSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Value";

            // make it readonly
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void bntList_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedValue)
            {
                case "selectall":
                   
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        listBox1.SetSelected(i, true);
                    }
                    break;
                case "export":
                    var folderBrowserDialog1 = new FolderBrowserDialog();
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
                        foreach (var item in listBox1.Items)
                        {
                            SaveFile.WriteLine(item);
                        }

                        SaveFile.Close();
                    }
                    break;
                case "import":
                    var fileContent = string.Empty;
                    var filePath = string.Empty;

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = "c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the path of specified file
                            filePath = openFileDialog.FileName;

                            //Read the contents of the file into a stream
                            var fileStream = openFileDialog.OpenFile();

                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                fileContent = reader.ReadToEnd();
                            }
                        }
                    }
                    string line;
                        var file = new System.IO.StreamReader(filePath);
                    myList= new List<int>();
                    while ((line = file.ReadLine()) != null)
                        {
                            //listBox1.Items.Add(line);
                        myList.Add(Int32.Parse(line));

                    }
                    LoadListPartual();
                    break;
                case "clear":
                    myList = null;
                    listBox1.DataSource = null;
                    listBox1.Items.Clear();
                    listBox1.SelectedIndex = -1;
                    bntClaculate.Visible = false;
                    bntClear.Visible = false;
                    break;
                case "load":
                    LoadList();
                    listBox1.SelectedIndex = -1;
                    bntClaculate.Visible = false;
                    bntClear.Visible = false;
                    break;
                case "AddVal":
                    string input1 = Microsoft.VisualBasic.Interaction.InputBox("Please enter value to to added", "Add to List", "", this.Left + (this.Width / 2) - 200, this.Top + (this.Height / 2) - 100);
                    if (int.TryParse(input1, out int value))
                    {
                        var newVal= Int32.Parse(input1);
                        if (myList.Contains(newVal))
                        {
                            if (MessageBox.Show("The value already exist", "Fail", MessageBoxButtons.OK) == DialogResult.Yes)
                            {

                            }
                        }
                        else
                        {
                            myList.Add(newVal);
                            LoadListPartual();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Inserted is not a integer", "Fail", MessageBoxButtons.OK) == DialogResult.Yes)
                        {

                        }
                    }

                        break;
                case "remove":
                    if (listBox1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select what you need to remove from the list below and try again", "Fail", MessageBoxButtons.OK);
                        break;
                    }
                        if (MessageBox.Show($"Please confirm removal of {label1.Text}", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] items = listBox1.SelectedItems.OfType<object>().Select(item => item.ToString()).ToArray();
                        foreach(var item in items)
                        {
                            var selectedVal = Int32.Parse(item);
                            myList.Remove(selectedVal);
                            LoadListPartual();
                        }
                    }
                    break;
                case "find":
                    string searchString = Microsoft.VisualBasic.Interaction.InputBox("Please enter search criteria", "Find what", "", this.Left + (this.Width / 2) - 200, this.Top + (this.Height / 2) - 100);
                    // Ensure we have a proper string to search for.
                    SearchInList( searchString);
                    break;
                case "minSum":

                    break;
            }
           
        }
  
        void SearchInList(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Find the item in the list and store the index to the item.
                int index = listBox1.FindString(searchString);
                // Determine if a valid index is returned. Select the item if it is valid.
                if (index != -1)
                    listBox1.SetSelected(index, true);
                else
                    MessageBox.Show("The search string did not match any items in the ListBox");
            }
        }
        void LoadList()
        {
            myList = new List<int>();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                var newNo = new MyList();
                var rand = new Random();
                int value = rand.Next(1, 10000);
                myList.Add(value);
            }
            myList.Sort();
            listBox1.DataSource = myList;
        }
        void LoadListPartual()
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            myList.Sort();
            listBox1.DataSource = myList;
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Get the currently selected item in the ListBox.
                string curItem = listBox1.SelectedItem.ToString();

                string[] items = listBox1.SelectedItems.OfType<object>().Select(item => item.ToString()).ToArray();
                string result = string.Join(",", items);
                label1.Text = result;

                label1.BackColor = Color.DarkRed;
                label1.ForeColor = Color.WhiteSmoke;
                label2.Text = items.Count().ToString();
                bntClaculate.Visible = true;
                bntClear.Visible = true;
            }
            else
            {
                label1.Text = "";
                label2.Text = "";
            }


        }

        private void ListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string s = listBox1.Items[listBox1.IndexFromPoint(e.Location)].ToString();

            label2.Text = s;
        }

        private void bntClaculate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select at least one number from the list box!", "Fail", MessageBoxButtons.OK);
                return;
            }
            selectedNumbersProssesed = new List<SlectedNumber>();
            if (listBox1.SelectedIndex != -1)
            {
                var itemNo = 1;
                string[] items = listBox1.SelectedItems.OfType<object>().Select(item => item.ToString()).ToArray();
                foreach (string item in items)
                {
                    int selNo = Int32.Parse(item);
                    CalculateMe makeCalc = new CalculateMe();

                    var selNoPross = new SlectedNumber();
                    selNoPross.ItemNo = itemNo;
                    itemNo++;
                    selNoPross.SelectedNo = selNo;
                    selNoPross.DigitsSum = makeCalc.FindSumFromNumberDigits(selNo);
                    selNoPross.DigitsProduct = makeCalc.FindProductFromNumberDigits(selNo);
                    selNoPross.IsPrime = makeCalc.isPrime(selNo);
                    selectedNumbersProssesed.Add(selNoPross);
                }

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = selectedNumbersProssesed;

                //find min and max
              
               var minSum = selectedNumbersProssesed.OrderBy(p => p.DigitsSum).First().DigitsSum;
                var maxSum = selectedNumbersProssesed.OrderByDescending(p => p.DigitsSum).First().DigitsSum;
                var minProd = selectedNumbersProssesed.OrderBy(p => p.DigitsProduct).First().DigitsProduct;
                var maxProd = selectedNumbersProssesed.OrderByDescending(p => p.DigitsProduct).First().DigitsProduct;
                var maxPrime = 0;
                if (selectedNumbersProssesed.Where(p => p.IsPrime).Count() > 0)
                {
                     maxPrime = selectedNumbersProssesed.Where(p => p.IsPrime).OrderByDescending(p => p.SelectedNo).First().SelectedNo;
                }
               

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells["DigitsSum"].Value.ToString() == minSum.ToString())
                    {
                        var cell = this.dataGridView1.Rows[row.Index].Cells[2].Style;
                        cell.BackColor = Color.Green;
                        cell.ForeColor = Color.WhiteSmoke;
                    }
                    if (row.Cells["DigitsSum"].Value.ToString() == maxSum.ToString())
                    {
                        var cell = this.dataGridView1.Rows[row.Index].Cells[2].Style;
                        cell.BackColor = Color.Red;
                        cell.ForeColor = Color.WhiteSmoke;
                      
                    }



                 
                    if (row.Cells["DigitsProduct"].Value.ToString() == minProd.ToString())
                    {
                        var cell = this.dataGridView1.Rows[row.Index].Cells[3].Style;
                        cell.BackColor = Color.Green;
                        cell.ForeColor = Color.WhiteSmoke;

                        this.dataGridView1.Rows[row.Index].Cells[3].Style.BackColor = Color.Green;
                    }
                    if (row.Cells["DigitsProduct"].Value.ToString() == maxProd.ToString())
                    {
                        var cell = this.dataGridView1.Rows[row.Index].Cells[3].Style;
                        cell.BackColor = Color.Red;
                        cell.ForeColor = Color.WhiteSmoke;
                    }

                    if (selectedNumbersProssesed.Where(p => p.IsPrime).Count() > 0)
                    {
                        if (row.Cells["SelectedNo"].Value.ToString() == maxPrime.ToString())
                        {
                            var cell = this.dataGridView1.Rows[row.Index].Cells[4].Style;
                            cell.BackColor = Color.Red;
                            cell.ForeColor = Color.WhiteSmoke;
                        }
                    }
                 
                }
            }
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clean selected?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                listBox1.SelectedIndex = -1;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                bntClaculate.Visible = false;
                bntClear.Visible = false;
            }

        }

       
    }
}
