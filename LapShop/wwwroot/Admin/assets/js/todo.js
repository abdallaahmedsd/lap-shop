(function ($) {
  'use strict';
  var $this = $(".todo-list .todo-element");
  $(".todo-list .todo-element:not(.edit-mode)").append('<div class="edit-icon"><i class="mdi mdi-pencil"></i></div>');

  $(".edit-icon").on("click", function () {
    $(this).parent().addClass("edit-mode");
    $(".todo-list .todo-element button[type='reset']").on("click", function () {
      $(this).closest(".todo-element").addClass("edit-mode");
    });
  });

})(jQuery);