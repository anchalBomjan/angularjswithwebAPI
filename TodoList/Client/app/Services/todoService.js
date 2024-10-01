window.app.factory("todoService", function ($http) {
    var baseUrl = "https://localhost:44303/api/ToDo";
   
    var service = {};
    service.todoItems = [{}];
    service.todoItem={};

    service.getTodos = function () {
        return $http.get(baseUrl);
    };

    service.getTodoById=function(id){
        return $http.get(baseUrl + '/' + id);
    };

    service.addTodo = function (newTodo) {
        return $http.post(baseUrl, newTodo).then(function (response) {
            service.todoItems.push(response.data);
            service.newTodo = {};
        });
    };

    service.updateTodo = function(todoItem) {
        return $http.put(baseUrl, todoItem);
    };

    service.deleteToDo = function (id) {
        return $http.delete(baseUrl + "/" + id);
    };

    return service;
});
