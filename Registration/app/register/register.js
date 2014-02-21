﻿(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'register';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$scope','datacontext','common','config', register]);

    function register($scope,datacontext,common,config) {
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;

        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'register';
        vm.save = save;
        function activate() {
        }
        function save() {
            datacontext.register(vm).catch(function (response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });
            });
        }
        //#region Internal Methods        

        //#endregion
    }
})();