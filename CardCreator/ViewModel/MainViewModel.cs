using CardCreator.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Annotations;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CardCreator.View;

namespace CardCreator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ClickSave { get; private set; }
        public ICommand ClickCancel { get; private set; }
        public ICommand ClickUploadImg { get; private set; }
        public ICommand OpenNewTypeWindow { get; private set; }

        public String Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }
        public string[] AllTypes
        {
            get => Model.AllTypes;
            set => Model.AllTypes = value;
        }
        public String SelectedType { get; set; }

        public int Attack
        {
            get => Model.Attack;
            set => Model.Attack = value;
        }

        public int Defence
        {
            get => Model.Defence;
            set => Model.Defence = value;
        }

        public int Cost
        {
            get => Model.Cost;
            set => Model.Cost = value;
        }
        public BitmapImage Image
        {
            get => Model.Image;
            set => Model.Image = value;
        }

        public string ImageSource
        {
            get => Model.ImageSource;
            set => Model.ImageSource = value;
        }

        private CardData Model;

        public MainViewModel()
        {
            Model = new CardData();
            ClickSave = new RelayCommand(ClickSaveMethod, CanExecuteSaveButton);
            ClickUploadImg = new RelayCommand(ClickUploadMethod, CanExecuteUploadButton);
            OpenNewTypeWindow = new RelayCommand(ClickOpenTypeMethod, CanExecuteOpenTypeButton);

        }

        private bool CanExecuteOpenTypeButton()
        {
            return true;
        }

        private void ClickOpenTypeMethod()
        {
            MainWindow.ShowTypeWindow();
        }

        private void ClickSaveMethod()
        {
            //var context = new CCContext();
            //var type= context.Types.Find(1);
            //Model.createCard("Drogon", 5,5,4, context.Types.Find(1), "aaaa");
            Console.WriteLine(ImageSource);
        }

        private bool CanExecuteSaveButton()
        {
            return true;
        }


        private void ClickUploadMethod()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(op.FileName));
                ImageSource = op.FileName;
            }
            RaisePropertyChanged("Image");
        }

        private bool CanExecuteUploadButton()
        {
            return true;
        }
    }
}