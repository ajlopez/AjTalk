
var Smalltalk;

global.Number.prototype._max_ = function(x) {
	if (this >= x)
		return this;
	return x;
}

global.Number.prototype._min_ = function(x) {
	if (this >= x)
		return this;
	return x;
}

global.Number.prototype['*'] = function(x) {
	return this * x;
}

global.Number.prototype['@'] = function(x) {
	var point = new Smalltalk.Point();
	console.log('new Point with ' + this + ' and ' + x);
	point._setX_setY_(this, x);
	return point;
}

global.Boolean.prototype._ifTrue_ = function(block) {
	if (this == true)
		return block();
	return null;
}

global.Boolean.prototype._ifFalse_ = function(block) {
	if (this == false)
		return block();
	return null;
}

exports.send = function(receiver, selector, args)
{
	console.log('Sending ' + selector + ' to ' + receiver);
	return receiver[selector].apply(receiver, args);
}

exports.sendSuper = function(receiver, clazz, selector, args)
{
	return clazz.__super.prototype[selector].apply(receiver, args);
}

exports.using = function(st) {
	Smalltalk = st;
}