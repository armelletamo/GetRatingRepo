using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class GetRating
    {
        [FunctionName("GetRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getRating/{ratingId}")] HttpRequest req,
            [CosmosDB(
                databaseName: "cosmoadminoh",
                collectionName: "ratings",
                ConnectionStringSetting = "CosmosDBConnectionString",
                Id = "{ratingId}")] RatingObject rating,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if(rating!=null){
                return new OkObjectResult(rating);
            }
            string responseMessage = "";

            return new OkObjectResult(responseMessage);
        }
    }

}
public class RatingObject{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime TimesTamp { get; set; }
    public string LocationName { get; set; }
    public int Rating { get; set; }
    public string UserNotes { get; set; }
}
