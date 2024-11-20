/* Function which change ordinary radiobuttons and checkboxes */
function radiocheckchange ( input ) {
	( function($) {
		var htlfndr_input = $( input );
		htlfndr_input.wrap( '<label class="switch-label-check" />' );
		htlfndr_input.after( '<span class="switch" />' );
		htlfndr_input.css( { "display": "none" });
	})( jQuery );
}

function custom_select(){
	if ($('.htlfndr-select-custom').length>0) $('.htlfndr-select-custom').CustomSelect({visRows:4, search:true, modifier: 'mod'});
	var customSelect = $('.htlfndr-custom-select select');
	// FIRST, create the custom select menus from the existing select
	customSelect.each(function() {
		var that = $(this);
		var listID = that.attr('id'),
		groups = that.children('optgroup'),
			theOptions = "",
			startingOption = "",
			customSelect = "";
		//check if there are option groups
		if(groups.length) {
			groups.each(function() {
				var curGroup = $(this);
				var	curName = curGroup.attr('label');
				//Open the option group
				theOptions += '<li class="optgroup">' + curName + '</li>';
				//get the options
				curGroup.children('option').each(function() {
					var curOpt = $(this);
					var curVal = curOpt.attr('value'),
						curHtml = curOpt.html(),
						isSelected = curOpt.attr('selected');
					if(isSelected === 'selected') {
						startingOption = curHtml;
						theOptions += '<li class="selected" data-value="' + curVal + '">' +
							curHtml + '</li>';
					}else {
						theOptions += '<li data-value="' + curVal + '">' + curHtml + '</li>';
					}
				});
				//Close the option group
				//theOptions += '<li class="optgroup-close"></li>';
			});
			//add options not in a group to the top of the list
			that.children('option').each(function() {
				var curOpt = $(this);
				var curVal = curOpt.attr('value'),
					curHtml = curOpt.html(),
					isSelected = curOpt.attr('selected');
				if(isSelected === 'selected') {
					startingOption = curHtml;
					theOptions = '<li class="selected" data-value="' + curVal + '">' + curHtml +
						'</li>' + theOptions;
				}else {
					theOptions = '<li data-value="' + curVal + '">' + curHtml + '</li>' + theOptions;
				}
			});
		} else {
			that.children('option').each(function() {
				var curOpt = $(this);
				var curVal = curOpt.attr('value'),
					curHtml = curOpt.html(),
					isSelected = curOpt.attr('selected');
				if(isSelected === 'selected') {
					startingOption = curHtml;
					theOptions += '<li class="selected" data-value="' + curVal + '">' +
						curHtml + '</li>';
				}else {
					theOptions += '<li data-value="' + curVal + '">' + curHtml + '</li>';
				}
			});
		}
		//build the custom select
		customSelect = '<div class="htlfndr-dropdown-container">' +
			'<div class="htlfndr-dropdown-select fa-angle-down">' +
			'<span class="' + startingOption + '">' + startingOption +
			'</span></div><ul class="htlfndr-dropdown-select-ul" data-role="' + listID +'">' +
			theOptions + '</ul></div> <!-- .htlfndr-dropdown-container -->';
		//append it after the actual select
		$(customSelect).insertAfter(that);
	});

	var	selectdd = $('.htlfndr-dropdown-select'),
		selectul = $('.htlfndr-dropdown-select-ul'),
		selectli = $('.htlfndr-dropdown-select-ul li');

	//THEN make them work
	selectdd.on('click',function(){
		$(this).parent('.htlfndr-dropdown-container').toggleClass('active');
	});
	//Hide it on mouseleave
		selectul.on('mouseleave',function(){
			$(this).parent('.htlfndr-dropdown-container').removeClass('active');
		});
	//select the option
	selectli.on('click',function(){
		var that = $(this);
		//ensure clicking group labels does not cause change
		if(!that.hasClass('optgroup')) {
			var	parentUl = that.parent('ul'),
				thisdd = parentUl.siblings('.htlfndr-dropdown-select'),
				lihtml = that.html(),
				livalue = that.attr('data-value'),
				originalSelect = '#' + parentUl.attr('data-role');
			//close the dropdown
			parentUl.parent('.htlfndr-dropdown-container').toggleClass('active');
			//remove selected class from all list items
			that.siblings('li').removeClass('selected');
			//add .selected to clicked li
			that.addClass('selected');
			//set the value of the hidden input
			$(originalSelect).val(livalue);

			/* Remove class if isset */
			thisdd.children('span').removeClass();
			/* Add class to <span> for adding currency icon */
			thisdd.children('span').addClass(lihtml);
			//change the dropdown text
			thisdd.children('span').html(lihtml);
		}
	});
}
function user_tabs(){
	$( '.htlfndr-user-tabs' ).tabs().removeClass( 'ui-widget-content' ).addClass( 'ui-tabs-vertical ui-helper-clearfix' );
	$( '.htlfndr-user-tabs ul' ).removeClass( 'ui-widget-header' );
	$( '.htlfndr-user-tabs li' ).removeClass( 'ui-corner-top' );

	$( '.htlfndr-user-tabs' ).on('click','li',function(event){
		$('.htlfndr-button-to-top').hide();
		if ($('#htlfndr-user-tab-4').css('display')=='block' || $('#htlfndr-user-tab-5').css('display')=='block')
			$('.htlfndr-button-to-top').show();
	})
	/* Hotel description tabs. Using Responsive tabs script */
	if ( $( '#htlfndr-hotel-description-tabs' ).length ) {
		// This function may be removed. Because Responsive tabs script does not need
		// class 'active' for <li> elements - we use only for markup.
		var list = $('#htlfndr-hotel-description-tabs' ).find( 'ul > li' );
		var active_tab = 0;
		list.each( function() {
			if ( $( this ).hasClass( 'active' ) ) {
				active_tab = parseInt($( this ).attr('data-number'),10);
			}
		});

		$('#htlfndr-hotel-description-tabs').responsiveTabs({
			startCollapsed: 'accordion',
			animation: 'slide',
			active: active_tab
			//active: 4
		});
	}
}
function click_check(){
	$('.navbar-header').on('click','.navbar-toggle',function(event){
		$('.dropdown-toggle.active-on-device').removeClass('active-on-device');
	})
	
	$('#htlfndr-sing-up-form').on('click','a',function(event){
		 $('#htlfndr-sing-up').trigger( "click" );
		//$('.modal-backdrop').hide();
		
	});
	$('#htlfndr-sing-in-form').on('click','a',function(event){
		 $('#htlfndr-sing-in').trigger( "click" );
		//$('.modal-backdrop').hide();
		
	});
	$('body').on('click','.btn-primary',function(event){
	  k=0;
	
	  $(this).parents('form').find('input:required,textarea:required').each(function(){
	   $(this).removeClass('incorrect');
		if ($(this).val()=='') {$(this).addClass('incorrect');k=1;}
	  })
	  if (k==0) return true;
	  return false;
	})
	if ($('.htlfndr-credit-card .glyphicon-remove').length){
		$('.htlfndr-credit-card').on( 'click','.glyphicon-remove', function() {
			$(this).parents('.htlfndr-credit-card').hide();
		})
	}
	if ($('.htlfndr-hotel-post .glyphicon-remove').length){
	$('.htlfndr-hotel-post').on('click','.glyphicon-remove',function(event){
			$(this).parents('.htlfndr-hotel-post').hide();
		})
	}
	
	/* Button "To top" */
	$( '.htlfndr-footer' ).on( 'click','.htlfndr-button-to-top', function() {
		var target = $( '.htlfndr-wrapper' ); // Parent element of the whole page
		$( 'html, body' ).animate( {
				scrollTop: target.offset().top
			}, 800,
			'linear' );
	});
	$(".htlfndr-menu_elements").on("click","a", function (event) {
		event.preventDefault();

		//remove block identifier from href attribute
		var id  = $(this).attr('href'),

		//get to know the height from page beginning to the block with the anchor
			top = $(id).offset().top;
		
		//anonymize the passing to the distance - top in 1500 msec
		$('body,html').animate({scrollTop: top}, 1500);
	});

	/* Function for saving data of selected Grid/Row view in a browser local storage */
	/* Toggle classes by clicking "Grid/Row" buttons on the Search Result page */
	if ( $( '.htlfndr-search-result-sorting').length ) {
		var grid_view, row_view, parent_block;
		grid_view = $( '#htlfndr-grid' );
		row_view = $( '#htlfndr-row' );

		// Find wrapper
		parent_block = $( '.htlfndr-hotel-post-wrapper' );

		// Call a function for getting data of selected view by user
		// from a local storage if it's present. Only for large desktops,
		// because for other there is not "Row view".
		
		// Click on "Grid view" button
		grid_view.on( 'click', function() {
			// Change style of button
			if ( row_view.hasClass( 'htlfndr-active' ) ) {
				htlfndr_preloader();
				row_view.removeClass( 'htlfndr-active' )
			}
			$( this ).addClass( 'htlfndr-active' );
			// Change a classes of parent elements
			parent_block.removeClass( 'col-md-12' );
			parent_block.addClass( 'col-md-4' );
			parent_block.closest( '.htlfndr-search-result').removeClass( 'htlfndr-row-view' );
			parent_block.closest( '.htlfndr-search-result').addClass( 'htlfndr-grid-view' );
			// Call function for saving selected view in local storage
		});
		// Click on "Row view" button
		row_view.on( 'click', function() {
			// Change style of button
			if ( grid_view.hasClass( 'htlfndr-active' ) ) {
				htlfndr_preloader();
				grid_view.removeClass( 'htlfndr-active' )
			}
			$( this ).addClass( 'htlfndr-active' );
			// Change a classes of parent elements
			parent_block.removeClass( 'col-md-4' );
			parent_block.addClass( 'col-md-12' );
			parent_block.closest( '.htlfndr-search-result').removeClass( 'htlfndr-grid-view' );
			parent_block.closest( '.htlfndr-search-result').addClass( 'htlfndr-row-view' );
			// Call function for saving selected view in local storage
		});
	}
	/* Initialize a TinySort plugin for sorting content by selected parameters */
	$( '.htlfndr-search-result-sorting' ).on( 'click','#htlfndr-sort-by-price,#htlfndr-sort-by-rating,#htlfndr-sort-by-popular', function( event ) {
		event.preventDefault();
		htlfndr_select_sorting_parameters( $( this ) );
		htlfndr_preloader();
		var target = event.target;
		switch(target.id) {
			case 'htlfndr-sort-by-price':
				tinysort( '.htlfndr-hotel-post-wrapper', {
					selector: '.htlfndr-hotel-price>.cost'
				});
				break;
			case 'htlfndr-sort-by-rating':
				tinysort( '.htlfndr-hotel-post-wrapper', {
					selector: '.htlfndr-rating-stars',
					data: 'rating',
					order: 'desc'
				});
				break;
			case 'htlfndr-sort-by-popular':
				 tinysort( '.htlfndr-hotel-post-wrapper', {
					selector: '.htlfndr-hotel-reviews>span',
					order: 'desc'
				})
				break;
			default:
			// do nothing
		}
		// Let the sort plugin work
	});

	/* Change number hotels to show */
	$( '.htlfndr-show-number-hotels' ).on( 'click',' > ul > li > a' ,function( event ) {
		event.preventDefault();
		htlfndr_preloader();
		var change_span, change_span_new, change_text, change_number;
		change_span = $( '.htlfndr-show-number-hotels>.dropdown-toggle>span' );
		change_text = $( this ).text().toString();
		// Next variable contains info that will be used for sorting in future
		change_number = parseInt( $( this ).attr( 'data-number' ),10 );
		 // Check if we already have a sorting
		if ( ( $( 'span' ).is( change_span ) ) ||
			( $( change_span ).text().toString() != $( change_text ) ) ) {
			change_span_new = '<span style="display: none;">' + change_text + '</span>';
		}
		if ( $( change_span ).text().toString() != $( change_text ) ) {
			$( change_span ).remove();
		}
		// Display a selected sorting parameter
		$( change_span_new ).appendTo( '.htlfndr-show-number-hotels>.dropdown-toggle' )
			.fadeIn( 'slow' );
	});		

	/* Pagination */
	// Remove focus from links
	$( '.htlfndr-pagination' ).on( 'focus' ,'.pagination > li > a', function() {
		$( this ).blur();
	});

	$( '.htlfndr-pagination').on( 'click','.pagination > li > a', function(event) {
		// Remove event.preventDefault() if need default working links
		event.preventDefault();
		htlfndr_preloader();
		// Create a variable for all items
		var li_page = $( '.htlfndr-pagination .pagination > li' );
		var li_current = $( '.htlfndr-pagination .pagination > .current' );
		var parent = $( this ).parent();
		if ( $( parent ).hasClass( 'htlfndr-left' ) || $( parent ).hasClass( 'htlfndr-right' ) ) {
			if ( $( parent ).hasClass( 'htlfndr-left' ) ) {
				if ( ! $( parent ).next().hasClass( 'current' ) ) {
					$( li_current ).prev().addClass( 'current' );
					$( li_current ).removeClass( 'current' );
				}
			} else if ( ! $( parent ).prev().hasClass( 'current' ) ) {
				$( li_current ).next().addClass( 'current' );
				$( li_current ).removeClass( 'current' );
			}
		} else {
			$( li_page ).removeClass( 'current' );
			$( parent ).addClass( 'current' );
		}
		$( this).unbind("hover");
	});
}
function browser_width(){
	/* Variable for make clear a browser window width */
	var htlfndr_window_width = $( window ).width();

	/* Dropdown menu.
	* Adding some attributes (neccessary for Bootstrap 3+) for the 'a' element
	* to make the dropdown work.
	*/
	if (htlfndr_window_width<1280){
		$('.dropdown-submenu').on( 'click', '>a',function() {
			//$('.open').removeClass('open');
			if ($(this).parent().hasClass('open')) { return true;}
			else{
				$(this).parent().addClass('open');
				return false;
			}
		})
		$('.nav.navbar-nav').on('click','.dropdown',function(){
			$(this).find('.open').removeClass('open');

		});
		$('.pagination').on( 'click','.htlfndr-right,.htlfndr-left', function() {
			$(this).find('a').css({
				'background-color' : '#08c1da',
				'color' : '#fff'
			}).delay(400);
			$(this).find('a').animate({
				'background-color' : 'transparent',
				color : '#000000'
			},200)
		})
	}
	if (htlfndr_window_width<1280 && htlfndr_window_width>767){
		$('.dropdown-submenu').on( 'click','>a', function() {
			$('.open').removeClass('open');				
		})
		$('.nav.navbar-nav').on( 'mouseleave','.dropdown', function() {
			$('.open').removeClass('open');
		})
	}
	if (htlfndr_window_width<900){
		$('.dropdown-submenu').on( 'hover','a', function() {
			$('#htlfndr-main-nav .dropdown-submenu .dropdown-menu').each(function(){
				$(this).css('left','-'+$(this).width()+'px');
			})
		})
		
	}

	// Check, if we have "Row view" on the desktop smaller than 768px
	// and change it to "Grid view" automatically
	if ( (htlfndr_window_width < 768) && $( '.htlfndr-search-result').hasClass( 'htlfndr-row-view' ) ) {
		var htlfndr_search_result = $( '.htlfndr-search-result' );
		htlfndr_search_result.removeClass( 'htlfndr-row-view' );
		htlfndr_search_result.addClass( 'htlfndr-row-view' );
	}
	/* Move sidebar to top of page on mobile */
	if ( htlfndr_window_width < 992 ) {
		var add_to_wishlist = $( '.htlfndr-add-to-wishlist' ).detach();
		var sidebar_top_part = $( '.htlfndr-hotel-visit-card' ).detach();
		sidebar_top_part.insertBefore( '#htlfndr-main-content' );
		sidebar_top_part.wrap( '<aside class="htlfndr-moved-sidebar-part" />' );
		add_to_wishlist.prependTo( sidebar_top_part );
	}
	if ( $( '.htlfndr-payment-page' ).length ) {
		$( 'body' ).find( '.htlfndr-selectmenu > ul' ).css( 'max-height', '150px' );
		if( htlfndr_window_width < 992 ) {
			var sidebar_top_part_2 = $( '.htlfndr-booking-details' ).detach();
			sidebar_top_part_2.insertBefore( '#htlfndr-main-content' );
			sidebar_top_part_2.wrap( '<aside class="htlfndr-moved-sidebar-part" />' );
		}
	}
}
function calendar(){
	$( '#htlfndr-date-out,#htlfndr-date-in,#htlfndr-date-in-cal' ).datepicker({
		showAnim: "drop",
		dateFormat: 'd M yy',
		showOtherMonths: true,
		selectOtherMonths: true,
		minDate: "-0D",
		beforeShow: function () { // Set default next date
			var current_date = $( '#htlfndr-date-in' ).datepicker( 'getDate' );
			if ( current_date ) return {
				minDate: current_date
			}
		}
	});

	// Remove virtual keyboard on touch devices
	$( '#htlfndr-date-in, #htlfndr-date-out,#htlfndr-date-in-cal' ).on( 'focus', function () {
		$( this ).blur();
	});

	// Adding class to datepicker for customizing it styles
	if( $( 'body' ).find( '.ui-datepicker' ).length ) {
		var datepick = $( 'body' ).find( '.ui-datepicker' );
		datepick.addClass( 'htlfndr-datepicker' );
	}

	/* Clear date by clicking on the close icon */
	$('.htlfndr-clear-datepicker').on('click', function(){
		var clearen = $(this).parent().find( 'input' );
		$.datepicker._clearDate(clearen);
	});
}

