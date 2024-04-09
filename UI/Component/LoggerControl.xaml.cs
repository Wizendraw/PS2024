using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WelcomeExtended.Loggers;

namespace UI.Component
{
    /// <summary>
    /// Interaction logic for LoggerControl.xaml
    /// </summary>
    public partial class LoggerControl : UserControl
    {
        public LoggerControl()
        {
            InitializeComponent();

            ConcurrentDictionary<int, string> logger2 = new ConcurrentDictionary<int, string>();
            //get info for logs to display
            HashLogger hashLogger = new HashLogger("Ime");
            hashLogger.LoadLogs("logs.json");
            
            HashLogger.CopyLogsTo(out logger2);
            logger2[1] = "Mesage 1";
            logger2[2] = "Message 2";
            
            logger.DataContext = logger2;
        }
    }
}
