using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OrganizationAPI
{
    [Route("api/")]
    [ApiController]
    public class OrganizationController : Controller
    {
        // GET api/organizations
        [HttpGet("organizations")]
        public ActionResult<List<Organization>> GetList()
        {
            return OrganizationService.getOrgList();
        }

        // GET api/ein/123
        [HttpGet("ein/{EIN}")]
        public ActionResult<IEnumerable<Organization>> GetByEIN(string ein)
        {
            return OrganizationService.getOrgListByEin(ein);
        }

        // GET api/orgname/Blackbaud
        [HttpGet("orgname/{OrgName}")]
        public ActionResult<IEnumerable<Organization>> GetByOrgName(string orgName)
        {
            return OrganizationService.getOrgListByOrgName(orgName);
        }

    }
}