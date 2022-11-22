# EmailSender
An email sender library with sample web app.


## Introduction
This is a C#/ASP.NET project for the Clarity Ventures' internal assignment. The Email Sender Library has the following features: 

- Code was written in C# with .NET 6 framework(requirement 1).
- The library EmailSenderAPI has a .dll and can be reused for any projects/entry points(requiurement 2). 
- The service EmailSenderService allows emails to be sent synchrnously as well as asynchronously.
- Email sender, recipient, subject, body, date, send attempt and status are logged in console and stored in a file email_log.txt(requirement 3).
- Incase of a failure, the email will be retried for a max of 3 times after 5 seconds(requirement 4).
- The library uses SMTP, credentials are stored in appsettingd.json and can be configured in the Web App(requirement 5).
- The Web App contains an API that can be called using REST clients such as Postman and Swagger(requirement 7, extra point).
- The Web App uses an ASP.NET MVC, and contains a front end UI that users can input fields 'recipient', 'subject' and 'body' to send emails using AJAX(requirement 8, extra point)


## API
The EmailSender API library contains the following 3 classes: 

- EmailSenderAPI.EmailSenderService: The service class that can send emails synchronously and asynchronously. The two methods `SendMail(string recipient, string subject, string body)` and `SendMailAsync(string recipient, string subject, string body)` can be called from the application code. 
- EmailSenderAPI.EmailSenderCredential: The configuration class that contains information for the SMTP server credentials. 
- EmailSenderAPI.EmailSendException: The exception class whose instance may be thrown upon failure of email send. The API will retry up to a total of 3 times(including the initial attempt) before throwing exception. It can be caught and handled by the client code. 


## Web App
The EmailSender Web application contains both an ASP.NET WEB API(REST) which can be called from postman/swagger/front-end, as well as an ASP.NET Web MVC sample front end which calls the API upon submitting the send email form. 

To send an email using postman, simply enter the route /api/email(ie. https://localhost:7190/api/email) with Post method. Then select Body and Form Data, and click the blue Send button to complete the request, as shown in the screenshot below:
![Send Email using Postman](https://i.imgur.com/iEciJDp.png)

To send an email using the ASP.NET Web front end, just start the application and go to the route /Home/Email(ie. https://localhost:7190/Home/Email), and fill out a simple send email form as shown below:
![Send Email using Front end](https://i.imgur.com/vzKF8oV.png)

**Note**: In order to use/test the API and web application, it is necessary to specify the values `Host`, `Email` and `Password` fields in appsettings.json, section `EmailSettings`. Otherwise, the email server will fail authentication and emails will not be sent.  


## Downloads/Installation
Simply use Git clone or download the zip file from the master branch. The repo contains a solution file, you may simply open it with Visual Studio 2019/2022, and build the solution. Finally, you may debug the project EmailSenderWeb to see how the library/API work in action.
