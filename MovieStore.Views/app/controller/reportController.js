app.controller('ReportController', ['$scope', '$route', '$parse', 'appFactory', function ($scope, $route, $parse, appFactory) {
    var url = "http://localhost:23674/";

    $scope.initialize = function () {
        appFactory.getGenres()
        .then(function (data) {
            $scope.genres = data;
        });
    }

    $scope.generateReport = function (reportName, hasParams, index) {
        var paramString = "";
        var UrlQueryParam = "";

        if (hasParams == true) {
            switch (index) {
                case 2:
                    paramString = "genre=" + $scope.genre;
                    break;
                case 3:
                    paramString = "year=" + $scope.year;
                    break;
            }

            paramString = window.btoa(paramString);
            UrlQueryParam = "?rpt=" + reportName + "&p=" + paramString + "&f=1";
        } else {
            UrlQueryParam = "?rpt=" + reportName + "&f=1";
        }
        
        var NewTab = window.open(url + "ViewReport.aspx" + UrlQueryParam, '_blank');
        NewTab.focus();
    }
}]);