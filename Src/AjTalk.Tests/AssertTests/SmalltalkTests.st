
[Smalltalk isNil not] assert.

[(Smalltalk at: #Smalltalk) == Smalltalk] assert.
[(Smalltalk at: #Machine) == Machine] assert.
[(Smalltalk at: #Object) == Object] assert.

One := 1.

[(Smalltalk at: #One) == 1] assert.

Smalltalk at: #Two put: 2.

[(Smalltalk at: #Two) == 2] assert.

