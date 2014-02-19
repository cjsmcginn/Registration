/*
purpose: We should have a provider for things common to the application
whicj will share functions, libraries, etc so that they can be changed without worrying about the dependencies
this will also share the configuraion with the rest of the application
*/
(function () {
    'use strict';

    // Module name is handy for logging
    var id = 'common';

    // Create the module
    var commonModule = angular.module(id, []);
    commonModule.factory(id, ['$rootScope','config','routes',common]);
    function common($rootScope, config,routes) {
        function $broadcast() {
            return $rootScope.$broadcast.apply($rootScope, arguments);
        }
        //provide way for controllers to get named routes
        function getView(path) {
            return _.find(routes, function (item) { return item.url == path }).config.templateUrl;
        }
        //expose common libraries, functions, declarations, etc to our application
        return {
            $_: _,
            $broadcast: $broadcast,
            config: config,
            routes: {
                register:'/register'
            },
            getView:getView

        };
    }

})();