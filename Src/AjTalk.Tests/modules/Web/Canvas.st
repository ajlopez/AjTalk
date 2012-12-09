Object subclass:#Canvas
    instanceVariableNames: 'builder brush'
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Web'
!

!Canvas class methods!

define: aSymbol tag: aTag
    | newclass currentenv mthname |
    currentenv := Environment current.
    self scope setCurrent.
    
    newclass := Brush subclass: aSymbol
        instanceVariableNames: ''
        classVariableNames: ''
        poolDictionaries: ''
        category: 'Web'.    
        
    mthname := (aSymbol !!Substring: 0 with: 1) toLower , (aSymbol !!Substring: 1).
    
    newclass class compile: 'new ^self new: ' , $' , aTag , $'.
    
    self compile: mthname , '
            | brush |
            brush := ' , aSymbol , ' new.
            brush canvas: self.
            self brush: brush.
            ^brush'.            

    self compile: mthname , ': content
            | brush |
            brush := self ' , mthname , '.
            brush with: content.
            ^brush'.            
    
    currentenv setCurrent.
! !

!Canvas methods!

initialize
    builder := StringBuilder new
!

render: anObject
    anObject ifNotNil: [builder append: (anObject toString)]
!

brush: aBrush
    brush ifNotNil: [brush close].
    brush := aBrush
!

paragraph
    | brush |
    brush := Paragraph new.
    brush canvas: self.
    self brush: brush.
    ^brush
!
    
paragraph: content
    | brush |
    brush := self paragraph.
    brush with: content.
    ^brush
!
    
header
    | brush |
    brush := Header new.
    brush canvas: self.
    self brush: brush.
    ^brush
!
    
header: content
    | brush |
    brush := self header.
    brush with: content.
    ^brush
!

div
    | brush |
    brush := Div new.
    brush canvas: self.
    self brush: brush.
    ^brush
!
    
div: content
    | brush |
    brush := self div.
    brush with: content.
    ^brush
!

asString
    brush ifNotNil: [brush close].
    ^builder toString
! !

!Object methods!

renderOn: canvas
    canvas render: self
! !

!String methods!

renderOn: canvas
    canvas render: self
! !

!UndefinedObject methods!

renderOn: canvas
    ^nil
! !

!Block methods!

renderOn: canvas
    self value
! !

Canvas define: #ListItem tag: 'li'.
Canvas define: #Html tag: 'html'.
Canvas define: #Head tag: 'head'.
Canvas define: #Body tag: 'body'.
Canvas define: #Title tag: 'title'.
Canvas define: #UnorderedList tag: 'ul'.
Canvas define: #OrderedList tag: 'ol'.
Canvas define: #Break tag: 'br'.
Canvas define: #HorizontalRule tag: 'hr'.

!