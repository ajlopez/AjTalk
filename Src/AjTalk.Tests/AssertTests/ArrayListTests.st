| list |

list := ArrayList new.

list add: 1.
list add: 2.

[list size == 2] assert.

[(list at: 1) == 1] assert.
[(list at: 2) == 2] assert.

[list anySatisfy: [ :item | item == 1]] assert.
[list anySatisfy: [ :item | item == 2]] assert.
[list anySatisfy: [ :item | item == 3]] assertFalse.

list at: 1 put: 10.

[(list at: 1) == 10] assert.
!

| list |

list := ArrayList with: 10.

[list size == 1] assert.
[(list at: 1) == 10] assert
!

| list |

list := ArrayList new.
[(list add: 2 withOccurrences: 3) == 2] assert.
[list size == 3] assert.
[(list at: 1) == 2] assert.
[(list at: 2) == 2] assert.
[(list at: 3) == 2] assert.
[list allSatisfy: [ :item | item == 2]] assert.
[list allSatisfy: [ :item | item == 3]] assertFalse.
!

| list |

list := ArrayList new.

list addAll: #(1 2 3).
[list size == 3] assert.
[(list at: 1) == 1] assert.
[(list at: 2) == 2] assert.
[(list at: 3) == 3] assert.

[(list addIfNotPresent: 3) == 3] assert.
[list size == 3] assert.
[(list at: 1) == 1] assert.
[(list at: 2) == 2] assert.
[(list at: 3) == 3] assert.

[(list addIfNotPresent: 4) == 4] assert.
[list size == 4] assert.

!