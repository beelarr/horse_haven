"use strict";

app.controller("caseList", function($scope, caseFactory, filterFactory, caseFactory, $rootScope, $location){
    $scope.title = "Case List";
    $scope.submitButtonText = "Add or Edit Cases";
    $scope.searchText = true;
    $scope.searchText = filterFactory;
    $scope.cases = [];

    const showAllCases = function () {
        caseFactory.getAllCases()
            .then(() => {
                $scope.cases = cases;
            });
    };

    $scope.editCase = function () {
        caseFactory.editCase()
            .then((data) => {
            $scope.case = data
                $scope.case.id = $routeParams.caseId;
            });
    };

    showAllCases();
});
