/*! Copyright © 2012-2025 Alex Kukhtin. All rights reserved. */

(function () {
	if (window.IntersectionObserver && window.IntersectionObserverEntry) {
		let target = document.querySelector("#scrollspy");
		if (!target) return;
		new IntersectionObserver(entries => {
			let dy = entries[0].boundingClientRect.y;
			if (dy < 0)
				document.body.classList.add('has-scroll');
			else
				document.body.classList.remove('has-scroll');
		}).observe(target);
	}
})();