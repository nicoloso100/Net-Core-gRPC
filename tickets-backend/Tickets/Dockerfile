#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS=https://+:443
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["tickets-backend/Tickets/Tickets.csproj", "."]
COPY ["tickets-backend/TicketsServices/TicketsServices.csproj", "../TicketsServices/"]
COPY ["tickets-backend/TicketsDomain/TicketsDomain.csproj", "../TicketsDomain/"]
COPY ["tickets-backend/TicketsRepository/TicketsRepository.csproj", "../TicketsRepository/"]
COPY ["tickets-backend/TicketsDTOs/TicketsDTOs.csproj", "../TicketsDTOs/"]
RUN dotnet restore "./Tickets.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "tickets-backend/Tickets/Tickets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tickets-backend/Tickets/Tickets.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tickets.dll"]