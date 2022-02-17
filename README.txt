1. 
	- I spent an hour and half to set up the api as well as the unit tests.
	- I have never worked with Angular and haven't done much UI in the last few years so it took me a while to figure out how to do the UI.
	  Initially I set up a basic MVC app to serve as UI and created all the logic in backend. Then I started reading up about basics of angular, 
	  and did a course on plurasight to set up an angular project. By following the tutorial in the course, I managed to create an angular project 
	  for UI and moved all the sorting and filtering logic in there instead of backend.
	  
2. 
	- I used visual studio 2019 both for API and angular.
	- I used Newtonsoft.Json nuget packages to deserialize josn to object
	- Swashbuckle.AspNetCore niget package for swagger
	- I used Resharper throughout development
	
3. 
	- I only have experience with azure. I would deploy the front end code to a blob storage and the .net core API to APIM (API Management)
	- Create a new azure app service
	- Publish the api to app service
	- In order to add the api to APIM: 
		- Go to APIM (API Management) and select APIs blade
		- Add new API and set up settings like display name, name, url and app service url
	- We can either keep the app setting configurations in code and publish from vidual studio or keep them on azure app service configurations
	- I signed up for a personal azure account and deployed the API and UI on azure.
	- Please navigate to https://deloittestoragesandra.z16.web.core.windows.net/
	
4. 
	THere are varios ways to protect data. Here are some:
	- Authentication: 
		THis is to verify the identity of the user or program that sent the request.
		APIs authenticate with a password, multi-factor authentication, or an authentication token, 
		which serves as a unique id. To authenticate a request with a token, an API matches the token 
		sent in the request with one stored in its data store. 
		
	- Authorization:
		This is to API grant access to only the authorized end points and methods
		
	- Validating incoming requests:
		This is to check even an authorised request is harmful or not. 
		THis can prevent an authenticated user submitting a harmful a script via a request
		
	- Encrypting all requests and responses. We should also encrypt sensetive data in data store too
	- API should only provide the necessary information only and avoid oversharing data
	- Put a limit to number of api calls coming from a user over a span of time
	- Log API activity
	- Perform regular security checks
	- Write automated tests to validate all the above points
	
5. 
	- First thing I would check is CPU and memory usage
	- Use logging which enables it to figure out the problmatic areas in wither code, database or environment;
	- Run a database trace for a day and in trace log look for the ones that have long duration value
	- Recently we developed a simple application for users to purchase some customised reports. As part of load testing, we figures 
		out the application slowed down when 50 users tried purchasing at the same time.
	- Looking at code, we decided to cahe some of the information that rarely change. There was a problem with the way database 
	transaction was set up. Also some sql scripts were improved. 
