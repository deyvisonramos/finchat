# FINCHAT!

This is a simple test application which implements a chat with SignalR and it has a bot attached to it communicating to the chat using RabbitMQ.

# Stack
	- asp.net core 3.1
	- dotnet core 3.1
	- entity framework core
	- asp.net identity core
	- asp.net signalR
	- docker and docker-compose

## How to use

### Docker
Start by making sure that you have the following ports free on your machine: **5000, 5001, 15672, 5672**

The way to run is using the docker-compose files inside the folder named "docker". There are two files there, one name **finchat_dependencies.yml** and another one **finchat_production.yml**.

- The  **finchat_dependencies.yml** needs to be executed first and it is used to create the containers for Sql Server and RabbitMQ. Just go ahead and run **docker-compose -f ./finchat_dependencies.yml up -d**
	> This command creates the docker container for RabbitMQ and Sql Server well and it tries to create the database used by the application, but it is a work in progress and it is not stable. So after the containers creation, connect to the Sql Server to check if the database has been created and if not, you can do that manually by using the script **create-database-script.sql** inside the sql folder, in the project root. It's possible to do the same using a Entity Framework migration, check it [here](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) .
	> It is also good to chechk if is everything ok with RabbitMQ (http://localhost:15672).

### Development

- To run the application in debug, you'll need to provide to the web application (FinChat.Chat.Web) connection to a Sql Server database and to RabbitMQ, both of them you'll find in the file **appsettings.Development.json**, inside the project. Reminding that you can use the **create-database-script.sql** script to create the database or run an Entity Framework migration, just need to point to the data project (FinChat.Chat.Data).
- You'll need to provide the connection settings to the bot project's (FinChat.ChatBots.StockQuotation) **appsettings.Development.json** too.
- With everything setup with just need to start the (FinChat.Chat.Web) project and then the bot (FinChat.ChatBots.StockQuotation), necessarily in that order.

That's all!
