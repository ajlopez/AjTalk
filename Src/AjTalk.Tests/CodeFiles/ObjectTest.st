'First tests for Object'!
'new and basicNew methods belong to Behavior, there are defined here for test purpose'!

!Object class methods!

basicNew
	^self !!newObject.
!

new
	^self basicNew.
! !	

result := Object new.
resultclass := result class.
aresame := result == result.
arenotsame := result == Object new.
notaresame := result ~~ result.
notarenotsame := result ~~ Object new.
areequal := result = result.
arenotequal := result = Object new.
notareequal := result ~= result.
notarenotequal := result ~= Object new.
!
