
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
	root := 'c:/apache-tomcat-6.0.18/webapps/docs'.
	@System.Console !!WriteLine: 'initialize'
!

process: context
	| filename input nbytes |
	filename := context !!Request !!Url !!AbsolutePath.
	
	@System.Console !!WriteLine: filename.
	
	(filename = '' or: [filename = '/']) ifTrue: [filename := 'index.html'].
	
	(filename !!StartsWith: '/') ifTrue: [filename := filename !!Substring: 1].
	@System.Console !!WriteLine: filename.
	
	filename := @System.IO.Path !!Combine: root with: filename.

	@System.Console !!WriteLine: filename.	
	
	(@System.IO.File !!Exists: filename) 
	ifFalse: [ context !!Response !!Abort. ]
	ifTrue: [		
		input := @System.IO.FileStream !!new: filename with: @System.IO.FileMode !!Open.
		[[nbytes := input !!Read: bytes with: 0 with: bytes !!Length] value > 0] whileTrue: [
			context !!Response !!OutputStream !!Write: bytes with: 0 with: nbytes.
		].
		
		input !!Close.
		
		context !!Response !!OutputStream !!Close
	]
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
