var base = require('./js/ajtalk-base.js');
var send = base.send;
var sendSuper = base.sendSuper;
var primitives = require('./js/ajtalk-primitives.js');
function ClientCanvasClass()
{
}
function ClientCanvas()
{
}
ClientCanvas.prototype.__class = ClientCanvasClass.prototype;
ClientCanvas.classPrototype = ClientCanvasClass.prototype;
ClientCanvasClass.prototype['_basicNew'] = function() { return new ClientCanvas(); };
ClientCanvas.prototype.html5canvas = null;
ClientCanvas.prototype['_drawLine_to_'] = function(fromPoint, toPoint)
{
    var self = this;
    console.log('_drawLine_to_');
    send(self.html5canvas, '_x1_y1_x2_y2_', [send(fromPoint, '_x'), send(fromPoint, '_y'), send(toPoint, '_x'), send(toPoint, '_y')]);
};
ClientCanvas.prototype['_example1'] = function()
{
    var self = this;
    console.log('_example1');
    send(self, '_drawLine_to_', [send(10, '@', [10]), send(100, '@', [100])]);
};
ClientCanvas.prototype['_example2'] = function()
{
    var self = this;
    var __context = {};
    console.log('_example2');
    send(10, '_do_', [function(k) {
        send(self, '_drawLine_to_', [send(send(k, '*', [10]), '@', [send(k, '*', [10])]), send(send(k, '*', [20]), '@', [send(k, '*', [20])])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};

exports.ClientCanvas = ClientCanvas;
