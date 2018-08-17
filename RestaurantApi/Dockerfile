












FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/RestaurantApi.dll"]

# Build runtime image
# FROM microsoft/dotnet:sdk
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "testnewproject.dll"]