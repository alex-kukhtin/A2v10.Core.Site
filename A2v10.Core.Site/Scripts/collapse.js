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