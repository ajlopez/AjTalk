| dict |

dict := ObjectDictionary new.

[dict isNotNil] assert.

dict at: 'One' put: 1.
dict at: 'Two' put: 2.

[dict isEmpty] assertFalse.
[dict size == 2] assert.
[(dict at: 'One') == 1] assert.
[(dict at: 'Two') == 2] assert.

VirtualMachine exit.

!