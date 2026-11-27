using System;
using System.Windows.Forms;

namespace OperationManager_Sandbox
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Replace Form1 with MainForm if that is the actual form class.
            Application.Run(new Form1());
        }
    }
}