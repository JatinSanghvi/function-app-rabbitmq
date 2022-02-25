## Prerequisites

Although, the versions listed below are not strict requirements, if in case a particular command fails at your end, just make sure that your tool's version is not far off.

```console
> docker --version
Docker version 20.10.12, build e91ed57

> dotnet --version
6.0.101

> func version
4.0.3971
```

## Test Instructions

1. Run RabbitMQ Docker container (Reference: https://www.rabbitmq.com/download.html).

    ```console
    > docker run --interactive --tty --rm --name rabbitmq --publish 5672:5672 --publish 15672:15672 rabbitmq:3-management
    ```

2. Login to http://localhost:15672. with `guest/guest` as username/password. Open page http://localhost:15672/#/queues. Add queues `inputQueue` and `outputQueue`. Use default options.

3. In another console, start this Function App locally.

    ```console
    > func start
    ```

4. Open page http://localhost:15672/#/queues/%2F/inputQueue and publish message `World` to queue.

5. Verify that the event shows up in the Function App logs.

    ```log
    [2022-01-28T11:13:24.838Z] Executing 'RabbitMqExample' (Reason='RabbitMQ message detected from queue: inputQueue at 2022-01-28 16:43:24', Id=de09cdcf-4c14-4fba-9cfa-fb0c6f6316df)
    [2022-01-28T11:13:24.850Z] Message received: World.
    [2022-01-28T11:13:24.875Z] Executed 'RabbitMqExample' (Succeeded, Id=de09cdcf-4c14-4fba-9cfa-fb0c6f6316df, Duration=73ms)
    ```

6. Open page http://localhost:15672/#/queues/%2F/outputQueue and get the message from queue. The payload should be `Hello, World.`.

7. Stop the function app and stop/remove the Docker container by pressing `Ctrl+C` in both console windows.
