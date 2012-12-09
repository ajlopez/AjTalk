
Object subclass: #Server
	instanceVariableNames: 'root listener routes'
	classVariableNames: ''
	poolDictionaries: ''
	category: ''
!

!Server class methods!

new
	^self basicNew initialize
! !

!Server methods!

initialize
	listener := @System.Net.HttpListener !!new.
	routes := ObjectDictionary new.
!

root: directory
	root := directory
!

addPrefix: address
	listener !!Prefixes !!Add: address.
!

get: route do: block
	routes at: route put: block
!

processFile: name context: context
	| input bytes nbytes filename |
	root ifNil: [^false].
	filename := name.
	(filename = '' or: [filename = '/']) ifTrue: [filename := 'index.html'].
	(filename !!StartsWith: '/') ifTrue: [filename := filename !!Substring: 1].
	filename := @System.IO.Path !!Combine: root with: filename.
	
	@System.Console !!WriteLine: filename.

	(@System.IO.File !!Exists: filename) ifFalse: [^false].	

	bytes := @System.Array !!CreateInstance: @System.Byte with: 1024 * 16.

	input := @System.IO.FileStream !!new: filename with: @System.IO.FileMode !!Open.
	[[nbytes := input !!Read: bytes with: 0 with: bytes !!Length] value > 0] whileTrue: [
		context !!Response !!OutputStream !!Write: bytes with: 0 with: nbytes.
	].
	
	input !!Close.	
	context !!Response !!OutputStream !!Close.
	
	^true
!

process: context
	| url |
	url := context !!Request !!Url !!AbsolutePath.
	
	@System.Console !!WriteLine: url.
	
	(self processFile: url context: context) ifTrue: [^self].
	
	(routes contains: url) 
		ifTrue: [
			(routes at: url) value: context !!Request value: context !!Response.
			context !!Response !!Close.
		]
		ifFalse: [
			context !!Response !!Abort
		]
!

start
	listener !!Start.
	@System.Console !!WriteLine: 'start'.
	[true] whileTrue: [
		| context |
		context := listener !!GetContext.
		self process: context.
	].
	@System.Console !!WriteLine: 'end start'
! !

