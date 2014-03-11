Registration
=======



# Overview
This application was inspired by [John Pappa’s Hot Towel SPA](https://github.com/johnpapa/HotTowel) in **AngularJS**. It highlights some basic design elements with Bootstrap 3, OWIN and Nancy for hosting and routing, TinyIOC for dependency injection, Entity Framework Code First, and mainly AngularJS. The application demonstrates registration and profile maintenance.


Components
--------------------
#### Registration.Core  
This project contains the Domain classes, some extensions for encryption, and service interfaces. This project is a shared reference with the other solution components. These are the components that could be swapped out using TinyIOC if you wished to change the behavior or use a different means of persistence.

#### Registration.Data
This is the project that defines the persistence store. This particular implementation makes use of Code First Entities to create the DB at runtime, and seed it with some data (countries and states).

#### Registration.Services
This project defines the services that the web application consumes. It serves to separate the UI from the functionality of the application. Classes in this project implement contracts defined in Registration.Core that are familiar to the website.

#### Registration
This project is a website utilizing Nancy and OWIN for hosting and routing. This is where the AngularJS application is implemented. The application demonstrates a possible implementation of an AngularJS application that decouples concerns.

Quickstart
---
1. Set Registration as the Start Up project. Run the project.
2. You will be presented with a registration screen. Once registered, a cookie will be stored on your browser. Subsequent visits will take you to the profile page.
3. You may log out, which will expire the cookie and bring you back to the default page.





