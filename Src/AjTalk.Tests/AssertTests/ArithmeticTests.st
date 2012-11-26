
[1 == 1] assert.
[1+1 == 2] assert.
[0 < 1] assert.
[0 == 0] assert.
[1 > 0] assert.
[1 > 0.4] assert.
[1 < 1.4] assert.
[0.4 > 0] assert.
[0.4 < 1] assert.
[0.4 >= 0] assert.
[0.4 <= 1] assert.

"test precedence"
[1+2*3 == 9] assert.

[1+(2*3) == 7] assert.

[1/2 == 0.5] assert.
