# Absa Assessment
Hi

I have created an Angular Application as the front end with an Asp.net Core 3.1 Backend 
I have tried to implement good practice with regard to the architecture albeit my naming convention leaves a little to be desired, I have used a sqlite database that is embedded in the project, 
I have used the following patterns and Technologies:
*	Dependency Injection
*	Inversion of Control
*	Repository Pattern
*	Web API
*	Angular 

 Due to Circumstance and Time Constraints I was unable to do the following:
1.	There is no business Logic or validations
2.	I was unable to get this working on Docker 
3.	I did not complete unit tests for all the layers of the application 
4.	I did not get a chance to remove all the auto generated “fluff” in the projects and there may be some redundant commented code.
I may have over complicated the problem and I did hit a few issues with some technologies that i am not 100% familiar with (unfortunately I spend way more time than I should have trying to figure these out). I had to cease development on this as my other projects needed some attention.

Things I would have changed:
* I would have created a straight forward WebAPI app and a separate Angular App, 
* I would have liked to add the Jasmine test cases on the UI and Nunit Test for the backend, 
* I would have also liked to add the Edit and delete features to the app. 
* Also would have liked to get this working in docker.

To see the app working:
1.	Git Clone https://github.com/pauldc4/AbsaAssessment.git
2.	Open solution in Visual studio (preferably 2019) and Run (the project will take a few minutes to compile the first time as it has to downloading all its dependencies)

*if visual studio becomes unresponsive please shut down visual studio and run a manual npm install on AbsaAssessment\TelephoneDirectory\ClientApp, then open  Visual Studio again 
and run.*

#### Prerequisites
* GIT (latest version) 
* Node.js (latest version) 
* NPM (latest version)
* NuGET (latest version)
* Visual Studio 2019 with Asp.Net and Web development tools installed 
* Dot Net Core 3.1

**Please view the video on the basic usage BasicUsage.mp4**
