
var AjTalk = require('./Program.js');
var base = require('./js/ajtalk-base.js');
var send = base.send;
base.using(AjTalk);

console.log('loaded');

var obj = new AjTalk.Object();

obj._class();
send(obj, '_class');
var point = new AjTalk.Point();
point._class();

point._setX_setY_(1,2);
console.log(point._x());
console.log(point._y());

var point2 = AjTalk.Point.classPrototype._basicNew();
point2._setX_setY_(Number(3),Number(4));
console.log(point2._x());
console.log(point2._y());

console.log(point2._max());
console.log(point2._min());

var point3 = send(point, '*', [point2]);

console.log(point3._x());

