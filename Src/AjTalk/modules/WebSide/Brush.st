Object subclass: #Brush
    instanceVariableNames: 'tag canvas closed attributes'
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Web'
!

!Brush class methods!

style: name
    self compile: name , ': value
        self attribute: ''style'' add: ''' , name , ': '' , value , '';'''.
!

new: tag
    | brush |
    brush := self basicNew.
    brush initialize.
    brush tag: tag.
    ^brush
! !

!Brush methods!

initialize
    closed := false
!

attribute: name
    attributes ifNil: [^nil].
    (attributes contains: name) ifTrue: [^attributes at: name].
    ^nil.
!

attribute: name value: value
    attributes ifNil: [attributes := ObjectDictionary new].
    attributes at: name put: value.
!

attribute: name add: value
    | oldvalue |
    oldvalue := self attribute: name.
    oldvalue isNil 
        ifTrue: [
            self attribute: name value: value
        ]
        ifFalse: [
            self attribute: name value: oldvalue , ' ', value
        ]
!

renderAttributesOn: canvas
    attributes ifNotNil: [
        attributes keys do: [ :key ||value|
            canvas render: ' ', key.
            value := attributes at: key.
            value ifNotNil: [
                canvas render: '="', value, '"'
            ].
        ]
    ]
!

with: content
    closed := true.
    content isNil 
        ifTrue: [
            canvas render: '<' , tag , '/>'
        ]
        ifFalse: [
            canvas render: '<' , tag.
            self renderAttributesOn: canvas.
            canvas render: '>'.
            content renderOn: canvas.
            canvas render: '</', tag , '>'
        ]
!

canvas: aCanvas
    canvas := aCanvas
!

close
    closed ifFalse: [self with: nil]
!

tag: aTag
    tag := aTag
! !

Brush subclass: #Paragraph
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Web'
!

!Paragraph class methods!

new
    ^self new: 'p'
! !

Brush subclass: #Header
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Web'
! !

!Header class methods!

new
    ^self new: 'h1'
! !

!Header methods!

level: aLevel
    tag = 'h' , aLevel
! !

Brush subclass: #Div
    instanceVariableNames: ''
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Web'
! !

!Div class methods!

new
    ^self new: 'div'
! !

Brush style: #width.
Brush style: #height.


