using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNaverMovieFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientID = "cbEDW0kI1eKUmmsjYA2L";
            string clientSecret = "OgeWmN8qSi";
            string search = "starwars"; // 변경 가능
            string openApiUrl = $"https://openapi.naver.com/v1/search/movie?query={search}"; // query 까지 적어야함 

            var responseJson = GetOpenApiResult(openApiUrl, clientID, clientSecret);

            JObject parsedJson = JObject.Parse(responseJson);
            
            int total = Convert.ToInt32(parsedJson["total"]);
            Console.WriteLine($"총 검색 결과 :{total}");

            int display = Convert.ToInt32(parsedJson["display"]);
            Console.WriteLine($"총 검색 결과 :{display}");

            JToken items = parsedJson["items"];

            JArray json_array = (JArray)items;

            foreach (var item in json_array)
            {
                Console.WriteLine($"{item["title"]} / {item["image"]} / {item["subtitle"]} / {item["actor"]}");
            }


        }

        private static string GetOpenApiResult(string openApiUrl, string clientID, string clientSecret)
        {
            var result = "";

            try
            {
                WebRequest request = WebRequest.Create(openApiUrl);
                request.Headers.Add("X-Naver-Client-Id", clientID);
                request.Headers.Add("X-Naver-Client-Secret", clientSecret);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                result = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외발생 : {ex}");
            }

            return result;
        }
    }
}
