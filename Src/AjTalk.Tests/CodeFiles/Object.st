"This is a first test for core library"

nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

Object class methods!

basicNew
	^self !newObject.
!

new
	^self basicNew.
! !	

Object methods!

class
	^self !behavior.
! !	

result := Object new.
resultclass := result class.
!
