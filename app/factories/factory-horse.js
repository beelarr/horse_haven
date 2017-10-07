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

    return{addHorse, editHorse};

});