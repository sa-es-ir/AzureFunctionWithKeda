## Durable Functions

Durable Functions is an extension of Azure Functions that enables you to perform long-lasting, stateful operations in Azure. Azure provides the infrastructure for maintaining state information. You can use Durable Functions to orchestrate a long-running workflow. Using this approach, you get all the benefits of a serverless hosting model, while letting the Durable Functions framework take care of activity monitoring, synchronization, and runtime concerns.
===
## Tutorial

#### 1. Create a new directory for the function app

```cli
mkdir DurableFunction
cd DurableFunction
```

#### 2. Initialize the directory for functions

```cli
func init . --docker
```

Select **dotnet**

#### 3. Add a new durable function

```cli
func new
```

Select **DurableFunctionsOrchestration** then select a name for your function.
