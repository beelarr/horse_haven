"use strict";

app.controller("boardingList", function($scope, horseFactory, filterFactory, boardingFactory, $rootScope, $location){
    $scope.title = "Boarding List";
    $scope.submitButtonText = "Add or Edit Boarding List";
    $scope.searchText = true;
    $scope.searchText = filterFactory;
    $scope.boardingTypes = [];

    const showAllBoardingTypes = function () {
        boardingFactory.getAllBoardingTypes()
            .then((tasks) => {
            $scope.boardingTypes = boardingTypes;
            });
    };

    $scope.deleteBoardingType = function (id) {
        boardingFactory.deleteBoardingType(id)
            .then(() => {
            showAllBoardingTypes();
                $location.url("/boardingTypes");
            });
    };


    showAllBoardingTypes();
});
