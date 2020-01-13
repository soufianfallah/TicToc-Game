using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace game
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundPlayer;


        public Form1()
        {
            InitializeComponent();
            _soundPlayer = new SoundPlayer("C: \\ Users \\ THEDEAD \\ Documents \\ Visual Studio 2017 \\ game \\ 01 Beautiful People.wav");
        }
        public int player = 2;
        public int turns = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;




        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void buttonclick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if (checkdraw() ==true)
                {
                    MessageBox.Show("****Tie game****");
                    sd++;
                    Newgame();

                }

                if(checkwinner()==true )
                {
                    if(button.Text=="X")
                    {
                      ForeColor = (ForeColor == new Color()) ? Color.Black : ForeColor;
                        MessageBox.Show(" {X} player  \n ****WON****");
                        s1++;
                        Newgame();

                    }
                    else
                    {
                        MessageBox.Show(" {O} player \n ****WON****");
                        s2++;
                        Newgame();
                    }
                    
                }

            }

        }

        private void exB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void REB_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            Newgame();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Xwin.Text = "| {X} | player :  " + s1;
            Owin.Text = "| {O} | player  :  " + s2;
            DRAW.Text = "|  {DRAW} |  :  " + sd;


        }

        void Newgame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "" ;
            Xwin.Text = "| {X} | player :  " + s1;
            Owin.Text = "| {O} | player  :  " + s2;
            DRAW.Text = "|  {DRAW} |  :  " + sd;

           
        }

        private void NGB_Click(object sender, EventArgs e)
        {

            Newgame();
        }

        bool checkdraw ()
        {
            if ((turns == 9)&&(checkwinner()==false))
            {  return true;
            }
            else
            {  return false;
            }
        }

        bool checkwinner()
        {
            //horizontal check

            if((A00.Text==A01.Text) && (A01.Text==A02.Text) && A00.Text !="")
            {
                return true;
            }
            else if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && A10.Text != "")
            {
                return true;
            }
            else if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && A20.Text != "")
            {
                return true;
            }
            //vertical check
            if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && A01.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) &&  A02.Text != "")
            {
                return true;
            }
             
            if((A00.Text==A11.Text) && (A11.Text==A22.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && A02.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void CKM_CheckedChanged(object sender, EventArgs e)
        {

            if (CKM.Checked)
            {
                CKM.Text = " STOP";
                _soundPlayer.Play();
            }
            else
            {
                CKM.Text = " PLAY";
                _soundPlayer.Stop();
            }
        }
    }
}
