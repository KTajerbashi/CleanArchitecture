/*=========================================================================================
	File Name: form-validation.js
	Description: jquery bootsreap validation js
	----------------------------------------------------------------------------------------
	Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
	Version: 1.0
	Author: PIXINVENT
	Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

(function(window, document, $) {
	'use strict';

	// Input, Select, Textarea validations except submit button
	$("input,select,textarea").not("[type=submit]").jqBootstrapValidation();

})(window, document, jQuery);