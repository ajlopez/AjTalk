
| env |

env := Environment new: #MyEnvironment.

[(Smalltalk at: #MyEnvironment) isNil not] assert.
[(Smalltalk at: #MyEnvironment) == MyEnvironment] assert.

[(env at: #Smalltalk) == Smalltalk] assert.

