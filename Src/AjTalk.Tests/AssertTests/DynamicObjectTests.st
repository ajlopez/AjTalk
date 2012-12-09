
| dyn |

dyn := DynamicObject new.

[dyn isNotNil] assert.

[dyn name isNil] assert.

!

| dyn |

dyn := DynamicObject new.

dyn name: 'Joe Doe'.
[dyn name isNotNil] assert.
[dyn name = 'Joe Doe'] assert.

!

VirtualMachine exit.