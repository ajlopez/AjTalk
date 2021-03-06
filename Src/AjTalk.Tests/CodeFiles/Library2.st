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

"TODO Review implementation, used in Squeak/Pharo Kernel Objects .st"!

Object subclass:#WeakIdentityKeyDictionary
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

"TODO Review implementation, used in Squeak/Pharo Kernel Classes .st"!

Object subclass:#TPureBehavior
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

!TPureBehavior class methods!

classTrait
	^nil

! !

"TODO implement uses: trait for Squeak/Pharo"!

!Behavior methods!

uses: trait instanceVariableNames: instVarNames
	^self instanceVariableNames: instVarNames
!

subclass: nameOfClass  
	uses: trait
	instanceVariableNames: instVarNames
	classVariableNames: classVarNames
	poolDictionaries: poolDictnames
	category: category
	
	^self subclass: nameOfClass
		instanceVariableNames: instVarNames
		classVariableNames: classVarNames
		poolDictionaries: poolDictnames
		category: category
! !

!Object methods!

= anObject
	^@AjTalk.Language.ObjectOperators equals: self with: anObject.
!

initialize
	^self
!

== anObject
	^@AjTalk.Language.ObjectOperators same: self with: anObject.
!

~= anObject
	^@AjTalk.Language.ObjectOperators negateboolean: self = anObject.
!

~~ anObject
	^@AjTalk.Language.ObjectOperators negateboolean: self == anObject.
!

error: aMessage
	(@AjTalk.Exceptions.ErrorException new: aMessage) raise.
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

Object subclass:#Collection
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Collections-Abstract'
!

!Collection methods!

isEmpty
    ^self size == 0
!

size
    | tally |
    tally := 0.
    self do: [:each | tally := tally + 1].
    ^tally

! !

Collection subclass: #TEnumerable nativeType: @System.Collections.IEnumerable!

Object subclass: #String nativeType: @System.String
!

!String methods!

subStrings: separator
	^self !!Split: (separator nat: 0).
!

size
    ^self !!Length
! !


!UndefinedObject methods!

environment
    ^nil
!

classTrait
	^nil
! !

!UndefinedObject class methods!

environment
    ^nil
! !

"To use in PharoCoreKernelObjects, Object initialize"
Object subclass: #WeakIdentityKeyDictionary
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category:'Kernel-Classes'
!

Object subclass: #IdentityDictionary
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category:'Kernel-Classes'
!
 