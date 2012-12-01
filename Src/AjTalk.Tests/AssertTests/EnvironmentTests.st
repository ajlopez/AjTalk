
| env myglobal subenv myobj |

"Current environment is Smalltalk"

[Environment current == Smalltalk] assert.

env := Environment new: #MyEnvironment.

"The new environment was defined as global at Smalltalk"

[(Smalltalk at: #MyEnvironment) isNil not] assert.
[(Smalltalk at: #MyEnvironment) == MyEnvironment] assert.
[(Smalltalk at: #MyEnvironment) == env] assert.

[MyEnvironment isNil not] assert.
[MyEnvironment == env] assert.

"Dotted expression syntax sugar for MyEnvironment at: #Smalltalk"

[MyEnvironment.Smalltalk == Smalltalk] assert.

"Dotted expression syntax sugar for Smalltalk at: #MyEnvironment"

[Smalltalk.MyEnvironment == MyEnvironment] assert.

[(env at: #Smalltalk) == Smalltalk] assert.
[(MyEnvironment at: #Smalltalk) == Smalltalk] assert.

"Define a global at Smalltalk environment"

MyGlobal := Object new.

"Switch to env environment"

env setCurrent.

"Current environment check"

[Environment current == env] assert.
[Environment current == Smalltalk.MyEnvironment] assert.

"The current environment is a referenced by a global variable at Smalltalk environment"
[Environment current == MyEnvironment] assert.

"Define a 'global' at current env environment"

MyGlobal := Object new.

"Define a class at current env environment, no change to syntax"

Object subclass:#MyClass
	instanceVariableNames:''
	classVariableNames:''
	poolDictionaries:''
	category:''
.

[(env at: #MyClass) isNil not] assert.
[(Smalltalk at: #MyClass) isNil] assert.

"Compile class method to get MyGlobal from its environment 
(at MyClass creation time:
 each class has an Scope pointing to the environment that was current 
 at the time of class definition. The 'globals' in their methods are resolved using that
 scope"

MyClass class compile: 'global ^MyGlobal'.

"Back to Smalltalk environment"

Smalltalk setCurrent.

"MyClass is not defined here, at env environment"

[MyClass isNil] assert.
[(env at: #MyClass) isNil not] assert.

myglobal := (env at: #MyClass) global.

"The retrieved myglobal is MyGlobal at env, and it's different from MyGlobal at Smalltalk"

[myglobal isNil not] assert.
[myglobal == (env at: #MyGlobal)] assert.
[myglobal ~~ MyGlobal] assert.

"Accesing the same global using dotted name"

[myglobal == MyEnvironment.MyGlobal] assert.

"MyGlobal here is different from MyGlobal at env"

[MyGlobal isNil not] assert.
[(Smalltalk at: #MyGlobal) isNil not] assert.
[MyGlobal == (Smalltalk at: #MyGlobal)] assert.
[(env at: #MyGlobal) isNil not] assert.
[MyGlobal ~~ (env at: #MyGlobal)] assert.

"Sub enviroment"

subenv := Environment new: #MySubenvironment in: MyEnvironment.

[MyEnvironment.MySubenvironment == subenv] assert.

"Smalltalk environment is still accesible from subenvironment"

[MyEnvironment.MySubenvironment.Smalltalk == Smalltalk] assert.

"You can create an object instance of MyEnviroment class"

myobj := MyEnvironment.MyClass new.

[myobj isNil not] assert.
[myobj class == MyEnvironment.MyClass] assert.

"
TODO: to have a way of import (locate, load and set in current environment) a package/module
Maybe:

Package import: #MyLisp.
Package import: #MyWeb.WebServer.

As in Python, a 'package' already imported is retrieved from a cache
"