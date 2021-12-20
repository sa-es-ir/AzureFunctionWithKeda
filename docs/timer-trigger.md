## Timer Trigger Functions

The time-triggered Azure Function allows us to schedule time for executing the function. It means that it triggers the function on a specified time. It works as CRON expressions work. When creating a time-triggered function, we need to specify a time in CRON format that determines when the trigger will execute. The CRON expression consists of six parts - second, minute, hour, day, month, and day of the week in Azure Function and each part is separated by space.
Unlike HTTP-triggered Azure functions, timing info is stored in an Azure storage account so for any trigger functions you need to create an Azure storage account, for more information about creating Azure storage account see this [Link](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal)
===
## Tutorial

#### 1. Create a new directory for the function app

```cli
mkdir TimerTrigger
cd TimerTrigger
```

#### 2. Initialize the directory for functions

```cli
func init . --docker
```

Select **dotnet**

#### 3. Add a new timer trigger function

```cli
func new
```

Select **TimerTrigger** then select a name for your function.
