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

ClassDescription subclass:#Metaclass
	instanceVariableNames:'myClass'
	classVariableNames:'ConfirmationQuerySignal'
	poolDictionaries:''
	category:'Kernel-Classes'
!

Object subclass: #Rectangle instanceVariableNames: 'x y width height'
!Rectangle methods!
"Get x"
x
	^x
!
"Get y"
y
	^y
!
"Set x"
x: newX
	x := newX
!
"Set y"
y: newY
	y := newY
!