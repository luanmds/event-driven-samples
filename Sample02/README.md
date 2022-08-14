# Sample 02 - CQRS With a Url Shoterned Project

This sample project aims to demonstrate the concepts of Command Query Segregation of Responsibility, or CQRS, through a microservice project called a URL shortener (the one you may have seen in several tutorials).

The sample consists of a Command to shorten the URL and a Query to fetch the shortened link in a NoSQL (MongoDB) database. 

The Controller receives a URL as parameter, after calls Command first to generate and save the url shortened. Second, calls Query Handler to create a query for get url shortened from database.

## How to Run

1. Install Docker and Docker-Compose your machine;
2. Execute the docker-compose.yaml file to Run project.
