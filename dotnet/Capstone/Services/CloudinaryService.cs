using Microsoft.AspNetCore.Mvc;
using RestSharp;
using static System.Net.WebRequestMethods;
using Capstone.Models;

namespace Capstone.Services
{
    public class CloudinaryService: ICloudinaryService
    {
        private readonly string API_URL = "";
        private readonly RestClient client = new RestClient();

        //public CloudinaryFile GetCloudinaryFiles()
        //{
        //    RestRequest request = new RestRequest(API_URL + "");
        //    IRestResponse<CloudinaryFile> response = client.Get<CloudinaryFile>(request);

        //    return response.Data;
        //}
    }
}
