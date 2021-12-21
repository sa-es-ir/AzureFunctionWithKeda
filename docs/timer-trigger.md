## Timer Trigger Functions

The time-triggered Azure Function allows us to schedule time for executing the function. It means that it triggers the function on a specified time. It works as CRON expressions work. When creating a time-triggered function, we need to specify a time in CRON format that determines when the trigger will execute. The CRON expression consists of six parts - second, minute, hour, day, month, and day of the week in Azure Function and each part is separated by space.
Unlike HTTP-triggered Azure functions, timing info is stored in an Azure storage account so for any trigger functions you need to create an Azure storage account, for more information about creating Azure storage account see this [Link](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal)

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

## 4. Run function


```cli
func start
```

## Keda yaml file
for deploy keda on your kubernetes cluster the yaml file would be like this ([see complete file](../build/timer-trigger-deploy.yml)):
```cli
apiVersion: keda.sh/v1alpha1
kind: ScaledObject
metadata:
  name: timer-trigger-function-with-keda
  namespace: keda-namespace
spec:
  scaleTargetRef:
    name: timer-trigger-function-with-keda
  minReplicaCount: 0
  maxReplicaCount: 20
  triggers:
    - type: cron
      metadata:
        timezone: Asia/Tehran #Required
        start: 0 0 * * * #Required
        end: 59 23 * * * #Required
        desiredReplicas: "10" #Required
```
there are some important things in KEDA to be explain
- ``kind: ScaledObject`` tells kubernetes that this service is for keda and use for auto scalling
- ``scaleTargetRef`` consider that KEDA should trigger which service that run on kubernetes for detecting auto scalling when service was busy and needs more pods (in this case we first create deployment named ``timer-trigger-function-with-keda``)
- ``triggers`` consider type of scaled object, there several trigger types, for Timer Trigger function use **Cron**
- ``timezone`` One of the acceptable values from the IANA Time Zone Database. The list of timezones can be found [here](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones)
- ``start`` Cron expression indicating the start of the cron schedule.
- ``end`` Cron expression indicating the end of the cron schedule.
- ``desiredReplicas`` Number of replicas to which the resource has to be scaled between the start and end of the cron schedule.


Notice: Start and end should not be same.

For example, the following schedule is not valid:
```cli
start: 30 * * * *
end: 30 * * * *
```
Having all that configured we can now deploy the YAML file to AKS.
```bashe
kubectl apply -f .\timer-trigger-deploy.yml
```
To check if everything is working, check the deployment.
```bash
> kubectl get deploy
NAME                        READY   UP-TO-DATE   AVAILABLE   AGE
 timer-trigger-function-with-keda            0/0     0            0           20h

> kubectl get ScaledObject
NAME                       SCALETARGETKIND           SCALETARGETNAME             TRIGGERS      AUTHENTICATION   READY   ACTIVE      AGE
timer-trigger-function-with-keda   apps/v1.Deployment   timer-trigger-function-with-keda            cron                       True      False     20h
```
