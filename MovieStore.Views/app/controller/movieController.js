app.controller('MovieController', ['$scope', '$route', 'appFactory', function ($scope, $route, appFactory) {

    $scope.isAdding = false;
    $scope.isEditMode = false;
    $scope.movies = {};
    $scope.movieDTO = {};

    $scope.initialize = function () {
        appFactory.getGenres()
        .then(function (data) {
            $scope.genres = data;
        });

        appFactory.getMPAA()
        .then(function (data) {
            $scope.mpaas = data;
        });

        $scope.actions.get();
        //$scope.actions.update();
    };

    $scope.actions = {

        get: function () {
            var promise = appFactory.getMovies();
            promise.then(function (data) {
                $scope.movies = data;
            });
        },

        create: function () {
            $scope.movieDTO.Enable = true;
            var promise = appFactory.createMovie($scope.movieDTO);
            promise.then(function (data) {
                alert("Movie added!");
                $scope.actions.get();
                $scope.movieDTO = {};
            });
        },

        update: function () {
            var promise = appFactory.updateMovie($scope.movieDTO);
            promise.then(function (data) {
                alert("Movie updated!");
                $scope.actions.get();
                $scope.movieDTO = {};
                $scope.actions.hideFields();
            });
        },

        disable: function (id) {
            appFactory.getMovieById(id).then(function (data) {
                $scope.movieDTO = data;
                $scope.movieDTO.Enable = false;
                
                appFactory.updateMovie($scope.movieDTO).then(function (data) {
                    alert("Movie deleted!");
                    $scope.actions.get();
                });
            });

        },

        showAddFields: function () {
            $scope.isAdding = true;
            $scope.isEditMode = false;
        },

        hideFields: function () {
            $scope.isAdding = false;
            $scope.movieDTO = {};
        },

        editMode: function (id) {
            appFactory.getMovieById(id).then(function (data) {
                $scope.movieDTO = data;
            });

            $scope.isAdding = true;
            $scope.isEditMode = true;
        }
    };
}]);