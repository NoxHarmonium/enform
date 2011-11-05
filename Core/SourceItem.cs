using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


public enum SourceType
{
    Custom,
    FileSystem,
    FERET

}

namespace ENFORM.Core
{
    public class SourceItem
    {
        protected string filename = "";
        private string name = "";        
        private Size size;      
        protected int sampleType;
        protected bool cached = false;
        protected Image internalImage;
        protected SourceType sourceType;
        Preprocessor preprocessor = null;

        public Preprocessor Preprocessor
        {
            get { return preprocessor; }
            set { preprocessor = value; }
        }

        public Size Size
        {
            get 
            { 
                return size; 
            }            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Filename
        {
            get
            {
                return filename;
            }
        }
 
        public int SampleType
        {
            get
            {
                return sampleType;
            }
            set
            {
                sampleType = value;
            }
        }

        public bool Cached
        {
            get
            {
                return cached;
            }
        }

        public SourceType SourceType
        {
            get
            {
                return sourceType;
            }            
        }
       

        public Image InternalImage
        {
            get
            {
                if (cached)
                {
                    if (preprocessor != null)
                    {
                        return preprocessor.Process((Bitmap)internalImage);
                    }
                    else
                    {
                        return internalImage;
                    }

                }
                else
                {
                    Image img = null;
                    try
                    {
                        if (filename.ToLower().EndsWith(".ppm"))
                        {
                            img = new PixelMap.PixelMap(filename).BitMap;
                        }
                        else
                        {
                            img = Image.FromFile(filename);
                        }
                    }
                    catch (Exception e)
                    {
                        Utils.Logger.Log("Error reading file.\n Exception: " + e.Message);
                    }
                    if (preprocessor != null && img != null)
                    {
                        return preprocessor.Process((Bitmap)img);
                    }
                    else
                    {
                        return img;
                    }
                    
                }

            }
            set
            {
               
                internalImage = value;                
                size = internalImage.Size;
                cached = true;


            }

        }

        public string[] GetStringValues()
        {
            //s,"0","File System",size
            if (name != "")
            {

                return new string[] 
                { 
                    name, 
                    this.SampleType.ToString(), 
                    this.SourceType.ToString(), 
                    this.Size.ToString() 
                };
            }
            else
            {
                return new string[] 
                { 
                    filename, 
                    this.SampleType.ToString(), 
                    this.SourceType.ToString(), 
                    this.Size.ToString() 
                };
            }

        }
        
        /// <summary>
        /// Creates a source item from filename
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sampleType"></param>
        public SourceItem(string filename, int sampleType)
        {
            this.filename = filename;
            this.sampleType = sampleType;
            this.sourceType = SourceType.FileSystem;            
            Image image = this.InternalImage;
            this.size = new Size(image.Width, image.Height);
            this.name = filename.Substring(filename.LastIndexOf("\\")+1);
        }

        /// <summary>
        /// Creates a new source item from a filename with a nickname
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sampleType"></param>
        /// <param name="name"></param>
        public SourceItem(string filename, int sampleType, string name)
            : this(filename, sampleType)
        {
            this.name = name;
        }
        
        /// <summary>
        /// Creates a new source item from a filename with a nickname and precached file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sampleType"></param>
        /// <param name="name"></param>
        public SourceItem(string filename, int sampleType, string name, Image image)            
        {

            this.name = name;
            this.filename = filename;
            this.sampleType = sampleType;
            this.sourceType = SourceType.FileSystem;   
            
            this.internalImage = image;
            cached = true;


            this.size = new Size(image.Width, image.Height);
        }

        
        /// <summary>
        /// Creates a new custom editable source item stored in memory.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="sampleType"></param>
        /// <param name="name"></param>
        public SourceItem(Size size, int sampleType, string name)
        {
            internalImage = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(internalImage);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, size.Width, size.Height));

            this.size = size;
            this.sampleType = sampleType;
            this.name = name;
            this.cached = true;
            this.sourceType = SourceType.Custom;
        }

        /// <summary>
        /// Load the file off the hard drive and store in memory for quick retrieval.
        /// </summary>
        public void Cache()
        {
            if (filename.ToLower().EndsWith(".ppm"))
            {
                internalImage = new PixelMap.PixelMap(filename).BitMap;
            }
            else
            {               
                internalImage = Image.FromFile(filename);
            }
            cached = true;
        }



    }
}
