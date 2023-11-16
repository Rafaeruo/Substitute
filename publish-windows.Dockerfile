FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build

# Install Visual Studio Build Tools
RUN curl -SL --output vs_buildtools.exe https://aka.ms/vs/17/release/vs_buildtools.exe
RUN vs_buildtools.exe --installPath C:\BuildTools --add Microsoft.VisualStudio.Component.VC.Tools.x86.x64 Microsoft.VisualStudio.Component.Windows10SDK.19041 --quiet --wait --norestart --nocache

WORKDIR /source

COPY . .
RUN dotnet publish -o /publish Substitute.Console/Substitute.Console.csproj

FROM mcr.microsoft.com/windows/nanoserver:ltsc2022-amd64
WORKDIR /publish
COPY --from=build /publish .

# Usage:

# - Build the image:
# docker build -f publish-windows.Dockerfile . -t substitute-publish-windows:latest

# - Create a container based on that image (there is no need to run it):
# docker create --name substitute-publish-windows substitute-publish-windows

# - Copy the publish output files from the container over to the host:
# docker cp substitute-publish-windows:/publish ./publish