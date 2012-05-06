
http = require('http');

var AjTalk = require('./Program.js');
var base = require('./js/ajtalk-base.js');
var send = base.send;
base.using(AjTalk);

console.log('loaded');

var page = new AjTalk.HtmlPage();

function Response(res) {
	this.write_ = function(text) { res.write(text); }
}

http.createServer(function(req,res) {
	var html = new AjTalk.HtmlCanvas();
	html.$response = new Response(res);
	page.render_(html);
	res.end();
}).listen(8080);

