
Object subclass: #Template
    instanceVariableNames: 'block'
    classVariableNames: ''
    poolDictionaries: ''
    category: 'Templates'
!

!Template class methods!

new: aBlock
    ^self new block: aBlock
!

compileWriteText: text
    ^' stream write: ''', (text !!Replace: '''' with: ''''''), '''.'
!

compileWriteExpression: expr
    ^' stream write: (', expr, ').'
!

compileTemplateWithCode: text
    | code position rest |
    code := ''.
    rest := text.
    position := rest !!IndexOf: '<#'.
    
    [position >= 0] whileTrue: [
        code := code , (self compileWriteText: (rest !!Substring: 0 with: position)).
        rest := rest !!Substring: position + 2.
        position := rest !!IndexOf: '#>'.
        code := code , (rest !!Substring: 0 with: position).
        rest := rest !!Substring: position + 2.
        position := rest !!IndexOf: '<#'.
    ].
    
    code := code , (self compileWriteText: rest).
    ^code.
!

compileTemplate: text
    | code position rest |
    code := ':model :stream |'.
    rest := text.
    position := rest !!IndexOf: '${'.
    
    [position >= 0] whileTrue: [
        code := code , (self compileTemplateWithCode: (rest !!Substring: 0 with: position)).
        rest := rest !!Substring: position + 2.
        position := rest !!IndexOf: '}'.
        code := code , (self compileWriteExpression: (rest !!Substring: 0 with: position)).
        rest := rest !!Substring: position + 1.
        position := rest !!IndexOf: '${'.
    ].
    
    code := code , (self compileTemplateWithCode: rest).
    ^code.
!

file: filename
    ^self text: (@System.IO.File !!ReadAllText: filename)
!

text: text
    | code block |
    code := self compileTemplate: text.
    block := self compileBlock: code.
    ^self new: block
! !

!Template methods!

block: aBlock
    block := aBlock
!

run: model stream: stream
    block value: model value: stream
! !