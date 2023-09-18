(function(window, document, $) {
    'use strict';
    $(document).ready(function(){
		$('.chat-application').height( $(window).height() - $('.navbar').height() - 100 );
		$(window).resize(function(){
		    $('.chat-application').height( $(window).height() - $('.navbar').height() - 100 );
		});

		if($('.chat-sidebar').length > 0){
			$('.chat-sidebar').perfectScrollbar();
		}

		$('.chat-app-sidebar-toggle').on('click', function(){
	        $('.chat-sidebar').removeClass('d-none d-sm-none').addClass('d-block d-sm-block');
	        $('.content-overlay').addClass('show');
	    });

	    $('.content-overlay').on('click', function(){
	        $(this).removeClass('show');
	        $('.chat-sidebar').removeClass('d-block d-sm-block').addClass('d-none d-sm-none');
	    });
	});
})(window, document, jQuery);