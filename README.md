<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better, please fork the repo and create a pull request or simply open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->





<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<h3 align="center" style="font-size:32;">Shakespeareanator API</h3>
<p align="center">  
  <a href="">
    <img src="https://pbs.twimg.com/media/CoO0NhpWYAENO99?format=jpg&name=900x900" alt="Logo" width="450" height="335">
  </a>
</p>

<p align="center" style="font-size:8;">
  source: https://twitter.com/_secondstory/status/757647310235004930
</p



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
  * [With Docker](#with-docker)
* [Usage](#usage)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

Does your kids love the wonderful Pokemon world? Does your beloved kiddywinks interpret Shakespeare's dramas every night before going to bed?

<i>Or haply ye art just looking for something to remove those folk from the television?</i>

HERE WE ARE: Shakespeareanator is an API project with the aim to provide a description of your favourite Pokemons in Shakespearean style.


### Built With


* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Docker](https://www.docker.com/)


<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

In order to run the application, please ensure to have installed on your machine the .NET Core 3.1 SDK package (https://dotnet.microsoft.com/download/dotnet-core/3.1).

### Installation

1. Clone the repo
```sh
git clone https://github.com/mbk2787/shakespeareanator.git
```
2. Locate src folder and publish the app
```sh
dotnet publish -c Release
```
3. Locate published app and run it
```sh
dotnet .\Shakespeareanator.Api.dll
```

### With Docker

Ensure to have installed Docker, you can download it here:
* Windows: 	https://docs.docker.com/docker-for-windows/install/
* Mac:		https://docs.docker.com/docker-for-mac/install/
* Linux:	https://docs.docker.com/engine/install/

1. Locate src folder and build the image
```sh
docker build -t shakespeareanator .
```
2. Run the image
```sh
docker run -d --name shakespeareanator_container shakespeareanator
```


<!-- USAGE EXAMPLES -->
## Usage

Get a Shakespearean description of your favourite Pokemon in this way:
```sh
/pokemon/<pokemon_name>
```

_For more examples, please visit the [demo site](https://shakespeareanator.herokuapp.com/pokemon/ditto)_.



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Marco Bernasconi - bernasconi.berna@gmail.com

Project Link: https://github.com/mbk2787/shakespeareanator
