# Sample 03 - Event-Sourcing with a Customer Management Project
This sample project aims to demonstrate the concepts of Event Sourcing through a microservice project about a Customer Management.

The sample consists of a Controller with three endpoints:
- the first one we can create a customer
- the second we change that customer's data
- and, finally, the third one is used to search for the events that occurred with a customer

With each creation or change in a customer, an equivalent event is generated to store history and provide us with what happened to that customer.

## How to Run

1. Install Docker and Docker-Compose your machine;
2. Execute the docker-compose.yaml file to Run project;
3. Open your favorite browser in **http://localhost:8000/swagger**;