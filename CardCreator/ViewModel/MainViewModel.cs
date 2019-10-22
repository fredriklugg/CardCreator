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
            Console.WriteLine(ImageSource);
            updateTypeMinMax();
            ClearFields();
            RaisePropertyChanged("");
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

        private void ClearFields()
        {
            Name = "";
            Attack = 0;
            Defence = 0;
            Cost = 0;
            SelectedType = null;
            Image = null;
            ImageSource = "";
        }
        private void updateTypeMinMax()
        {
            using (var context = new CCContext())
            {
                var maxAtk = (from t in context.Types
                    where t.Name == SelectedType
                    select t.Max_Attack);
                var minAtk = (from t in context.Types
                    where t.Name == SelectedType
                    select t.Min_Attack);

                Console.WriteLine(""+ maxAtk + " and " + minAtk);

            }
        }
    }
}