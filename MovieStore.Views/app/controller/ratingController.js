app.controller('RatingController', ['$scope', '$route', 'appFactory', function ($scope, $route, appFactory) {

    $scope.isAdding = false;
    $scope.isEditMode = false;
    $scope.mpaaDTO = {};
    $scope.mpaas = {};

    $scope.initialize = function () {
        $scope.actions.get();
    };

    $scope.actions = {

        get: function () {
            var promise = appFactory.getMPAA();
            promise.then(function (data) {
                $scope.mpaas = data;
            });
        },

        create: function () {
            $scope.mpaaDTO.Enable = true;
            var promise = appFactory.createMPAA($scope.mpaaDTO);
            promise.then(function (data) {
                alert("Rating Added!");
                $scope.actions.get();
                $scope.mpaaDTO = {};
            });
        },

        update: function () {
            var promise = appFactory.updateMPAA($scope.mpaaDTO);
            promise.then(function (data) {
                alert("MPAA Updated!");
                $scope.actions.get();
                $scope.mpaaDTO = {};
                $scope.actions.hideFields();
            });
        },

        disable: function (id) {
            appFactory.getMpaaById(id).then(function (data) {
                $scope.mpaaDTO = data;
                $scope.mpaaDTO.Enable = false;

                appFactory.updateMPAA($scope.mpaaDTO).then(function (data) {
                    alert("MPAA deleted!");
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
            $scope.mpaaDTO = {};
        },

        editMode: function (id) {
            appFactory.getMpaaById(id).then(function (data) {
                $scope.mpaaDTO = data;
            });

            $scope.isAdding = true;
            $scope.isEditMode = true;
        }
    };
}]);