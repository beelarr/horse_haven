app.controller("listCtrl", function ($scope, horseFactory, userFactory, filterFactory, $rootScope ) {
    $scope.horses = [];
    let user = userFactory.getCurrentUSer();
    $rootScope.searchText = true;
    $scope.searchText = filterFactory;

    const showAllHorses = function () {
        horseFactory.getAllHorses()
            .then((horses) => {
            $scope.horses = horses;
            });
    };

    $scope.deleteHorse = function (id) {
        todoFactory.deleteHorse(id)
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
