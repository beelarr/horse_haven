app.controller("listCtrl", function ($scope, horseFactory, userFactory, filterFactory, $rootScope ) {
    $scope.title = "Horse List";
    $scope.submitButtonText = "Add a new Horse";

    $scope.horses = [];
    // let user = userFactory.getCurrentUser();
    $rootScope.searchText = true;
    $scope.searchText = filterFactory;

    const showAllHorses = function () {
        horseFactory.getAllHorses()
            .then((horses) => {
            $scope.horses = horses;
            });
    };

    $scope.deleteHorse = function (id) {
        horseFactory.deleteHorse(id)
            .then(() => {
            showAllHorses();
            });
    };

    $scope.toggleHorses = function (obj) {
        let status = obj.isEntered ? true : false;
        let tmpObj = {isEntered: status};
        horseFactory.editHorse(obj.id, tmpObj)
            .then(() => {
            showAllHorses();
            });
    };

    showAllHorses()

})
