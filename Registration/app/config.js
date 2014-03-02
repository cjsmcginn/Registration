/*
purpose: allows for a centralized place to set configuration options that are applicable
to the application as a whole. Logging, toastr settings, events, etc
*/
(function () {
    'use strict';
    var id = 'config';
    var app = angular.module('app');
    var spinnerOptions = {
        radius: 40,
        lines: 7,
        length: 0,
        width: 30,
        speed: 1.7,
        corners: 1.0,
        trail: 100,
        color: '#F58A00',
        top: window.outerHeight / 5,
        left: 'auto'
    };
    function toastrOptions() {
        return {
            closeButton: false,
            debug: false,
            positionClass: "toast-top-right",
            onclick: null,
            showDuration: 300,
            hideDuration: 1000,
            timeOut: 5000,
            extendedTimeOut: 1000,
            showEasing: "swing",
            hideEasing: "linear",
            showMethod: "fadeIn",
            hideMethod: "fadeOut"
        };
    };

    var events = {
        showErrors: 'showErrors',
        loadView:'loadView',
        showView: 'showView',
        showBusy:'showBusy',
        controllerActivateSuccess: 'controllerActivateSuccess',
        spinnerToggle: 'spinnerToggle'

    };
    var config = {
        events: events,
        appErrorPrefix: '[Application Error] - ',
        toastrOptions: toastrOptions,
        spinnerOptions:spinnerOptions

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
    }]);

})();