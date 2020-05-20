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
(function () {

	const SELECTOR_DATA_TOGGLE = '[data-toggle="collapse"]'

	const slice = [].slice;

	const toggleList = slice.call(document.querySelectorAll(SELECTOR_DATA_TOGGLE))

	function toggle(ev) {
		let cont = ev.target.closest('.container');
		if (!cont)
			return;
		let target = cont.querySelector('.collapse');
		if (target)
			target.classList.toggle('show');
	}

	for (let el of toggleList) {
		el.addEventListener('click', toggle);
	}

})();