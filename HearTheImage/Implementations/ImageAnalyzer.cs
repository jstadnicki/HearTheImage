using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            images.ToList().ForEach(image => results.Add(image, GetImageInWord(image)));
            return results;
        }

        private List<string> GetImageInWord(string url)
        {
            switch (url)
            {
                case "https://artofcode.blob.core.windows.net/photos/8bf8e8ed-e57b-44f9-b302-ff07d2d93c77":
                    return new List<string> {"Bee"};
                case "https://artofcode.blob.core.windows.net/photos/c75d3966-6776-4beb-abff-997bd5c52dcf":
                    return new List<string> { "TrueCat" };
                case "https://artofcode.blob.core.windows.net/photos/f088cb5b-b322-47a0-a2a6-d7bc1b3f7ec1":
                    return new List<string> {  "Bird" };
                case "https://artofcode.blob.core.windows.net/photos/03874c23-9605-4255-91f5-4b3cb1381e31":
                    return new List<string> { "Duck" };
            }
            throw new KeyNotFoundException();
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