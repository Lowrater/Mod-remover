using GalaSoft.MvvmLight;
using GTAModChanger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAModChanger.ViewModels
{
   public class ProgressBarViewModel : ViewModelBase
    {
        //-- Models
        private ProgressBarModel progressBarModel = new ProgressBarModel();

        //-- Intefaces
        //-- Commands
        //-- constructor
        public ProgressBarViewModel()
        {
            //-- Accepts the number sent from BottomContentViewModel to update the UI interface progressBar in the bottom.
            MessengerInstance.Register<int>(this, (progressValueNumber) =>
            {
                progressValue = progressValueNumber;
            });
        }

        //-- Properties
        public int progressValue
        {
            get => progressBarModel._progressValue;
            set
            {
                Set(ref progressBarModel._progressValue, value);
            }
        }

        //-- Methods

 
    }
}
