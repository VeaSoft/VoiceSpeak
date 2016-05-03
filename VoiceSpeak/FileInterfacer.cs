using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace VoiceSpeak
{
    class FileInterfacer
    {
        FileStream fs;
        public string read(string filePath)
        {
            string result = "";
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                BufferedStream bStream = new BufferedStream(fs);
                StreamReader sReader = new StreamReader(bStream);
                result = sReader.ReadToEnd();
            }
            catch (IOException ex)
            {

            }
            finally
            {
                fs.Flush();
                fs.Close();
            }
            return result;
        }
        public void write(object parame)
        {
            string[] values = (string[])parame;
            string filePath = values[0];
            string content = values[1];
            if (filePath.Equals(string.Empty))
            {
                return;
            }
            try
            {
                File.WriteAllText(filePath, content);   
            }
            catch (IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }
    }
}
