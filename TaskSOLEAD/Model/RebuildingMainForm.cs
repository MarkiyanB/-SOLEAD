using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using TaskSOLEAD.Model.Data;
using TaskSOLEAD.ViewModel;

namespace TaskSOLEAD.Model
{
    static class RebuildingMainForm
    {
        //Add new company
        static public string CreateCompany(string name, string address, string foundationyear, string revenue, string businesstype)
        {
            string result = "This company already has";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool chekIsExist = db.Companies.Any(el => el.Name == name);
                if (!chekIsExist)
                {
                    Company newCompany = new Company
                    {
                        Name = name,
                        Address = address,
                        FoundationYear = foundationyear,
                        Revenue = revenue,
                        BusinessType = businesstype
                    };
                    db.Companies.Add(newCompany);
                    db.SaveChanges();
                    result = "Add new Company";
                }
                return result;
            }
        }


        //START Searching company

        //DO list with all company
        public static List<string> AllCompany
        {
            get
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var result = db.Companies
                                  .Select(c => c.Name)
                                  .ToList();
                    return result;
                }
                
            }
        }


        //END Searching company      

        public static IEnumerable MyCompany(string selectedItem)
        {
                using (ApplicationContext db = new ApplicationContext())
                {
                        var result = from b in db.Companies
                                     where b.Name == selectedItem
                                     select new
                                     {
                                         b.Name,
                                         b.Address,
                                         b.FoundationYear,
                                         b.BusinessType,
                                         b.Revenue
                                     };
                        var temp = result.ToList();
                        return temp;
                }   
        }
            
            
        

        







        //Delete Conpany if she will be found
        //public static string DeleteCompany(Company company)
        //{
        //    string result = "";
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        //check position is exist
        //        db.Companies.Remove(company);
        //        db.SaveChanges();
        //        result = ";
        //    }
        //    return result;
        //}
        //
        //
        //public static string EditCompany(Company oldCompany, string newName, string newAddress, string newFoundationyear, string newRevenue, string newBusinesstype)
        //{
        //    string result = "";
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        Company company = db.Companies.FirstOrDefault(p => p.Id == oldCompany.Id);
        //        company.Name = newName;
        //        company.Address = newAddress;
        //        company.FoundationYear = newFoundationyear;
        //        company.Revenue = newRevenue;
        //        company.BusinessType = newBusinesstype;
        //        db.SaveChanges();
        //        result = "";
        //    }
        //    return result;
        //}
        //



    }
}
