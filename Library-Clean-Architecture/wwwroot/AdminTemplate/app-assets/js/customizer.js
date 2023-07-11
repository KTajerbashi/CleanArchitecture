// call persian date picker
$('.datepicker').persianDatepicker();
$('.date').persianDatepicker();

$('.date-inline').persianDatepicker({
    inline: true,

});

$('.calendar').persianDatepicker({
    inline: true,

});
(function(window, document, $) {
    'use strict';
    $(document).ready( function(){

        /********************************
        *           Customizer          *
        ********************************/
        var body = $('body'),
        default_bg_color = $('.app-sidebar').attr('data-background-color'),
        default_bg_image = $('.app-sidebar').attr('data-image');

        $('.cz-bg-color span[data-bg-color="'+default_bg_color+'"]').addClass('selected');
        $('.cz-bg-image img[src$="'+default_bg_image+'"]').addClass('selected');

        // Customizer toggle & close button click events  [Remove customizer code from production]
        $('.customizer-toggle').on('click',function(){
            $('.customizer').toggleClass('open');
        });
        $('.customizer-close').on('click',function(){
            $('.customizer').removeClass('open');
        });
        if($('.customizer-content').length > 0){
            $('.customizer-content').perfectScrollbar({
                theme:"dark"
            });
        }

        // Change Sidebar Background Color
        $('.cz-bg-color span').on('click',function(){
            var $this = $(this),
            bgColor = $this.attr('data-bg-color');

            $this.closest('.cz-bg-color').find('span.selected').removeClass('selected');
            $this.addClass('selected');

            $('.app-sidebar').attr('data-background-color', bgColor);
            if(bgColor == 'white'){
                $('.logo-img img').attr('src','../app-assets/img/logo-dark.png');
            }
            else{
                if($('.logo-img img').attr('src') == '../app-assets/img/logo-dark.png'){
                    $('.logo-img img').attr('src','../app-assets/img/logo.png');
                }
            }
        });

        // Change Background Image
        $('.cz-bg-image img').on('click',function(){
            var $this = $(this),
            src = $this.attr('src');

            $('.sidebar-background').css('background-image', 'url(' + src + ')');
            $this.closest('.cz-bg-image').find('.selected').removeClass('selected');
            $this.addClass('selected');
        });

        $('.cz-bg-image-display').on('click',function(){
            var $this = $(this);
            if($this.prop('checked') === true){
                $('.sidebar-background').css('display','block');
            }
            else{
                $('.sidebar-background').css('display','none');
            }
        });


        $('.cz-compact-menu').on('click',function(){
            $('.nav-toggle').trigger('click');
            if($(this).prop('checked') === true){
                $('.app-sidebar').trigger('mouseleave');
                $('.user-settings-wrap').addClass('d-none');
            }
            else{
                $('.user-settings-wrap').removeClass('d-none');
            }
        });

        $('.cz-sidebar-width').on('change',function(){
            var $this = $(this),
            width_val = this.value,
            wrapper = $('.wrapper');

            if(width_val === 'small'){
                $(wrapper).removeClass('sidebar-lg').addClass('sidebar-sm');
            }
            else if(width_val === 'large'){
                $(wrapper).removeClass('sidebar-sm').addClass('sidebar-lg');
            }
            else{
                $(wrapper).removeClass('sidebar-sm sidebar-lg');
            }

        });

    });
})(window, document, jQuery);