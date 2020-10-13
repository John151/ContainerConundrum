using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerConundrum
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }

        int row = 0;        //common values for position in lists, arrays etc
        int col = 0;        //will be used by multiple functions and reset
        int length = 0;

        int[,] rectangularArray; //declares rectangular array
        int[] oneDimensionalArr; //declares 1d array
        int[][] jagged; //tries to declaire jagged array, fails
        List<int> storageList = new List<int>();
        SortedList<string, int> newSortedList = new SortedList<string, int>();
        Stack<string> nameStack = new Stack<string>();
        Queue<string> nameQueue = new Queue<string>();
        ArrayList newArrayList = new ArrayList();

        private void btnRectAdd_Click_1(object sender, EventArgs e)
        {//rectangular array add button
            try
            {
                if (txtRectNumRows.Text == "")
                {
                    MessageBox.Show("Please enter a value in the rows field", "Error");
                    txtRectNumRows.Focus();
                }
                else if (txtRectNumCol.Text == "")
                {
                    MessageBox.Show("Please enter a value in the collumns field", "Error");
                    txtRectNumCol.Focus();
                }

                else if (rectangularArray == null)
                {
                    int rowCount = Convert.ToInt32(txtRectNumRows.Text);
                    int columnCount = Convert.ToInt32(txtRectNumCol.Text);
                    txtRectNumRows.ReadOnly = true;
                    txtRectNumCol.ReadOnly = true;

                    rectangularArray = new int[rowCount, columnCount];
                }

                if (txtRectValue.Text == "")
                {
                    MessageBox.Show(
                        "Please enter a value in the fields.", "Entry Error");
                    txtRectValue.Focus();
                }
                else
                {
                    int maxRows = rectangularArray.GetLength(0);
                    int maxCollumns = rectangularArray.GetLength(1);
                    int inputValue = Convert.ToInt32(txtRectValue.Text);

                    if ((row + 1) == maxRows && (col + 1) == maxCollumns)
                    {
                        rectangularArray[row, col] = inputValue;
                        txtRectValue.ReadOnly = true;
                        btnRectAdd.Enabled = false;
                        btnDisplay.Focus();
                    }
                    else if ((col + 1) < maxCollumns)
                    {
                        rectangularArray[row, col] = inputValue;
                        col++;
                    }
                    else if ((row + 1) < maxRows)
                    {
                        rectangularArray[row, col] = inputValue;
                        row++;
                        col = 0;
                    }
                    else
                    {
                        MessageBox.Show("here's an error in the adding button function", "alert");
                    }
                }                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private void btnDisplay_Click(object sender, EventArgs e)
        {//Rectangular Array display button
            try
            {
            string rectangularArrayOutput = "";
            for (int i = 0; i < rectangularArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangularArray.GetLength(1); j++) 
                    rectangularArrayOutput += rectangularArray[i, j] + " ";
                rectangularArrayOutput += "\n";

            }
            MessageBox.Show(rectangularArrayOutput, "Rectangular Array Values");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnArrayAdd_Click(object sender, EventArgs e)
        {//adds values to array box, number 9
            try
            {
                if (txtArrayLength.Text == "")
                {
                    MessageBox.Show("Please enter a value in the length field", "Error");
                    txtArrayLength.Focus();
                }

                else if (txtArrayValue.Text == "")
                {
                    MessageBox.Show(
                        "Please enter a value in the field.", "Entry Error");
                    txtArrayValue.Focus();
                }

                else if (oneDimensionalArr == null)
                {
                    length = Convert.ToInt32(txtArrayLength.Text);
                    oneDimensionalArr = new int[length];
                    txtArrayLength.ReadOnly = true;
                }

                else if ((row +1) == length)
                {
                    oneDimensionalArr[row] = Convert.ToInt32(txtArrayValue.Text);
                    txtArrayValue.ReadOnly = true;
                    btnArrayAdd.Enabled = false;
                    btnArrayDisplay.Focus();
                }

                else if ((row+ 1) <= length)
                {
                    oneDimensionalArr[row] = Convert.ToInt32(txtArrayValue.Text);
                    row++;
                }

                else                    
                {
                        MessageBox.Show("here's an error in the adding array button function", "alert");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnArrayDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string arraynumbers = "";
                for (int i = 0; i < oneDimensionalArr.Length; i++)
                    arraynumbers += oneDimensionalArr[i] + " ";
                MessageBox.Show(arraynumbers, "Values of Array");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnJaggedAdd_Click(object sender, EventArgs e)
        {//adds to list, list items will end up in jagged array as single column

            if (jagged == null)
            {

                if (txtJaggedRows.Text == "")
                    {
                        MessageBox.Show("Please choose how many rows", "Error");
                        txtJaggedRows.Focus();
                    }
                else if (txtJagNumCol.Text == "")
                    {
                        MessageBox.Show("Please choose how many columns for this row", "Error");
                    }
                else
                {
                        row = Convert.ToInt32(txtJaggedRows.Text);
                        length = Convert.ToInt32(txtJaggedRows.Text);

                        txtJaggedRows.ReadOnly = true;
                        col = Convert.ToInt32(txtJagNumCol.Text);
                        txtJagNumCol.ReadOnly = true;
                        int [][] jagged = new int[row][];
                        jagged[row] = new int[col];
                } //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.' occurrs here

            }
            else
            {
                if (txtJaggedValue.Text == "")
                {
                    MessageBox.Show("Please enter a value in the value box", "Error");
                    txtJaggedValue.Focus();
                }
                else if (storageList.Count == col)
                {//stops adding items to collumn, submits them and moves to next row

                    try
                    {                       
                        for (int i = 0; (i+ 1) < col; i++)
                        {
                            jagged[row][i] = storageList[i];
                        }
                        storageList.Clear();
                        row++;
                        if (row > length)
                        {
                            btnJaggedAdd.Enabled = false;
                            txtJaggedValue.ReadOnly = true;
                            btnJaggedDisplay.Focus();
                        }
                        else
                        {
                            txtJagNumCol.Text = "";
                            txtJagNumCol.Focus();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }

                }
                else
                {
                    int jaggedListItem = Convert.ToInt32(txtJaggedValue.Text);
                    storageList.Add(jaggedListItem);
                }
                
            }

        }

        private void btnJaggedDisplay_Click(object sender, EventArgs e)
        {
            string jaggedArrayDisplay = "";
            for (int i = 0; i < jagged.GetLength(0); i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                    jaggedArrayDisplay += jagged[i][j] + " ";
                jaggedArrayDisplay += "\n";
            }
            MessageBox.Show(jaggedArrayDisplay, "Jagged Array contents");    
        }

        private void btnListAdd_Click(object sender, EventArgs e)
        {
            int newItem = Convert.ToInt32(txtList.Text);
            storageList.Add(newItem);
        }

        private void btnListDisplay_Click(object sender, EventArgs e)
        {
            string stringMessage = "";
            foreach (int i in storageList)
                stringMessage += i.ToString() + " ";
            MessageBox.Show(stringMessage, "List Contents");
        }

        private void btnSortedAdd_Click(object sender, EventArgs e)
        {
           if (txtKey.Text == "" || txtValue.Text == "")
            {
                MessageBox.Show("Please enter a key value pair", "error");
            }
           else if (newSortedList.ContainsKey(txtKey.Text))
            {
                MessageBox.Show("Key already exists, choose another", "error");
                txtKey.Focus();
            }
           else
            {
                string key = txtKey.Text;
                int value = Convert.ToInt32(txtValue.Text);
                newSortedList.Add(key, value);
            }
        }

        private void btnSortedDisplay_Click(object sender, EventArgs e)
        {
            string sortedDisplay = "";
            foreach (KeyValuePair<string, int> entry in newSortedList)
            {
                sortedDisplay += entry.Key + "\t"
                              + entry.Value + "\n"; 
            }
            MessageBox.Show(sortedDisplay, "Sorted List Contents");
        }

        private void btnStackAdd_Click(object sender, EventArgs e)
        {
            if (txtStack.Text == "")
            {
                MessageBox.Show("Please enter a value", "Error");
            }
            else
            {
                nameStack.Push(txtStack.Text);
            }
        }

        private void btnStackDisplay_Click(object sender, EventArgs e)
        {
            string nameStackString = "";
            while (nameStack.Count > 0)
                nameStackString += nameStack.Pop() + "\n";
            MessageBox.Show(nameStackString, "Stack Contents");
        }

        private void btnQueAdd_Click(object sender, EventArgs e)
        {
            if (txtQueue.Text == "")
            {
                MessageBox.Show("Please enter a value", "Error");
            }
            else
            {
                nameQueue.Enqueue(txtQueue.Text);
            }
        }

        private void btnQueDisplay_Click(object sender, EventArgs e)
        {
            string nameQueueString = "";
            while (nameQueue.Count > 0)
                nameQueueString += nameQueue.Dequeue() + "\n";
            MessageBox.Show(nameQueueString, "Queue contents");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double d = Convert.ToDouble(txtAL.Text);
            newArrayList.Add(d);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ALString = "";
            foreach (decimal d in newArrayList)
                ALString += d + "\n";
            MessageBox.Show(ALString, "Array List contents");
        }
    }
}
