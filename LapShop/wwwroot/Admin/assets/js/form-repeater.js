(function($) {
  'use strict';
  $(function() {
    $('.repeater').repeater({
      // (Optional)
      // "defaultValues" sets the values of added elements.  The keys of
      // defaultValues refer to the value of the input's name attribute.
      // If a default value is not specified for an input, then it will
      // have its value cleared.
      defaultValues: {
        'text-input': 'foo'
      },
      // (Optional)
      // "show" is called just after an element is added.  The element is hidden
      // at this point.  If a show callback is not given the element will
      // have $(this).show() called on it.
      show: function() {
        $(this).slideDown();
      },
      // (Optional)
      // "hide" is called when a user clicks on a data-repeater-delete
      // element.  The element is still visible.  "hide" is passed a function
      // as its first argument which will properly remove the element.
      // "hide" allows for a confirmation step, to send a delete request
      // to the server, etc.  If a hide callback is not given the element
      // will be deleted.
      hide: function(deleteElement) {
        if (confirm('Are you sure you want to delete this element?')) {
          $(this).slideUp(deleteElement);
        }
      },
      // (Optional)
      // Removes the delete button from the first list element,
      // defaults to false.
      isFirstItemUndeletable: true
    })
  });
})(jQuery);