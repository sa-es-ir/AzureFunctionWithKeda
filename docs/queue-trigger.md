## Queue Trigger Functions

A queue-triggered function executes code when a new message comes into a queue, a data structure from which you can retrieve items in the order they came in (we call this ordering principle FIFO: first in, first out)
===
## Tutorial

#### 1. Create a new directory for the function app

```cli
mkdir QueueTrigger
cd QueueTrigger
```

#### 2. Initialize the directory for functions

```cli
func init . --docker
```

Select **dotnet**

#### 3. Add a new queue trigger function

```cli
func new
```

Select **QueueTrigger** then select a name for your function.
