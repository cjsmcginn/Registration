(function () {
    'use strict';
    var controllerId = 'profile';

    angular.module('app').controller(controllerId,
        ['$scope', 'common', 'config', 'datacontext', 'logger', profile]);

    function profile($scope, common, config, datacontext, logger) {
        var vm = this;

        // #region Bindable properties and functions
        vm.activate = activate;
        vm.title = 'profile';
        vm.countrySelected = countrySelected;
        vm.save = save;
        vm.logOut = logOut;
        //#endregion
        activate();

        //#region Internal Methods        
        function activate() {
            common.activateController([getProfile()], controllerId);
        }
        function getProfile() {
            common.$broadcast(config.events.showBusy, { busy: true });
            datacontext.getProfile().then(function (response) {
                vm.profile = response;
            }).catch(function (response) {
                if (response == 401)
                    common.$broadcast(config.events.loadView, { view: common.routes.login });
            }).finally(function () {
                common.$broadcast(config.events.showBusy, { busy: false });
            });
        }
        function countrySelected() {
            getStates();
        }
        function getStates() {
            datacontext.getStates(vm.profile.country.key).then(function (response) {
                vm.profile.stateProvince = null;
                vm.profile.stateProvinces = response;
            }).catch(function (response) {
                common.$broadcast(config.events.showErrors, { show: true, errors: [response] });
            });
        }
        function save() {
            datacontext.postProfile(vm.profile).then(function (response) {
                logger.logSuccess('Profile Saved', null, null, true);
            });
        }
        function logOut() {
            datacontext.logOut().then(function (response) {
                common.$broadcast(config.events.loadView, { view: common.routes.login });
            });
        }
        //#endregion
    }
})();
