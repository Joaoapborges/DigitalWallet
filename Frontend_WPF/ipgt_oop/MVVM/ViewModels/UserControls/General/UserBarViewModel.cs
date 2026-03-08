using ipgt_oop.Core;
using ipgt_oop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ipgt_oop.MVVM.ViewModels.UserControls.General
{
    public class UserBarViewModel : ObservableObject
    {
        private BitmapImage _myImage;

        public BitmapImage MyImage
        {
            get => _myImage;
            set => SetProperty(ref _myImage, value);
        }

        public UserBarViewModel()
        {
            MyImage = Base64ToBitmapImage.Base64Converter("");
        }
    }
}
