# RabbitMQ

This project is a example of producing and consuming events on RabbitMQ. This project also include two separate dockerize solutions in .Net Core 3.1.

## Installation

Docker Desktop is required to use Dockerize solutions. Also If you are using Docker, there is no necessary to install rabbitmq on your local system.

* Download [Docker Desktop](https://www.docker.com/products/docker-desktop).

## Usage
First in terminal just go to docker-compose.yml file path and write this code below.

```bash
$ docker-compose up --build -d
```
Then three container will create on Docker.
* Consumer
* Producer
* RabbitMQ
