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
            url: '/register',
            config: {
                templateUrl: 'app/register/register.html',
                title: 'register',
                controller: 'register'

            }
        }

        ]
    };

})();