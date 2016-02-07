(function () {
    "use strict";

    angular.module("app")
        .directive("modal", function () {
            return {
                restrict: "E",
                templateUrl: "templates/cbModal",
                transclude: true
            };
        })
})();