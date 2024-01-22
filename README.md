# LibraryApi
.Net web api designed with implementation of DDD and Cqrs with Mediator pattern. Consists of 4 layers: api project (presentation layer) and 3 class libraries (that represents application, domain and infrastructure layers)
## Prerequisites
- .Net 7;
- Docker.
## Setup
1. Clone this repository.
2. Run docker.
3. Run this project.
If you want to acces database using external applications (like MS SQL Management studio):
- Server name: localhost,8002;
- Username: sa;
- Password: password@12345#.

Jwt options are stored in appsettings.json 
## Structure
Api consists of two controllers: for book management (according to requirements) and for user management (wasn't mentioned in requirements so just a few endpoints).
Only authorized users can access Book endpoints. User endpoints allow anonymous users.
Database is configured to scaffold automatically if it doesn't exist.
