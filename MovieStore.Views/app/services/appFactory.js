app.factory('appFactory', ['$http', '$q', function ($http, $q) {
    var factory = {};
    var api = "http://localhost:51153/api/"

    factory.getGenres = function () {
        var q = $q.defer();
        $http.get(api + 'Genre/GetGenres')
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.getGenreById = function (genreID) {
        var q = $q.defer();
        $http.get(api + 'Genre/GetGenreById?id=' + genreID)
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.createGenre = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "Genre/Create",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.updateGenre = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "Genre/Update",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.getMovies = function () {
        var q = $q.defer();
        $http.get(api + 'Movie/GetMovies')
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.getMovieById = function (movieID) {
        var q = $q.defer();
        $http.get(api + 'Movie/GetMovieById?id=' + movieID)
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.createMovie = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "Movie/Create",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.updateMovie = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "Movie/Update",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.getMPAA = function () {
        var q = $q.defer();
        $http.get(api + 'MPAA/GetMPAA')
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.getMpaaById = function (mpaaID) {
        var q = $q.defer();
        $http.get(api + 'MPAA/GetMpaaById?id=' + mpaaID)
        .success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.createMPAA = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "MPAA/Create",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    },

    factory.updateMPAA = function (obj) {
        var q = $q.defer();
        $http({
            method: "POST",
            url: api + "MPAA/Update",
            data: obj
        }).success(function (data) {
            q.resolve(data);
        }).error(function (e) {
            q.reject(e);
        });

        return q.promise;
    }

    return factory;
}]);