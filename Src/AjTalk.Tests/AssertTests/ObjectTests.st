
| obj |

obj := Object new.

[obj class == Object] assert.
[obj class class == Object class] assert.
[obj class class class == Metaclass] assert.
[obj class class superclass == Class] assert.
[Metaclass superclass == ClassDescription] assert.
[Class superclass == ClassDescription] assert.