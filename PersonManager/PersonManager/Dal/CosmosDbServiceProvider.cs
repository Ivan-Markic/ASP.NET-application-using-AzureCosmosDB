using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    public class CosmosDbServiceProvider
    {
        private const string Account = "https://pppkperson.documents.azure.com:443/";
        private const string Key = "WYBSUVPoaa9bP4lKNiluDQTRJBvPrW8Nnpu7KGouwMIcl9PgBee9X16gJ1yxsPVBFt6EjMJFWewFVrodaekLsA==";
        private const string ContainerName = "People";
        private const string DatabaseName = "People";

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}