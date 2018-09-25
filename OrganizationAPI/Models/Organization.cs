namespace OrganizationAPI
{
    public class Organization
    {
        public string EIN;
        public string OrgName1;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string OrgUrl;

        public Organization(string ein, string orgName1, string address, string city, string state, string zip, string orgUrl)
        {
            EIN = ein;
            OrgName1 = orgName1;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            OrgUrl = orgUrl;
        }
        
    }
}