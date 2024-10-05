(function($) {
  'use strict';
  if ($("#fileuploader").length) {
    $("#fileuploader").uploadFile({
      url: "../../~/Admin/assets/images/",
      fileName: "myfile"
    });
  }
})(jQuery);