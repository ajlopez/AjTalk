"Tests for Object"

result := Object new.

Test assert: result isNotNil.

resultclass := result class.

Test assert: resultclass isNotNil.
Test assertAreSame: resultclass with: Object.

Test assert: result == result.
Test assertIsFalse: result == Object new.
Test assertIsFalse: result ~~ result.
Test assert: result ~~ Object new.
Test assert: result = result.
Test assertIsFalse: result = Object new.
Test assertIsFalse: result ~= result.
Test assert: result ~= Object new.
!
