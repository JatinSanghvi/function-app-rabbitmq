## Test Instructions

1. Run RabbitMQ Docker container.
    ```ps
    > docker run -d --hostname my-rabbit --name some-rabbit --publish 5672:5672 --publish 15672:15672 rabbitmq:3-management
    2bc6ede97651021fda6bc797b79b90114acf07400afa0f4111b1486e1179290e
    ```
    - Reference: https://hub.docker.com/_/rabbitmq/

2. Check RabbitMQ logs (optional).
    ```ps
    > docker logs some-rabbit
    ```

3. Login to http://localhost:15672. with `guest/guest` as username/password.

4. Open page http://localhost:15672/#/queues and add queues `inputQueue` and `outputQueue`. Use default options.

5. Start this Function App locally.
    ```ps
    > func start
    ```

6. Open page http://localhost:15672/#/queues/%2F/inputQueue and publish message `World` to queue.

7. Verify that the event shows up in the Function App logs.
    ```log
    [2022-01-28T11:13:24.838Z] Executing 'RabbitMqExample' (Reason='RabbitMQ message detected from queue: inputQueue at 2022-01-28 16:43:24', Id=de09cdcf-4c14-4fba-9cfa-fb0c6f6316df)
    [2022-01-28T11:13:24.850Z] Message received: World.
    [2022-01-28T11:13:24.875Z] Executed 'RabbitMqExample' (Succeeded, Id=de09cdcf-4c14-4fba-9cfa-fb0c6f6316df, Duration=73ms)
    ```

8. Open page http://localhost:15672/#/queues/%2F/outputQueue and use get message option. The payload should be `Hello, World.`.

9. Remove the Docker container using ID from step 1, else use `docker ps --all` command to get container ID again.
    ```ps
    docker rm --force 2bc6ede97651
    ```
