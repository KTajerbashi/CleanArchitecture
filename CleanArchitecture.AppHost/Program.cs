var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArchitecture_EndPoint_WebApi>("cleanarchitecture-endpoint-webapi");

builder.Build().Run();
