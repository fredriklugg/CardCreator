using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CardCreator.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CardCreator.ViewModel
{
    public partial class TypeViewModel : ViewModelBase
    {
        public ICommand ClickCancel { get; set; }
        public ICommand ClickSave { get; set; }

        private TypeData typeData;

        public String Name
        {
            get => typeData.Name;
            set => typeData.Name = value;
        }
        public int MinAttack
        {
            get => typeData.MinAttack;
            set => typeData.MinAttack = value;
        }
        public int MaxAttack
        {
            get => typeData.MaxAttack;
            set => typeData.MaxAttack = value;
        }

        public int MinDefence
        {
            get => typeData.MinDefence;
            set => typeData.MinDefence = value;
        }

        public int MaxDefence
        {
            get => typeData.MaxDefence;
            set => typeData.MaxDefence = value;
        }

        public int MinCost
        {
            get => typeData.MinCost;
            set => typeData.MinCost = value;
        }
        public int MaxCost
        {
            get => typeData.MaxCost;
            set => typeData.MaxCost = value;
        }

        public TypeViewModel()
        {
            typeData  = new TypeData();
            
            ClickSave = new RelayCommand(ClickSaveMethod, CanExecuteSaveButton);
            ClickCancel = new RelayCommand(ClickCancelMethod, CanExecuteCancelButton);
        }

        private bool CanExecuteCancelButton()
        {
            return true;
        }

        private void ClickCancelMethod()
        {
            Console.WriteLine("Close Window");
        }

        private bool CanExecuteSaveButton()
        {
            return true;
        }

        private void ClickSaveMethod()
        {
            typeData.createType(Name, MinAttack,MaxAttack,MinDefence,MaxDefence,MinCost,MaxCost);

            ClearFields();

        }

        private void ClearFields()
        {
            Name = "";
            MinAttack = 0;
            MaxAttack = 0;
            MinDefence = 0;
            MaxDefence = 0;
            MinCost = 0;
            MaxCost = 0;

            RaisePropertyChanged("");
        }
    }
}