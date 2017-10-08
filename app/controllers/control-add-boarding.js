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
            .then((data) => {

                $location.url("/boardingTypes");

            });
    }
});



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
