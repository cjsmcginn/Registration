/*
purpose: allows for a centralized place to set configuration options that are applicable
to the application as a whole. Logging, toastr settings, events, etc
*/
(function () {
    'use strict';
    var id = 'config';
    var app = angular.module('app');


    var events = {
        showErrors: 'showErrors',
        showView:'showView'
    };
    var config = {
        events: events,
        appErrorPrefix: '[Application Error] - ',
        controllerActivateSuccess: 'controllerActivateSuccess'
    };

    app.value(id, config);

    app.config(['$logProvider', function ($logProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);

    app.config(['commonConfigProvider', function (cfg) {
        cfg.config.controllerActivateSuccessEvent = config.events.controllerActivateSuccess;
        //cfg.config.spinnerToggleEvent = config.events.spinnerToggle;
    }]);

})();