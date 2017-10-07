"use strict";

app.controller("editHorseCtrl", function ($scope, horseFactory, $routeParams, $location) {
    $scope.title = "Edit Horse";
    $scope.submitButtonText = "Edit Horse";

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
    const showEditHorse = function () {
        horseFactory.getSingleHorse($routeParams.horseId)
            .then((data) => {
                $scope.horse = data;
                $scope.horse.id = $routeParams.horseId;
            });
    };

    $scope.submitHorse = function () {
        horseFactory.editHorse($routeParams.horseId, $scope.horse)
            .then((data) => {
            $location.path("/horses");
            });
    };

    showEditHorse();
});