# _Create API in ASP.NET Core_

#### By _**Tiffany Rodrigo**_

#### Create an API for a local animal shelter. The API will list the available cats and dogs at the shelter using C# ASP.Net Core MVC

## Technologies Used
* _C#_
* _.Net 5.0_
* _ASP.Net Core_
* _MySQL_
* _EntityFramework Core_
* _Swagger_
* _Swashbuckle_
* _Pagination_
* _API Versioning_




## Description

Create an API for a local animal shelter. The API will list the available cats and dogs at the shelter using C# ASP.Net Core MVC.




## Setup/Installation Requirements
* _Install the MySQL Community Server & MySQL Workbench_
* _Install .NET5_
* _Clone this repository to your desktop._
* _Import sql database :
* _Add a new file called appsettings.json in the AnimalShelter folder and store the following { "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[NAME-OF-THE-DATABASE-YOU-CREATED-ABOVE];uid=root;pwd=[YOUR-PASSWORD-HERE];" } }_
* _Create your own database by Navigating to the AnimalShelter directory in terminal run the following command:_
  * _Run "dotnet restore" in Terminal then hit enter_
  * _Run "dotnet build" to Terminal_
  * _Run "dotnet ef database update"_
  * _Run dotnet run_
  * _To use the API,visit http://localhost:5000/swagger in your browser or use http://localhost:5000/api/v1/animals in  Postman to access the endpoints listed below._

## Versioning
  * _There are two version of api v1 and v2_
  * _The api v1 has pagination  implemented_
  * _Go to postman and paste the follwing link  http://localhost:5000/api/v1/animals  which gives the paginated result of two records per page_
  * _Go to postman and paste the follwing link  http://localhost:5000/api/v2/animals  which gives all the records available_

## Swagger
* _visit http://localhost:5000/swagger in your browser_
* _Select v1 or v2 from the select a definition drop down_
* _Execute request_

## Pagination
* _Pagination is implemented for api version1.0_
* _Two records are displayed per page _
    * _To view a different page, add "?pagenumber=REQUESTED PAGE" to the end of the GET request:Example: http://localhost:5000/api/v1/animals?pagenumber=3_
    * _To view less than 2 records per page, add "?pagesize=NUMBER OF RECORDS" to the end of the GET request:http://localhost:5000/api/v1/animals?pagesize=1_
    * _These filters can be combined in the request using & Example : http://localhost:5000/api/v1/animals?pagenumber=3&pagesize=1_

 ## API EndPoints
 * _The base url is http://localhost:5000_

  ### GET :/api/v2/animals
    * _http://localhost:5000/api/v2/animals This link will display all the animals record_ 
    * _Add filter like species, gender, name, minimumAge using query string(?).Example http://localhost:5000/api/v2/animals?species=dog&gender=male_

  ### POST :/api/v2/animals
  * _To add  a new animal record to the database of the API we need post request
  * _Execute http://localhost:5000/api/v2/animals in postman with the following code in the body part_
      {
        "animalId": int,
        "name": string,
        "species": string,
        "age": int,
        "gender": string
    }
    * _Change the Values and execute in postman_
  ### GET :/api/v2/animals/{id}
  * _http://localhost:5000/api/v2/animals/4 will retrive the details of animal Id 4_
  ### PUT :/api/v2/animals/{id}
  * _To edit an animal record in database we need a put request_
  * _Execute http://localhost:5000/api/v2/animals/4 in postman along with the entire modified animal details in the body of the request._
  * _Example:_    
  {
        "animalId": int,
        "name": string,
        "species": string,
        "age": int,
        "gender": string
    }
  ### DELETE :/api/v2/animals/{id}
  * _To delete any record from database execute the delete request_
  * _Execute http://localhost:5000/api/v2/animals/4 to delete the animal record of id 4_




## License

_MIT_

Copyright (c) _April_ 4th 2022_ _Tiffany Rodrigo_




