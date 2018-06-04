[![Build status](https://asadsahi.visualstudio.com/_apis/public/build/definitions/a1519ab8-9104-47eb-96cc-6c37519c8b69/7/badge)](https://asadsahi.visualstudio.com/playground/_build/index?context=allDefinitions&path=%5C&definitionId=7&_a=completed)
[![Join the chat at https://gitter.im/asadsahi-AspNetCoreSpa/Lobby](https://badges.gitter.im/asadsahi-AspNetCoreSpa/Lobby.svg)](https://gitter.im/asadsahi-AspNetCoreSpa/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![MIT license](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

## Features

* [ASP.NET Core](http://www.dot.net/)
* [Entity Framework Core](https://docs.efproject.net/en/latest/)
    * Both Sql Server and Sql lite databases are supported (Check installation instrcutions for more details)
 
## Pre-requisites

1. [.Net core sdk](https://www.microsoft.com/net/core#windows)
2. Either [VSCode](https://code.visualstudio.com/) with [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) extension OR [Visual studio 2017](https://www.visualstudio.com/)

**Make sure you have Node version >= latest LTS and NPM >= latest LTS

## Installation
```
1. Clone the repo
    git clone https://github.com/Liang-Zhinian/CqrsFrameworkDotNet.git
2. Change directory
    cd CqrsFrameworkDotNet
3. dotnet restore
4. Point to Sqllite or SqlServer
    
This project supports both sql server and sql lite databases

* Run with Sqlite:
    * Project is configured to run with sqlite by default and there is an 'Initial' migration already added (see Migrations folder)
    * After changing you models, you can add additional migrations 
    [see docs](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)

* Run with SqlServer:
    * To run under sql server:
        * npm run clean
        * Delete `Migrations` folder
        * Flip the switch in appsettings.json called `useSqLite` to `false`, this should point to use local sql server setup as default instance. (See appsettings.json file for connection string)
        * Run `dotnet ef migrations add "InitialMigrationName"`

```
