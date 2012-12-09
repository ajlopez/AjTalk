
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

| dyn |

dyn := DynamicObject new.

dyn name: 'Customer';
	table: 'customers';
	properties: [ |list| list := ObjectList new.
			list add: [DynamicObject new;
				name: 'Id';
				description: 'Id';
				yourself].
			list add: [DynamicObject new;
				name: 'Name';
				description: 'Customer Name';
				yourself				
			].
			^list
		] value.

[dyn name == 'Customer'] assert.
[dyn table == 'customers'] assert.
[dyn properties size == 2] assert.
[(dyn properties at: 1) name = 'Id'] assert.
[(dyn properties at: 2) name = 'Name'] assert.
!


VirtualMachine exit.