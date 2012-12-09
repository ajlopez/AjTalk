
Module import: #Web.

!

| server |

server := Web.Server new
	root: 'c:/apache-tomcat-6.0.18/webapps/docs';
	addPrefix: 'http://*:8000/';
	start
!

