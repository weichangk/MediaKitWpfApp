using MediaKitWpfApp.Common;
using MediaKitWpfApp.Models;
using MediaKitWpfApp.Repositores;
using MediaKitWpfApp.Util;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.ViewModels
{
    public class OutputFolderViewModel : BindableBase
    {
        private const string OutputFolder = "OutputFolder";


        private readonly VideoFuncEnum videoFunc;
        private readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;

        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }
        public DelegateCommand<string> SaveCurrentOutputFolderCommand { get; private set; }


        private string currentOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        public string CurrentOutputFolder
        {
            get { return currentOutputFolder; }
            set { currentOutputFolder = value; }
        }

        private ObservableCollection<string> outputFolderList = new();
        public ObservableCollection<string> OutputFolderList
        {
            get { return outputFolderList; }
            set { outputFolderList = value; }
        }


        public OutputFolderViewModel(VideoFuncEnum videoFunc, Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.videoFunc = videoFunc;
            this.sysParmBaseRepository = sysParmBaseRepository;

            currentOutputFolder = Path.Combine(currentOutputFolder, videoFunc.ToString());

            OpenOutputFolderCommand = new DelegateCommand<string>(OpenOutputFolder);
            SaveCurrentOutputFolderCommand = new DelegateCommand<string>(SaveCurrentOutputFolder);
            InitOutputFolderList();
        }


        private void OpenOutputFolder(string folder)
        {
            if (!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            System.Diagnostics.Process.Start("Explorer.exe", currentOutputFolder);
        }

        private void InitOutputFolderList()
        {
            if(!Directory.Exists(currentOutputFolder))
                Directory.CreateDirectory(currentOutputFolder);

            var taskResultModel = sysParmBaseRepository.Value.GetByKeyAndTypeAsync(OutputFolder, videoFunc.ToString());
            var resultModel = (ResultModel<SysParm>)taskResultModel.Result;
            if (resultModel != null && resultModel.Success && resultModel.Data != null)
            {
                currentOutputFolder = resultModel.Data.Value;
            }
            outputFolderList.Clear();
            outputFolderList.Add("与源文件夹相同");
            outputFolderList.Add(currentOutputFolder);
            outputFolderList.Add("...");
        }

        private void SaveCurrentOutputFolder(string newFolder)
        {
            var taskResultModel = sysParmBaseRepository.Value.InsertOrUpdateValueByKeyAndTypeAsync(OutputFolder, videoFunc.ToString(), newFolder);
            var resultModel = (ResultModel<SysParm>)taskResultModel.Result;
            if (resultModel != null && resultModel.Success)
            {
                currentOutputFolder = newFolder;
                outputFolderList[1] = newFolder;
            }
        }
    }
}
