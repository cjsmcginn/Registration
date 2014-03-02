(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'login';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$rootScope','common','config','datacontext','model','logger', login]);

    function login($rootScope,common,config,datacontext,model,logger) {
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;

        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'login';
        vm.account = new model.Account();
        vm.doLogin = doLogin;
        vm.register = register;
        activate();
        function activate() {
            common.activateController([], controllerId);
        }

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
