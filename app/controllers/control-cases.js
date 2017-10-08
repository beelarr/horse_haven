"use strict";

app.controller("caseCtrl", function ($scope, caseFactory, $location) {
    $scope.title = "Case Controller";

    $scope.case = {
        caseId: "",
        description: ""
    };

    $scope.caseList = [];

    const getCaseList = function () {
        $scope.caseList = [
            {
                caseId: "1234",
                description: "Horse was rescued, horse is grateful"
            },
            {
                caseId: "5678",
                description: "Horse was rescued, horse is grateful"
            }
        ];
        // caseFactory.getCaseList()
        //     .then((data) => {
        //         console.log(data);
        //         $location.url("/cases");

        //     });
    }
    getCaseList();

    $scope.submitCase = function(Case) {
        console.log(Case);
        // caseFactory.addCase($scope.case)
        //     .then((data) => {
        //         $location.url("/cases");

        //     });
    };

    $scope.editCase = function () {
        caseFactory.addCase($scope.editedCase)
            .then((data) => {
                $location.url("/cases");

            });
    };
});