/*=========================================================================================
    File Name: wizard-steps.js
    Description: wizard steps page specific js
    ----------------------------------------------------------------------------------------
    Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
    Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

// Wizard tabs with icons setup
(function(window, document, $) {
    'use strict';
    $(document).ready( function(){
        $(".icons-tab-steps").steps({
            headerTag: "h6",
            bodyTag: "fieldset",
            transitionEffect: "fade",
            titleTemplate: '<span class="step">#index#</span> #title#',
            labels: {
                finish: 'Submit'
            },
            onFinished: function (event, currentIndex) {
                alert("Form submitted.");
            }
        });

        // To select event date
        $('.pickadate').pickadate();
     });
})(window, document, jQuery);