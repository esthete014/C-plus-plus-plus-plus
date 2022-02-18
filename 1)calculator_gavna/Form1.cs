//         Copyright 2022 esthete014 Nikolay Kochetov
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
kostili:

1)
dlya backspace 
chisloEkrana eto poslednee vivedennoe chislo
adreschisla eto otkuda vzyto chislo:
    0-prosto nulevoe znachenie
    1-number1
    2-number2

*/

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int pButton = 0;
        float number1 = 0;
        float number2 = 0;
        float chislopamyati = 0;
        int znak = 0;
        int sostoyanie = 1;
        //float chisloEkrana = 0; //vozmojno potom dlya istorii operaciy budet
        int adreschisla = 0;
        void backspace(ref float number1, ref float number2, ref float chislopamyati, ref int adreschisla)//backspace
        {
            if (adreschisla == 1)
            {
                float num = number1;
                num -= num % 10;
                float res = num / 10;
                number1 = res;
                chislopamyati = res;
                label2.Text = number1.ToString();
            }
            if (adreschisla == 2)
            {
                float num = number2;
                num -= num % 10;
                float res = num / 10;
                number2 = res;
                chislopamyati = res;
                label2.Text = number2.ToString();
            }
        }
        //funkciya operaciy(11x+y, 12x-y, 13x*y, 14x/y, 17x**y, 18x!, 19x**0,5
        void deistvieznaka(ref float num1, ref float num2, ref int znak, ref float chislopamyati)
        {
            if (znak == 11)
            {
                chislopamyati = num1 + num2;
            }
            if (znak == 12)
            {
                chislopamyati = num1 - num2;
            }
            if (znak == 13)
            {
                chislopamyati = num1 * num2;
            }
            if (znak == 14)
            {
                chislopamyati = num1 / num2;
            }
            if (znak == 17)//x**y
            {
                chislopamyati = (float)Math.Pow(num1, num2);
            }
            if (znak == 18)//factorial
            {
                chislopamyati = 1;
                for (int i = 1; i <= num1; i++)
                {
                    chislopamyati *= i;
                }
            }
            if (znak == 19)//x**0,5
            {
                chislopamyati = (float)Math.Pow(num1, 0.5);
            }
        }
        //eto ya funkciyu deistviya sdelal
        //snachala proverka na znak(dlya perehoda sostoyaniya)
        //sostoyaniya:1 vvod pervogo chisla, 2 vvod znaka, 3 vvod vtorogo chisla, 4 ravno
        void deistvie(ref int pButton, ref float num1, ref float num2, ref int sostoyanie, ref float chislopamyati, ref int znak, ref int adreschisla)
        {
            if (10 < pButton && pButton < 15 || 16 < pButton && pButton < 20)
            {
                sostoyanie = 2;//proverka na kakie-to funkcii
            }
            //pri vvode pervogo chisla
            if (sostoyanie == 1)
            {
                chislopamyati = chislopamyati * 10 + pButton;
                num1 = chislopamyati;
                label2.Text = num1.ToString();
                adreschisla = 1;
            }
            //pri vvode znaka
            if (sostoyanie == 2)
            {
                znak = pButton;
            }
            //pri vvode vtorogo chisla
            if (sostoyanie == 3)
            {
                if (num2 == 0)
                {
                    chislopamyati = 0;
                }
                chislopamyati = chislopamyati * 10 + pButton;
                num2 = chislopamyati;
                label2.Text = num2.ToString();
                adreschisla = 2;
            }
            //ravno
            if (sostoyanie == 4)
            {
                deistvieznaka(ref num1, ref num2, ref znak, ref chislopamyati);
                num1 = chislopamyati;
                label2.Text = chislopamyati.ToString();
                adreschisla = 1;
                chislopamyati = num2 = znak = 0;
                sostoyanie = 2;
            }
        }
        private void label1_Click(object sender, EventArgs e)//eto pashalka
        {
            if (label3.Visible == true)
            {
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)//1
        {
            pButton = 1;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button2_Click(object sender, EventArgs e)//2
        {
            pButton = 2;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button3_Click(object sender, EventArgs e)//3
        {
            pButton = 3;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button4_Click(object sender, EventArgs e)//4
        {
            pButton = 4;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button5_Click(object sender, EventArgs e)//5
        {
            pButton = 5;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button6_Click(object sender, EventArgs e)//6
        {
            pButton = 6;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button7_Click(object sender, EventArgs e)//7
        {
            pButton = 7;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button8_Click(object sender, EventArgs e)//8
        {
            pButton = 8;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button9_Click(object sender, EventArgs e)//9
        {
            pButton = 9;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button10_Click(object sender, EventArgs e)//0
        {
            pButton = 0;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button11_Click(object sender, EventArgs e)//x+y
        {
            pButton = 11;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 3;
        }
        private void button12_Click(object sender, EventArgs e)//x-y
        {
            pButton = 12;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 3;
        }
        private void button13_Click(object sender, EventArgs e)//x*y
        {
            pButton = 13;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 3;
        }
        private void button14_Click(object sender, EventArgs e)//x/y
        {
            pButton = 14;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 3;
        }
        private void button15_Click(object sender, EventArgs e)//ce
        {
            number1 = number2 = chislopamyati = 0;
            pButton = znak = 0;
            sostoyanie = 1;
            label2.Text = "0";
            adreschisla = 0;
        }
        private void button16_Click(object sender, EventArgs e)//=
        {
            pButton = 16;
            sostoyanie = 4;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button17_Click(object sender, EventArgs e)//x**y
        {
            pButton = 17;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 3;
        }
        private void button18_Click(object sender, EventArgs e)//x!
        {
            pButton = 18;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 4;
            pButton = 16;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button19_Click(object sender, EventArgs e)//x**0,5
        {
            pButton = 19;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
            sostoyanie = 4;
            pButton = 16;
            deistvie(ref pButton, ref number1, ref number2, ref sostoyanie, ref chislopamyati, ref znak, ref adreschisla);
        }
        private void button20_Click(object sender, EventArgs e)//backspace
        {
            backspace(ref number1, ref number2, ref chislopamyati, ref adreschisla);
        }
    }
}
