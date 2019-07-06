#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1803 AS base

WORKDIR /app

EXPOSE 80

COPY ./publish .

ENTRYPOINT ["dotnet", "ContanerizedVisits.dll"]