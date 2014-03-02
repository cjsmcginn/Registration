/*
purpose: serves as the controller for the default landing space of users, responsible for deciding what is displayed when they hit the site.
*/
(function () {
    'use strict';
    var controllerId = 'home';

    angular.module('app').controller(controllerId,
        ['$scope', 'common', 'config', 'datacontext', home]);

    function home($scope, common, config, datacontext) {
        
        var vm = this;

        // #region Bindable properties and functions
        vm.activate = activate;
        vm.title = 'home';
        vm.activate();
        vm.login = common.getView(common.routes.login);
        vm.profile = common.getView(common.routes.profile);
        //#endregion


        //#region Internal Methods 

        function activate() {
            common.activateController([getAccount()], controllerId);
        }
        function getAccount() {
            common.$broadcast(config.events.showBusy, { busy: true });
            var promise = datacontext.getAccount().then(function(response) {
                vm.account = response;
            });
            promise['catch'](function(response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });
            });
            promise['finally'](function () {
                common.$broadcast(config.events.showBusy, { busy: false });
            });
        }
               

        //#endregion
    }
})();
