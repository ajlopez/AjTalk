"First definition for Object"

nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

Object methods!

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

