/*
purpose: serves as the controller for logging in users, or providing a means to navigate to registration
*/
(function () {
    'use strict';

    var controllerId = 'login';
    angular.module('app').controller(controllerId,
        ['$rootScope','common','config','datacontext','model','logger', login]);

    function login($rootScope,common,config,datacontext,model,logger) {

        var vm = this;

        // #region Bindable properties and functions
        vm.activate = activate;
        vm.title = 'login';
        vm.account = new model.Account();
        vm.doLogin = doLogin;
        vm.register = register;
        activate();
        function activate() {
            common.activateController([], controllerId);
        }
        // #endregion
        //#region Internal Methods        
        function doLogin() {
            common.$broadcast(config.events.spinnerToggle, { show: true });

            var promise = datacontext.login(vm).then(function(response) {
                vm.account = response;
                if (!vm.account.isAuthenticated) {
                    logger.logError('Invalid username or password', null, null, true);
                } else
                    common.$broadcast(config.events.loadView, { view: common.routes.profile });

            });
            promise['catch'](function(response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });
            });
            promise['finally'](function() {
                common.$broadcast(config.events.spinnerToggle, { show: false });
            });
        }
        function register() {
            common.$broadcast(config.events.loadView, { view:common.routes.register });
        }
        //#endregion
    }
})();
