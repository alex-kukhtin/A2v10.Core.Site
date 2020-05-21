/*! Copyright © 2012-2017 Alex Kukhtin. All rights reserved. */

(function () {
	if (window.IntersectionObserver && window.IntersectionObserverEntry) {
		new IntersectionObserver(entries => {
			let dy = entries[0].boundingClientRect.y;
			if (dy < 0)
				document.body.classList.add('has-scroll');
			else
				document.body.classList.remove('has-scroll');
		})
		.observe(document.querySelector("#scrollspy"));
	}
})();
/*! Copyright © 2012-2017 Alex Kukhtin. All rights reserved. */

(function () {

	const SELECTOR_DATA_TOGGLE = '[data-toggle="collapse"]'
	const SHOW_CLASS = 'show';
	const COLLAPSED_CLASS = 'collapsed';
	const ARIA_EXPANDED = 'aria-expanded';

	const slice = [].slice;

	const toggleList = slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE))

	function toggle(ev) {
		let t = ev.target.closest(SELECTOR_DATA_TOGGLE);
		if (!t) return;
		let ts = t.getAttribute('data-target');
		if (!ts) return;
		let target = document.querySelector(ts);
		if (!target) return;
		if (target.classList.contains(SHOW_CLASS)) {
			target.classList.remove(SHOW_CLASS);
			t.classList.add(COLLAPSED_CLASS);
			t.setAttribute(ARIA_EXPANDED, false);
		} else {
			target.classList.add(SHOW_CLASS);
			t.classList.remove(COLLAPSED_CLASS);
			t.setAttribute(ARIA_EXPANDED, true);
		}
	}

	for (let el of toggleList) {
		el.addEventListener('click', toggle);
	}

})();