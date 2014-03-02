(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'scratch';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$scope','common','config','datacontext','logger', scratch]);

    function scratch($scope, common, config, datacontext, logger) {
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;

        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'scratch';
        vm.showBusy = showBusy;
        vm.showException = showException;
        vm.showSuccess = showSuccess;
        activate();


        //#region Internal Methods        
        function activate() {
            common.activateController([], controllerId);
        }
        function showBusy() {
            common.$broadcast(config.events.spinnerToggle, { show: true });
        }
        function showException() {
            logger.logException('An exception Occured');
        }
        function showSuccess() {
            logger.logSuccess('Success',null,null,true);
        }
        //#endregion
    }
})();
