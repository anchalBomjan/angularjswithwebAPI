CREATE TABLE ToDos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    IsEditing BIT DEFAULT 0,
    Done BIT DEFAULT 0
);


Database First Approached after that I just want to replicate this table into ApplicationDbContext  in Data folder  and Models through  scaffolding   so We just need packages
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
After that in nmp cmd:
Scaffold-DbContext "Server=DESKTOP-ANCHAL\SQLEXPRESS;Database=TodoList;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context ApplicationDbContext -Tables ToDos
