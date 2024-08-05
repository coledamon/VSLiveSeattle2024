var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("pg")
                //.PublishAsAzurePostgresFlexibleServer() //needed for azure hosting with azure database hosting
                .WithPgAdmin()
                .AddDatabase("db");

//bicep things
//var bicep = builder.AddBicepTemplate("bicep",
//    """
//    param x string

//    output y string = X
//    """).WithParameter("x", "1");


//azure blobs
//var blobs = builder.AddAzureStorage("storage")
//                    .RunAsEmulator()
//                    .AddBlobs("blobs");

var be = builder.AddProject<Projects.WebApplication1>("backend");

builder.AddProject<Projects.WebApplication20>("api")
    //.WithExternalHttpEndpoints() //needed for azure
    .WithReference(db)
    .WithReference(be)
    //.WithEnvironment("X", bicep.GetOutput("y")) //bicep stuff
    //.WithReference(blobs) //azure hosting blobs
    ;
builder.Build().Run();
