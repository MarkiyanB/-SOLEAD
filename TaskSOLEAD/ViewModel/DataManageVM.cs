using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using TaskSOLEAD.Migrations;
using TaskSOLEAD.Model;
using TaskSOLEAD.Model.Data;

namespace TaskSOLEAD.ViewModel
{
    class DataManageVM : INotifyPropertyChanged
    {
        
        public List<string> allCompany = RebuildingMainForm.AllCompany;
        
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged("SearchCompany"); }
        }
        public string NameCompany { get; set; }
        public string AddressCompany { get; set; }
        public string FoundationYearCompany { get; set; }
        public string RevenueCompany { get; set; }
        public string BusinessTypeCompany { get; set; }



        private RelayCommand addNewCompany;
        private RelayCommand searchcompany;
        public RelayCommand AddNewCompany
        {
            get
            {
                return addNewCompany ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (NameCompany == null || NameCompany.Replace(" ", "").Length == 0)
                    {
                        Console.WriteLine("-");
                    }
                    else
                    {
                        resultStr = RebuildingMainForm.CreateCompany(NameCompany, AddressCompany, FoundationYearCompany, RevenueCompany, BusinessTypeCompany);
                        
                    }
                }
                );
            }
        }

        //Searching
        public IEnumerable<string> SearchCompany
        {
            get
            {
                if (SearchText == null)
                {
                    return null; 
                }
                else if (SearchText == "")
                {
                    return null;
                }
                else 
                {
                    return allCompany.Where(x => x.ToUpper().StartsWith(SearchText.ToUpper()));
                }               
            }
        }





        public string selectedItem;
        public string SelectedItem 
        {
            get
            { 
                return this.selectedItem;
                
            }
        
            set
            {
                if (value != this.selectedItem)
                {
                    this.selectedItem = value;
                    IEnumerable myCompany = RebuildingMainForm.MyCompany(selectedItem);
                    

                }
            }
        }



        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
