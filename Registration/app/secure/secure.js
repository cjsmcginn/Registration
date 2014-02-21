(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'secure';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$scope','common', secure]);

    function secure($scope,common) {
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;

        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'secure';
        activate();
        function activate() {
            common.activateController([], controllerId);
        }

        //#region Internal Methods        

        //#endregion
    }
})();
