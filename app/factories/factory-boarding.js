"use strict";

app.factory("boardingFactory", function ($q, $http) {

    const addBoardingType  =  (obj) => {
        let newObj = JSON.stringify(obj);
        return $http.post(``, newObj)
            .then((data) => {
                return data;
            }, (error) => {
                console.log('error', error.code, error.message);
            });
    };

    const getAllBoardingTypes = function () {
        let types = [];
        return $http.get(`/api/boardings`)
            .then((boardingTypeObj) => {
                //TODO: parse data from db
            })
    };

    const editBoardingType = (id, obj) => {
        let newObj = JSON.stringify(obj);
        return $http.patch(``, newObj)
            .then((data) => {
                return (data)
            }, (error) => {
                console.log('error', error.code, error.message);
            });
    };

    const getSingleBoardingType = function(itemId){
        return $q((resolve, reject) =>{
            $http.get(`/api/boardingTypes`)
                .then((itemObj) => {
                    resolve(itemObj.data);
                })
                .catch((error) => {
                    reject(error);
                });
        });
    };
    return {getAllBoardingTypes, editBoardingType, getSingleBoardingType, addBoardingType};
});
