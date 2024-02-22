---
marp: true
theme: wctc
style: |
  @import 'wctc-theme.css';
---
![WCTC Logo](https://www.wctc.edu/_resources/images/waukesha_logo.svg)

# Introduction to the Repository Pattern
## Simplifying Data Access in Software Development
*Instructor: Mark McArthey*

---

# Overview of the Repository Pattern
- **Definition:** A design pattern that separates data access logic from business logic, providing a more abstract interface for data operations.
- **Purpose:** To abstract the data layer, allowing for more flexible data access and easier testing.
- **Use Cases:** Ideal for applications with complex data access requirements or when using multiple data sources.


---

# Benefits of the Repository Pattern
- **Decoupling:** Separates data access logic from business logic, reducing dependencies and increasing modularity.
- **Testability:** Simplifies unit testing by allowing easy mocking or stubbing of data access methods.
- **Maintainability:** Centralizes data access logic, making it easier to manage and update.
- **Abstraction:** Provides a consistent interface for data access, abstracting away the details of the underlying data source.
- **Flexibility:** Enables switching between different data sources or technologies with minimal impact on the rest of the application.


---

# Key Components
- **Client:** Part of the application needing data access
- **Repository Interface:** Defines data access methods
- **Concrete Repository:** Implements the interface
- **Data Source:** The storage mechanism (e.g., database)

---

# Writing Testable Code
### How it Makes You a Better Coder

---

# Modular Design
- **Testability leads to modularity.**
- **Benefits:**
  - Easier to understand
  - Easier to maintain
  - Easier to test

---

# Clearer Interfaces
- **Designing for testability creates clearer interfaces.**
- **Benefits:**
  - Reduces coupling
  - Increases flexibility
  - Simplifies future changes

---

# Reduced Complexity
- **Testable code is less complex.**
- **Benefits:**
  - Breaks code into manageable pieces
  - Simplifies the overall system

---

# Improved Code Quality
- **Writing testable code enhances quality.**
- **Benefits:**
  - Encourages focused functions and classes
  - Easier to understand and maintain
  - Easier to debug

---

# Easier Debugging
- **Testable code is easier to debug.**
- **Benefits:**
  - Isolates specific code parts in tests
  - Simplifies identifying and fixing problems

---

# Refactoring Safety
- **Testable code is safer to refactor.**
- **Benefits:**
  - Comprehensive tests catch regressions
  - Changes can be made with confidence

---

# Applying Testability to SOLID Principles

---

# Single Responsibility Principle (SRP)
- **Modular Design:** Each class has a single responsibility.
- **Testability:** Easier to write tests for a focused class.
- **Example:**
<style scoped>
pre {
  font-size: 14px;
}
</style>
  ```csharp
  // Good: Single responsibility
  public class OrderProcessor
  {
      public void ProcessOrder(Order order) { /* ... */ }
  }

  // Bad: Multiple responsibilities
  public class OrderProcessor
  {
      public void ProcessOrder(Order order) { /* ... */ }
      public void GenerateInvoice(Order order) { /* ... */ }
  }
```
---

# Open/Closed Principle (OCP)
- **Clearer Interfaces:** Designing for extension rather than modification leads to clearer interfaces and reduced coupling.
- **Testability:** Changes can be made by adding new code, not modifying existing code, preserving test integrity.

- **Example:**
<style scoped>
pre {
  font-size: 14px;
}
</style>
  ```csharp
  // Good: Open for extension
  public abstract class Shape
  {
      public abstract double Area();
  }

  public class Circle : Shape
  {
      public double Radius { get; set; }
      public override double Area() => Math.PI * Radius * Radius;
  }

  // Bad: Closed for extension
  public class Shape
  {
      public double Width { get; set; }
      public double Height { get; set; }
      public double Area() => Width * Height;
  }
```
---

# Liskov Substitution Principle (LSP)
- **Reduced Complexity:** Subtypes should be substitutable for their base types without altering the correctness of the program.
- **Testability:** Ensures that tests for the base type are valid for subtypes, simplifying testing.
- **Example:**
<style scoped>
pre {
  font-size: 14px;
}
</style>
  ```csharp
  // Good: Substitutable
  public class Bird
  {
      public virtual void Fly() { /* ... */ }
  }

  public class Duck : Bird { /* ... */ }

  // Bad: Not substitutable
  public class Bird
  {
      public void Fly() { /* ... */ }
  }

  public class Ostrich : Bird
  {
      public new void Fly()
      {
          throw new NotSupportedException("Ostriches can't fly!");
      }
  }
```
---

# Interface Segregation Principle (ISP)
- **Modular Design:** Clients should not be forced to depend on interfaces they do not use, promoting modularity.
- **Testability:** Smaller, focused interfaces are easier to mock and test.
- **Example:**
<style scoped>
pre {
  font-size: 14px;
}
</style>
  ```csharp
  // Good: Segregated interfaces
  public interface IPrinter
  {
      void Print(Document d);
  }

  public interface IScanner
  {
      void Scan(Document d);
  }

  // Bad: Fat interface
  public interface IMachine
  {
      void Print(Document d);
      void Scan(Document d);
      void Fax(Document d);
  }
```
---

# Dependency Inversion Principle (DIP)
- **Clearer Interfaces:** High-level modules should not depend on low-level modules, but on abstractions.
- **Testability:** Dependency inversion facilitates the use of test doubles (e.g., mocks, stubs) for dependencies.
- **Example:**
<style scoped>
pre {
  font-size: 12px;
}
</style>
  ```csharp
  // Good: Dependency inversion
  public interface IRepository
  {
      void Save(object data);
  }

  public class DataManager
  {
      private readonly IRepository _repository;

      public DataManager(IRepository repository)
      {
          _repository = repository;
      }
  }

  // Bad: High-level module depends on low-level module
  public class DataManager
  {
      private readonly FileRepository _repository;

      public DataManager()
      {
          _repository = new FileRepository();
      }
  }
```
---

# Repository Pattern in Action (Interface)
- **Scenario:** Managing a collection of movies in an application.
- **Repository Interface:** Defines CRUD operations for movies.
  ```csharp
    public interface IMovieRepository
    {
        Movie GetById(int id);
        IEnumerable<Movie> GetAll();
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
  ```

---

# Repository Pattern in Action (Concrete)
- **Concrete Repository:** Implements the interface using a data source (e.g., in-memory list, database).
  ```csharp
  public class MovieRepository : IMovieRepository
  {
      // Implementation details...
  }
  ```
- **Usage in Application:** Business logic interacts with the repository, not directly with the data source.
  ```csharp
  var repository = new MovieRepository();
  var movies = repository.GetAll();
  ```

---

# Integrating with Dependency Injection
- **Purpose:** Decouples the creation of repository instances from their usage, allowing for more flexible and testable code.
- **Example:** Using a DI container (e.g., Microsoft.Extensions.DependencyInjection) to register and resolve repository dependencies.
  ```csharp
  services.AddSingleton<IMovieRepository, MovieRepository>();

---

# Integrating with Dependency Injection Benefits
- **Loose Coupling:** Business logic is not tied to specific repository implementations.
- **Testability:** Easily swap out real repositories with mock implementations for testing.
- **Lifetime Management:** DI containers can manage the lifecycle of repository instances, ensuring proper resource management.
Usage in Application: Inject the repository into services or controllers.

---

# Integrating with Dependency Injection Usage
- **Usage in Application:** Inject the repository into services or controllers.
  ```csharp
  public class MovieService
  {
      private readonly IMovieRepository _repository;

      public MovieService(IMovieRepository repository)
      {
          _repository = repository;
      }

      // Use _repository in service methods...
  }

---
# How We Implement
# Step 1: Direct Data Access
- **Issue:** Code is tightly coupled with data access logic.
- **Example Code:**
  ```csharp
  var movies = File.ReadAllLines("movies.csv");
  foreach (var movie in movies)
  {
      Console.WriteLine(movie);
  }

---

# How We Implement
# Step 2: Using only a context (data access class)
- **Issue:** Main program becomes messy and hard to maintain.
- **Example Code:**
  ```csharp
  var context = new MovieContext();
  var movies = context.GetAllMovies();
  foreach (var movie in movies)
  {
      Console.WriteLine(movie.Title);
  }

---

# How We Implement
# Step 3: Introducing a Repository
- **Solution:** Clean up the main method by abstracting data operations.
- **Example Code:**
  ```csharp
  var repo = new MovieRepository(new MovieContext());
  var movies = repository.GetAllMovies();
  foreach (var movie in movies)
  {
      Console.WriteLine(movie.Title);
  }

--- 

# Advanced Concepts
- **Unit of Work:** Manages related operations as a single transaction for data consistency.
  - Coordinates multiple repositories.
  - Example: Committing changes to multiple entities together.
- **Specification Pattern:** Encapsulates query logic for dynamic and reusable queries.
  - Allows for building complex queries dynamically.
  - Example: Filtering movies by genre or rating.
- **CQRS (Command Query Responsibility Segregation):** Separates read and write operations for better scalability and maintainability.
  - Use different models for querying and updating data.
- **Event Sourcing:** Stores changes as a sequence of events for auditing and historical reconstruction.
  - Example: Tracking changes to a movie's details over time.

---

# Hands-On Exercise
- Implement the Repository Pattern
- Guidelines and resources for the exercise

---

# Summary and Key Takeaways
- **Repository Pattern:** Provides a clean separation between data access and business logic, improving maintainability and testability.
- **Evolution:** Starting with direct data access, moving to repositories, and then introducing a context for cleaner code.
- **Dependency Injection:** Enhances flexibility and testability by decoupling repository implementation from usage.
- **Advanced Concepts:** Explore Unit of Work, Specification Pattern, CQRS, and Event Sourcing for more complex scenarios.
- **Choose Wisely:** Select the appropriate approach based on your application's needs and complexity.

