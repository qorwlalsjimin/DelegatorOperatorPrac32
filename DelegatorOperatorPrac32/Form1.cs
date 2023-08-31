using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatorOperatorPrac32
{
    //public delegate void SendString(string message);
    public partial class Form1 : Form
    {
        public delegate void SendString(string message);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //public delegate void SendString(string message); //클래스 정의 안 되는 곳은 안 됨 
            Button button = new Button();
            button.Text = "나만의 델리게이터 버튼";

            /* 첫번째 방법 */
            //button.Click += button_click1 + button_click2;

            /* 두번째 방법 */
            button.Click += button_click1; //전통 델리게이터 
            button.Click += (s, e2) => MessageBox.Show("잘가!"); //람다

            Controls.Add(button);

            SendString sayHello, sayGoodbye, multiDelegate;
            sayHello = Hello;
            sayGoodbye = Goodbye;

            multiDelegate = sayHello + sayGoodbye; //메서드를 가져온 변수로 연산 가능 
            multiDelegate("아이유");

            multiDelegate -= sayGoodbye;
            multiDelegate("백지민");

            
        }

        private void Goodbye(string message)
        {
            Console.WriteLine("안녕히가세요, " + message + "양!");
        }

        private void Hello(string message)
        {
            Console.WriteLine("안녕하세요, "+ message + "양!");
        }

        private void button_click1(object sender, EventArgs e)
        {
            MessageBox.Show("안녕!");
        }
    }
}
