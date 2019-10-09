using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CardCreator.Model;
using Microsoft.Win32;

namespace CardCreator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ClickSave { get; private set; }
        public ICommand ClickCancel { get; private set; }
        public ICommand ClickUploadImg { get; private set; }

        public String Name
        {
            get => Model.Name;
            set => Model.Name = value;
        }
        public string[] AllTypes {
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
        


        private CardData Model;
        public MainViewModel()
        {
            Model = new CardData();
            ClickSave = new RelayCommand(ClickSaveMethod, CanExecuteSaveButton);
            ClickUploadImg = new RelayCommand(ClickUploadMethod, CanExecuteUploadButton);
        }

        private void ClickSaveMethod()
        {
            
        }

        private bool CanExecuteSaveButton()
        {
            return true;
        }
        private void ClickCancelMethod()
        {

        }

        private bool CanExecuteCancelButton()
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
            }
            RaisePropertyChanged("Image");
        }

        private bool CanExecuteUploadButton()
        {
            return true;
        }
    }
}