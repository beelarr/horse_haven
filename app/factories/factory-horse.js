"use strict";


app.factory("horseFactory", function ($q, $http){

    const addHorse  =  (obj) => {
        let newObj = JSON.stringify(obj);
        return $http.post(``, newObj)
            .then((data) => {
            return data;
            }, (error) => {
            console.log('error', error.code, error.message);
            });
    };


    const editHorse = (id, obj) => {
        let newObj = JSON.stringify(obj);
        return $http.patch(``, newObj)
            .then((data) => {
                return (data)
                }, (error) => {
                console.log('error', error.code, error.message);
                });
    };

    const getSingleHorse = function(itemId){
        return $q((resolve, reject) =>{
            $http.get(`/api/horses`)
                .then((itemObj) => {
                    resolve(itemObj.data);
                })
                .catch((error) => {
                    reject(error);
                });
        });
    };

    const getAllHorses = function () {
        let horses = [];
        return $http.get(`api/horses`)
            .then((itemObject) => {

                resolve(horses)
            })
            .catch((error) => {
            console.log(error.number, error.message);
            })
    };

    return{addHorse, editHorse, getSingleHorse, getAllHorses};

});
