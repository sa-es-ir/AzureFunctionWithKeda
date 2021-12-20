<img src="https://raw.githubusercontent.com/Azure/azure-functions-cli/master/src/Azure.Functions.Cli/npm/assets/azure-functions-logo-color-raster.png" width="150"><img src="https://keda.sh/img/logos/keda-icon-color.png" width="150">


# Azure Function samples With Keda
Azure Functions is a cloud service available on-demand that provides all the continually updated infrastructure and resources needed to run your applications. You focus on the pieces of code that matter most to you, and Functions handles the rest. Functions provides serverless compute for Azure. You can use Functions to build web APIs, respond to database changes, process IoT streams, manage message queues, and more.

In this project I try to solve some common issues on Azure Functions development and deployment using Kubernetes and Keda.


## Common issues
- Use appsetting.json
- Use Dependency injection
- Map request body in HttpTrigger and DurableFunction
- Create yml file for Keda based on azure function type