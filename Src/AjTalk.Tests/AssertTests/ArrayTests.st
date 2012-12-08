| array |

array := Array new: 3.

[array size == 3] assert.

array at: 1 put: 1.
array at: 2 put: 2.
array at: 3 put: 3.

[(array at: 1) == 1] assert.
[(array at: 2) == 2] assert.
[(array at: 3) == 3] assert.

