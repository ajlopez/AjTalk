nil subclass: #Object
!

Object subclass: #Collection
!

Collection subclass: #List nativeType: @System.Collections.ArrayList
!

myList := List new
!

myList add: 1
!

myList add: 'foo'
!
