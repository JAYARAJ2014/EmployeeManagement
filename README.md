# EmployeeManagement
A sample project to learn ASP.NET Core Mvc from ground up

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
