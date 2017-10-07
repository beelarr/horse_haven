"use strict"

app.controller("addHorseCtrl", function($scope, horseFactory, $location){
    $scope.title = "New Horse";
    $scope.submitButtonText = "Add a New Horse";

    $scope.horse = {
        horseId: "",
        horseHavenId: "",
        name: "",
        breed: "",
        color: "",
        gender: {},
        age: "",
        countyOfOrigin: "",
        horseStatusId: "",
        arrivalDate: "",
        departureDate: "",
        eligibleForOwnershipDate: "",
        adopterId: "",
        caseId: ""

    };

    $scope.submitHorse = function () {
        horseFactory.addHorse($scope.horse)
            .then((data) => {
            $location.url("/horses");

        });
    }
});