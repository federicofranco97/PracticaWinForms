using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaWinForms.Business
{
    public class StorageManager
    {   

        /// <summary>
        /// Get the content from file and if the file does not exist throw exception
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns></returns>
        public string GetStorageFile(string path)
        {
            if (File.Exists(path))
            {
                string fileContent = File.ReadAllText(path);
                return fileContent;
            }
            else
            {
                //If there is no file return empty string
                return string.Empty;
            }
        }


        public void SaveStorageFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
