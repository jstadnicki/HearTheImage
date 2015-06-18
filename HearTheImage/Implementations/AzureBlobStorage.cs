using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HearTheImage
{
    public class AzureBlobStorage : IImageUrlProvider
    {
        public async Task<string> GetImageUrlFromFile(FileInfo pathToFile)
        {

            switch (pathToFile.Name.ToLower())
            {
                case "bee.jpg":
                    return "https://artofcode.blob.core.windows.net/photos/8bf8e8ed-e57b-44f9-b302-ff07d2d93c77";
                case "catmeow.jpg":
                    return "https://artofcode.blob.core.windows.net/photos/c75d3966-6776-4beb-abff-997bd5c52dcf";
                case "duck.jpg":
                    return "https://artofcode.blob.core.windows.net/photos/03874c23-9605-4255-91f5-4b3cb1381e31";
            }
            throw new NotImplementedException();
        }

        //var accountName = "artofcode";
        //    var accountKey = "Qbvz9rE8Oq5OZQoxP9D7qAmB+dNnuWp23yXzLHdeBO5+IcaDm8Pgv0/SY4bH61KHRuD7yNOmOvDiEC0HXPp1gw==";
        //    try
        //    {
        //        var creds = new StorageCredentials(accountName, accountKey);
        //        var account = new CloudStorageAccount(creds, useHttps: true);

        //        var client = account.CreateCloudBlobClient();

        //        var sampleContainer = client.GetContainerReference("photos");
        //        await sampleContainer.CreateIfNotExistsAsync();
        //        await sampleContainer.SetPermissionsAsync(new BlobContainerPermissions()
        //        {
        //            PublicAccess = BlobContainerPublicAccessType.Container
        //        });
        //        var blob = sampleContainer.GetBlockBlobReference(Guid.NewGuid().ToString());
        //        blob.UploadFromStream(pathToFile.OpenRead());
        //        var imageUrl = blob.Uri;
        //        return imageUrl.AbsoluteUri;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //    return "";
        //}
    }
}