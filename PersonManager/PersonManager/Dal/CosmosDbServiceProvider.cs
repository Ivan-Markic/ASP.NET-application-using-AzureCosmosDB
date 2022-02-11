using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    public class CosmosDbServiceProvider
    {
        private const string Account = "azureAccount";
        private const string Key = "Key";
        private const string ContainerName = "ContainerName";
        private const string DatabaseName = "DBName";

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
