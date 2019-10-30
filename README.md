# EmployeeManagement
A sample  ASP.NET Core Mvc application that has:

Repository Pattern Mock Repository Implementation,  Sql Server Based Repository Implementation  using  Entity Framework Core

## Model Validation
Consider the following 

`   
 <input asp-for="Name" class="form-control" placeholder="Name"/>
`

The  Name property in the asp-for section represents the Name property in the Model object (Employee in this case). 
So in order to enable validation, all we need to do is add data annotations to the model as shown below:

`[Required(ErrorMessage = "Cannot skip Name")]`

`[MaxLength(20, ErrorMessage = "Not more than 20 chars")]`

`public string Name { get; set; }`

Note: Properties that are integer (Or numeric) are inherently required. 


###Adding EF Core  Migrations

`dotnet ef migrations add InitialModel`

To persist the changes 

`dotnet ef database update`
For seeding the DB , override OnModelCreate in AppDbContext and then initialize modelBuilder.Entity with necessary data objects

Add additional mgiration for seeding

`dotnet ef migrations add SeedEmployeesTable`

Update the db

`dotnet ef database update`

