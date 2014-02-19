/*purpose:
    we need a place where we can configure everything that is application in scope
    this will be a value provider for easy access accross the application

*/
(function () {
    'use strict';

    // Module name is handy for logging
    var id = 'config';
    var app = angular.module('app');
    
    //this gets returned to our value provider
    var config = {
        events: {},
        routes: {
            register:'/register'
        }

    };
    //value provider
    app.value(id, config);
})();