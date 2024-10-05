(function($) {
  'use strict';
  if ($('.grid').length) {
    var colcade = new Colcade('.grid', {
      columns: '.grid-col',
      elements: '.grid-element'
    });
  }
})(jQuery);