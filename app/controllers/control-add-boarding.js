"use strict";

app.controller("addBoardingCtrl", function($scope, boardingFactory, $location){
    $scope.title = "New Boarding Type";
    $scope.submitButtonText = "Add a New Type";

    $scope.boarding = {
        boardingTypeId: "",
        description: "",
        rate: ""
    };

    $scope.submitBoardingType() = function () {
        boardingFactory.addBoardingType($scope.boarding)
            .then(() => {

                $location.url("/boardingTypes");

            });
    }

});



