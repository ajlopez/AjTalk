
Module import: #Module1.

[Module1 isNil not] assert.
[Module1.Class1 isNil not] assert.

Module import: #Module2.

[Module2 isNil not] assert.
[Module2.Class2 isNil not] assert.

Module import: #{Module2.Submodule2}.

[Module2 isNil not] assert.
[Module2.Submodule2 isNil not] assert.
[Module2.Submodule2.Class22 isNil not] assert.

(Environment new: #MyEnvironment) setCurrent.

Module import: #{Module2.Submodule2}.

Smalltalk setCurrent.

[MyEnvironment.Module2 isNil not] assert.
[MyEnvironment.Module2.Submodule2 isNil not] assert.
[MyEnvironment.Module2.Submodule2.Class22 isNil not] assert.


