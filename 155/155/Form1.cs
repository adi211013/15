using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _155
{
    public partial class Form1 : Form
    {
        List<Button> buttonList;
        public Form1()
        {
            InitializeComponent();
        }
        int ruchy = 0;
        Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonList = new List<Button>() {button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,button11,button12,button13,button14,button15,button16 };
            button16.Visible = false;
            button16.Text = "";
            Losowanie();

            buttonList.ForEach(x => { x.Click += (s, EventArgs) => { swap(sender, EventArgs, buttonList.IndexOf(x)); }; });
        }
        public void plus1(int index)
        {
            if (index == 3 || index == 7 || index == 11 || index == 15)
            { return; }
            if (buttonList[index + 1].Visible == false) 
            {
                var temp = buttonList[index + 1].Text;
                buttonList[index + 1].Text = buttonList[index].Text;
                buttonList[index].Text = temp;
                buttonList[index].Visible = false;
                buttonList[index + 1].Visible = true;
            }


        }
        public void plus4(int index)
        {
            if (buttonList[index + 4].Visible == false)
            {
                var temp = buttonList[index + 4].Text;
                buttonList[index + 4].Text = buttonList[index].Text;
                buttonList[index].Text = temp;
                buttonList[index].Visible = false;
                buttonList[index + 4].Visible = true;
            }    
        }
        public void minus1(int index)
        {
            if(index==4||index==0||index==8||index==12)
            { return; }
            if (buttonList[index - 1].Visible == false)
            {
                var temp = buttonList[index - 1].Text;
                buttonList[index - 1].Text = buttonList[index].Text;
                buttonList[index].Text = temp;
                buttonList[index].Visible = false;
                buttonList[index - 1].Visible = true;
            }

        }
        public void minus4(int index)
        {
            if (buttonList[index - 4].Visible==false)
            {
                var temp = buttonList[index - 4].Text;
                buttonList[index - 4].Text = buttonList[index].Text;
                buttonList[index].Text = temp;
                buttonList[index].Visible = false;
                buttonList[index - 4].Visible = true;
            }

        }
        public bool wygrana()
        {
            if(button1.Text=="1" && button2.Text=="2"&&button3.Text == "3" && button4.Text == "4"&& button5.Text == "5" && button6.Text == "6" && button7.Text == "7" && button8.Text == "8" && button9.Text == "9" && button10.Text == "10" && button11.Text == "11" && button12.Text == "12" && button13.Text == "13" && button14.Text == "14" && button15.Text == "15")
                return true;
            return false;
        }
        public void swap(object sender, EventArgs e,int index) 
        {
            ruchy++;
            this.Text = "Zrobiles " + ruchy + " ruchy";
            if (index == 0)
            {
                plus1(index);plus4(index);
            }
            else if (index == 15)
            {
                minus1(index);minus4(index);
            }
            else if (index >= 12)
            {
                minus4(index); minus1(index); plus1(index);
            }
            else if (index < 4)
            {
                plus1(index);plus4(index);minus1(index);
            }
            else
            {
                plus1(index);plus4(index);minus1(index);minus4(index);
            }

            if (wygrana())
            {
                var pytanie = MessageBox.Show("Wygrales, \nGrasz dalej?", "Gratuluje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pytanie == DialogResult.Yes)
                {
                    Losowanie();
                    this.Text = "";
                    ruchy = 0;
                }
                else
                {
                    Thread.Sleep(5000);
                    Application.Exit();
                }
            }    
        }
        public void Losowanie()
        {
            var arr = Enumerable.Range(1, 15).OrderBy(x => random.Next()).Take(15).ToList();
            for (int i=0;i<15;i++) 
            {
                buttonList[i].Text = arr[i].ToString();
            }
        }

    }
}
