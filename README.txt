# Library OOP

A small C# project that models a basic library system using Object-Oriented Programming (OOP) concepts.

The project was created as an early exercise in C# and OOP, with a focus on designing classes, relationships between objects, encapsulation, inheritance, and basic business rules.

## Overview

The project models a library domain containing:

* **Authors** — authors can have books and awards.
* **Books** — books are associated with an author and have a type and publication year.
* **Library Members** — members have a membership type and status and can borrow and return books.
* **Library** — maintains collections of books, authors, and members.
* **Human** — a base class shared by authors and library members.

The project currently focuses on the **object model and its behavior**, rather than providing a complete user-facing library application.

## Domain Model

```text
              Human
             /     \
            /       \
        Author    LibraryMember
           |             |
           |             |
           v             v
         Books      Borrowed Books
           ^
           |
          Book

              Library
            /    |    \
           /     |     \
       Books  Authors  Members
```

### Main Classes

| Class           | Responsibility                                         |
| --------------- | ------------------------------------------------------ |
| `Human`         | Base class containing common information about people  |
| `Author`        | Represents an author, including their books and awards |
| `Book`          | Represents a book and its relationship with an author  |
| `LibraryMember` | Represents a library member and manages borrowed books |
| `Library`       | Maintains collections of books, authors, and members   |

## OOP Concepts Demonstrated

### Encapsulation

The classes use private fields and expose behavior through methods. Input validation is performed before modifying object state.

Collections such as an author's books and a member's borrowed books are also protected from direct modification by returning copies of the internal lists.

### Inheritance

`Author` and `LibraryMember` inherit from the `Human` base class:

```csharp
Human
├── Author
└── LibraryMember
```

This allows common properties and behavior to be defined once and reused.

### Abstraction

The `Human` class provides a common abstraction for people in the library domain.

This is a basic form of abstraction through a shared base class rather than an interface or abstract class hierarchy.

### Polymorphism

The project demonstrates limited polymorphism through overriding `ToString()` in derived classes such as `Author`.

### Object Relationships

The project uses relationships between objects to model the library domain.

For example:

* A `Book` has an `Author`.
* An `Author` maintains a collection of books.
* A `LibraryMember` maintains a collection of borrowed books.
* A `Library` maintains collections of books, authors, and members.

## Features

* Create and manage authors.
* Associate books with authors.
* Add and remove author awards.
* Create library members.
* Support different membership types and statuses.
* Borrow and return books.
* Apply borrowing limits based on membership type.
* Validate basic input values.
* Maintain relationships between related objects.

## Membership Rules

The current implementation defines two membership types:

| Membership Type | Maximum Borrowed Books |
| --------------- | ---------------------: |
| `Free`          |                      5 |
| `Paid`          |                     10 |

Members with a `Passive` status cannot borrow books.

## Project Structure

```text
Library_OOP/
├── Library.slnx
└── Library/
    ├── Author.cs
    ├── Book.cs
    ├── Human.cs
    ├── Library.cs
    ├── Library.csproj
    ├── LibraryMember.cs
    └── Program.cs
```

## Technologies

* C#
* .NET 10
* .NET standard library collections (`List<T>`)
* No external NuGet packages

## Data Storage

The project currently stores data **in memory** using C# collections.

There is no database or persistent storage, so data is not preserved after the application exits.

## Testing

No automated test project is currently included.

## Current Limitations

This is intentionally a small OOP learning project rather than a complete library management application.

Current limitations include:

* No graphical or interactive Console UI.
* No database or persistent storage.
* No automated tests.
* No authentication or user management.
* No full loan-record system.
* Limited book availability tracking.
* `Program.cs` currently does not contain a complete application flow.

## Learning Focus

The main purpose of this project is to practice the fundamentals of Object-Oriented Programming in C#:

* Classes and objects
* Encapsulation
* Inheritance
* Basic abstraction
* Polymorphism
* Object relationships
* Constructors
* Access modifiers
* Collections
* Enums
* Basic validation

This project represents an early step in learning C# and OOP and intentionally keeps the domain model relatively simple.
