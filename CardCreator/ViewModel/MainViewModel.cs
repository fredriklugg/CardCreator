using CardCreator.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CardCreator.View;
using Microsoft.EntityFrameworkCore;

namespace CardCreator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ClickSave { get; private set; }
        public ICommand ClickUploadImg { get; private set; }
        public ICommand OpenNewTypeWindow { get; private set; }

        private CardData Model;

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

        public int MinAtk
        {
            get => Model.MinAtk;
            set => Model.MinAtk = value;
        }
        public int MaxAtk
        {
            get => Model.MaxAtk;
            set => Model.MaxAtk = value;
        }
        public int MinDef
        {
            get => Model.MinDef;
            set => Model.MinDef = value;
        }
        public int MaxDef
        {
            get => Model.MaxDef;
            set => Model.MaxDef = value;
        }
        public int MinCost
        {
            get => Model.MinCost;
            set => Model.MinCost = value;
        }
        public int MaxCost
        {
            get => Model.MaxCost;
            set => Model.MaxCost = value;
        }
        public string TypeName
        {
            get => Model.TypeName;
            set => Model.TypeName = value;
        }

         private string _SelectedType;
         public string SelectedType
        {
            get { return _SelectedType; }
            set
            {
                _SelectedType = value;
                UpdateTypeMinMax();
            }
        }


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
            
            //Console.WriteLine(ImageSource);
            using (var context = new CCContext())
            {
                var type = context.Types.First(t => t.Name == SelectedType);

                int typeId = type.TypeId;

                var cards = new Card
                    {
                        Name = Name,
                        Attack = Attack,
                        Defence = Defence,
                        Cost = Cost,
                        TypeId = type.TypeId,
                        Image = ImageSource
                    };
                    context.Cards.Add(cards);

                    context.SaveChanges();
                    Console.WriteLine("Added to database");

            }
            
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
        private void TypeListChange()
        {
            UpdateTypeMinMax();
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
        private void UpdateTypeMinMax()
        {
            using (var context = new CCContext())
            {
                var attributes = context.Types.Where(t => t.Name == SelectedType)
                    .Select(t => new
                    {
                        MaxAtk = t.Max_Attack,
                        MinAtk = t.Min_Attack,
                        MaxDef = t.Max_Defence,
                        MinDef = t.Min_Defence,
                        MaxCost = t.Max_Cost,
                        MinCost = t.Min_Cost
                    }).FirstOrDefault();

                if (attributes == null)
                {
                    return;
                }

                TypeName = SelectedType;
                MinAtk = attributes.MinAtk;
                MaxAtk = attributes.MaxAtk;
                MinDef = attributes.MinDef;
                MaxDef = attributes.MaxDef;
                MinCost = attributes.MinCost;
                MaxCost = attributes.MaxCost;

                RaisePropertyChanged("");

            }
        }

        public void UpdateMainWindow()
        {
            RaisePropertyChanged("");
        }
    }
}