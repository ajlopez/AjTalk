"First definition for Object"

nil subclass:#Object
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:'Kernel-Objects'
!

!Object methods!

= anObject
	^@AjTalk.Language.ObjectOperators equals: self with: anObject.
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
	(@AjTalk.Exceptions.ErrorException new: aMessage) raise
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

