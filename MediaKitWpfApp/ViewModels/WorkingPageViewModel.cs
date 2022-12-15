﻿using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkingPageViewModel : BindableBase, INavigationAware
    {
        private readonly IEventAggregator ea;

        private VideoFuncEnum videoFunc;

        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private ObservableCollection<WorkingItemViewModel> workingItems = new();

        public ObservableCollection<WorkingItemViewModel> WorkingItems
        {
            get { return workingItems; }
            set { workingItems = value; RaisePropertyChanged(); }
        }

        public WorkingPageViewModel(IEventAggregator _ea)
        {
            ea = _ea;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var func = navigationContext.Parameters["func"];
            if (func != null)
                videoFunc = Enum.Parse<VideoFuncEnum>(func.ToString());
            switch (videoFunc)
            {
                case VideoFuncEnum.VideoConverter:
                    break;
                case VideoFuncEnum.VideoCompress:
                    break;
                default:
                    break;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
