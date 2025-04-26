# Phonebook application

This is a phonebook application developed by using C#, Entity Framework & SQL Serve. The app consists of CRUD methods for Contacts, their Categories &  their Skills, as well as an Email & SMS service

## Requirements / Description
1) This application records contacts with their phone numbers and emails
2) Users should be able to Add, Delete, Update and Read from a database, using the console.
3) Entity Framework is to be used; Raw SQL is not allowed.
4) The application code should contain a base Contact class with **at least** {Id INT, Name STRING, Email STRING and Phone Number(STRING)}
5) E-mails and phone numbers should be validated and let the user know what formats are expected
6) The code should folow Code-First Approach, which means EF will create the database schema.
7) SQL Server should be used, not SQLite

## Challenges
1) Create a functionality that allows users to add the contact's e-mail address and send an e-mail message from the app.
2) Expand the app by creating categories of contacts (i.e. Family, Friends, Work, etc).
3) What if you want to send not only e-mails but SMS?

## Before using the application
* After cloning the application, update the connection string in appsettings.json to target your SQL Server
* There is some dummy data created everytime you run the app, feel free to use the add or update functionality to add your own data
* For the Email & SMS service, you will need to create your own secrets.json file and add your own credentials for the SMS and Email functionality
* For the SMS service, you will also have to verify your number on a Twilio Trial account, and also get a virtual Twilio number from which you will send SMS messages
* Your credentials should be entered in the following format in secrets.json:
``` {
  "Email": {
    "smtp_username": "your@email",
    "smtp_password": "yourAppPassword"
  },
 "Sms": {
    "from_phone_number": "virtualTwilioNumber",
    "account_sid": "yourAccountSID",
   "auth_token": "yourAuthorisationToken"
  } 
}
```

## General Info
1) Everytime the app starts, the database is deleted & re-created with dummy data
2) The application consists of menus presenting CRUD options for Contacts, Categories & Skills
3) Each contacts can belong to one category, a category can have many contacts. Each contact can have many skills, a skill can belong to many contacts.
4) There is also an option to send an email or an SMS message to a specific contact (Contact will have to have verified Twilio phone number)
