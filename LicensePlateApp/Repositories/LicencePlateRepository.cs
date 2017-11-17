using LicensePlateApp.Entities;
using LicensePlateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensePlateApp.Repositories
{
    public class LicencePlateRepository
    {
        const string POLICEPLATESTART = "RB";
        const string DIPLOMATPLATESTART = "DT";
        LicencePlateContext LicencePlateContext;
        public LicencePlateRepository(LicencePlateContext licencePlateContext)
        {
            LicencePlateContext = licencePlateContext;
        }

        public List<LicencePlate> GetAllLicencePlates()
        {
            return LicencePlateContext.LicencePlates.Select(x => x).ToList();
        }

        public List<LicencePlate> GetQuery(string licenceplate)
        {
            return LicencePlateContext.LicencePlates.Where(x => x.Plate.Contains(licenceplate) == true).ToList();
        }

        public List<LicencePlate> GetAllFromSpecifiedBrand(string brand)
        {
            return LicencePlateContext.LicencePlates.Where(x => x.CarBrand == brand).ToList();
        }

        public List<LicencePlate> GetQuertWithSpecial(string licenceplate)
        {
            return LicencePlateContext.LicencePlates.Where(x =>
                                                            x.Plate.Contains(licenceplate) == true
                                                            && (x.Plate.Substring(0,2) == DIPLOMATPLATESTART || x.Plate.Substring(0,2) == POLICEPLATESTART))
                                                            .ToList();
        }
    }
}
