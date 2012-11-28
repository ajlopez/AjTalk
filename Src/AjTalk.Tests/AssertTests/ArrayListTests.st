| list |

list := ArrayList new.

list add: 1.
list add: 2.

[list size == 2] assert.

[(list at: 1) == 1] assert.
[(list at: 2) == 2] assert.

list at: 1 put: 10.

[(list at: 1) == 10] assert
!

| list |

list := ArrayList with: 10.

[list size == 1] assert.
[(list at: 1) == 10] assert
!

