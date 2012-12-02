
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
	@System.Console !!WriteLine: 'initialize'
!

process: context
	| filename |
	filename := context !!Request !!Url !!AbsolutePath.
	@System.Console !!WriteLine: filename.
!

start
	listener !!Start.
	@System.Console !!WriteLine: 'start'.
	[true] whileTrue: [
		| context |
		@System.Console !!WriteLine: 'get context'.
		context := listener !!GetContext.
		@System.Console !!WriteLine: 'new request'.
		self process: context.
	].
	@System.Console !!WriteLine: 'end start'
! !

WebServer new start
!
