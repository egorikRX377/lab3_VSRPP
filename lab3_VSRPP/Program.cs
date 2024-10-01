using lab3_VSRPP;
using System;
using System.Windows.Forms;

namespace ListBoxExample
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 dialogForm = new Form1();
            dialogForm.ShowDialog();  
        }
    }
}