Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## How to test the projects

The frontend relies on React framework to render the simple html page. The backend depends 
on C# to run the API server.

To quickly test, open a console in both project to run the server.

For frontend, run `npm start`. For backend, run `dotnet run --launch-profile https` at corresponding
project folder. The API server has set CORS so the frontend could fecth API via axios easily.

The web page runs the web app in the development mode.
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

## SPEC and tools
It is designed with input X = (0, 100], Y = (0, 10000] for the APIs.

It also applies package `Open.Numeric.Primes` for generating prime numbers, and it applies `BigInterger` 
to generate Fibonacci sequence for the number data type will be incorrect beyond 78th Fibonacci number. 
The random characters are in pseudo-random with a seed, so for the same seed, it always give the same 
outcomes. The characters will be A-z, a-z, and 0-9.

## Structure and relevant

There are four parts of the page. The header, simply hint the purpose of the page. The instruction,
describes how to use the page. The inputs, using two text box for sending inputs to API server to get
the returned result. The result, show the calculated result from API server and render it.

Regarding the background, I'd like to keep it plain so it could focus on the instructions and have a
little play with the features.

When the button is triggered, it would ask data from API server, and the API server is run on specific
port, so the link is fixed for requesting.

This assessment is developed under macOS with Visual Studio Code, however, it doesn't use launch.json
to run neither servers.

## Files

### Frontend
src\App.css saves several styling for the components.
src\App.js runs the main logic of the web page.
src\ButtonComponent.js has a component for creating button.
src\README.md describes how the assessment works and some of the details to be examined.

### Backend
Program.cs sets CORS policy and runs the main logic of the server.
utils.cs implements the APIs.
Controllers\EndpointsController.cs responds the API calls.

## References
[API call at frontend](https://builtin.com/software-engineering-perspectives/react-api), this is for frontend call API from backend server, it has to address 
CORS issue. However, applying axios would resolve the issue without configure too much 
parameters comparing to use fetch().

[How to Consume REST APIs in React](https://www.freecodecamp.org/news/how-to-consume-rest-apis-in-react/) 

[Fetch API Data on Button Click in React](https://dev.to/wanguiwaweru/fetch-api-data-on-button-click-in-react-513i) 

[Controller action return types in ASP.NET Core web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-9.0)