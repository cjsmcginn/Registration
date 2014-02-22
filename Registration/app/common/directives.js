(function () {
    'use strict';

    // Define the directive on the module.
    // Inject the dependencies. 
    // Point to the directive definition function.
    angular.module('app').directive('uiValidateEquals', function () {

        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {


                elm.on('blur', function (e, n) {
                    var source = scope.$eval(attrs.uiValidateEquals);
                    var target = ctrl.$modelValue;
                    if (source && target) {
                        ctrl.$setValidity('equal', source == target);
                        var content = attrs.uiValidateEqualsError;
                        elm.popover({
                            placement: 'bottom',
                            conatiner: 'body',
                            content: content
                        });
                        if (ctrl.$invalid) {
                            elm.popover('show');
                            elm.focus();
                        } else {
                            elm.popover('hide');
                        }
                    }
                    return undefined;
                });

            }
        };
    });
    /// ng-minlength appears to have a bug in this release 
    angular.module('app').directive('uiMinlength', function () {

        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {
                elm.on('blur', function (e, n) {
                    var min = Number(scope.$eval(attrs.uiMinlength));
                    var target = ctrl.$modelValue;

                    if (target) {
                        var valid = target.length >= min;
                        ctrl.$setValidity('minlength', valid);
                        if (!valid) {
                            var content = 'Value must be at least ' + min.toString() + ' characters';
                            elm.popover({
                                placement: 'bottom',
                                conatiner: 'body',
                                content: content
                            });
                            elm.popover('show');
                            elm.focus();
                        } else if (ctrl.$valid) {
                            elm.popover('destroy');
                        }
                    }
                });

            }
        };
    });
    angular.module('app').directive('uiMaxlength', function () {

        return {
            restrict: 'A',
            require: 'ngModel',

            link: function (scope, elm, attrs, ctrl) {
                elm.on('blur', function (e, n) {
                    var max = Number(scope.$eval(attrs.uiMaxlength));
                    var target = ctrl.$modelValue;
                    if (target) {
                        var valid = target.length <= max;
                        ctrl.$setValidity('maxlength', valid);
                        if (!valid) {
                            var content = 'Value cannot exceed ' + max.toString() + ' characters';
                            elm.popover({
                                placement: 'bottom',
                                conatiner: 'body',
                                content: content
                            });
                            elm.popover('show');
                            elm.focus();
                        } else if (ctrl.$valid) {
                            elm.popover('destroy');
                        }
                    }
                });

            }
        };
    });
    angular.module('app').directive('uiNavlist', function () {
        var element = null;
        return {
            restrict: 'A',
            transclude: true,
            link: function (scope, elm, attrs) {
                element = elm;

                //if (scope.$last) {
                //    //console.log(angular.element(elm).find('li'));
                //    elm.on('click', function (e, a) {
                //        angular.element(e.currentTarget).find('li').addClass(active);
                //        console.log(e);
                //        console.log(a);
                //    });
                //}

            }
        };


    });

    angular.module('app').directive('ccSpinner', ['$window', function ($window) {
        // Description:
        //  Creates a new Spinner and sets its options
        // Usage:
        //  <div data-cc-spinner="vm.spinnerOptions"></div>
        var directive = {
            link: link,
            restrict: 'A'
        };
        return directive;

        function link(scope, element, attrs) {
            scope.spinner = null;
            scope.$watch(attrs.ccSpinner, function (options) {
                if (scope.spinner) {
                    scope.spinner.stop();
                }

                scope.spinner = new $window.Spinner(options);
                scope.spinner.spin(element[0]);
            }, true);
        }
    }]);
})();