/*
purpose: This centralizes all routes in the application. Any routing requests are made here, which provides
a single point for configuring routes that the application should adhere to, abstracting physical and logical routes.
*/
(function () {
    'use strict';


    var app = angular.module('app');
    //create route collection and assign constant for access
    app.constant('routes', getRoutes());
    app.config(['$routeProvider', 'routes', routing]);

    function routing($routeProvider, routes) {
        routes.forEach(function (route) {
            $routeProvider.when(route.url, route.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    };
    function getRoutes() {
        return [
                {
                    url: '/',
                    config: {
                        templateUrl: 'app/home/home.html',
                        title: 'home',
                        controller: 'home'

                    }
                },
                {

                    url: '/register',
                    config: {
                        templateUrl: 'app/register/register.html',
                        title: 'register',
                        controller: 'register'

                    }
                },
                {

                    url: '/login',
                    config: {
                        templateUrl: 'app/login/login.html',
                        title: 'login',
                        controller: 'login'

                    }
                },
                {

                    url: '/account',
                    config: {
                        title: 'account',
                        controller: 'account'

                    }
                },
           {

               url: '/profile',
               config: {
                   title: 'profile',
                   templateUrl: 'app/profile/profile.html',
                   controller: 'profile'

               }
           },
            {

                url: '/states',
                config: {
                    title: 'states'

                }
            },
             {

                 url: '/logout',
                 config: {
                     title: 'logout'
                 }
             }
        ];
    };

})();