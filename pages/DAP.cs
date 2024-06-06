using log4net;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class DAP
    {

        public static async Task<List<Tuple<string, string, string>>> DapScheduleAsync(string DAPFlightTEST, string date)
        {
            ILog log = LogManager.GetLogger(typeof(DAP));

            //Building the quey for API
            var query = new Dictionary<string, string>()
            {
                ["fromDate"] = date,
                ["toDate"] = date,
               // ["operatingAirlineCode"] = airline
            };
            var uriprodenv = QueryHelpers.AddQueryString(DAPFlightTEST, query);
            log.Info("API uri is : " + uriprodenv.ToString());


            //Calling the API and capturing the response
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "806724f3e8ac4cd695eed69e1005073c");
            HttpResponseMessage response = await client.GetAsync(uriprodenv);
            var fltLegsDAP = new List<Tuple<string, string, string>>();
            fltLegsDAP.Add(Tuple.Create("flt", "orig", "dest"));
            if (response.IsSuccessStatusCode)
            {
                log.Info("DAP API call Response : " + response.StatusCode);
                string content = await response.Content.ReadAsStringAsync();
                var jsonres = JsonConvert.DeserializeObject<dynamic>(content);
                int legCount = jsonres["flights"].Count;

                //Adding flight legs to a list of tuples
                for (int i = 0; i < legCount; i++)
                {
                    int legsTotal = jsonres["flights"][i]["flightDetails"]["flightLegs"].Count;
                    for (int j = 0; j < legsTotal; j++)
                    {
                        string fltDepartTime = jsonres["flights"][i]["flightDetails"]["flightLegs"][j]["scheduledDateTimeUTC"]["out"];
                        DateTime givenDateTime = DateTime.Parse(fltDepartTime,null,System.Globalization.DateTimeStyles.RoundtripKind);
                        DateTime givenDate = givenDateTime.Date;
                        TimeSpan givenTime = givenDateTime.TimeOfDay;
                        DateTime currentDateTime = DateTime.UtcNow;
                        DateTime currentDate = currentDateTime.Date;
                        TimeSpan currentTime = currentDateTime.TimeOfDay;
                        if(givenDate==currentDate)
                        {
                            TimeSpan timeDiff = givenTime - currentTime;
                            if(timeDiff.TotalHours>=2)
                            {
                                string flt = jsonres["flights"][i]["flightDetails"]["operatingFlightNumber"];                                
                               // string legNum = jsonres["flights"][i]["flightDetails"]["flightLegs"][j]["legNumber"];
                                string orig = jsonres["flights"][i]["flightDetails"]["flightLegs"][j]["scheduledDepartureStation"]["airportCode"];
                                string dest = jsonres["flights"][i]["flightDetails"]["flightLegs"][j]["scheduledArrivalStation"]["airportCode"];

                                var tup = Tuple.Create(flt, orig, dest);
                                fltLegsDAP.Add(tup);
                            }
                        }                        
                    }
                }
                log.Info("Flight legs in DAP schedule : " + (fltLegsDAP.Count - 1));
            }
            else
            {
                log.Error("DAP API Error: " + response.StatusCode);
            }

            return fltLegsDAP;
        }

    }
}
