var builder = DistributedApplication.CreateBuilder(args);

var messageQ = builder.AddRabbitMQ("mq");

var workerApi = builder.AddProject<Projects.Worker_API>("workerApi")
    .WithReference(messageQ);

var workerManagerApi = builder.AddProject<Projects.WorkManagement_API>("workerManagerApi")
    .WithReference(workerApi)
    .WithReference(messageQ);

var submissionPortal = builder.AddProject<Projects.WorkSubmitPage>("submissionPortal")
    .WithReference(workerManagerApi)
    .WithExternalHttpEndpoints();

builder.Build().Run();
