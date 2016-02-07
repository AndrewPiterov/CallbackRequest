(function () {
    "use strict";

    angular.module("app").controller("CallbacksCtrl", callbacksCtrl);

    function callbacksCtrl($scope, $http) {

        $scope.visible = false;

        $scope.close = function () {
            $scope.visible = false;
            $scope.resultMessage = "";
        };

        $scope.newCallbackRequest = {};
        $scope.isBusy = false;

        $scope.addNewCallback = function () {

            $scope.isBusy = true;

            $http.post("api/callbacks", { name: $scope.newCallbackRequest.name, phone: $scope.newCallbackRequest.phone })
                .then(function (response) {
                    $scope.resultMessage = $scope.newCallbackRequest.name + ", Вам скоро перезвонят";
                }, function (error) {
                    console.log("Error: " + error);
                    $scope.resultMessage = "Произошла ошибка при отправке заявки";
                })
                .finally(function () {
                    $scope.newCallbackRequest = {};
                    $scope.isBusy = false;

                });
        }
    }
})();