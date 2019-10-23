# CrashBucketing :card_index_dividers:
This project aims to provide the ability to group application errors together into buckets for ease of processing.

## Tech Stack

This app is built on [.Net Core](https://dotnet.microsoft.com/download) 3.0 Web API and [Angular 8](https://angular.io/).

## Docker Quick Start :whale:

* Ensure you have [Docker](https://www.docker.com/) installed on your local environment.
* Run **docker build -t crashbuckets:v1.0 .**
* Run **docker run --name crshbuckets -p 5000:80 -d crashbuckets:v1.0**
* Navagate to https://localhost:5000 and the app will load.

## Running the App locally

* Prerequisits:
    1. Download [.Net Core SDK 3.0](https://dotnet.microsoft.com/download)
    2. Download [Node](https://nodejs.org/en/download/) v10.16.3 or higher

* Ensure you have an environment variable called ASPNETCORE_Environment with a value of Development. On Windows (in non-PowerShell prompts), run SET ASPNETCORE_Environment=Development. On Linux or macOS, run export ASPNETCORE_Environment=Development.

* Navigate to the CrashBucketing directory (CrashBucking/CrashBucketing) and run the following commands:
    1. **dotnet build** - to verify the app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.
    2. **dotnet run**
    3. Go to you browser **https://localhost:5001**


## Running nUnit Tests :white_check_mark:

* All unit tests have been written in nUnit 3. They cover the basic functionality of the API. Additional work needs be done here.

    1. Navigate to the home directory (CrashBuckets)
    2. Run **dotnet test**.




