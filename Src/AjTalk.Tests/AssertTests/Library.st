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

!Object methods!

yourself
	^self
!

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

Object subclass: #String nativeType: @System.String
!

!String methods!

size
	^self !!Length
! !

Object subclass: #Char nativeType: @System.Char
!

!Char methods!

isDigit
	^@System.Char !!IsDigit: self
!

isLetter
	^@System.Char !!IsLetter: self
! !

Object subclass: #Boolean nativeType: @System.Boolean
!

!Boolean methods!

not
	^self ifTrue: [^false] ifFalse: [^true]
!

or: aBlock
	^self ifTrue: [^true] ifFalse: [aBlock value]
!

and: aBlock
	^self ifTrue: [aBlock value] ifFalse: [^false]

! !

Object subclass: #CompiledBlock nativeType: @AjTalk.Language.Block
!

!CompiledBlock methods!

assert
	^self value ifFalse: [@AjTalk.Exceptions.AssertError new raise]
!

assertFalse
	^self value ifTrue: [@AjTalk.Exceptions.AssertError new raise]
! !

Object subclass:#Collection
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Collections-Abstract'
!

!Collection class methods!

with: anObject
	^ self new
		add: anObject;
		yourself
!

with: firstObject with: secondObject
	^ self new
		add: firstObject;
		add: secondObject;
		yourself
!

with: firstObject with: secondObject with: thirdObject
	^ self new
		add: firstObject;
		add: secondObject;
		add: thirdObject;
		yourself
!

with: firstObject with: secondObject with: thirdObject with: fourthObject
	^ self new
		add: firstObject;
		add: secondObject;
		add: thirdObject;
		add: fourthObject;
		yourself
!

with: firstObject with: secondObject with: thirdObject with: fourthObject with: fifthObject
	^ self new
		add: firstObject;
		add: secondObject;
		add: thirdObject;
		add: fourthObject;
		add: fifthObject;
		yourself
!

with: firstObject with: secondObject with: thirdObject with: fourthObject with: fifthObject with: sixthObject
	^ self new
		add: firstObject;
		add: secondObject;
		add: thirdObject;
		add: fourthObject;
		add: fifthObject;
		add: sixthObject;
		yourself
!

withAll: aCollection
	^(self new: aCollection size)
		addAll: aCollection;
		yourself
! !

!Collection methods!

add: newObject
	self subclassResponsability
!

do: aBlock
	self subclassResponsability
!

anySatisfy: aBlock
	self do: [:each | (aBlock value: each) ifTrue:[^true]].
	^false
!

addAll: aCollection
	aCollection do: [:each | self add: each].
	^aCollection
!

size
	| tally |
	tally := 0.
	self do: [each | tally := tally + 1].
	^tally

! !		

Collection subclass: #ArrayList nativeType: @System.Collections.ArrayList!

!ArrayList methods!

size 
	^self !!Count
! !	