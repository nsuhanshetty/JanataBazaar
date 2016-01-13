using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            log.Info("Application Janata Bazaar Started");

            Application.EnableVisualStyles();           
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Winform_MainMenu());
        }
    }
}
