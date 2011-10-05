using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENFORM
{
    public class Run
    {
        private int runID;

        public int RunID
        {
            get { return runID; }            
        }
        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }           
        }
        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }            
        }
        private int status;

        public int Status
        {
            get { return status; }         
        }
        private int blobIndex;

        public int BlobIndex
        {
            get { return blobIndex; }            
        }
        private string uuid;

        public string UUID
        {
            get { return uuid; }            
        }

        private float minFitness;

        public Run(int runID, DateTime startTime, DateTime endTime, int status, int blobIndex, string uuid, float minFitness)
        {
            this.runID = runID;
            this.startTime = startTime;
            this.endTime = endTime;
            this.status = status;
            this.blobIndex = blobIndex;
            this.uuid = uuid;
            this.minFitness = minFitness;

        }

        public string[] ToStringArray()
        {
            return new string[] {
                runID.ToString(), 
                startTime.ToString(), 
                endTime.ToString(),
                status.ToString(),         
                minFitness.ToString(),
                blobIndex.ToString()
            };
  
        }


    }
}
