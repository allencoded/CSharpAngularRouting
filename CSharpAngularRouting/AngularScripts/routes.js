app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode({ enabled: true, requireBase: false });
    $routeProvider
        .when("/Tests", { templateUrl: "view/Home/test", controller: "homeCtrl", caseInsensitiveMatch: true })
        .otherwise({ redirectTo: "/" });
});


app.controller('homeCtrl', function ($scope) {

});