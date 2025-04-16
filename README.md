# Vypex Coding Challenge - DONE 

## Problem Statement

HR require a portal to manage employees and their leave days. The portal should be able to display a list of employees, edit an employee's leave, add leave days, and show the total leave days taken by an employee on the employee list.

## Requirements

The portal requires the following features:

* Displays the list of employees. - DONE 
* Can add and remove leave days.  - NOT DONE
* Shows the total leave days taken by an employee on the employee list. - DONE
* Leave days must not overlap. - Implemented it Backend Service. 
* Leave days can be edited. - DONE
* Leave days have a start and end date. No need to track leave hours. Implemented it Backend Service. 
* Filter employees by name on the employee list. - DONE 

## What's provided

You're inheriting a partially completed project. The authors may or may not have been a bit sleepy after Thursday's steak special team lunch at the Carlton Brewhouse.

### Backend - DONE 

* Scaffolded ASP.NET Core 9 Web API with an endpoint that returns a mock list of employees.  - DONE
* Pre populated SQLite database that is currently NOT connected to the endpoint. - DONE
* Basic Employee model class with Id and Name properties registered in EF Core. 
* By default the service is available at https://localhost:7189
	* OpenAPI document https://localhost:7189/openapi/v1.json
	* API browser https://localhost:7189/scalar/v1
* `dotnet ef` tool has been installed as part of the project which can be run from the `Vypex.CodingChallenge.Service` folder.

### Frontend 

* Scaffolded Angular 19 frontend. - DONE
* An API service that communicates with the backend. - DONE 
* Front end with employees dashboard that lists employees. - DONE
* NgZorro/Ant Design for UI components. - DONE 

## What we want to see

We like to keep up with the latest and greatest from the Dotnet and Angular worlds so please use the latest technologies and best practices.
If there is anything in the scaffolded projects that you think could be done better please comment!

### Backend

* Connect the Employees endpoint to the "real" database. - DONE
* Add leave days to the employee model and database. - DONE 
* Implement the leave days api in the backend. - DONE 

### Frontend

#### Improve employees list component
* Add a refresh/reload button to refetch the list of employees. - DONE 
* Use new Angular 19 resources. - DONE 
* Handle potential API errors. - DONE
* Implement search by employee name functionality - DONE 
	* Minimise the number of requests to the API where possible - DONE 
* Feel free to change layout and structure of the page. 

#### Implement Edit employee functionality - PENDING 
* Use Angular forms and Ant Design components for user input. 
* Implement employee leave form control as a separate and re-usable component.  - DONE 
    * The user can dynamically add/modify multiple leave entries for an employee. - PENDING 
    * Leave days cannot overlap. - PEDING 
    * Both start and end date are required. - Implemented in BE Code 
    * Validate that `startDate` must be before `endDate`. -NOT DONE

#### Considerations
* Use [Ant Design](https://ng.ant.design/components/overview/en) UI library.  - DONE 
  * Feel free to add styles for any components you may use into */src/styles/antd.less* if they're not already included.
* Follow best coding practices and principles where you can. - DONE 
* Incorporate latest features from Angular including [Angular 19](https://angular.love/angular-19-whats-new) where possible. - YES DONE
	*  Standalone Components
 	*  Signals (Angular 16+) 
  	*  Routing with provideRouter : Configureed routes directly in main.ts with provideRouter.
  	*  Reactive Forms + Custom FormControl Integration
  	*  Subject + debounceTime for Search
  	*  Ant Design Components <nz-table>
   
* Feel free to add new dependencies if needed. - DONE 
* Unit tests are not required. 

## Out of scope

* Editing employee properties other than leave days. 
* Tests are not required.

## Tips

If you want to regenerate the SQLite db use the following command. The `--startup-project` and `--project` properties are important because of the project structure.
`dotnet ef database update --startup-project .\Vypex.CodingChallenge.Service\Vypex.CodingChallenge.Service.csproj --project .\Vypex.CodingChallenge.Infrastructure\Vypex.CodingChallenge.Infrastructure.csproj`

## Submission
Once you've completed the test, create a zip archive of your submission and send it to the recruiter.

Thank you and good luck!
