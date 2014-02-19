(function () {
    'use strict';

    // Controller name is handy for logging
    var controllerId = 'shell';

    // Define the controller on the module.
    // Inject the dependencies. 
    // Point to the controller definition function.
    angular.module('app').controller(controllerId,
        ['$scope','$http', 'common','routes',shell]);

    function shell($scope,$http,common,routes) {
        // Using 'Controller As' syntax, so we assign this to the vm variable (for viewmodel).
        var vm = this;
        //get the configured default view
        var vw = common.$_.find(routes, function (item) { return item.url == common.config.register; });
        //set current view display
        vm.currentView = common.getView(common.routes.register);
        
  
       
        // Bindable properties and functions are placed on vm.
        vm.activate = activate;
        vm.title = 'shell';

        function activate() {
        }

        //#region Internal Methods        

        //#endregion
    }
})();
