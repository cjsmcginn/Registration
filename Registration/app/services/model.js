/*
profile: define well known models to abstract client models from server models.
These models will be used to map data that comes back from the server so there will always be well known to the client
*/
(function () {
    'use strict';

    // Module name is handy for logging
    var serviceId = 'model';
    angular.module('app').factory(serviceId,
       ['$rootScope',
           model]);
    function model($rootScope) {
        var service = {
            Account: Account,
            Module: Module,
            Profile: Profile,
            Secure:Secure
        };
        return service;

        function Profile() {
            var result = {
                firstName: '',
                lastName: '',
                city: '',
                stateProvince: '',
                country: '',
                countries:[]
            };
            return result;
        };
        function Module() {
            var result = {
                id: '',
                title: '',
                index: 0
            };
            return result;
        };
        function Account() {
            var result = {
                username: '',
                password: '',
                isAuthenticated: false,
            };
            return result;
        };
        function Secure() {
            var result = {
                secretMessage: ''
            };
            return result;

        }

    };

})();