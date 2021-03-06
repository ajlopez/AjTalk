
var Smalltalk;

global.Number.prototype.max_ = function(x) {
	if (this >= x)
		return this;
	return x;
}

global.Number.prototype.min_ = function(x) {
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
	point.setX_setY_(this, x);
	return point;
}

global.Boolean.prototype.ifTrue_ = function(block) {
	if (this == true)
		return block();
	return null;
}

global.Boolean.prototype.ifTrue_ifFalse_ = function(blockTrue, blockFalse) {
	if (this == true)
		return blockTrue();
	else
		return blockFalse();
}

global.Boolean.prototype.ifFalse_ = function(block) {
	if (this == false)
		return block();
	return null;
}

global.Function.prototype.isBlock = function() { return true; }

global.Object.prototype.isBlock = function() { return false; }

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