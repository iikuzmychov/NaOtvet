jQuery(document).ready(function($) {

    jQuery('#wrapper').fitToParent();

    /* ======= Scrollspy ======= */
    $('body').scrollspy({ target: '#header', offset: 400});
    
    /* ======= Fixed header when scrolled ======= */
    
    $(window).bind('scroll', function() {
         if ($(window).scrollTop() > 50) {
             $('#header').addClass('navbar-fixed-top');
         }
         else {
             $('#header').removeClass('navbar-fixed-top');
         }
    });
   
    /* ======= ScrollTo ======= */
    $('a.scrollto').on('click', function(e){
        
        //store hash
        var target = this.hash;
                
        e.preventDefault();
        
		$('html, body').animate({
            scrollTop: $(target).offset().top
        }, 500);
        
        //Collapse mobile menu after clicking
		if ($('.navbar-collapse').hasClass('in')){
			$('.navbar-collapse').removeClass('in').addClass('collapse');
		}
		
	});
});

jQuery.fn.fitToParent = function (options) {

    this.each(function () {

        // Cache the resize element
        var $el = jQuery(this);

        // Get size parent (box to fit element in)
        var $box;
        if( $el.closest('.size-parent').length ) {
            $box = $el.closest('.size-parent');
        } else {
            $box = $el.parent();
        }

        // These are the defaults.
        var settings = jQuery.extend({  
                height_offset: 0,
                width_offset: 0,
                box_height: $box.height(),
                box_width: $box.width(),
        }, options );

        // Setup box and element widths
        var width = $el.width();
        var height = $el.height();
        var parentWidth = settings.box_width - settings.width_offset;
        var parentHeight = settings.box_height - settings.height_offset;

        // Maintin aspect ratio
        var aspect = width / height;
        var parentAspect = parentWidth / parentHeight;

        // Resize to fit box
		newWidth = parentWidth;
		newHeight = (newWidth / aspect);

        // Set new size of element
        $el.width(newWidth);
        $el.height(newHeight); 

    });
};


$(window).resize(function(){	
	jQuery('#wrapper').fitToParent();
});