using System;
using System.Windows.Forms;
using System.IO;
using DictionaryUI; 

namespace Dictionary
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                // diagnostic log to help identify silent exits
                try { File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_trace.log"), DateTime.Now + " - Before Application.Run\n"); } catch { }
                Application.Run(new Form1()); 
                try { File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_trace.log"), DateTime.Now + " - After Application.Run (exited normally)\n"); } catch { }
            }
            catch (Exception ex)
            {
                // Show a message box so the user sees the exception
                MessageBox.Show(ex.ToString(), "Startup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Also write to a log file in the app folder for inspection
                try { File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup_error.log"), ex.ToString()); } catch { }
            }
        }
    }
}