<img src="https://raw.githubusercontent.com/Azure/azure-functions-cli/master/src/Azure.Functions.Cli/npm/assets/azure-functions-logo-color-raster.png" width="150" height="150"><img src="https://keda.sh/img/logos/keda-icon-color.png" width="150" height="150">

|Platform|Version|
|---|---|
|TargetFramework| **net6.0** |
|AzureFunctions| **v4** |
|Keda| **2.0** |

# Azure Function samples with Keda
**Azure Functions** is a cloud service available on-demand that provides all the continually updated infrastructure and resources needed to run your applications. You focus on the pieces of code that matter most to you, and Functions handles the rest. Functions provides serverless compute for Azure. You can use Functions to build web APIs, respond to database changes, process IoT streams, manage message queues, and more.

**KEDA** is a Kubernetes-based Event Driven Autoscaler. With KEDA, you can drive the scaling of any container in Kubernetes based on the number of events needing to be processed.

In this project I try to solve some common issues on Azure Functions development and deployment using Kubernetes and Keda.

## Common issues
- **Use appsetting.json**
- **Use Dependency injection in startup**
- **Map request body in HttpTrigger and DurableFunction**
- **Create yml file for Keda based on azure function type**

## Pre-requisites

* [Azure Function Core Tools v4](https://github.com/azure/azure-functions-core-tools#installing).
* An Azure Subscription (to host the storage queue).  A free account works great - [https://azure.com/free](http://azure.com/free)
* Kubernetes cluster (can be [AKS](https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough-portal), GKE, EKS, OpenShift etc.) and [`kubectl`](https://kubernetes.io/docs/tasks/tools/install-kubectl/) pointing to your Kubernetes cluster (for [AKS](https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough#connect-to-the-cluster)).
* Docker and a Docker registry
## Install KEDA

[Follow the instructions](https://keda.sh/docs/2.0/deploy/) to deploy KEDA in your cluster.

To confirm that KEDA has successfully installed you can run the following command and should see the following CRD.

```cli
kubectl get customresourcedefinition
NAME                     AGE
scaledobjects.keda.sh    2h
scaledjobs.keda.sh       2h
```
## Azure Functions guidelines
- **[Durable Fucntion](azure-functions-docs.md)**
- **[Timer Trigger](azure-functions-docs.md)**
- **[Queue Trigger](azure-functions-docs.md)**

## ToDos
* ***Add other Azure function types***
* ***Add Unit test***