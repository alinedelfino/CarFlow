# CarFlow
Customer Satisfaction Survey, followed by partial sales flow, including:
* Form for customer (CRUD)
* Form for sales advisor (CRUD) + Statistics
* Form for Satisfaction survey
* Form for sales

Technologies:
* C# Asp.Net MVC

### Installing Instructions
* Install visual Studio 2017 Comunity Edition
* Install github [plugin](https://visualstudio.github.com/)
* Open the project from visual studio github plugin (Probably ask your user/pass)

#### Importing database
The whole process is described [here](https://msdn.microsoft.com/en-us/library/ms239722.aspx)
* View->Server Explorer->Data Connection->Add connection (Then choose Sql Server and point to the mdf file on the project folder)
* Click on the database and get it's connection string
* Update the file [appsettings.json](https://github.com/alinedelfino/CarFlow/blob/master/CarFlow/appsettings.json#L9) to include the new connection string

TODO:
* Add option to send email after each sale.
* Add graph from survey statistics.
* UML Description