function slider(){
	/* Initaialize the OWL Carousel for slider on the Main page */
	if ( $( '.htlfndr-slider-section').length ) {
		$( '.owl-carousel' ).owlCarousel({
			singleItem: true,
			autoPlay: 3000,
			pagination: false,
			paginationSpeed: 1000
		});
	}

	/* Initaialize the OWL Carousel for slider on the Room single page */
	if ( $( '#htlfndr-room-slider').length ) {
		$( '.owl-carousel' ).owlCarousel({
			singleItem: true,
			autoPlay: 60000,
			pagination: true,
			paginationSpeed: 1000
		});
	}

	/* Initaialize the OWL Carousel for slider on the Blog page */
	if ( $( '.htlfndr-post-thumbnail' ).hasClass('owl-carousel') ) {
		// Function for moving 'prev-next' slider buttons
		var htlfndr_move_buttons = function() {
			var buttons = $( '.owl-carousel' ).find('.owl-buttons' ).detach();
			buttons.insertBefore('.owl-controls');
		};
		$( '.owl-carousel' ).owlCarousel({
			singleItem: true,
			autoPlay: 60000,
			pagination: true,
			paginationSpeed: 1000,
			navigation: true,
			navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
			afterInit: htlfndr_move_buttons
		});
	}
	/* Initialize price slider */
	var htlfndr_slider = $( '#htlfndr-price-slider' );
	htlfndr_slider.slider({
		range: true,
		min: 0,
		max: 5000,
		values: [ 100, 1000 ],
		slide: function( event, ui ) {
			// Only shows the price online
			$( '#htlfndr-price-show' ).val( '$' + ui.values[ 0 ] + ' - $' + ui.values[ 1 ] );
			$('.price_min').text('$' + ui.values[ 0 ]);
			$('.price_max').text('$' + ui.values[ 1 ]);
			var k=0;
			$('.ui-slider-handle').each(function(){
			  if (k==0) $('.price_min').css({'left':$(this).position().left-20})
				else $('.price_max').css({'left':$(this).position().left-20})
			  k++;

			})
		},
		change: function( event, ui ) {
			// Submit two variables of selected price: start-price and stop-price
			$( '#htlfndr-price-start' ).val(ui.values[ 0 ]);
			$( '#htlfndr-price-stop' ).val(ui.values[ 1 ]);
			$('.price_min').text('$' + ui.values[ 0 ]);
			$('.price_max').text('$' + ui.values[ 1 ]);
			var k=0;
			$('.ui-slider-handle').each(function(){
			  if (k==0) $('.price_min').css({'left':$(this).position().left-20})
				else $('.price_max').css({'left':$(this).position().left-20})
			  k++;

			})
		}
	});
	$( '#htlfndr-price-show' ).val( '$' + htlfndr_slider.slider( 'values', 0 ) +
		' - $' + htlfndr_slider.slider( 'values', 1 ) );
	$('.price_min').text('$' + htlfndr_slider.slider( 'values', 0 ));
	$('.price_max').text('$' + htlfndr_slider.slider( 'values', 1 ));
	var k=0;
	$('.ui-slider-handle').each(function(){
	  if (k==0) $('.price_min').css({'left':$(this).position().left-20})
		else $('.price_max').css({'left':$(this).position().left-20})
	  k++;

	})

}
function edit(){
	var self;
	if ( $( 'ul li' ).hasClass( 'dropdown' ) ) {
		self = $( '.dropdown' );
		var childlink = self.children( 'a' );

		self.each( function() {
			childlink.attr ( {
				'class': 'dropdown-toggle',
				'data-toggle': 'dropdown',
				'role': 'button',
				'aria-haspopup': 'true',
				'aria-expanded': 'false'
			});
		});

		// Adding and removing class to the link on small desktops for the needed effects
		self.on( 'click', function() {
			$( this ).children( 'a' ).toggleClass( 'active-on-device' );
		});
	}

	/* Initialize selectmenu */
	$( '.htlfndr-dropdown' ).selectmenu();

	if( $( 'body' ).find( '.ui-selectmenu-menu' ).length ) {
		var selectmenu = $( 'body' ).find( '.ui-selectmenu-menu' );
		selectmenu.addClass( 'htlfndr-selectmenu' );
		if( $( 'body' ).find( '.htlfndr-payment-page' ).length ) {
			selectmenu.addClass( 'htlfndr-selectmenu-payment-page' );
		}
	}

	/* Calling function for change checkbox view */
	radiocheckchange( ':checkbox' );
	radiocheckchange( '.htlfndr-classic-radio :radio' );
	radiocheckchange( '.htlfndr-check-radios :radio' );
	$( ".htlfndr-check-radios input[type='checkbox']:checked,input[type='radio']:checked" ).each(function(){
		$(this).parent().parent().removeClass( 'hover' ).children('p label').not('.switch-label-check').addClass('mainColor2');
	})
	$( "input[type='checkbox'],input[type='radio']" ).change(function() {

		 $(this).parent().parent().removeClass( 'hover' ).children('label').not('.switch-label-check').removeClass('mainColor2');
		 $("input[type='radio']").parent().parent().removeClass( 'hover' ).children('label').not('.switch-label-check').removeClass('mainColor2');
		 $( ".htlfndr-check-radios input[type='checkbox']:checked,.htlfndr-classic-radio input[type='radio']:checked" ).parent().parent().removeClass( 'hover' ).children('p label').not('.switch-label-check').addClass('mainColor2');
	});
	$('.htlfndr-check-radios label').each(function(){
		$(this).hover( function() {
			$(this).parent().addClass('hover');
		}, function() {
			$( this ).parent().removeClass( 'hover' );
		  });
	})
	/* Adding a 'span' with text for the hotel price string with class 'special-offer' */
	var special_span = '<span class="htlfndr-special">special offer</span>';
	if( $( '#htlfndr-user-tab-4 .htlfndr-hotel-post' ).hasClass( 'special-offer' ) ) {
		self = $( '.htlfndr-hotel-post.special-offer' );
		self.prepend( special_span );
	}
	else if( $( '.htlfndr-hotel-post' ).hasClass( 'special-offer' ) ) {
		self = $( '.htlfndr-hotel-post.special-offer' );
		self.find( '.htlfndr-hotel-price' ).each( function() {
			$( this ).prepend( special_span );
		});
	} else if ( $( '.htlfndr-hotel-visit-card' ).hasClass( 'special-offer' ) ) {
		self = $( '.htlfndr-hotel-visit-card.special-offer' );
		self.find( '.htlfndr-hotel-price' ).prepend( special_span );
	}

	if ( $( '.htlfndr-modify-search-aside.widget' ).length ) {
		// Find out if isset current widget
		var widget, select_id, new_select_menu, new_select_menu_id;
		widget = $( '.htlfndr-modify-search-aside.widget' );
		// Find current selects
		widget.find( '.htlfndr-dropdown' ).each( function() {
			// Save an ID of each select
			select_id = $( this ).attr( 'id' );
			new_select_menu = $( 'body' ).find( '.ui-selectmenu-menu > ul' );
			// Find an ID of the list with select's options, created by Jquery UI
			new_select_menu_id = new_select_menu.attr( 'id' );
			if ( new_select_menu_id == ( select_id + '-menu' ) ) {
				new_select_menu.addClass( 'htlfndr-small-select-menu' );
			}
		})
	}

	/* Initialize User Rating Star script. */
	/* Only for pages with Modify search widget */
	if ( $( '.htlfndr-user-rating' ).length ) {
		$( '.htlfndr-user-rating' ).starrr( {
			emptyStarClass: 'fa fa-star htlfndr-empty-star',
			change: function(e, value) {
				$( '#htlfndr-rating').val( value );
			}
		});
	}


	/* Check, if a checkbox is disabled and then stylize the label */
	if ( $( '.switch-label-check').length ) {
		var find_disabled_check, find_disabled_check_id, needed_label;
		find_disabled_check = $( '.switch-label-check').find( 'input[type="checkbox"],input[type="radio"]' );
		find_disabled_check.each( function() {
			// If our checkbox is disabled, get its ID
			if ( $( this ).prop( 'disabled' ) ) {
				find_disabled_check_id = $(this).attr('id');
			}
			// Compare the getted ID of checkbox with the label's attribute "for"
			needed_label = $( this ).parent().next();
			if ( find_disabled_check_id == needed_label.attr( 'for' ) ) {
				needed_label.addClass( 'label-of-disabled-check' );
			} else {
				needed_label.removeClass( 'label-of-disabled-check' );
			}
		})
	}
	/* Tooltips for Change View buttons */
	$( '[data-toggle="tooltip"]' ).tooltip();

	/* Tabs for single hotel page */
	$( '#htlfndr-gallery-and-map-tabs' ).tabs();
	if ( $( '.htlfndr-hotel-gallery' ).length ) {
		var sync1 = $( '#htlfndr-gallery-synced-1' );
		var sync2 = $( '#htlfndr-gallery-synced-2' );

		sync1.owlCarousel(
			{
				singleItem: true,
				autoPlay: 3000,
				slideSpeed: 1000,
				stopOnHover: true,
				navigation: true,
				navigationText: [
					'<i class="fa fa-angle-left"></i>',
					'<i class="fa fa-angle-right"></i>'
				],
				pagination: false,
				afterAction: htlfndr_synced_slider_position,
				responsiveRefreshRate: 200
			}
		);

		sync2.owlCarousel(
			{
				items: 5,
				itemsDesktop: [
					1199,
					5
				],
				itemsDesktopSmall: [
					991,
					5
				],
				itemsTablet: [
					768,
					3
				],
				itemsMobile: [
					499,
					2
				],
				pagination: false,
				responsiveRefreshRate: 100,
				afterInit: function ( element ) {
					element.find( '.owl-item' ).eq( 0 ).addClass( 'synced' );
				}
			}
		);

		sync2.on( 'click', '.owl-item', function ( event ) {
				event.preventDefault();
				var number = $( this ).data( 'owlItem' );
				sync1.trigger( 'owl.goTo', number );
			}
		);
	}
	/* End initializing of OWL Carousel on the hotel single page (gallery + map) */

	make_hover( $( '.htlfndr-select-hotel-button, .htlfndr-read-more-button, .htlfndr-follow-button' ) );

	/* Function fallback for <meter> tag if browser have not support it */
	var no_meter_support = function() {
		return( 'value' in document.createElement('meter'));
	};

	if( no_meter_support() === false ) {
		var meter, fake_meter, fake_meter_fill, fake_meter_fill_width;
		meter = $( '.htlfndr-meter' );

		meter.each( function() {
			// Remove border from <meter> tag
			$( this ).css( 'border', 'none' );
			// Get <div> within <meter>
			fake_meter = $( this ).children();
			// Get <span> within <div>
			fake_meter_fill = $( this ).children().children();
			// Get 'data-value' attribute from <div>
			fake_meter_fill_width = fake_meter.attr( 'data-value' );
			// Set width of <span>
			fake_meter_fill.css( 'width', (fake_meter_fill_width * 100) + '%' );
		} );
	}

	/* Change view of radio buttons for the Review form */
	// Reverts $.fn.button to jquery ui btn and
	// assigns bootstrap button functionality to $.fn.btn.
	$.fn.btn = $.fn.button.noConflict();
	$( '.htlfndr-radio-set' ).buttonset();
	$( '#htlfndr-radio-card' ).buttonset();

	/* Accordions */
	htlfndr_accordion( '.htlfndr-payment-page #htlfndr-accordion-3' );
	htlfndr_accordion( '.htlfndr-payment-page #htlfndr-accordion-4' );

	/* Form input error highlight */
	if ( $( '.htlfndr-input-error' ).length ) {
		var error_text = '<p class="htlfndr-error-text">Please enter a first and last name using letters only.</p>';
		$( '.htlfndr-input-error' ).after( error_text );
	}	

	/* Initialize counters for User page */
	if( $( 'body' ).find( '.htlfndr-count' ).length ) {
		$( '.htlfndr-count' ).each( function() {
			var $this = $( this );
			$( { Counter: 0 } ).animate( { Counter: $this.text() }, {
				duration: 3000,
				easing: 'swing',
				step: function() {
					$this.text( Math.ceil( this.Counter ) );
				}
			});
		});
	}
}
function htlfndr_accordion(element_id) {
		if ( $(element_id ).length ) {
			$(element_id).find( '.htlfndr-accordion-title' ).on( 'click', function() {
				$( this ).toggleClass( 'active' );
				$(element_id).find( '.htlfndr-accordion-inner' ).slideToggle('fast');
			});
		}
	};
