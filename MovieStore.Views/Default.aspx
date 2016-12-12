<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="app">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container" ng-view>
    
    </div>

    <script src="Scripts/angular.min.js"></script> 
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/angular.min.js"></script> 
    <script src="app/app.js"></script>
    <script src="app/controller/homeController.js"></script>
    <script src="app/controller/genreController.js"></script>
    <script src="app/controller/ratingController.js"></script>
    <script src="app/controller/movieController.js"></script>
    <script src="app/controller/reportController.js"></script>
    <script src="app/services/appFactory.js"></script>
</body>
</html>
