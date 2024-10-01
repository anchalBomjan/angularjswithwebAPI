window.app.controller('createtoDoController',function($scope,todoService,$location){

    $scope.todo={
        title:'',
        content:''
    }
    $scope.Add=function(){
     
     var newTodo={
         title:$scope.todo.title,
         content:$scope.todo.content
     };
     todoService.addTodo(newTodo)
     $scope.todo.title='';
     $scope.todo.content='';
     $location.path('/todo'); 
 }
})

