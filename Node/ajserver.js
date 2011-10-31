
http = require('http');

var AjTalk = require('./Program.js');
var base = require('./js/ajtalk-base.js');
var send = base.send;
base.using(AjTalk);

console.log('loaded');

var page = new AjTalk.HtmlPage();

http.createServer(function(req,res) {
	var html = new AjTalk.HtmlCanvas();
	html.response = res;
	page._render_(html);
	res.end();
}).listen(8080);