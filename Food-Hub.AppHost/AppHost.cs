var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Food_Hub>("food-hub");

builder.Build().Run();
