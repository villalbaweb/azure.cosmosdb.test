using MongoDB.Driver;

var client = new MongoClient("mongodb://cosmosdb-mongodb-test-acc:h2qZfO1HPsu3JFgwGGzjGi46Z2WaBLtreMFUdfOKvNijr4iXzK0XBfydQH6f2IZmCvqEL3UZ9V5KACDbBI0OEA==@cosmosdb-mongodb-test-acc.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@cosmosdb-mongodb-test-acc@");
var db = client.GetDatabase("adventure");
var _products = db.GetCollection<Product>("products");



// Create new object and upsert (create or replace) to container
_products.InsertOne(new Product(
    Guid.NewGuid().ToString(),
    "gear-surf-surfboards",
    "Yamba Surfboard", 
    12, 
    false
));


// Read multiple items from container
_products.InsertOne(new Product(
    Guid.NewGuid().ToString(),
    "gear-surf-surfboards",
    "Sand Surfboard",
    4,
    false
));

var products = _products.AsQueryable().Where(p => p.Category == "gear-surf-surfboards");

Console.WriteLine("Multiple products:");
foreach (var prod in products)
{
    Console.WriteLine(prod.Name);
}

public record Product(
    string Id,
    string Category,
    string Name,
    int Quantity,
    bool Sale
);