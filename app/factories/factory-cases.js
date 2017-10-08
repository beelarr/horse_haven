app.factory("caseFactory", function ($q, $http) {

    const addCase = (obj) => {
        return obj;
        // let newObj = JSON.stringify(obj);
        // return $http.post(``, newObj)
        //     .then((data) => {
        //         return data;
        //     }, (error) => {
        //         console.log('error', error.code, error.message);
        //     });
    };


    const editCase = (id, obj) => {
        return id, obj;
        // let newObj = JSON.stringify(obj);
        // return $http.patch(``, newObj)
        //     .then((data) => {
        //         return (data)
        //     }, (error) => {
        //         console.log('error', error.code, error.message);
        //     });
    };

    return { addCase, editCase };

});