nil subclass: #Object
!

Object subclass: #FileInfo nativeType: @System.IO.FileInfo
!

myFileInfo := FileInfo new: 'Unknown.txt'
!

result := myFileInfo exists
!
