/*
purpose: to expose and abstract all CRUD operations that the application relies on
to more easily adjust to changes. Any api change in terms of data should be made here.
this also provides a way to pass in mock data if necessary, if it exposes the same prototype methods
*/
(function () {
    'use strict';

    // Factory name is handy for logging
    var serviceId = 'datacontext';

    // Define the factory on the module.
    // Inject the dependencies. 
    // Point to the factory definition function.
    // TODO: replace app with your module name
    angular.module('app').factory(serviceId, ['$q','$http','routes','common','model.mapper', datacontext]);

    function datacontext($q,$http,routes,common,mapper) {
        // Define the functions and properties to reveal.
        var service = {
            getAccount: getAccount,
            register: register,
            login: postLogin,
            getProfile: getProfile,
            getStates: getStates,
            postProfile: postProfile,
            logOut:logOut
        };

        return service;

        function getAccount() {
            var url = common.getRoute(common.routes.account);
            var d = null;
            var request = $q.defer();

            $http({ url: url, method: 'GET' }).success(function (data, status, headers, configuration) {
                request.resolve(mapper.account.toModel(data));
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not get account");
            });

            return request.promise;
        }
        function register(model) {
            var url = common.getRoute(common.routes.register);
            var d = mapper.account.fromModel(model);
            var request = $q.defer();
            $http({ url: url, method: 'POST', data: d }).success(function (data, status, headers, configuration) {
                request.resolve(mapper.account.toModel(data));
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not create account");
            });
            return request.promise;
        }
        function postLogin(model) {
            var url = common.getRoute(common.routes.login);
            var d = mapper.account.fromModel(model);
            var request = $q.defer();

            $http({ url: url, method: 'POST', data: d }).success(function (data, status, headers, configuration) {
                request.resolve(mapper.account.toModel(data));
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not login");
            });
            return request.promise;
        }
        function getProfile() {
            var url = common.getRoute(common.routes.profile);
            var request = $q.defer();
            $http({ url: url, method: 'GET'}).success(function (data, status, headers, configuration) {
                request.resolve(mapper.profile.toModel(data));
            }).error(function (data, status, headers, configuration) {
                request.reject(status);
            });
            return request.promise;
        }
        function postProfile(model) {
            var url = common.getRoute(common.routes.profile);
            var d = mapper.profile.fromModel(model);
            var request = $q.defer();
            $http({ url: url, method: 'POST',data:d }).success(function (data, status, headers, configuration) {
                request.resolve(mapper.profile.toModel(data));
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not get Profile    " + status);
            });
            return request.promise;
        }
        function getStates(country) {
            var url = common.getRoute(common.routes.states) + '/' + country;
            var request = $q.defer();
            $http({ url: url, method: 'GET'}).success(function (data, status, headers, configuration) {
                request.resolve(data);
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not get States   " + status);
            });
            return request.promise;
        }
        function logOut() {
            var url = common.getRoute(common.routes.logout);
            var request = $q.defer();
            $http({ url: url, method: 'POST' }).success(function (data, status, headers, configuration) {
                request.resolve(data);
            }).error(function (data, status, headers, configuration) {
                request.reject("Could not logouts   ");
            });
            return request.promise;
        }
    }
})();