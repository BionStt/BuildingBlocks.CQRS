# BuildingBlocks.CQRS

[![NuGet](https://img.shields.io/nuget/dt/BuildingBlocks.CQRS.svg)](https://www.nuget.org/packages/BuildingBlocks.CQRS) 
[![NuGet](https://img.shields.io/nuget/vpre/BuildingBlocks.CQRS.svg)](https://www.nuget.org/packages/BuildingBlocks.CQRS)

BuildingBlocks.CQRS is an abstraction to ease implementing CQRS using MediatR and FluentValidation, performing both handling and validations by following simple conventions.

<h3>Implementing Commands and CommandHandlers</h3>

<h4>Command</h4>

```c#
public class RegisterCustomerCommand : Command<Guid>
{
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string Name { get; protected set; }

    public RegisterCustomerCommand(string email, string name, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
```

Notice that Command can expect a T of struct that will match to the CommandHandler result: 

<h4>CommandHandler</h4>

```c#
public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand, Guid>
{   
    public override async Task<Guid> ExecuteCommand(RegisterCustomerCommand command, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Guid.NewGuid());
    }
}
```

<br><b>The TStruct can be omitted though in case don't want to return an Id from the CommandHandler:</b>

```c#
public class RegisterCustomerCommand : Command
{
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string Name { get; protected set; }

    public RegisterCustomerCommand(string email, string name, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
```

```c#
public class RegisterCustomerCommandHandler : CommandHandler<RegisterCustomerCommand>
{   
    public override async Task ExecuteCommand(RegisterCustomerCommand command, CancellationToken cancellationToken)
    {
        await Task.FromResult(new CommandHandlerResult(command));
    }
}
```
<hr>
<h3>Implementing Queries and QueryHandlers</h3>

<h4>Query<T></h4>

```c#
public class GetOrdersQuery : Query<List<OrderDetailsViewModel>>
{
    public Guid CustomerId { get; set; }

    public GetOrdersQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
```

Different from Commands, the Query class is not restricted to return struct types only.

<h4>QueryHandler<T></h4>

```c#
public class GetOrdersQueryHandler : QueryHandler<GetOrdersQuery, List<OrderDetailsViewModel>>
{
    public override async Task<List<OrderDetailsViewModel>> ExecuteQuery(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<OrderDetailsViewModel>());
    }
}
```


<h4>Command and Query Validation</h4>

To perform validations with Commands and Queries, BuildingBlocks.CQRS was designed to use <a href="https://fluentvalidation.net">FluentValidation</a>. Althought validating them is optional, it is highly recommended and, can be easily implemented by creating a Validator class where it's an AbstractValidator<TCommand>. That said, all you have to do is to override the Validate method in your Command/Query as shown bellow.

```c#
 public override ValidationResult Validate()
 {
    return new RegisterCustomerCommandValidator().Validate(this);
 }
```

Once you have this method overriden, both <b>QueryHandler</b> and <b>CommandHandler</b> will check the validation result and then return <b>QueryHandlerResult</b> and <b>CommandHandlerResult</b> respectively.
These objects carry a ValidationResult object with a possible list of validation errors. Once you set a validator for your commands or queries, only the valid ones will be executed.


<hr>
<h3>A practical example<h4>
Please check <a href="https://github.com/falberthen/EcommerceDDD">this</a> complete SPA application using BuildingBlocks.CQRS for a practical <a href="https://github.com/falberthen/EcommerceDDD/tree/master/EcommerceDDD.WebApp/Controllers">API</a> example.

<hr>
<h2>Install-Package BuildingBlocks.CQRS</h2>

https://www.nuget.org/packages/BuildingBlocks.CQRS/
