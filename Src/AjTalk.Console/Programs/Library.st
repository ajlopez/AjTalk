"This is a first test for core library"

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

"Tricky code to access compile: method as instance method"
Object !!metaclass !!setSuperClass: Behavior.
Object !!setSuperClass: nil.
Behavior !!defineInstanceMethod: (@AjTalk.Language.BehaviorDoesNotUnderstandMethod new: (Behavior !!machine)).
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
