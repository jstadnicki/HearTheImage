﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HearTheImage
{
    public class ImageAnalyzer : IImageAnalyzer
    {
        public async Task<Dictionary<string, List<string>>> GetWords(IEnumerable<string> images)
        {
            var results = new Dictionary<string, List<string>>();

            var d = new Dictionary<string, List<string>>();
            d["bee"] = new List<string> {"bee"};
            return d;
        }


    //foreach (var image in images)
    //        {
    //            //Debug.WriteLine(image);
    //            HttpClient httpclient = new HttpClient();
    //            var response = await
    //                httpclient.GetAsync(
    //                    string.Format("https://www.wolframcloud.com/objects/cf7f6caf-1294-4e45-b601-33b5faf1eac2?name={0}", image));
    //            response.EnsureSuccessStatusCode();
    //            var responseString =
    //                (await response.Content.ReadAsStringAsync());
    //            responseString = responseString.Replace("[\"Concept\",", "")
    //                .Replace("Entity", "")
    //                .Replace("\"]", "\"");
    //            responseString = "[" + responseString.Remove(0, 1);
    //            responseString = responseString.Remove(responseString.Length - 1, 1);
    //            responseString += "]";
    //            //Debug.WriteLine(responseString);
    //            var @object = JsonConvert.DeserializeObject<List<string>>(responseString);

    //            results.Add(image, @object);
    //            Debug.WriteLine(image);
    //        }
    //        return results;
    //    }
    }
}