/* Function for verifying and adding sorting parameters, that was selected by user */
function htlfndr_select_sorting_parameters( element ) {
	var sorted_by, show_sort_old, show_sort_new;
	sorted_by = element.text();
	show_sort_old = $( '.htlfndr-show-sort');
	// Check if we already have a sorting
	if ( ( $( 'span').is( show_sort_old ) ) ||
		( $( show_sort_old ).text().toString() != $(sorted_by).toString() ) ) {
		show_sort_new = '<span class="htlfndr-show-sort">' + sorted_by + '</span>';
	}
	if ( $( show_sort_old ).text().toString() != $(sorted_by).toString() ) {
		$( show_sort_old ).remove();
	}
	// Check if we already have a class
	if ( ! $( '.htlfndr-sort ' ).hasClass( 'sorted' ) ) {
		$( '.htlfndr-sort ').addClass( 'sorted' );
	}
	// Display a selected sorting parameter
	$(show_sort_new).insertAfter( '.htlfndr-sort>.dropdown-toggle' ).fadeIn( 'slow' );
}
/* Function for overlay preloader */
function htlfndr_preloader() {
	// Show preload overlay
	$( '.htlfndr-loader-overlay' ).fadeIn( 100 );
	// Stop preload overlay
	setTimeout( function() {
		$( '.htlfndr-loader-overlay' ).css( 'display', 'none' );
	}, 400);
}
/* Start initializing of OWL Carousel on the hotel single page (gallery) */
function htlfndr_synced_slider_position( element ) {
	var current = this.currentItem;
	$( '#htlfndr-gallery-synced-2' )
		.find( '.owl-item' )
		.removeClass( 'synced' )
		.eq( current )
		.addClass( 'synced' );
	if ( undefined !== $( '#htlfndr-gallery-synced-2' ).data( 'owlCarousel' ) ) {
		htlfndr_synced_center( current );
	}
}

