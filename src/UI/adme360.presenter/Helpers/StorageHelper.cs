using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace dl.wm.presenter.Helpers
{
    public static class StorageHelper
    {

        public static async Task<List<string>> GetThumbNailUrls(AzureStorageConfig storageConfig, string imageName)
        {
            List<string> thumbnailUrls = new List<string>();

            // Create storagecredentials object by reading the values from the configuration (appsettings.json)
            StorageCredentials storageCredentials = new StorageCredentials(storageConfig.AccountName, storageConfig.AccountKey);

            // Create cloudstorage account by passing the storagecredentials
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the container
            CloudBlobContainer container = blobClient.GetContainerReference(storageConfig.ImageContainer);

            BlobContinuationToken continuationToken = null;

            BlobResultSegment resultSegment = null;

            //Call ListBlobsSegmentedAsync and enumerate the result segment returned, while the continuation token is non-null.
            //When the continuation token is null, the last page has been returned and execution can exit the loop.
            do
            {
                //This overload allows control of the page size. You can return all remaining results by passing null for the maxResults parameter,
                //or by calling a different overload.
                resultSegment = await container
                    .ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 10, continuationToken, null, null)
                    ;

                //var segments = ((IEnumerable<CloudBlockBlob>) resultSegment.Results).Where(x => x.Name == imageName);

                foreach (var listBlobItem in resultSegment.Results)
                {
                    var blobItem = (CloudBlockBlob) listBlobItem;
                    if(blobItem.Name == imageName)
                        thumbnailUrls.Add(blobItem.StorageUri.PrimaryUri.ToString());
                }

                //Get the continuation token.
                continuationToken = resultSegment.ContinuationToken;
            }

            while (continuationToken != null);

            return await Task.FromResult(thumbnailUrls);
        }
    }
}
