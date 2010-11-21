"Tests for Behavior"

Behavior subclass: #NewBehavior.
!

NewBehavior class compile: 'myself ^self.'.
!

Test assertAreSame: NewBehavior with: NewBehavior myself.
!

