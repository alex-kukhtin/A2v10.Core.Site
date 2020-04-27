/*Multi Line comment here
  **/
const t = 22 + 1;
let str211 = `i am \` \" \n the text "" ${t}`;
// single line comment
let xFunc = (t) => { return t + 234; }

[].forEach((t) => {
	console.dir(t + 1.234);
});

var tf=555+1133;
let fx=123 + 55;
const template = {
	cmd() {
		return t + 212;
	},
	props: {
		a:'55',
		x(f) { return xFunc(f) + 711.55; },
		y() { return 901511; },
		f: acyncFunc
	}
};

async function acyncFunc(tx) {
	if (tx.invoke) return (23);
	if (tx.catch) return function () { return tx + 24; }
	return await tx.invoke()
}

export default template;