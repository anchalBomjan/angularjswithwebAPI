
var app = angular.module('myApp', ['ngRoute'])
.config(['$routeProvider', function($routeProvider){
    $routeProvider
    .when('/home',{
        templateUrl:'app/views/createTodo.html',
        controller: 'createtoDoController'
    })
    .when('/todo',{
        templateUrl: 'app/views/toDoList.html',
        controller:'toDoController'
    })
    .otherwise({
        redirectTo: ''
    });

}])