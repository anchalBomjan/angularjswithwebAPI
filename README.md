#Scafoldding to model and ApplicationDbContext
Scaffold-DbContext "Server=DESKTOP-ANCHAL\SQLEXPRESS;Database=TodoList;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context ApplicationDbContext -Tables ToDos
