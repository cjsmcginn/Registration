/*
purpose: define a mapper that can map client models to server models and visa versa, as this decouples
small changes in server models that would typically require client code to change if there was no layer
such as this, to handle such situations.
*/
(function () {
    'use strict';

    // Module name is handy for logging
    var serviceId = 'model.mapper';
    angular.module('app').factory(serviceId,
       ['$rootScope', 'model','common',
           modelMapper]);
    function modelMapper($rootScope, model,common) {
        var module = {
            toModel: function (data) {
                var result = new model.Module();
                result.title = data.title;
                result.id = data.id;
                result.index = data.index;
                return result;
            },
            toModels: function (data) {
                var result = [];
                for (var i = 0; i < data.length; i++) {
                    result.push(module.toModel(data[i]));
                }
                return result;
            },
            fromModel: function (obj) {

                return obj;
            }
        };
        var account = {
            toModel: function (data) {
                var result = new model.Account();
                result.username = data.account.username;
                result.emailAddress = data.account.emailAddress,
                result.emailAddressConfirm = data.account.emailAddressConfirm,
                result.password = data.account.password;
                result.password = data.account.passwordConfirm,
                result.isAuthenticated = data.isAuthenticated;
                result.errors = data.errors;
                return result;
            },
            toModels: function (data) {
                var result = [];
                for (var i = 0; i < data.length; i++) {
                    result.push(account.toModel(data[i]));
                }
                return result;
            },
            fromModel: function (obj) { return obj; }
        };
        var profile = {
            toModel: function (data) {
                var result = new model.Profile();
                result.firstName = data.firstName;
                result.lastName = data.lastName;
                result.city = data.city;
                result.countryId = data.countryId;
                result.stateProvinceId = data.stateProvinceId;
                result.countries = data.availableCountries;
                result.stateProvinces = data.availableStateProvinces;
                result.keepPrivate = data.keepPrivate;
                result.bio = data.bio;
                if (result.countries)
                    result.country = common.$_.filter(result.countries, function (item) { return item.key == result.countryId; })[0];
                if (result.stateProvinces)
                    result.stateProvince = common.$_.filter(result.stateProvinces, function (item) { return item.key == result.stateProvinceId; })[0];
     
                return result;
            },
            toModels: function (data) {
                var result = [];
                for (var i = 0; i < data.length; i++) {
                    result.push(profile.toModel(data[i]));
                }
                return result;
            },
            fromModel: function (obj) {
                var result = {
                    firstName: obj.firstName,
                    lastName: obj.lastName,
                    city: obj.city,
                    countryId: obj.country != null ? obj.country.key : null,
                    stateProvinceId: obj.stateProvince != null ? obj.stateProvince.key : null,
                    bio: obj.bio,
                    keepPrivate:obj.keepPrivate==null?false:obj.keepPrivate
                };
                return result;
            }
        };


        var service = {
            account: account,
            module: module,
            profile: profile
        };

        return service;
    };

})();