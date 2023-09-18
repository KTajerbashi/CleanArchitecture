/*=========================================================================================
	File Name: taskboard.js
	Description: Taskboard elements using dragula js
	--------------------------------------------------------------------------------------
	Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
	Version: 1.0
	Author: GeeksLabs
	Author URL: http://www.themeforest.net/user/geekslabs
==========================================================================================*/

(function(window, document, $) {
    'use strict';
	$(document).ready(function(){
		// Draggable Cards
		dragula([document.getElementById('drag-todos'),  document.getElementById("drag-in-progress"),  document.getElementById("drag-completed"),  document.getElementById("drag-on-hold")]);

		// Change Card color if moved
		dragula([document.getElementById('card-move')])
		.on('drag', function (el) {
			el.className = el.className.replace('card-moved', '');
		}).on('drop', function (el) {
			el.className += ' card-moved';
		}).on('over', function (el, container) {
			container.className += ' card-over';
		}).on('out', function (el, container) {
			container.className = container.className.replace('card-over', '');
	    });
	});
})(window, document, jQuery);