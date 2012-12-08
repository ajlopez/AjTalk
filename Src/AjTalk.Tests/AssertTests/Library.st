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

isMemberOf: aClass
	^self class == aClass
!

isKindOf: aClass
	self class == aClass
		ifTrue: [^true]
		ifFalse: [^self class inheritsFrom: aClass]
!

= anObject
	^@AjTalk.Language.ObjectOperators !!equals: self with: anObject.
!

== anObject
	^@AjTalk.Language.ObjectOperators !!same: self with: anObject.
!

~= anObject
	^@AjTalk.Language.ObjectOperators !!negateboolean: self = anObject.
!

~~ anObject
	^@AjTalk.Language.ObjectOperators !!negateboolean: self == anObject.
!

error: aMessage
	(@AjTalk.Exceptions.ErrorException new: aMessage) raise.
!

subclassResponsability
	self error: 'subclass responsability'
!

isNil
	^false.
!

isNotNil
	^true.
!

ifNil: aBlock
	^nil.
!	

ifNotNil: aBlock
	^aBlock value.
!

initialize
	^self.
!

asTransactional 
    ^@AjTalk.Transactions.TransactionalObject new: self with: Machine transactionManager
!

class
	^self !!behavior.
! !

!Behavior methods!

basicNew
	^self !!newObject.
!

new
	^self basicNew initialize.
!

inheritsFrom: aClass
	| aSuperclass |
	aSuperclass := self superclass.
	[aSuperclass == nil]
		whileFalse:
			[aSuperclass == aClass ifTrue: [^true].
			aSuperclass := aSuperclass superclass].
	^false
!

"TODO: review implementation to use current environment"
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

Object subclass: #Integer nativeType: @System.Int32
!

!Integer methods!

timesRepeat: aBlock
	| count |
	count := 1.
	[count <= self]
		whileTrue:
			[aBlock value.
			count := count + 1]	
! !

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

add: newObject withOccurrences: anInteger
	anInteger timesRepeat: [self add: newObject].
	^ newObject
!

anySatisfy: aBlock
	self do: [:each | (aBlock value: each) ifTrue: [^ true]].
	^ false
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

ArrayList !!AddTrait: (Machine !!GetNativeBehavior: @System.Collections.IEnumerable))!

!ArrayList methods!

size 
	^self !!Count
!

add: aValue
	^self !!add: aValue
!

at: anIndex
	^self !!nat: anIndex - 1
!

at: anIndex put: aValue
	^self !!nat: anIndex - 1 put: aValue
! !

Object subclass: #Environment nativeType: @AjTalk.Context!

!Environment class methods!

current
	^Machine !!CurrentEnvironment.
!

new: aName
	| newenv |
	newenv := @AjTalk.Context !!new: Smalltalk.
	Smalltalk at: aName put: newenv.
	newenv at: #Smalltalk put: Smalltalk.
	^newenv
!

new: aName in: anEnvironment
	| newenv |
	newenv := @AjTalk.Context !!new: anEnvironment.
	anEnvironment at: aName put: newenv.
	^newenv
! !

!Environment methods!

setCurrent
	Machine !!CurrentEnvironment: self
!	

at: aName
	^self !!GetValue: aName
!

at: aName put: aValue
	self !!SetValue: aName with: aValue
! !

Object subclass: #FileLoader
	instanceVariableNames: 'e'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Kernel-Classes'
!

!FileLoader class methods!

load: aFilename
	Machine !!LoadFile: aFilename
! !

Object subclass:#Module
	instanceVariableNames: 'e'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Kernel-Classes'
!

!Module class methods!

import: aName
	Machine !!ImportModule: aName
! !

Object subclass: #Block nativeType: @AjTalk.Language.Block
!

Object subclass: #StringBuilder nativeType: @System.Text.StringBuilder
!

Object subclass: #VirtualMachine nativeType: @AjTalk.Machine
!

!VirtualMachine class methods!

exit
	self exit: 0
!

exit: value
	@System.Environment !!Exit: value
! !

"Test class"

Object subclass:#Test
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Test'
!

!Test class methods!

assert: aBoolean
	aBoolean ifFalse: [self error: 'assert'].
!

assertIsFalse: aBoolean
	aBoolean ifTrue: [self error: 'assert'].
!

assert: aBoolean message: aMessage
	aBoolean ifFalse: [self error: aMessage].
!
	
assertIsFalse: aBoolean message: aMessage
	aBoolean ifTrue: [self error: aMessage].
!
	
assertAreEqual: aValue with: otherValue
	self assert: aValue = otherValue message: 'assertAreEqual'.
!

assertAreEqual: aValue with: otherValue message: aMessage
	self assert: aValue = otherValue message: aMessage.
!
	
assertAreSame: aValue with: otherValue
	self assert: aValue == otherValue message: 'assertAreSame'.
!

assertAreSame: aValue with: otherValue message: aMessage
	self assert: aValue == otherValue message: aMessage.
! !

