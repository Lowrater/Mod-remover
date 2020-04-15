using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GTAModChanger.Interfaces.ContentService;
using GTAModChanger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GTAModChanger.ViewModels
{
    public class MiddleContentViewModel : ViewModelBase
    {
        //-------------------------------------- Model
        private MiddleContentModel middleContentModel = new MiddleContentModel();

        //-------------------------------------- Interfaces
        private IContentService contentService;

        //-------------------------------------- Commands
        public ICommand GetModFolderStringCommand => new RelayCommand(GetModFolder);
        public ICommand GetRootFolderStringCommand => new RelayCommand(GetRootFolder);

        //-------------------------------------- Constructor
        public MiddleContentViewModel(IContentService _contentService)
        {
            //-- Constructor injection
            this.contentService = _contentService;
        }

        //-------------------------------------- Properties
        public string ModFolderString
        {
            get => middleContentModel._modFolderString;
            set
            {
                Set(ref middleContentModel._modFolderString, value);
                contentService.modFolder = value;
            }
        }

        public string RootFolderString
        {
            get => middleContentModel._rootFolderString;
            set
            {
                Set(ref middleContentModel._rootFolderString, value);
                contentService.rootFolder = value;

            }
        }

        //-------------------------------------- Methods

        public void GetModFolder()
        {
            ModFolderString = contentService.GetFolderPath();
        }

        public void GetRootFolder()
        {
            RootFolderString = contentService.GetFolderPath();
        }

    }
}
