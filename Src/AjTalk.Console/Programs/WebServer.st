
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
!

process: context
	| filename |
	filename := context !!Request !!Url !!AbsolutePath.
	@System.Console !!WriteLine: filename.
	^nil
!

start
	listener !!Start.
	[true] whileTrue: [
		| context |
		context := listener !!GetContext.
		@System.Console !!WriteLine: 'new request'.
		self process: context.
	]
! !

WebServer new start
!
