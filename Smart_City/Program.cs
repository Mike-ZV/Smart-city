using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Police_Master;

namespace Smart_City
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyMaster am = new AssemblyMaster();

            #region CS
            am.CityServices_URL = @"SmartCity_Services.xml";

            CityService cs = new CityService();
            cs.Service_Code = 102;
            cs.Service_Name = "Police";

            am.Create_City_Service(cs);
            #endregion

            #region City
            am.Cities_URL = @"SmartCity_Cities.xml";

            City city = new City();
            city.City_Area = 300629;
            city.City_Population = 834813;
            city.City_Name = "Актобе";
            city.City_Services = new List<CityService>() { cs };

            am.Create_City(city);
            #endregion

            #region Region
            am.Regions_URL = @"SmartCity_Region.xml";

            Region region = new Region();
            region.Main_City = city;
            region.Population = 834813;
            region.Cities = null;
            region.Region_Name = "Актюбинская область";

            am.Create_Region(region);
            #endregion

            #region Police station
            Master_Police mp = new Master_Police();

            mp.Police_Station_URL = @"Police_Station.xml";
            Police_Station ps = new Police_Station();
            ps.Police_Station_Adress = "Тимирязева 31";
            ps.city = am.GetCity()[0];
            ps.Police_Station_ID = 001;
            ps.Police_Station_Name = "Тимимрязева";

            mp.Create_Police_Station(ps);
            #endregion

            #region
            #endregion
        }
    }
}
