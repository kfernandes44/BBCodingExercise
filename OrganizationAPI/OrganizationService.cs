using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;

namespace OrganizationAPI
{
    public class OrganizationService
    {
        public static List<Organization> getOrgList(){
            String fileName = "f1023EZ_approvals_2018_april_june.xlsx";
            FileInfo file = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(file)) {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
//                int totalRows = workSheet.Dimension.Rows;
//                int totalColumns = workSheet.Dimension.Columns;

                // Means of searching for column headers 
                //foreach (var firstRowCell in workSheet.Cells[workSheet.Dimension.Start.Row, workSheet.Dimension.Start.Column, 1, workSheet.Dimension.End.Column]) {
                //    firstRowCell.Value.ToString;
                //}

                List<Organization> organizationList = new List<Organization>();

                for (int i = 2; i <= 100; i++) {
                    organizationList.Add(
                        new Organization (
                            workSheet.Cells[i,1].Value.ToString(),
                            workSheet.Cells[i,5].Value.ToString(),
                            workSheet.Cells[i,7].Value.ToString(),
                            workSheet.Cells[i,8].Value.ToString(),
                            workSheet.Cells[i,9].Value.ToString(),
                            workSheet.Cells[i,10].Value.ToString(),
                            workSheet.Cells[i,58].Value.ToString()
                        )
                    );
                }
                return organizationList;
            }
        }

        public static List<Organization> getOrgListByEin(string ein)
        {
            List<Organization> organizationList = getOrgList();
            IEnumerable<Organization> modifiedOrgList = new List<Organization>();
            
            modifiedOrgList = from o in organizationList  
                where o.EIN.Contains(ein) 
                select o;

            return modifiedOrgList.ToList();
        }
        
        public static List<Organization> getOrgListByOrgName(string orgName)
        {
            List<Organization> organizationList = getOrgList();
            IEnumerable<Organization> modifiedOrgList = new List<Organization>();
            
            modifiedOrgList = from o in organizationList  
                where o.OrgName1.Contains(orgName) 
                select o;

            return modifiedOrgList.ToList();
        }
        
        //        public static void Main(string[] args){
        //String dataURL = "https://www.irs.gov/pub/irs-tege/f1023EZ_approvals_2018_april_june.xls";
//            String fileName = "f1023EZ_approvals_2018_april_june.xlsx";
//            List<Organization> orgList = getOrgList();
//            foreach (Organization org in orgList)
//            {
//                Console.WriteLine("EIN: " + org.Ein +
//                                  " Name: " + org.OrgName2);
//                Console.WriteLine(" Address: " + org.Address1+", "+org.City1+", "+org.State1+" "+org.Zip1+
//                                  " Url: " + org.OrgUrl1);
//                Console.WriteLine("-----------------------------------------");
//            }
            
//            List<Organization> orgList = getOrgListByOrgName("GREENLEAF");
//            foreach (Organization org in orgList)
//            {
//                Console.WriteLine("EIN: " + org.EIN +
//                                  " Name: " + org.OrgName1);
//                Console.WriteLine(" Address: " + org.Address+", "+org.City+", "+org.State+" "+org.Zip+
//                                  " Url: " + org.OrgUrl);
//                Console.WriteLine("-----------------------------------------");
//            }
            
            
        //}
    }
}