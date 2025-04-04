var builder = DistributedApplication.CreateBuilder(args);

var workerApi = builder.AddProject<Projects.Worker_API>("workerApi");

var workManagerApi = builder.AddProject<Projects.WorkManagement_API>("workerManagerApi");

var submissionPortal = builder.AddProject<Projects.WorkSubmitPage>("submissionPortal");

builder.Build().Run();
