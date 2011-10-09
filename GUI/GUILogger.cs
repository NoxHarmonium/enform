using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENFORM.Core;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using ENFORM.Core.Logging;

namespace ENFORM.GUI
{
    class GUILogger : ILogger
    {
        
        
        private frmLogBox logbox;
        public delegate void logDelegate(string message, string thread);
        public delegate void setPosDelegate(int x, int y);
        public delegate void closeLogDelegate();
        
        public void StartLogger()
        {
            logbox = new frmLogBox();
            logbox.Show();          
        }

        private void log(string message, string thread)
        {
            logbox.AddLogEntry(message, thread);
        }


        private  void setPos(int x, int y)
        {
            logbox.Location = new Point(x, y);
            logbox.BringToFront();

        }

        private void closeLogBox()
        {
            logbox.Close();            
        }    
            

        public void Log(string message)
        {

            string thread = Thread.CurrentThread.Name;
          
            if (logbox.InvokeRequired)
            {
                logbox.Invoke(new logDelegate(log), new object[] { message, thread });
            }
            else
            {
                log(message, thread);
            }           

        }


        public void StopLogger()
        {
            if (logbox != null && logbox.Visible)
            {
                if (logbox.InvokeRequired)
                {
                    logbox.Invoke(new closeLogDelegate(closeLogBox));
                }
                else
                {
                    closeLogBox();
                }
            }
        }

        public void SetLogWindowLocation(int x, int y)
        {
            
           
            if (logbox.InvokeRequired)
            {
                logbox.Invoke(new setPosDelegate(setPos), new object[] { x, y });
            }
            else
            {
                setPos(x, y);
            }
            
        }




        public void Log(string format, params object[] args)
        {
            Log(String.Format(format, args));

        }
    }
}
