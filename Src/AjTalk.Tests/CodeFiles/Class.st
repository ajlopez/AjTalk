"First definition for Class"

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

ClassDescription subclass:#Class
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

"Tricky code: first knot in class hierarchy"
Object !!metaclass !!setSuperClass: Class.
Class !!defineInstanceMethod: (@AjTalk.Language.BehaviorDoesNotUnderstandMethod new: (Class !!machine)).
Class !!machine !!classClass: Class.
!

ClassDescription subclass:#Metaclass
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

Class methods!

subclass: aSymbol
	| newcls |
	newcls := self !!machine !!createClass: aSymbol with: self with: '' with: ''.
	self !!machine !!setGlobalObject: aSymbol with: newcls.
	^newcls.
!

subclass: aSymbol
	instanceVariableNames: instVarNames	
	classVariableNames: classVarNames
	poolDictionaries: poolDicts
	category: aCategory
	| newcls |
	newcls := self !!machine !!createClass: aSymbol with: self with: instVarNames with: classVarNames.
	self !!machine !!setGlobalObject: aSymbol with: newcls.
	^newcls.
! !

Object subclass: #MyClass.
!

Object subclass: #Rectangle
	instanceVariableNames: 'width height'
	classVariableNames: 'number'
	poolDictionaries: ''
	category: 'Test'.
!

Rectangle methods!

width
	^width.
!

width: newValue
	width := newValue.
!

height
	^height.
!

height: newValue
	height := newValue.

! !

rect := Rectangle new width: 100; height: 50.

!
