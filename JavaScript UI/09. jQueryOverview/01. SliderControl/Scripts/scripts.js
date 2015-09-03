(function($) {
	$(document).ready(function() {
		var $current = $('.current').css('opacity', '1'),
			direction = 'right',
			interval;

		$('.btn').on('mouseenter', function() {
			$(this).animate({
				opacity: 1
			}, 200);
		}).on('mouseleave', function() {
			$(this).animate({
				opacity: 0
			}, 200);
		}).on('click', function() {
			window.clearInterval(interval);
			if ($(this).hasClass('left')) {
				direction = 'left';
			} else {
				direction = 'right';
			}

			slide();
			interval = window.setInterval(slide, 5000);
		});
		interval = window.setInterval(slide, 5000);

		function slide() {
			$current.animate({
				opacity: 0
			}, 300, function() {
				$current.removeClass('current');

				if (direction === 'right') {
					$current = $current.next();
					if (!$current[0]) {
						$current = $($('#slider li')[0]);
					}
				} else {
					$current = $current.prev();
					if (!$current[0]) {
						$current = $($('#slider li:last-of-type')[0]);
					}
				}

				$current.addClass('current').animate({
					opacity: 1
				}, 300);
			});
		}
	});
}(jQuery));