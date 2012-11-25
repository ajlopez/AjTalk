"First definition for Class"

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
Class !!machine !!classClass: Class.
!

ClassDescription subclass:#Metaclass
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Classes'
!

!Class methods!

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

