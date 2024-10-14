# Survivor Competition Web API

This project implements a Web API for managing competitors and categories in a Survivor competition. The API allows for CRUD (Create, Read, Update, Delete) operations on competitors and categories, maintaining a one-to-many relationship between them.

## Project Structure

### Entities

1. **BaseEntity Class**
   - A base class to provide common properties like `Id` and `CreatedDate` for derived entities.

2. **Competitor Class**
   - Represents a competitor in the competition.
   - Properties:
     - `Id`: Unique identifier.
     - `Name`: Name of the competitor.
     - `CategoryId`: Foreign key linking to the Category.

3. **Category Class**
   - Represents a category in which competitors participate.
   - Properties:
     - `Id`: Unique identifier.
     - `Name`: Name of the category.

### Controllers

#### CompetitorController

- **Endpoints:**
  - `GET /api/competitors`: Retrieve all competitors.
  - `GET /api/competitors/{id}`: Retrieve a specific competitor by ID.
  - `GET /api/competitors/categories/{CategoryId}`: Retrieve competitors by category ID.
  - `POST /api/competitors`: Create a new competitor.
  - `PUT /api/competitors/{id}`: Update a specific competitor by ID.
  - `DELETE /api/competitors/{id}`: Delete a specific competitor by ID.

#### CategoryController

- **Endpoints:**
  - `GET /api/categories`: Retrieve all categories.
  - `GET /api/categories/{id}`: Retrieve a specific category by ID.
  - `POST /api/categories`: Create a new category.
  - `PUT /api/categories/{id}`: Update a specific category by ID.
  - `DELETE /api/categories/{id}`: Delete a specific category by ID.

## Testing the API

You can test the API using tools like **Postman** or **Swagger** to ensure all CRUD operations work correctly. 

### Instructions for Testing

1. **Postman:**
   - Create a new request for each endpoint and set the appropriate HTTP method.
   - For POST and PUT requests, set the request body to JSON format.

2. **Swagger:**
   - If Swagger is set up in your project, you can access the API documentation at `/swagger` to test endpoints directly from your browser.

### Setup

1. Clone the repository.
2. Run the project using your preferred method (e.g., Visual Studio, .NET CLI).
3. Ensure your database is set up and migrations are applied.

This README provides a concise overview of the Survivor competition Web API and serves as a guide for implementation and testing.
