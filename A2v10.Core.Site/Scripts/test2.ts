
const t = 'i am the test 2-1*';
let xFunc = (t) => { return t + 234; }

[].forEach((t) => {
	console.dir(t + .234e+03);
});

const template = {
	cmd() {
		return t + '212';
	},
	props: {
		a:'55',
		x(f) { return xFunc(f) + 711.55; },
		y() { return 901511; }
	}
};

export default template;