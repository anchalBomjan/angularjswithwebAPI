
#Using  Angularjs 1.2 and .net web api 8  to perform simple crud Operation
#Database firstApproached 
#Scafoldding to model and ApplicationDbContext
Scaffold-DbContext "Server=DESKTOP-ANCHAL\SQLEXPRESS;Database=TodoList;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context ApplicationDbContext -Tables ToDos




# This example able to understand  the concept of route , scope, load the files after certain event

