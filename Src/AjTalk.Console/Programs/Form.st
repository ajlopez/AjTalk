"Forms definition"

Object subclass: #Form nativeType: @System.Windows.Forms.Form!

Form methods!

run
	@System.Windows.Forms.Application run: self
!

add: aControl
	self controls add: aControl
! !

Object subclass: #Button nativeType: @System.Windows.Forms.Button!

Button methods!

dock
	self dock: (@System.Windows.Forms.DockStyle fill)
! !

Object subclass: #TextBox nativeType: @System.Windows.Forms.TextBox!

