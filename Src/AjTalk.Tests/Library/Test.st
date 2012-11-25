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

