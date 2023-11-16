FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install NativeAOT build prerequisites
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
       clang zlib1g-dev

WORKDIR /source

COPY . .
RUN dotnet publish -o /publish Substitute.Console/Substitute.Console.csproj

FROM alpine:latest
WORKDIR /publish
COPY --from=build /publish .

# Usage:

# - Build the image:
# docker build -f publish-linux.Dockerfile . -t substitute-publish-linux:latest

# - Create a container based on that image (there is no need to run it):
# docker create --name substitute-publish-linux substitute-publish-linux

# - Copy the publish output files from the container over to the host:
# docker cp substitute-publish-linux:/publish ./publish