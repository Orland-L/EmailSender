# EmailSender
An email sender library with sample web app.


## Introduction
This is a C#/ASP.NET project for the Clarity Ventures' internal assignment. The Email Sender Library has the following features: 

- Code was written in C# with .NET 6 framework(requirement 1).
- The library EmailSenderAPI has a .dll and can be reused for any projects/entry points(requirement 2). 
- The class EmailSenderService allows emails to be sent synchrnously as well as asynchronously.
- Email sender, recipient, subject, body, date, send attempt and status are logged in console and stored in a file email_log.txt(requirement 3).
- Incase of a failure, the email will be retried for a max of 3 times after 5 seconds(requirement 4).
- The library uses SMTP, credentials are stored in appsettings.json and can be configured in the Web App(requirement 5).
- The Web App contains an API that can be called using REST clients such as Postman and Swagger(requirement 7, extra point).
- The Web App uses an ASP.NET MVC, and contains a front end UI that users can input fields 'recipient', 'subject' and 'body' to send emails using AJAX(requirement 8, extra point)


## API
The EmailSender API library contains the following 3 classes: 

- `EmailSenderAPI.EmailSenderService`: The service class that can send emails synchronously and asynchronously. The two methods `SendMail(string recipient, string subject, string body)` and `SendMailAsync(string recipient, string subject, string body)` can be called from the application code. 
- `EmailSenderAPI.EmailSenderCredential`: The configuration class that contains information for the SMTP server credentials. 
- `EmailSenderAPI.EmailSendException`: The exception class whose instance may be thrown upon failure of email send. The API will retry up to a total of 3 times(including the initial attempt) before throwing exception. It can be caught and handled by the client code. 


## Web App
The EmailSender Web application contains both an ASP.NET WEB API(REST) which can be called from postman/swagger/front-end, as well as an ASP.NET Web MVC sample front end which calls the API upon submitting the send email form. 

To send an email using postman, simply enter the route /api/email(ie. https://localhost:7190/api/email) with Post method. Then select Body and Form Data, and click the blue Send button to complete the request, as shown in the screenshot below:
![Send Email using Postman](https://i.imgur.com/iEciJDp.png)

To send an email using the ASP.NET Web front end, just start the application and go to the route /Home/Email(ie. https://localhost:7190/Home/Email), and fill out a simple send email form as shown below:
![Send Email using Front end](https://i.imgur.com/vzKF8oV.png)


## Build and Use

If you have visual studio with a microsoft windows operating system, it is possible to clone the project directly on Github with a web browser. Simply clicking the green Code button and select `Open with Visual Studio`. This will be able to pull the files automatically from Github, and create a solution based on the contents of the project. 

![Use Github and Visual Studio](https://i.imgur.com/jkHXdJf.png)


You may download the zip version of the files and uncompress the archive, or use the command command `gh repo clone Orland-L/EmailSender` to pull the repo into your local machine. At this point, just clicking on the 'Debug' button in visual studio for the Web project and you will be able to start the local web server. At this point, it is possible to run postman client or use the email send form directly on the browser to send emails. 

Alternatively, on non-windows based operating system it is possible to build and debug the project using Visual Studio Code with .NET Core SDK installed. I use windows operating system myself so I have not tested this myself, please let me know if there is any issue if you need to build the solution in unconventional ways. 

**Note**: In order to use/test the API and web application, it is necessary to specify the values `Host`, `Email` and `Password` fields in appsettings.json, section `EmailSettings`. Otherwise, the email server will fail authentication and emails will not be sent.  
