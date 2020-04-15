using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTAModChanger.Interfaces.ContentService
{
    public class ContentService : IContentService
    {

        public string modFolder { get; set; }
        public string rootFolder { get; set; }
        /// <summary>
        /// Gets folder path of the selected folder from the user
        /// </summary>
        /// <returns></returns>
        public string GetFolderPath()
        {
            //-- PathHolder
            string thePath = "";

            //-- Code that Gets selected folder
            FolderBrowserDialog folderdialog = new FolderBrowserDialog();
            DialogResult result = folderdialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderdialog.SelectedPath))
            {
                thePath = folderdialog.SelectedPath;
            }

            return thePath;
        }

        /// <summary>
        /// Removes the mod from the RootFolderPath depending on the content from the ModFolderPath
        /// </summary>
        /// <param name="RootFolderPath"></param>
        /// <param name="ModFolderPath"></param>
        public void RemoveMods(string RootFolderPath, string ModFolderPath)
        {

        }

        /// <summary>
        /// Adds the mod from the ModFolderPath depending on the content from the RootFolderPath
        /// </summary>
        /// <param name="RootFolderPath"></param>
        /// <param name="ModFolderPath"></param>
        public void AddMods(string RootFolderPath, string ModFolderPath)
        {

        }
    }
}
