app.controller('GenreController', ['$scope', '$route', 'appFactory', function ($scope, $route, appFactory) {
    
    $scope.isAdding = false;
    $scope.isEditMode = false;
    $scope.genreObj = {};

    $scope.genreDTO = {};

    $scope.initialize = function () {
        $scope.actions.get();
        //$scope.actions.update();
    };

    $scope.actions = {

        get: function () {
            var promise = appFactory.getGenres();
            promise.then(function (data) {
                $scope.genreObj = data;
            });
        },

        create: function () {
            $scope.genreDTO.Enable = true;
            var promise = appFactory.createGenre($scope.genreDTO);
            promise.then(function (data) {
                alert("Genre Added!");
                $scope.actions.get();
                $scope.genreDTO = {};
            });
        },

        update: function () {
            var promise = appFactory.updateGenre($scope.genreDTO);
            promise.then(function (data) {
                alert("Genre Updated!");
                $scope.actions.get();
                $scope.genreDTO = {};
                $scope.actions.hideFields();
            });
        },

        disable: function (id) {
            appFactory.getGenreById(id).then(function (data) {
                $scope.genreDTO = data;
                $scope.genreDTO.Enable = false;

                appFactory.updateGenre($scope.genreDTO).then(function (data) {
                    alert("Genre deleted!");
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
            $scope.genreDTO = {};
        },

        editMode: function (id) {
            appFactory.getGenreById(id).then(function (data) {
                $scope.genreDTO = data;
            });

            $scope.isAdding = true;
            $scope.isEditMode = true;
        }
    };
    
}]);