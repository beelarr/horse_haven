'use strict';

// Declare app level module which depends on views, and components
const app = angular.module('horseHaven', ['ngRoute']);

let isAuth = (userFactory) => new Promise ((resolve, reject) => {
    userFactory.isAuthenticated()
    .then((user) => {
        if (user){
            resolve();
        }else{
            reject();
    }
    });
});

app.config(['$locationProvider', '$routeProvider', ($locationProvider, $routeProvider) => {
    $routeProvider
    .when('/login', {
        templateUrl: '../partials/user.html',
        controller: 'userCtrl'
    })
    .when('/horses', {
        templateUrl: '../partials/horses.html',
        controller: 'listCtrl',
        // resolve: {isAuth}
    })
    .when('/horse/newHorse', {
        templateUrl: '../partials/form.html',
        controller: 'addHorseCtrl',
        // resolve: {isAuth}
    })
    .when('/horse/:horseId', {
        templateUrl: '../partials/details.html',
        controller: 'detailHorseCtrl',
        // resolve: {isAuth}
    })
    .when('/horse/:horseId/edit', {
        templateUrl: '../partials/form.html',
        controller: 'editHorseCtrl',
        // reslove: {isAuth}
    })
    .when('/people/adopters', {
        templateUrl: '../partials/adopters.html',
        controller: 'peopleCtrl',
        // reslove: {isAuth}
    })
    .when('/people/serviceProviders', {
        templateUrl: '../partials/serviceProviders.html',
        controller: 'peopleCtrl',
        // reslove: {isAuth}
    })
    .when('/horse/:horseId/horseStatus', {
        templateUrl: '../partials/horseStatus.html',
        controller: 'detailHorseCtrl',
        // reslove: {isAuth}
    })
    .when('/serviceTypes', {
        templateUrl: '../partials/typesOfService.html',
        controller: 'serviceCtrl',
        // reslove: {isAuth}
    })
    .when('/boardingTypes', {
        templateUrl: '../partials/boardingTypes.html',
        controller: 'boardingList',
        // reslove: {isAuth}
    })
    .when('/cases', {
        templateUrl: '../partials/cases.html',
        controller: 'caseCtrl',
        // reslove: {isAuth}
    })
    .when('/boardingTypes/:boardingTypeId', {
        templateUrl: '../partials/boardingTypeForm.html',
        controller: 'boardingList'
        // reslove: {isAuth}
    })
    .otherwise('/');

}]);
