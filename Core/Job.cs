using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENFORM
{
    public class Job
    {
        private string id;
        private string filename;     

        public Job(string filename)
        {
            Guid guid = Guid.NewGuid();
            id = guid.ToString();
            this.filename = filename;
         

        }

        public string Filename
        {
            get
            {
                return filename;   
            }
        }

        public string ID
        {
            get
            {
                return id;
            }
        }

        

    }
}
