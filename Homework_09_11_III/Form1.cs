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

namespace Homework_09_11_III
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mutex mutex = new Mutex();

        void Thread_one()
        {
            mutex.WaitOne();
            for (int i = 0; i < 21; i++)
            {
                listBox1.Invoke((MethodInvoker)delegate {
                    listBox1.Items.Add(i.ToString());
                });
                Thread.Sleep(1000);
            }
            mutex.ReleaseMutex();
        }

        void Thread_two()
        {
            mutex.WaitOne();
            for (int i = 10; i > -1; i--)
            {
                listBox2.Invoke((MethodInvoker)delegate {
                    listBox2.Items.Add(i.ToString());
                });
                Thread.Sleep(1000);
            }
            mutex.ReleaseMutex();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            Thread t1 = new Thread(Thread_one);
            Thread t2 = new Thread(Thread_two);

            t1.Start();
            t2.Start();

        }
    }
}
