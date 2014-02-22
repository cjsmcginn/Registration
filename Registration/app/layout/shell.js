(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'shell';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$rootScope','$http','common','config',shell]);

    function shell($rootScope, $http, common, config) {
        var events = config.events;
       
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;
        //vm.spinnerOptions = {
        //    radius: 40,
        //    lines: 7,
        //    length: 0,
        //    width: 30,
        //    speed: 1.7,
        //    corners: 1.0,
        //    trail: 100,
        //    color: '#F58A00'


        //};
        vm.currentView = common.getView(common.routes.home);
   
       
        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'shell';
        vm.closeErrors = closeErrors;
        function toggleSpinner(on) {
             vm.isBusy = on;
        }

        function showErrors(on) {
             vm.showErrors = on;
        }
        function closeErrors() {
            common.$broadcast(events.showErrors, { show: false, errors: null });
        };
        function showView(view) {
            vm.currentView = null;
            vm.currentView = common.getView(view);
        }
        function activate() {
        }

        $rootScope.$on(events.spinnerToggle,
            function (data, args) {
                toggleSpinner(args.show);
            }
        );
        $rootScope.$on(events.showView, function (data, args) {
            showView(args.view);
        });
        $rootScope.$on(events.showErrors, function (data, args) {
            vm.errors = args.errors;
            showErrors(args.show);
        });
        $rootScope.$on(events.controllerActivateSuccess,
         function (data, args) {
             logSuccess('Loaded ' + args.controllerId, null, true);
         });
    }
})();
