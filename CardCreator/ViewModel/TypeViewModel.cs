using System;
using System.Windows;
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
            typeData.createType("Orc", 2,6,3,7,2,8);
        }
    }
}