# ToDoBase

## Database Configuration

- Create local couchbase cluster named localhost (or provide something in environment variable CB_HOST)

- Create following bucket:

  > - todos (or provide something in environment variable CB_BUCKET)

- And create user for 'todos' bucket with 'Full Admin' role:

  > - username: todoadmin (or provide something in environment variable CB_USER)
  > - password: todoadmin (or provide something in environment variable CB_PASS)

- Then create following collections under '\_default' scope of bucket 'todos':

  > - users (or provide something in environment variable CB_USERS_COLLECTION)
  > - todoitems (or provide something in environment variable CB_TODO_ITEMS_COLLECTION)

- Finally create primary indexes on previously created collections:
  > CREATE PRIMARY INDEX ON `default`:`todos`.`_default`.`users`
  > CREATE PRIMARY INDEX ON `default`:`todos`.`_default`.`todoitems`

## Running tests

- Download source code from https://github.com/nuriu/ToDoBase
- Run the tests from main repo folder via;
  > dotnet test

## Running app

- First run database container with required configuration
- Then pull the image and run container with following command:
  > docker run -p 5000:5000 nuriu/todobase

## Tech Stack

- .NET 5
- Couchbase
- Swagger
- Docker
- NUnit
