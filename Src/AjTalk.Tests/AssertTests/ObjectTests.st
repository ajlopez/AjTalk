
| obj rect |

obj := Object new.

[obj class == Object] assert.
[obj class class == Object class] assert.
[obj class class class == Metaclass] assert.
[obj class class superclass == Class] assert.
[Metaclass superclass == ClassDescription] assert.
[Class superclass == ClassDescription] assert.

[obj isMemberOf: Object] assert.

"TODO fix hierarchy"
"[obj isMemberOf: UndefinedObject] assert."

Object subclass: #Rectangle.

rect := Rectangle new.

[rect isMemberOf: Rectangle] assert.
[obj isMemberOf: Rectangle] assertFalse.

[rect isKindOf: Object] assert.
[obj isKindOf: Object] assert.
