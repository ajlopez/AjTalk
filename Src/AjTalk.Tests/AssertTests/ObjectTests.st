
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

Object subclass: #Rectangle
	instanceVariableNames: 'x y width height'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Kernel-Classes'.
	
rect := Rectangle new.

[rect isMemberOf: Rectangle] assert.
[obj isMemberOf: Rectangle] assertFalse.

[rect isKindOf: Object] assert.
[obj isKindOf: Object] assert.

['foo' isMemberOf: String] assert.
[1 isMemberOf: Integer] assert.

['foo' isMemberOf: Integer] assertFalse.
[1 isMemberOf: String] assertFalse.

[[true] isMemberOf: Block] assert.

