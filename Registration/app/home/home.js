﻿(function () {
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
            datacontext.getAccount().then(function (response) {
                vm.account = response;
            }).catch(function (response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });
            }).finally(function () {
                common.$broadcast(config.events.showBusy, { busy: false });
            });
        }
               

        //#endregion
    }
})();