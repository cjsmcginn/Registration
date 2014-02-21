(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'shell';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$scope','$http','common','config',shell]);

    function shell($scope, $http, common, config) {
        var events = config.events;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;
        vm.currentView = common.getView(common.routes.home);
   
       
        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'shell';
        vm.closeErrors = closeErrors;
        function showErrors(on) { vm.showErrors = on; }
        function closeErrors() {
            common.$broadcast(events.showErrors, { show: false, errors: null });
        };
        function showView(view) {
            vm.currentView = null;
            vm.currentView = common.getView(view);
        }
        function activate() {
        }

        function viewLoad() {
            console.log('loaded again')
        }

        $scope.$on(events.showView, function (data, args) {
            showView(args.view);
        });
        $scope.$on(events.showErrors, function (data, args) {
            vm.errors = args.errors;
            showErrors(args.show);
        });
        $scope.$on(events.controllerActivateSuccess,
         function (data, args) {
             logSuccess('Loaded ' + args.controllerId, null, true);

         });
    }
})();
