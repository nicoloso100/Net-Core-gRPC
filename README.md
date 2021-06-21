
# Net-Core-gRPC
.Net Core API with gRPC

## How to run

You must perform the following steps to run the entire application

### Requirements

 - [x] Docker >= 20.10.5
 - [x] dotnet >= 5.0.203
 - [ ] Nodejs>= 14.15.3 (Only for alternative steps)

### Steps

 1. Clone the project
 2. Create a [development certificate](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide#with-powershell) (In case you do not have one in the route ${HOME}/.aspnet/https/aspnetapp.pfx) with the following commands in **Poweshell**:

		dotnet dev-certs https --clean
		dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p test123
		dotnet dev-certs https --trust

		
 3. Navigate to the root folder of the project and excecute docker compose:

		cd Net-Core-gRPC
		docker-compose up

### Alternative Steps

If you don't meet the requeriments you can also run the app with the following steps:

 1. Navigate to the tickets-backend folder, then run the app with dotnet CLI:

		cd Net-Core-gRPC/tickets-backend
		dotnet run --project Tickets

Now the API is running on [https://localhost:5000/](https://localhost:5000/), to confirm you can navigate to the URL and you will see a message saying that everything is working

 2. Then, navigate to the client folder, install all the packages and run the client

		cd ../tickets-client
		npm install
		npm start
Now you can start the client on [http://localhost:3000/](http://localhost:3000/)

For this alternative steps you will be using a MongoDB instance hosted in [MongoDB Atlas](https://www.mongodb.com/cloud/atlas)		

## How to use

Once the docker compose is running you can navigate to the following routes:

 -    [http://localhost:8081/](http://localhost:8081/) (**does not apply for alternative steps**)
Where you will be able to access the database if you want to see all the data created / updated / deleted from the App

 - [https://localhost:5000/](https://localhost:5000/)
 Where you will see a message to confirm if the API is running OK

 - [http://localhost:3000/](http://localhost:3000/)
 Where you will be able to acces to the Client for testing the API

## Architecture

the architecture of the app was based on the [Onion Architecture](https://www.codeguru.com/csharp/csharp/cs_misc/designtechniques/understanding-onion-architecture.html#:~:text=Onion%20Architecture%20is%20based%20on,on%20the%20actual%20domain%20models.), implementing the API, Domain, DTOs, Repository, Services an Unit Tests layers.

I also covered basics of [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design) and [Test Driven Development](https://en.wikipedia.org/wiki/Test-driven_development).

![architecture](https://i.imgur.com/UGR1DzP.png)

## Git
For Git, the master, develop and features branches were used, maintaining a workflow based on GitFlow.

![Git flow](https://i.imgur.com/cGmVvGW.png)

