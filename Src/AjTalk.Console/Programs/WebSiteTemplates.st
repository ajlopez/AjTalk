
Module import: #Web.
Module import: #Templates.

!

Object subclass:#TemplateServer
    instanceVariableNames:''
    classVariableNames:'templates'
    poolDictionaries:''
    category:'Kernel-Classes'
!

!TemplateServer class methods!

loadTemplate: name
	| filename |
	filename := 'templates/', name , '.tpl'.
	^Templates.Template file: filename
!

processResponse: res template: name model: model
	| stream template|
	template := templates at: name.
	stream := @System.IO.StreamWriter new: res !!OutputStream.
	template run: model stream: stream.		
	stream !!Flush.
!

initialize
	templates := ObjectDictionary new.
	templates at: '/' put: (self loadTemplate: 'index').
	templates at: '/customers' put: (self loadTemplate: 'customers').
!

run
| server customers model |

customers := ObjectList new
	add: (DynamicObject new id: 1; name: 'Customer 1'; yourself);
	add: (DynamicObject new id: 2; name: 'Customer 2'; yourself);
	add: (DynamicObject new id: 3; name: 'Customer 3'; yourself);
	yourself.

model := DynamicObject new customers: customers; yourself.	

server := Web.Server new
	addPrefix: 'http://*:8000/';
	get: '/' do: [ :req :res |
		TemplateServer processResponse: res template: '/' model: nil.
	];
	get: '/customers' do: [ :req :res |
		TemplateServer processResponse: res template: '/customers' model: model.
	];
	start
! !

@System.Console !!WriteLine: (Templates.Template compileTemplate: (@System.IO.File !!ReadAllText: 'templates/customers.tpl')).
TemplateServer initialize run

