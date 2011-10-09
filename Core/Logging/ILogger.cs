using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENFORM.Core.Logging
{
    public interface ILogger
    {
        void StartLogger();

        void Log(string message);

        void Log(string format, params object[] args);
        

        void StopLogger();

                

    }
}
