/*purpose: serve as container for the application to centralize ui interaction and behavior
listens for events, provides common layout*/
(function () {
    'use strict';
    var controllerId = 'shell';
    angular.module('app').controller(controllerId,
        ['$rootScope','$http','common','config',shell]);

    function shell($rootScope, $http, common, config) {
        var events = config.events;
       
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        var vm = this;
        vm.spinnerOptions = config.spinnerOptions;
        vm.currentView = common.getView(common.routes.home);
       
        // #region Bindable properties and functions
        vm.activate = activate;
        vm.title = 'shell';
        vm.closeErrors = closeErrors;
        vm.visible = false;
        //#endregion

        activate();

        //#region Internal Methods 
        function toggleSpinner(on) {
             vm.isBusy = on;
        }
        function showErrors(on) {
             vm.showErrors = on;
        }
        function showView(on) {
            vm.visible= on;
        }
        function showBusy(on) {
            toggleSpinner(on);
            showView(!on);
        }
        function closeErrors() {
            common.$broadcast(events.showErrors, { show: false, errors: null });
        };
        function loadView(view) {
            vm.currentView = null;
            vm.currentView = common.getView(view);
        }
        function activate() {
            common.activateController([], controllerId);
        }
        $rootScope.$on(events.spinnerToggle,
            function (data, args) {
                toggleSpinner(args.show);
            }
        );
        $rootScope.$on(events.showView, function (data, args) {
            showView(args.show);
        });
        $rootScope.$on(events.loadView, function (data, args) {
            loadView(args.view);
        });
        $rootScope.$on(events.showBusy, function (data, args) {
            showBusy(args.busy);
        });
        $rootScope.$on(events.controllerActivateSuccess,
         function (data, args) {
             logSuccess('Loaded ' + args.controllerId, null, true);
         });
        //#endregion
    }
})();
