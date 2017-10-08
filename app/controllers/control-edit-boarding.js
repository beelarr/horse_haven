"use strict";

app.controller("editBoardingCtrl", function ($scope, boardingFactory, $routeParams, $location) {
    $scope.title = "Edit Boarding Type";
    $scope.submitButtonText = "Save";

    $scope.boarding = {
        boardingTypeId: "",
        description: "",
        rate: ""
    };


    const showEditBoardingType = function () {
        boardingFactory.getSingleBoardingType($routeParams.boardingTypeId)
            .then((data) => {
                $scope.boardingType = data;
                $scope.boardingType.id = $routeParams.boardingTypeId;
            });
    };

    $scope.submitBoardingType = function () {
        boardingFactory.editBoardingType($routeParams.boardingTypeId, $scope.boardingType)
            .then((data) => {
                $location.path("/boardingTypes");
            });
    };

    showEditBoardingType();
});
