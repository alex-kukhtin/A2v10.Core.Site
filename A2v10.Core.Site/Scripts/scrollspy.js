
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