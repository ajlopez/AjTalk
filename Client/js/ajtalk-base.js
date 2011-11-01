base = function() {

var Smalltalk;

Number.prototype._max_ = function(x) {
	if (this >= x)
		return this;
	return x;
}

Number.prototype._min_ = function(x) {
	if (this >= x)
		return this;
	return x;
}

Number.prototype['*'] = function(x) {
	return this * x;
}

Number.prototype['@'] = function(x) {
	var point = new Smalltalk.Point();
	console.log('new Point with ' + this + ' and ' + x);
	point._setX_setY_(this, x);
	return point;
}

Number.prototype['_do_'] = function(block) {
	for (var k=1; k<=this; k++)
		block(k);
}

Boolean.prototype._ifTrue_ = function(block) {
	if (this == true)
		return block();
	return null;
}

Boolean.prototype._ifTrue_ifFalse_ = function(blockTrue, blockFalse) {
	if (this == true)
		return blockTrue();
	else
		return blockFalse();
}

Boolean.prototype._ifFalse_ = function(block) {
	if (this == false)
		return block();
	return null;
}

Function.prototype._isBlock = function() { return true; }

Object.prototype._isBlock = function() { return false; }

var send = function(receiver, selector, args)
{
	console.log('Sending ' + selector + ' to ' + receiver);
	if (args == undefined)
		return receiver[selector].apply(receiver);
	return receiver[selector].apply(receiver, args);
}

var sendSuper = function(receiver, clazz, selector, args)
{
	return clazz.__super.prototype[selector].apply(receiver, args);
}

var using = function(st) {
	Smalltalk = st;
}

return {
	send: send,
	sendSuper: sendSuper,
	using: using
}

}();
