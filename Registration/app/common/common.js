/*
purpose: We should have a provider for things common to the application
which will share functions, libraries, etc so that they can be changed without worrying about the dependencies
this will also share the configuraion with the rest of the application
*/
(function () {
    'use strict';

    var id = 'common';


    var commonModule = angular.module('common', []);
    commonModule.provider('commonConfig', function () {
        this.config = {},
        this.$get = function () {
            return {
                config: this.config
            };
        };
    });
    commonModule.factory('common', ['$rootScope','$q', 'commonConfig', 'logger','routes', common]);
    function common($rootScope, $q,commonConfig, logger, routes) {
        function $broadcast() {
            //we dont want to broadcast events that are not defined
            if (!arguments || !arguments[0])
                logger.logWarning("An attempt to broadcast an undefeined event was made",null,null,true);
            return $rootScope.$broadcast.apply($rootScope, arguments);
        }

        //provide way for controllers to get named rroutes as views returning templateUrl
        function getView(path) {
            return _.find(routes, function (item) { return item.url == path; }).config.templateUrl;
        }
        //provide a way to get a route that is not a view
        function getRoute(path) {
            try {
                return _.find(routes, function (item) { return item.url == path; }).url;
            } catch (e) {
                throw ("Path" + path + " Could not be found. Did you forget to configure the route in config.routes.js?");
            }
        }
        //common way of raising errors so they can be handled in a single place
        function raiseError(message, cause) {
            throw ({message:message,cause:cause});
        }
        function activateController(promises, controllerId) {
            return $q.all(promises).then(function (eventArgs) {
                var data = { controllerId: controllerId };
                $broadcast(commonConfig.config.controllerActivateSuccessEvent, data);
            });
        }
        //expose common libraries, functions, declarations, etc to our application
        return {
            $_: _,
            $broadcast: $broadcast,
            activateController: activateController,
            logger:logger,
            routes: {
                home: '/',
                register: '/register',
                account: '/account',
                login: '/login',
                profile: '/profile',
                states: '/states',
                logout:'/logout'
            },
            getView: getView,
            getRoute: getRoute,
            raiseError:raiseError
     
        };
    }

})();