using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_V1
{
    public partial class Calculator : Form
    {

        private void Calculator_Load(object sender, EventArgs e)
        {
            //Sets the begining state of the calculators screen to show 0
            CalcDisp.Text = "0";
            // Sets the operator label, and first number label to blank
            OperatorLbl.Text = "";
            FirstNumLbl.Text = "";
            //Sets the  starting state of the operator to empty
            opr = "";
            //Sets the focus on the Equals button
            ActiveControl = EqualsBtn;
            



        }
        public Calculator()
        {
            InitializeComponent();
        }
        //Creates each operators state as a string
        public string opr;
        public string opr1 = "+";
        public string opr2 = "-";
        public string opr3 = "/";
        public string opr4 = "x";

        public string num;
        public string firstnumber;
        bool NegBtnClicked = false;
        bool eq = false;
        bool dPoint = false;

        public void OneBtn_Click(object sender, EventArgs e)
        {
            
            Display("1");
        }

        private void TwoBtn_Click(object sender, EventArgs e)
        {
            Display("2");
        }

        private void ThreeBtn_Click(object sender, EventArgs e)
        {
            Display("3");
        }

        private void FourBtn_Click(object sender, EventArgs e)
        {
            Display("4");
        }

        private void FiveBtn_Click(object sender, EventArgs e)
        {
            Display("5");
        }

        private void SixBtn_Click(object sender, EventArgs e)
        {
            Display("6");
        }

        private void SevenBtn_Click(object sender, EventArgs e)
        {
            Display("7");
        }

        private void EightBtn_Click(object sender, EventArgs e)
        {
            Display("8");
        }

        private void NineBtn_Click(object sender, EventArgs e)
        {
            Display("9");
        }

        private void ZeroBtn_Click(object sender, EventArgs e)
        {
            Display("0");
        }

        private void DecimalBtn_Click(object sender, EventArgs e)
        {
            if (!dPoint == true)
            {
                Display(".");
                dPoint = true;
            }
            EqualsBtn.Focus();
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            {
                Operator("/");
                opr = opr3;
            }
            else if (!(opr == opr3))
            {
                opr = opr3;
                OperatorLbl.Text = opr;
            }
            EqualsBtn.Focus();


        }

        private void MultiplyBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            { 
            Operator("x");
            opr = opr4;
            }
            else if (!(opr == opr4))
            {
                opr = opr4;
                OperatorLbl.Text = opr;
            }
            EqualsBtn.Focus();


        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            { 
            Operator("-");
            opr = opr2;
            }
            else if (!(opr == opr2))
            {
                opr = opr2;
                OperatorLbl.Text = opr;
            }
            EqualsBtn.Focus();

        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            { 
            Operator("+");
            opr = opr1;
            }
            else if (!(opr == opr1))
            {
                opr = opr1;
                OperatorLbl.Text = opr;
            }
            EqualsBtn.Focus();

        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            {
                Calculate();
                opr = "";
                FirstNumLbl.Text = "";
                OperatorLbl.Text = "";
                eq = true;
                dPoint = false;

            }
            EqualsBtn.Focus();

        }

        public void Operator(string o)
        {
            dPoint = false;
            if (opr == "")
            {
                firstnumber = CalcDisp.Text;
                FirstNumLbl.Text = firstnumber;
                OperatorLbl.Text = o;
                CalcDisp.Text = "";
                

            }
            else
            {
                Calculate();
                firstnumber = CalcDisp.Text;
                FirstNumLbl.Text = firstnumber;
                OperatorLbl.Text = o;
                CalcDisp.Text = "";
            }
            EqualsBtn.Focus();
        }

        public void Display(string num)
        {
                if (CalcDisp.Text == "0" || eq == true)
                {
                    CalcDisp.Text = num;
                    eq = false;
                }

                else
                {
                    CalcDisp.Text = CalcDisp.Text + num;
                }
                EqualsBtn.Focus();

        }

        public void Calculate()
        {
            double ans = 0;
            double fn = Convert.ToDouble(firstnumber);
            double sn = Convert.ToDouble(CalcDisp.Text);
            
            if (opr == opr1)
            {
                ans = fn + sn;
                
                
            }
            else if (opr == opr2)
            {
                ans = fn - sn;
                
            }
            else if (opr == opr3)
            {
                ans = fn / sn;
                
                
            }
            else if (opr == opr4)
            {
                ans = fn * sn;
            }

            CalcDisp.Text = ans.ToString();
            EqualsBtn.Focus();

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            CalcDisp.Text = "0";
            OperatorLbl.Text = "";
            FirstNumLbl.Text = "";
            opr = "";
            EqualsBtn.Focus();
        }

        
        private void NegBtn_Click(object sender, EventArgs e)
        {
            if (NegBtnClicked == false) 
            { 
                CalcDisp.Text = "-" + CalcDisp.Text;
                NegBtnClicked = true;
            }
            else 
            {
                CalcDisp.Text = CalcDisp.Text.Replace("-", string.Empty);
                NegBtnClicked = false;
            }
            EqualsBtn.Focus();

        }

        private void BackSpaceBtn_Click(object sender, EventArgs e)
        {
            if (!(CalcDisp.Text == ""))
            {
                CalcDisp.Text = CalcDisp.Text.Remove(CalcDisp.Text.Length - 1, 1);
                EqualsBtn.Focus();
            }
        }

        

        private void NumberPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.NumPad1:
                    e.Handled = true;
                    OneBtn.PerformClick();
                    break;
                case Keys.NumPad2:
                    e.Handled = true;
                    TwoBtn.PerformClick();
                    break;
                case Keys.NumPad3:
                    e.Handled = true;
                    ThreeBtn.PerformClick();
                    break;
                case Keys.NumPad4:
                    e.Handled = true;
                    FourBtn.PerformClick();
                    break;
                case Keys.NumPad5:
                    e.Handled = true;
                    FiveBtn.PerformClick();
                    break;
                case Keys.NumPad6:
                    e.Handled = true;
                    SixBtn.PerformClick();
                    break;
                case Keys.NumPad7:
                    e.Handled = true;
                    SevenBtn.PerformClick();
                    break;
                case Keys.NumPad8:
                    e.Handled = true;
                    EightBtn.PerformClick();
                    break;
                case Keys.NumPad9:
                    e.Handled = true;
                    NineBtn.PerformClick();
                    break;
                case Keys.NumPad0:
                    e.Handled = true;
                    ZeroBtn.PerformClick();
                    break;
                case Keys.Decimal:
                    e.Handled = true;
                    DecimalBtn.PerformClick();
                    break;
                case Keys.Subtract:
                    e.Handled = true;
                    MinusBtn.PerformClick();
                    break;
                case Keys.Divide:
                    e.Handled = true;
                     DivideBtn.PerformClick();
                    break;
                case Keys.Multiply:
                    e.Handled = true;
                    MultiplyBtn.PerformClick();
                    break;
                case Keys.Add:
                    e.Handled = true;
                    PlusBtn.PerformClick();
                    break;
                case Keys.Back:
                    e.Handled = true;
                    BackSpaceBtn.PerformClick();
                    break;
                

            }

        }
        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != (Keys.Enter) || ActiveControl.Name != "EqualButton")
                return base.ProcessCmdKey(ref msg, keyData);
            Debug.WriteLine($"Enter pressed on {ActiveControl.Name}\nDo something now");
            return true;
        }
        */

        private void EnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.Handled = true;
                EqualsBtn.PerformClick();
               
            }
        }

        
    }
}
