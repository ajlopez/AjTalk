"First definition for Behavior"

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

!Behavior class methods!

basicNew
	^self !!newObject.
!

new
	^self basicNew.
! !

!Behavior methods!

subclass: aSymbol
	| newcls |
	newcls := self !!machine !!createClass: aSymbol with: self with: '' with: ''.
	self !!machine !!setGlobalObject: aSymbol with: newcls.
	^newcls.
!

compile: aMethodSource
	| parser |
	parser := @AjTalk.Compiler.Parser new: aMethodSource.
	self !!defineInstanceMethod: (parser !!compileInstanceMethod: self).

! !

"Tricky code to access compile: method as instance method"
Object !!metaclass !!setSuperClass: Behavior.
Object !!setSuperClass: nil.
Behavior !!defineInstanceMethod: (@AjTalk.Language.BehaviorDoesNotUnderstandMethod new: (Behavior !!machine)).
!

