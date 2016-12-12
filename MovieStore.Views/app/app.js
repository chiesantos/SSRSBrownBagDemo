var app = angular.module('app', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/home', {
        controller: 'HomeController',
        templateUrl: 'app/views/home.html'
    })
    .when('/genre', {
        controller: 'GenreController',
        templateUrl: 'app/views/genre.html'
    })
    .when('/rating', {
            controller: 'RatingController',
            templateUrl: 'app/views/ratings.html'
        })
    .when('/movie', {
        controller: 'MovieController',
        templateUrl: 'app/views/movie.html'
    })
    .when('/reports', {
        controller: 'ReportController',
        templateUrl: 'app/views/reports.html'
    })
    .otherwise({ redirectTo: '/home' });
}]);