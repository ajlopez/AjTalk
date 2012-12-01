
Object subclass: #WebServer
	instanceVariableNames: 'root listener bytes'
	classVariableNames: ''
	poolDictionaries: ''
	category: ''
!

!WebServer class methods!

new
	^self basicNew initialize
! !

!WebServer methods!

initialize
	bytes := @System.Array !!CreateInstance: @System.Byte with: 1024 * 16.
	listener := @System.Net.HttpListener !!new.
	listener !!Prefixes !!Add: 'http://*:8000/'.
! !
