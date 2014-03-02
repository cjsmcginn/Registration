(function () {
    'use strict';

    angular.module('app').directive('uiValidateEquals', function () {
        
        return {
            require: '?ngModel',
            link: function (scope, elm, attr, ctrl) {
                if (!ctrl) return;
                attr.equals = true; // force truthy in case we are on non input element
                var source = scope.$eval(attr.uiValidateEquals);
                //check against source changes as well
                
                var validator = function () {
                    if (attr.equals) {
                        var valid = ctrl.$viewValue == source.$viewValue;
                        ctrl.$setValidity('equals', valid);
                        if (!valid)
                            elm[0].setCustomValidity(attr.uiValidateEqualsError);
                        else
                            elm[0].setCustomValidity('');
                        return ctrl.$viewValue;
                    }
                };
                source.$viewChangeListeners.push(validator);
              
                ctrl.$formatters.push(validator);
                ctrl.$parsers.unshift(validator);

                attr.$observe('equals', function () {
                    validator();
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