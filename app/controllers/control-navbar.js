"use strict";

app.controller('navCtrl', function($scope, $winidow, userFactory, filterFactory){
    $scope.searchText = filterFactory;
    $scope.isLoggedIn = false;

    $scope.logout = () => userFactory.logout();



});
d
