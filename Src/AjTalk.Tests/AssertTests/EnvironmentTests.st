
| env |

env := Environment new: #MyEnvironment.

[(Smalltalk at: #MyEnvironment) isNil not] assert.
[(Smalltalk at: #MyEnvironment) == MyEnvironment] assert.

[(env at: #Smalltalk) == Smalltalk] assert.

"Define a global at Smalltalk environment"

MyGlobal := Object new.

"Switch to env environment"

env setCurrent.

"Define a 'global' at current env environment"

MyGlobal := Object new.

"Back to Smalltalk environment"

Smalltalk setCurrent.

[MyGlobal isNil not] assert.
[(Smalltalk at: #MyGlobal) isNil not] assert.
[MyGlobal == (Smalltalk at: #MyGlobal)] assert.
[(env at: #MyGlobal) isNil not] assert.
[MyGlobal ~~ (env at: #MyGlobal)] assert.
