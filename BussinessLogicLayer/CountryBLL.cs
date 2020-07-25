using BussinesObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
   public class CountryBLL
    {
        public static IEnumerable<Country> GetAllCountry()
        {
            return CountryDAL.GetAllCountry();
        }
    }
}
