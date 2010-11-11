"Data definitions"

Object subclass: #SqlConnection nativeType: @System.Data.SqlClient.SqlConnection!

SqlConnection class methods!

new: connectionString
	^self createObject: connectionString
! !

SqlConnection methods!

executeReader: aQuery
	| command |
	command := @System.Data.SqlClient.SqlCommand !new: aQuery with: self.
	^command executeReader
! !


