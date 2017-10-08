"use strict";

app.factory("boardingFactory", function ($q, $http) {
    const getAllBoardingTypes = function () {
        let types = [];
        return $http.get(`/api/boardings`)
            .then((boardingTypeObj) => {
                //TODO: parse data from db
            })
    };
    return {getAllBoardingTypes};
});
