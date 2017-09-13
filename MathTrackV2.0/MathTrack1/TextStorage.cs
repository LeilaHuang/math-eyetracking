using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTrack1
{
   public class TextStorage
    {

        public string fileDir = @"C://Users/huangzeqian/Desktop/" + DateTime.Now.ToString("yyyyMMdd - HH：mm：ss") + ".txt";


        public TextStorage()
        {
            CreateTxt();
        }

        public void CreateTxt()
        {
            if (!File.Exists(fileDir))
            {
                FileStream fs = File.Create(fileDir);
                fs.Close();
            }
        }//end CreateTxt

        public void WriteText(string text)
        {
            //using (StreamWriter writer = File.AppendText(fileDir))
            //  {
                StreamWriter writer = new StreamWriter(fileDir, true, Encoding.UTF8); // StreamWriter writer = new StreamWriter(fileDir, true, Encoding.GetEncoding("gb2312"));

                writer.WriteLine(text);
                writer.Close();
          //  }


        }//end WriteText

    }
}
