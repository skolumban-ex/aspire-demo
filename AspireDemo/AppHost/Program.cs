var builder = DistributedApplication.CreateBuilder(args);

var workerApi = builder.AddProject<Projects.Worker_API>("workerApi");

var workerManagerApi = builder.AddProject<Projects.WorkManagement_API>("workerManagerApi")
    .WithReference(workerApi);

var submissionPortal = builder.AddProject<Projects.WorkSubmitPage>("submissionPortal")
    .WithReference(workerManagerApi)
    .WithExternalHttpEndpoints();

builder.Build().Run();
