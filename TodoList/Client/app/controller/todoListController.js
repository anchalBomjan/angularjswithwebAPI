// window.app.controller('toDoController',function($scope,todoService,$window){

//     todoService.getTodos()
//     .then(function(response){
//         var todos=response.data;
//         console.log(todos)
//         $scope.todoItems=todos;
//     });

//     $scope.editItem= function(index){
//         console.log(index)
//         todoService.getTodoById(index)
//         .then(function(response){
//             var tododata = response.data[0];
            
//             // Find the matching item in the todoItems array
//             for (var i = 0; i < $scope.todoItems.length; i++) {
//                 if ($scope.todoItems[i].id === tododata.id) {
//                     // Update the item with the response data
//                     $scope.todoItems[i].title = tododata.title;
//                     $scope.todoItems[i].content = tododata.content;
//                     $scope.todoItems[i].isEditing = true;  // Enable editing mode for this item
//                     break;
//                 }
//             }
//         })
//     };
//     $scope.saveItem=function(index){
//         var todoItem = $scope.todoItems[index];

//         // Call the service to save the updated todo item
//         todoService.updateTodo(todoItem)
//             .then(function(response) {
//                 // Once the item is successfully saved, disable editing mode
//                 $scope.todoItems[index].isEditing = false;
//                 console.log('Todo item saved successfully');
//             })
//             .catch(function(error) {
//                 console.error('Error saving todo item:', error);
//             });
//     }

//     $scope.deleteItem=function(index){
//         todoService.deleteToDo(index).then(function () {
//             $scope.todoItems = $scope.todoItems.filter(function (item) {
//                 return item.index !== index;
//             });
//         });

//     }
// })
window.app.controller('toDoController', function($scope, todoService, $window) {

    // Function to load all todos
    function loadTodos() {
        todoService.getTodos()
        .then(function(response) {
            var todos = response.data;
            console.log(todos);
            $scope.todoItems = todos;
        })
        .catch(function(error) {
            console.error('Error loading todos:', error);
        });
    }

    // Initial load of todos when the controller is initialized
    loadTodos();

    // Edit a todo item
    $scope.editItem = function(index) {
        console.log(index);
        todoService.getTodoById(index)
        .then(function(response) {
            var tododata = response.data;

            // Find the matching item in the todoItems array
            for (var i = 0; i < $scope.todoItems.length; i++) {
                if ($scope.todoItems[i].id === tododata.id) {
                    $scope.todoItems[i].title = tododata.title;
                    $scope.todoItems[i].content = tododata.content;
                    $scope.todoItems[i].isEditing = true;  // Enable editing mode for this item
                    break;
                }
            }
        })
        .catch(function(error) {
            console.error('Error fetching todo item:', error);
        });
    };

    // Save the updated todo item
    $scope.saveItem = function(index) {
        var todoItem = $scope.todoItems[index];

        // Call the service to save the updated todo item
        todoService.updateTodo(todoItem)
            .then(function(response) {
                // Once the item is successfully saved, disable editing mode
                $scope.todoItems[index].isEditing = false;
                console.log('Todo item saved successfully');

                // Reload the todos after saving
                loadTodos();  // Reload the list of todos
            })
            .catch(function(error) {
                console.error('Error saving todo item:', error);
            });
    };

    // Delete a todo item
    $scope.deleteItem = function(index) {
        todoService.deleteToDo(index)
            .then(function() {
                console.log('Todo item deleted successfully');

                // Reload the todos after deletion
                loadTodos();  // Reload the list of todos
            })
            .catch(function(error) {
                console.error('Error deleting todo item:', error);
            });
    };
});
