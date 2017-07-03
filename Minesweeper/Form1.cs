using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            


        }
        int[][] BackBoard;
        List<List<Button>> buttons;
        public void btnClick(object sender, EventArgs e)
        {  
           Button myButton = sender as Button;
           //MessageBox.Show(myButton.Name);
           //ButtonControls.ShowALL(BackBoard,ref buttons);
           string []cords = myButton.Name.Split(' ');
           int x = int.Parse(cords[0]);
           int y = int.Parse(cords[1]);
           ButtonControls.ButtonClick(ref buttons, BackBoard, x, y);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackgroundImage = Image.FromFile("Retry.PNG");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImage = Image.FromFile("Exit.PNG");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            int sizeOfBoard = 25;  // Change size of board here 
            int NumOfMines = 50;
           
            //button1.ImageAlign = ContentAlignment.MiddleRight;
            
            // Contains what appears after clicking on Buttons
            // 0 for empty
            // number < 10 for neighbour mines
            // 999 for Mine
            BackBoard = new int[sizeOfBoard][];
            for (int i = 0; i < sizeOfBoard; i++)
            {
                BackBoard[i] = new int[sizeOfBoard];
            }
            // Fill Mines Randomly
            BoardControls.FillMines(ref BackBoard, NumOfMines);


            // Fill Numbers based on neighbouring mines 
            BoardControls.FillNumbers(ref BackBoard);

            // Draw the Board and create list of buttons
             buttons = new List<List<Button>>();
            for (int x = 0; x < sizeOfBoard; x++)
            {
                buttons.Add(new List<Button>());
                for (int y = 0; y < sizeOfBoard; y++)
                {
                    Button newButton = new Button();
                    buttons[x].Add(newButton);
                    this.Controls.Add(newButton);
                    buttons[x][y].Size = new Size(23, 23);
                    buttons[x][y].Location = new Point(5+ x * 23, 50+ y*23);
                    buttons[x][y].Name = x.ToString() +" "+ y.ToString();
                    buttons[x][y].Click += btnClick;
                   
                }
            }




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            ButtonControls.ShowALL(BackBoard,ref buttons);
            Application.DoEvents();
            System.Threading.Thread.Sleep(3000);
            Application.Restart();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
