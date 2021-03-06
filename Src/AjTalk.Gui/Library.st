﻿"This is a first test for core library"

nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

Object subclass:#Behavior
	instanceVariableNames:'superclass flags methodDictionary instSize'
	classVariableNames:'SubclassInfo'
	poolDictionaries:''
	category:'Kernel-Classes'
!

!Object methods!

= anObject
	^@AjTalk.Language.ObjectOperators equals: self with: anObject.
!

== anObject
	^@AjTalk.Language.ObjectOperators same: self with: anObject.
!

~= anObject
	^@AjTalk.Language.ObjectOperators negate: self = anObject.
!

~~ anObject
	^@AjTalk.Language.ObjectOperators negate: self == anObject.
!

error: aMessage
	@AjTalk.Language.Primitives raiseException: (@AjTalk.Language.ErrorException new: aMessage).
!

isNil
	^false.
!

isNotNil
	^true.
!

class
	^self !!behavior.
! !

!Behavior methods!

basicNew
	^self !!newObject.
!

new
	^self basicNew.
!

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
Behavior !!defineInstanceMethod: (@AjTalk.Language.BehaviorDoesNotUnderstandMethod new: (Behavior !!machine) with: Behavior).
!

Behavior subclass:#ClassDescription
	instanceVariableNames:'instvars'
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

ClassDescription subclass:#Class
	instanceVariableNames:'name category classvars comment subclasses classFilename package revision environment signature attributes'
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

"Tricky code: first knot in class hierarchy"
Object !!metaclass !!setSuperClass: Class.
Class !!machine !!classClass: Class.
!

ClassDescription subclass:#Metaclass
	instanceVariableNames:'myClass'
	classVariableNames:'ConfirmationQuerySignal'
	poolDictionaries:''
	category:'Kernel-Classes'
!
