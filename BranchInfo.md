Master Branch
Contains the latest stable code.



Base Structure Branch For Representing C->S->R action

Does not handle exceptions, just a simple structure to represent the action.

Controller handles the Http reqet and response.
Service handles the business logic.
Repository handles the data access.


Extensions.ServiceCollectionExtensions deals with the DI container and registers the services.
Helpers.HttpContextHelper provides a common to create http response.