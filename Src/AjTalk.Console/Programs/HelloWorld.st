"
Hello World, Program main is invoked when image is loaded

To generate the image
ajtalk Programs\HelloWorld.st -s hello.im

To launch the image
ajtalk hello.im

"!


nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

Object subclass:#Program
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

!Program class methods!

main @System.Console writeLine: 'Hello, world'! !
