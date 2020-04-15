using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GTAModChanger.Interfaces.ContentService;
using System.IO;
using System.Windows;
using System.Windows.Input;


//-- Check = https://stackoverflow.com/questions/58744/copy-the-entire-contents-of-a-directory-in-c-sharp
namespace GTAModChanger.ViewModels
{
    public class BottomContentViewModel : ViewModelBase
    {
        //-------------------------------------- Models
        //-------------------------------------- Interfaces
        private IContentService contentService;
        //-------------------------------------- Commands
        public ICommand AddModsCommand => new RelayCommand(AddMods);
        public ICommand RemoveModsCommand => new RelayCommand(RemoveMods);

        //-------------------------------------- Constructor
        public BottomContentViewModel(IContentService _contentService)
        {
            this.contentService = _contentService;
        }

        //-------------------------------------- Properties
        private int progressValue = 0;

        //-------------------------------------- Methods
        public  void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
               CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
                //-- Sends the value progress
                Messenger.Default.Send<int, ProgressBarViewModel>(progressValue++);
            }

            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name));
                //-- Sends the value progress
                Messenger.Default.Send<int, ProgressBarViewModel>(progressValue++);
            }
        }

        /// <summary>
        /// Moves all files from one directory to another. Including folders
        /// </summary>
        public void AddMods()
        {
            if (!string.IsNullOrEmpty(contentService.modFolder) && !string.IsNullOrEmpty(contentService.rootFolder))
            {
                //-- Resets the progressValue counter
                progressValue = 0;
                Messenger.Default.Send<int, ProgressBarViewModel>(0);
                //-- Directory informations from the path from the user
                DirectoryInfo modDirectory = new DirectoryInfo(contentService.modFolder);
                DirectoryInfo rootDirectory = new DirectoryInfo(contentService.rootFolder);

                 //-- Verify the folder locations
                if (modDirectory.Exists && rootDirectory.Exists)
                {
                    CopyFilesRecursively(modDirectory, rootDirectory);
                    //-- Sets it to be finisheds
                    Messenger.Default.Send<int, ProgressBarViewModel>(100);
                }
                else
                {
                    MessageBox.Show("Please verify your directory locations in order to copy your files.");
                }
            }
            else
            {
                MessageBox.Show("Please provide valid paths in order to transfer mods.");
            }
        }

        /// <summary>
        /// Removes all files that exists in the directory
        /// </summary>
        public void RemoveMods()
        {
            if (!string.IsNullOrEmpty(contentService.modFolder) && !string.IsNullOrEmpty(contentService.rootFolder))
            {
                //-- Resets the progressValue counter
                progressValue = 0;
                Messenger.Default.Send<int, ProgressBarViewModel>(0);


                //-- Directory informations from the path from the user
                DirectoryInfo modDirectory = new DirectoryInfo(contentService.modFolder);
                DirectoryInfo rootDirectory = new DirectoryInfo(contentService.rootFolder);

                if (modDirectory.Exists && rootDirectory.Exists)
                {
                    //-- Checks the files exists and deletes them in the Root GTA V folder
                    foreach (FileInfo modfile in modDirectory.EnumerateFiles())
                    {
                        foreach (FileInfo modFileInRoot in rootDirectory.EnumerateFiles())
                        {
                            if (modfile.Name.Equals(modFileInRoot.Name))
                            {
                                modFileInRoot.Delete();
                                //-- Sends the value progress
                                Messenger.Default.Send<int, ProgressBarViewModel>(progressValue++);
                            }
                        }
                    }

                    //-- Checks if the folders exists in the Root GTA V folder
                    foreach (DirectoryInfo modFolder in modDirectory.EnumerateDirectories())
                    {
                        foreach (DirectoryInfo modFolderInRoot in rootDirectory.EnumerateDirectories())
                        {
                            if (modFolder.Name.Equals(modFolderInRoot.Name))
                            {
                                modFolderInRoot.Delete(true);
                                //-- Sends the value progress
                                Messenger.Default.Send<int, ProgressBarViewModel>(progressValue++);
                            }
                        }
                    }

                    //-- Sets it to be finisheds
                    Messenger.Default.Send<int, ProgressBarViewModel>(100);
                }
                else
                {
                    MessageBox.Show("Please verify your directory locations in order to remove your files.");
                }
            }
            else
            {
                MessageBox.Show("Please provide valid paths in order to transfer mods.");
            }

        }
    }
}
