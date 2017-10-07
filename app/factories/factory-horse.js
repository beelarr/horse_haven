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
        return $q((resolve, reject) => {
            let newObj = JSON.stringify(obj);
            $http.patch(``, newObj)
                .then((data) => resolve(data))
                .catch((error) => reject(error))
                });
        };

    return{addHorse, editHorse};

});