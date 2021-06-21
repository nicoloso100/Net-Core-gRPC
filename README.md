
# Net-Core-gRPC
.Net Core API with gRPC

## How to run

You must perform the following steps to run the entire application

### Requirements

 - [ ] Docker
 - [ ] dotnet

### Steps

 1. Clone the project
 2. Create a development certificate (In case you do not have one in the route {HOME}/.aspnet/https/aspnetapp.pfx) with the following commands in **Poweshell**:

		dotnet dev-certs https --clean
		dotnet dev-certs https -v -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p test123
		dotnet dev-certs https --trust

> You can also use a custom https certificate, just copy the certificate under the folder {HOME}/.aspnet/https/ and change the variables ASPNETCORE_Kestrel__Certificates__Default__Password and ASPNETCORE_Kestrel__Certificates__Default__Path in the docker-compose.yml

		
 3. Navigate to the root folder of the project and excecute docker compose:

		cd Net-Core-gRPC
		docker-compose up

## How to use

Once the docker compose is running ypu can navigate to the following routes:

 -    [http://localhost:8081/](http://localhost:8081/)
Where you will be able to access the database if you want to see all the data created / updated / deleted from the App

 - [https://localhost:5000/](https://localhost:5000/)
 Where you will see a message to confirm if the API is running OK

 - [http://localhost:3001/](http://localhost:3001/)
 Where you will be able to acces to the Client for testing the API