function htlfndr_synced_center( number ) {
	var sync2 = $( '#htlfndr-gallery-synced-2' );
	var sync2visible = sync2.data( 'owlCarousel' ).owl.visibleItems;
	var num = number;
	var found = false;
	for ( var i in sync2visible ) {
		if ( num === sync2visible[i] ) {
			found = true;
		}
	}

	if ( false === found ) {
		if ( num > sync2visible[sync2visible.length - 1] ) {
			sync2.trigger( 'owl.goTo', num - sync2visible.length + 2 )
		} else {
			if ( -1 === num - 1 ) {
				num = 0;
			}
			sync2.trigger( 'owl.goTo', num );
		}
	} else if ( num === sync2visible[sync2visible.length - 1] ) {
		sync2.trigger( 'owl.goTo', sync2visible[1] )
	} else if ( num === sync2visible[0] ) {
		sync2.trigger( 'owl.goTo', num - 1 )
	}
}
/* Function which make to see a hover effects for buttons on mobile  */
function make_hover( button ) {

	button.on( 'touchend', function( event ) {
		event.preventDefault();
		var element = $( this );
		element.addClass( 'hovered' );
		var link = element.attr( 'href' );
		setTimeout( function() {
			window.location = link;
		}, 500);
	});
}
( function($) {
	"use strict";

	/* Let's to know what browser is used. Needed for IE. */
	var doc = document.documentElement;
	doc.setAttribute( 'data-useragent', navigator.userAgent );

	/* Initialize Tabs on the User Page */
	$( document ).ready( function() {
		user_tabs();
		click_check();
		custom_select();
		browser_width();
		edit();
		calendar();
		slider();

	});

	var htlfndr_window_width = $( window ).width();

	$( window ).resize(function () {

		if ( htlfndr_window_width < 991 ) {

			var parent_block = $( '.htlfndr-hotel-post-wrapper' );

			if ( parent_block.hasClass( 'col-md-12' ) ) {
				parent_block.removeClass( 'col-md-12' );
				parent_block.addClass( 'col-md-4' );
				parent_block.closest( '.htlfndr-search-result').removeClass( 'htlfndr-row-view' );
				parent_block.closest( '.htlfndr-search-result').addClass( 'htlfndr-grid-view' );
			}
		}
	});

	if ( htlfndr_window_width < 1199 ) {
		$('.htlfndr-user-page .htlfndr-hotel-post-wrapper').css( 'margin-top', '-20px' );
	}
	
})( jQuery );