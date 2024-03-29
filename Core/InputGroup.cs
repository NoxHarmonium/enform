﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENFORM.Core
{
  
    [Serializable]
    public class InputGroup
    {
        private InputGroupType inputGroupType;
        private int segments;

        public InputGroupType InputGroupType
        {
            get { return inputGroupType; }            
        }        

        public  int Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public InputGroup(InputGroupType inputGroupType, int segments)
        {
            this.inputGroupType = inputGroupType;
            this.segments = segments;
        }

        public override string ToString()
        {
            return inputGroupType.ToString();
        }

        public int GetSegment(int x, int width, int height)
        {

            
            int hIndex = (x % width) / (width / this.segments);
            int vIndex = (x / width) / (height / this.segments);

            

            switch (this.inputGroupType)
            {
                case ENFORM.Core.InputGroupType.Grid:
                    return hIndex + vIndex * segments;
                 
                case ENFORM.Core.InputGroupType.Horozontal:
                    return vIndex;            
                   
                case ENFORM.Core.InputGroupType.Vertical:
                    return hIndex;
                    
                default:
                    throw new Exception("How did you get here?");
                

            }
            
            
        }
    }
}
