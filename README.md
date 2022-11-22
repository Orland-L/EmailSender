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
- The Web App contains an API that can be called using REST clients such as Postman and Swagge(requirement 7, extra point).
- The Web App uses an ASP.NET MVC, and contains a front end UI that users can input fields 'recipient', 'subject' and 'body' to send emails using AJAX(requirement 8, extra point)

## Downloads/Installation
Simply use Git clone or download the zip file from the master branch. The repo contains a solution file, you may simply open it with Visual Studio 2019/2022, and build the solution. Finally, you may debug the project EmailSenderWeb to see how the library/API work in action.