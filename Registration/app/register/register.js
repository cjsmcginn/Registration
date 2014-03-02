/*
purpose: serves as the controller for registration of new accounts
*/
(function () {
    'use strict';

    var controllerId = 'register';
    angular.module('app').controller(controllerId,
        ['$scope', 'datacontext', 'common', 'config','logger', register]);

    function register($scope, datacontext, common, config,logger,form) {
        var vm = this;

        // #region Bindable properties and functions
        vm.activate = activate;
        vm.title = 'register';
        vm.save = save;
        //#endregion
        activate();

        //#region Internal Methods        
        
        function activate() {
            common.activateController([], controllerId);
        }
        function save() {

            if (!$scope.registrationForm.$valid) {
                return;
            };
         
            common.$broadcast(config.events.spinnerToggle, { show: true });
            var promise = datacontext.register(vm).then(function(response) {
                if (response.errors.length > 0)
                    for (var i = 0; i < response.errors.length; i++)
                        logger.logError(response.errors[i], null, null, true);
                else
                    common.$broadcast(config.events.loadView, { view: common.routes.profile });
            });
            promise['catch'](function(response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });

            });
            promise['finally'](function () {
                common.$broadcast(config.events.spinnerToggle, { show: false });
            });
            
        }
        //#endregion
    }
})();
