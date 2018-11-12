using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using KBVB.AR.Data;
using KBVB.AR.Models;
using KBVB.AR.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KBVB.AR.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {

        private readonly INavigationServiceWithInit _navigationService;
        public ICommand ShareCommand { get; set; }
        private ObservableCollection<Picture> _myPictures;
        public ObservableCollection<Picture> MyPictures
        {
            get => _myPictures;
            set => Set(() => MyPictures, ref _myPictures, value);
        }

        private Picture _mySelectedPicture;
        public Picture MySelectedPicture
        {
            get => _mySelectedPicture;
            set
            {
                _mySelectedPicture = value;
                SharingEnabled = (value!=null);
            }
        }

        private int _index;

        public int Index
        {
            get => _index;
           
            set
            {
                Set(() => Index, ref _index, value);
                MySelectedPicture = MyPictures[_index];
            }
            
            
        }

        private bool _sharingEnabled;
        public bool SharingEnabled
        {
            get => _sharingEnabled;
            set => Set(() => SharingEnabled, ref _sharingEnabled, value);
        }

        public GalleryViewModel(INavigationServiceWithInit navigationService)
        {
            _navigationService = navigationService;
            ShareCommand = new RelayCommand(ShareImage);

            MyPictures = new ObservableCollection<Picture>(MockDataBuilder.GetFakePictures());
           
            Index = 0;
        }

        private void ShareImage()
        {
            DependencyService.Get<IShareService>().Share("testsubject", "testmessage", MySelectedPicture.ImageUrl);
        }
    }
}
