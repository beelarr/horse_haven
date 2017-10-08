"use strict";

app.controller('navCtrl', function($scope, $window, userFactory, filterFactory){
    $scope.searchText = filterFactory;
    $scope.isLoggedIn = true;

    $scope.logout = () => userFactory.logout();



});

