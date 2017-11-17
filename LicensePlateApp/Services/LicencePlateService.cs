using LicensePlateApp.Models;
using LicensePlateApp.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LicensePlateApp.Services
{
    public class LicencePlateService
    {
        const string POLICEPLATESTART = "RB";
        const string DIPLOMATPLATESTART = "DT";
        const int MAXLICENCEPLATELENGTH = 7;
        LicencePlateRepository LicencePlateRepository;
        public LicencePlateService(LicencePlateRepository licencePlateRepository)
        {
            LicencePlateRepository = licencePlateRepository;
        }

        public List<LicencePlate> GetAllLicencePlates()
        {
            return LicencePlateRepository.GetAllLicencePlates();
        }

        public List<LicencePlate> CheckInputPlate(string licenceplate)
        {
            if (CheckInputPlateLength(licenceplate) && CheckInputPlateAlphabetical(licenceplate))
            {
                return CheckIfInputPlateSpecial(licenceplate);                
            }
            throw new Exception("Sorry, the submitted licence plate is not valid");
        }

        private bool CheckInputPlateAlphabetical(string licenceplate)
        {
            return Regex.IsMatch(licenceplate, @"^[a-zA-Z0-9-]*$");
        }

        private bool CheckInputPlateLength(string licenceplate)
        {
            return (licenceplate != null && licenceplate.Length <= MAXLICENCEPLATELENGTH);
        }

        public List<LicencePlate> GetAllFromeSpecifiedBrand(string brand)
        {
            return LicencePlateRepository.GetAllFromSpecifiedBrand(brand);
        }

        public List<LicencePlate> GetAllLicenceFromSpecifiedBrandJson(string brand)
        {
            return (GetAllFromeSpecifiedBrand(brand));
        }

        public List<LicencePlate> CheckIfInputPlateSpecial(string licenceplate)
        {
            if (licenceplate.Contains(POLICEPLATESTART) || licenceplate.Contains(DIPLOMATPLATESTART))
            {
                return LicencePlateRepository.GetQuertWithSpecial(licenceplate);
            }
            return LicencePlateRepository.GetQuery(licenceplate);
        }
    }
}
