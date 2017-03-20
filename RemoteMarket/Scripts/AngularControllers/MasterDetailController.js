angular.module('MyApp') // extending from previously created angularJS  module in the First part
.controller('MasterDetailController', function ($scope, LocationService) {
    // expained about controller in Part2 // Here LocationService (Service) Injected
    
    $scope.WorkTypeId = null;
    $scope.JobId = null;
    $scope.WorkTypeList = null;
    $scope.JobList = null;

    $scope.StateTextToShow = "Select job";
    $scope.Result = "";
    // Populate Country
    LocationService.GetWorkTypes().then(function (d) {
        $scope.WorkTypeList = d.data;
    }, function (error) {
        alert('Error!');
    });
    // Function For Populate State  // This function we will call after select change country
    $scope.GetJobs = function () {
        $scope.JobId = null; // Clear Selected State if any
        $scope.JobList = null; // Clear previously loaded state list
        $scope.StateTextToShow = "Please Wait..."; // this will show until load states from database

        //Load State 
        LocationService.GetJobs($scope.WorkTypeId).then(function (d) {
            $scope.JobList = d.data;
            $scope.StateTextToShow = "Select job";
        }, function (error) {
            alert('Error!');
        });

    }
    // Function for show result
    $scope.ShowResult = function () {
        $scope.Result = "Selected Work type ID : " + $scope.WorkTypeId + " Job ID : " + $scope.JobId;
    }

})

.factory('LocationService', function ($http) { // explained about factory in Part2
    var fac = {};
    fac.GetWorkTypes = function () {
        return $http.get('/WorkType/GetWorkTypes')
    }
    fac.GetJobs = function (workTypeId) {
        return $http.get('/Job/GetJobs?workTypeId=' + workTypeId)
    }
    return fac;
});