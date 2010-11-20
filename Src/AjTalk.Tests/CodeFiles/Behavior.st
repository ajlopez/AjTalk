"First definition for Behavior"

nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

Object class methods!

basicNew
	^self !!newObject.
!

new
	^self basicNew.
! !	

Object methods!

class
	^self !!behavior.
! !	


Object subclass:#Behavior
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

Behavior subclass:#ClassDescription
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

Behavior methods!

subclass: aSymbol
	| newcls |
	newcls := self !!machine !!createClass: aSymbol with: self with: '' with: ''.
	self !!machine !!setGlobalObject: aSymbol with: newcls.
	^newcls.
!

compile: aMethodSource
	| parser |
	parser := @AjTalk.Compiler.Parser new: aMethodSource.
	parser compileInstanceMethod: self.

! !

"Tricky code to access compile: method as instance method"
Object !!metaclass !!setSuperClass: Behavior.
!

Behavior subclass: #NewBehavior.
!

NewBehavior compile: 'myself ^self.'.
!

