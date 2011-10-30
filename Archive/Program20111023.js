function ObjectClass()
{
}
function Object()
{
    this._class = new ObjectClass();
}
Object.prototype.$addInstanceVarNamed_withValue_ = function(aName, aValue)
{
    var self = this;
    console.log('$addInstanceVarNamed_withValue_');
    self.$class().$addInstVarName_(aName.$asString());
    self.$instVarAt_put_(self.$class().$instSize(), aValue);
};
Object.prototype.$at_ = function(index)
{
    var self = this;
    console.log('$at_');
    var _primitive = Primitive60(self, index);
    if (_primitive) return _primitive.value;
    ;
    index.$isInteger().$ifTrue_(function() {
        self.$class().$isVariable().$ifTrue_ifFalse_(function() {
            self.$errorSubscriptBounds_(index);
        }
        , function() {
            self.$errorNotIndexable();
        }
        );
    }
    );
    index.$isNumber().$ifTrue_ifFalse_(function() {
        return self.$at_(index.$asInteger());
    }
    , function() {
        self.$errorNonIntegerIndex();
    }
    );
};
Object.prototype.$at_modify_ = function(index, aBlock)
{
    var self = this;
    console.log('$at_modify_');
    return self.$at_put_(index, aBlock.$value_(self.$at_(index)));
};
Object.prototype.$at_put_ = function(index, value)
{
    var self = this;
    console.log('$at_put_');
    var _primitive = Primitive61(self, index, value);
    if (_primitive) return _primitive.value;
    ;
    index.$isInteger().$ifTrue_(function() {
        self.$class().$isVariable().$ifTrue_ifFalse_(function() {
            (index >= 1).$and_(function() {
                index <= self.$size();
            }
            ).$ifTrue_ifFalse_(function() {
                self.$errorImproperStore();
            }
            , function() {
                self.$errorSubscriptBounds_(index);
            }
            );
        }
        , function() {
            self.$errorNotIndexable();
        }
        );
    }
    );
    index.$isNumber().$ifTrue_ifFalse_(function() {
        return self.$at_put_(index.$asInteger(), value);
    }
    , function() {
        self.$errorNonIntegerIndex();
    }
    );
};
Object.prototype.$basicAddInstanceVarNamed_withValue_ = function(aName, aValue)
{
    var self = this;
    console.log('$basicAddInstanceVarNamed_withValue_');
    self.$class().$addInstVarName_(aName.$asString());
    self.$instVarAt_put_(self.$class().$instSize(), aValue);
};
Object.prototype.$basicAt_ = function(index)
{
    var self = this;
    console.log('$basicAt_');
    var _primitive = Primitive60(self, index);
    if (_primitive) return _primitive.value;
    ;
    index.$isInteger().$ifTrue_(function() {
        self.$errorSubscriptBounds_(index);
    }
    );
    index.$isNumber().$ifTrue_ifFalse_(function() {
        return self.$basicAt_(index.$asInteger());
    }
    , function() {
        self.$errorNonIntegerIndex();
    }
    );
};
Object.prototype.$basicAt_put_ = function(index, value)
{
    var self = this;
    console.log('$basicAt_put_');
    var _primitive = Primitive61(self, index, value);
    if (_primitive) return _primitive.value;
    ;
    index.$isInteger().$ifTrue_(function() {
        (index >= 1).$and_(function() {
            index <= self.$size();
        }
        ).$ifTrue_ifFalse_(function() {
            self.$errorImproperStore();
        }
        , function() {
            self.$errorSubscriptBounds_(index);
        }
        );
    }
    );
    index.$isNumber().$ifTrue_ifFalse_(function() {
        return self.$basicAt_put_(index.$asInteger(), value);
    }
    , function() {
        self.$errorNonIntegerIndex();
    }
    );
};
Object.prototype.$basicSize = function()
{
    var self = this;
    console.log('$basicSize');
    var _primitive = Primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    return 0;
};
Object.prototype.$bindWithTemp_ = function(aBlock)
{
    var self = this;
    console.log('$bindWithTemp_');
    return aBlock.$value_value_(self, nil);
};
Object.prototype.$enclosedSetElement = function()
{
    var self = this;
    console.log('$enclosedSetElement');
};
Object.prototype.$ifNil_ifNotNilDo_ = function(nilBlock, aBlock)
{
    var self = this;
    console.log('$ifNil_ifNotNilDo_');
    return aBlock.$value_(self);
};
Object.prototype.$ifNotNilDo_ = function(aBlock)
{
    var self = this;
    console.log('$ifNotNilDo_');
    return aBlock.$value_(self);
};
Object.prototype.$ifNotNilDo_ifNil_ = function(aBlock, nilBlock)
{
    var self = this;
    console.log('$ifNotNilDo_ifNil_');
    return aBlock.$value_(self);
};
Object.prototype.$in_ = function(aBlock)
{
    var self = this;
    console.log('$in_');
    return aBlock.$value_(self);
};
Object.prototype.$presenter = function()
{
    var self = this;
    console.log('$presenter');
    return self.$currentWorld().$presenter();
};
Object.prototype.$readFromString_ = function(aString)
{
    var self = this;
    console.log('$readFromString_');
    return self.$readFrom_(ReadStream.$on_(aString));
};
Object.prototype.$size = function()
{
    var self = this;
    console.log('$size');
    var _primitive = Primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    self.$class().$isVariable().$ifFalse_(function() {
        self.$errorNotIndexable();
    }
    );
    return 0;
};
Object.prototype.$yourself = function()
{
    var self = this;
    console.log('$yourself');
    return self;
};
Object.prototype.$_assoc_ = function(anObject)
{
    var self = this;
    console.log('$_assoc_');
    return Association.$basicNew().$key_value_(self, anObject);
};
Object.prototype.$bindingOf_ = function(aString)
{
    var self = this;
    console.log('$bindingOf_');
    return nil;
};
Object.prototype.$caseOf_ = function(aBlockAssociationCollection)
{
    var self = this;
    console.log('$caseOf_');
    return self.$caseOf_otherwise_(aBlockAssociationCollection, function() {
        self.$caseError();
    }
    );
};
Object.prototype.$caseOf_otherwise_ = function(aBlockAssociationCollection, aBlock)
{
    var self = this;
    console.log('$caseOf_otherwise_');
    aBlockAssociationCollection.$associationsDo_(function(assoc) {
        (assoc.$key().$value().$_equal_(self)).$ifTrue_(function() {
            return assoc.$value().$value();
        }
        );
    }
    );
    return aBlock.$value();
};
Object.prototype.$class = function()
{
    var self = this;
    console.log('$class');
    var _primitive = Primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    self.$primitiveFailed();
};
Object.prototype.$inheritsFromAnyIn_ = function(aList)
{
    var self = this;
    console.log('$inheritsFromAnyIn_');
    aList.$do_(function(elem) {
        Symbol.$hasInterned_ifTrue_(elem.$asString(), function(elemSymbol) {
            var aClass = null;
            (aClass = Smalltalk.$at_ifAbsent_(elemSymbol, function() {
                nil;
            }
            )).$isKindOf_(Class).$and_(function() {
                self.$isKindOf_(aClass);
            }
            ).$ifTrue_(function() {
                return true;
            }
            );
        }
        );
    }
    );
    return false;
};
Object.prototype.$isKindOf_ = function(aClass)
{
    var self = this;
    console.log('$isKindOf_');
    (self.$class() == aClass).$ifTrue_ifFalse_(function() {
        return true;
    }
    , function() {
        return self.$class().$inheritsFrom_(aClass);
    }
    );
};
Object.prototype.$isKindOf_orOf_ = function(aClass, anotherClass)
{
    var self = this;
    console.log('$isKindOf_orOf_');
    return self.$isKindOf_(aClass).$or_(function() {
        self.$isKindOf_(anotherClass);
    }
    );
};
Object.prototype.$isMemberOf_ = function(aClass)
{
    var self = this;
    console.log('$isMemberOf_');
    return self.$class() == aClass;
};
Object.prototype.$respondsTo_ = function(aSymbol)
{
    var self = this;
    console.log('$respondsTo_');
    return self.$class().$canUnderstand_(aSymbol);
};
Object.prototype.$xxxClass = function()
{
    var self = this;
    console.log('$xxxClass');
    return self.$class();
};
Object.prototype.$closeTo_ = function(anObject)
{
    var self = this;
    console.log('$closeTo_');
    return (function() {
        self.$_equal_(anObject);
    }
    ).$ifError_(function() {
        false;
    }
    );
};
Object.prototype.$hash = function()
{
    var self = this;
    console.log('$hash');
    return self.$scaledIdentityHash();
};
Object.prototype.$hashMappedBy_ = function(map)
{
    var self = this;
    console.log('$hashMappedBy_');
    return map.$newHashFor_(self);
};
Object.prototype.$identityHashMappedBy_ = function(map)
{
    var self = this;
    console.log('$identityHashMappedBy_');
    return map.$newHashFor_(self);
};
Object.prototype.$identityHashPrintString = function()
{
    var self = this;
    console.log('$identityHashPrintString');
    return (String('(') , self.$identityHash().$printString()) , ')';
};
Object.prototype.$literalEqual_ = function(other)
{
    var self = this;
    console.log('$literalEqual_');
    return (self.$class() == other.$class()).$and_(function() {
        self.$_equal_(other);
    }
    );
};
Object.prototype.$_equal_ = function(anObject)
{
    var self = this;
    console.log('$_equal_');
    return self == anObject;
};
Object.prototype.$_notequal_ = function(anObject)
{
    var self = this;
    console.log('$_notequal_');
    return (self.$_equal_(anObject)) == false;
};
Object.prototype.$adaptToFloat_andCompare_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToFloat_andCompare_');
    return self.$adaptToFloat_andSend_(rcvr, selector);
};
Object.prototype.$adaptToFloat_andSend_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToFloat_andSend_');
    return self.$adaptToNumber_andSend_(rcvr, selector);
};
Object.prototype.$adaptToFraction_andCompare_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToFraction_andCompare_');
    return self.$adaptToFraction_andSend_(rcvr, selector);
};
Object.prototype.$adaptToFraction_andSend_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToFraction_andSend_');
    return self.$adaptToNumber_andSend_(rcvr, selector);
};
Object.prototype.$adaptToInteger_andCompare_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToInteger_andCompare_');
    return self.$adaptToInteger_andSend_(rcvr, selector);
};
Object.prototype.$adaptToInteger_andSend_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToInteger_andSend_');
    return self.$adaptToNumber_andSend_(rcvr, selector);
};
Object.prototype.$adaptToScaledDecimal_andCompare_ = function(rcvr, selector)
{
    var self = this;
    console.log('$adaptToScaledDecimal_andCompare_');
    return self.$adaptToScaledDecimal_andSend_(rcvr, selector);
};
Object.prototype.$asActionSequence = function()
{
    var self = this;
    console.log('$asActionSequence');
    return WeakActionSequence.$with_(self);
};
Object.prototype.$asActionSequenceTrappingErrors = function()
{
    var self = this;
    console.log('$asActionSequenceTrappingErrors');
    return WeakActionSequenceTrappingErrors.$with_(self);
};
Object.prototype.$asDraggableMorph = function()
{
    var self = this;
    console.log('$asDraggableMorph');
    return (function () {var _aux = StringMorph.$contents_(self.$respondsTo_('dragLabel').$ifTrue_ifFalse_(function() {
        self.$dragLabel();
    }
    , function() {
        self.$printString();
    }
    )).$color_(Color.$white());return _aux;})().$yourself();
};
Object.prototype.$asOrderedCollection = function()
{
    var self = this;
    console.log('$asOrderedCollection');
    return OrderedCollection.$with_(self);
};
Object.prototype.$asSetElement = function()
{
    var self = this;
    console.log('$asSetElement');
};
Object.prototype.$asString = function()
{
    var self = this;
    console.log('$asString');
    return self.$printString();
};
Object.prototype.$asStringOrText = function()
{
    var self = this;
    console.log('$asStringOrText');
    return self.$printString();
};
Object.prototype.$as_ = function(aSimilarClass)
{
    var self = this;
    console.log('$as_');
    return aSimilarClass.$newFrom_(self);
};
Object.prototype.$complexContents = function()
{
    var self = this;
    console.log('$complexContents');
    return self;
};
Object.prototype.$mustBeBoolean = function()
{
    var self = this;
    console.log('$mustBeBoolean');
    return self.$mustBeBooleanIn_(thisContext.$sender());
};
Object.prototype.$mustBeBooleanIn_ = function(context)
{
    var self = this;
    console.log('$mustBeBooleanIn_');
    var proceedValue = null
    context.$skipBackBeforeJump();
    proceedValue = (function () {var _aux = NonBooleanReceiver.$new().$object_(self);return _aux;})().$signal_('proceed for truth.');
    return proceedValue !== false;
};
Object.prototype.$printDirectlyToDisplay = function()
{
    var self = this;
    console.log('$printDirectlyToDisplay');
    self.$asString().$displayAt_(Number(0).$_at_(100));
};
Object.prototype.$withoutListWrapper = function()
{
    var self = this;
    console.log('$withoutListWrapper');
    return self;
};
Object.prototype.$clone = function()
{
    var self = this;
    console.log('$clone');
    var _primitive = Primitive148(self);
    if (_primitive) return _primitive.value;
    ;
    self.$primitiveFailed();
};
Object.prototype.$copy = function()
{
    var self = this;
    console.log('$copy');
    return self.$shallowCopy().$postCopy();
};
Object.prototype.$copyAddedStateFrom_ = function(anotherObject)
{
    var self = this;
    console.log('$copyAddedStateFrom_');
    (self.$class().$superclass().$instSize() + 1).$to_do_(self.$class().$instSize(), function(index) {
        self.$instVarAt_put_(index, anotherObject.$instVarAt_(index));
    }
    );
};
Object.prototype.$copyFrom_ = function(anotherObject)
{
    var self = this;
    console.log('$copyFrom_');
    var mine = null
    var his = null
    var _primitive = Primitive168(self, anotherObject);
    if (_primitive) return _primitive.value;
    ;
    mine = self.$class().$allInstVarNames();
    his = anotherObject.$class().$allInstVarNames();
    Number(1).$to_do_(mine.$size().$min_(his.$size()), function(ind) {
        (mine.$at_(ind).$_equal_(his.$at_(ind))).$ifTrue_(function() {
            self.$instVarAt_put_(ind, anotherObject.$instVarAt_(ind));
        }
        );
    }
    );
    (self.$class().$isVariable() & anotherObject.$class().$isVariable()).$ifTrue_(function() {
        Number(1).$to_do_(self.$basicSize().$min_(anotherObject.$basicSize()), function(ind) {
            self.$basicAt_put_(ind, anotherObject.$basicAt_(ind));
        }
        );
    }
    );
};
Object.prototype.$copySameFrom_ = function(otherObject)
{
    var self = this;
    console.log('$copySameFrom_');
    var myInstVars = null
    var otherInstVars = null
    myInstVars = self.$class().$allInstVarNames();
    otherInstVars = otherObject.$class().$allInstVarNames();
    myInstVars.$doWithIndex_(function(each, index) {
        var match = null;
        ((match = otherInstVars.$indexOf_(each)) > 0).$ifTrue_(function() {
            self.$instVarAt_put_(index, otherObject.$instVarAt_(match));
        }
        );
    }
    );
    Number(1).$to_do_(self.$basicSize().$min_(otherObject.$basicSize()), function(i) {
        self.$basicAt_put_(i, otherObject.$basicAt_(i));
    }
    );
};
Object.prototype.$copyTwoLevel = function()
{
    var self = this;
    console.log('$copyTwoLevel');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = self.$class();
    newObject = self.$clone();
    (newObject == self).$ifTrue_(function() {
        return self;
    }
    );
    __class__.$isVariable().$ifTrue_(function() {
        index = self.$basicSize();
        (function() {
            index > 0;
        }
        ).$whileTrue_(function() {
            newObject.$basicAt_put_(index, self.$basicAt_(index).$shallowCopy());
            index = index - 1;
        }
        );
    }
    );
    index = __class__.$instSize();
    (function() {
        index > 0;
    }
    ).$whileTrue_(function() {
        newObject.$instVarAt_put_(index, self.$instVarAt_(index).$shallowCopy());
        index = index - 1;
    }
    );
    return newObject;
};
Object.prototype.$deepCopy = function()
{
    var self = this;
    console.log('$deepCopy');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = self.$class();
    (__class__ == Object).$ifTrue_(function() {
        return self;
    }
    );
    __class__.$isVariable().$ifTrue_ifFalse_(function() {
        index = self.$basicSize();
        newObject = __class__.$basicNew_(index);
        (function() {
            index > 0;
        }
        ).$whileTrue_(function() {
            newObject.$basicAt_put_(index, self.$basicAt_(index).$deepCopy());
            index = index - 1;
        }
        );
    }
    , function() {
        newObject = __class__.$basicNew();
    }
    );
    index = __class__.$instSize();
    (function() {
        index > 0;
    }
    ).$whileTrue_(function() {
        newObject.$instVarAt_put_(index, self.$instVarAt_(index).$deepCopy());
        index = index - 1;
    }
    );
    return newObject;
};
Object.prototype.$initialDeepCopierSize = function()
{
    var self = this;
    console.log('$initialDeepCopierSize');
    return 4096;
};
Object.prototype.$postCopy = function()
{
    var self = this;
    console.log('$postCopy');
    return self;
};
Object.prototype.$shallowCopy = function()
{
    var self = this;
    console.log('$shallowCopy');
    var __class__ = null
    var newObject = null
    var index = null
    var _primitive = Primitive148(self);
    if (_primitive) return _primitive.value;
    ;
    __class__ = self.$class();
    __class__.$isVariable().$ifTrue_ifFalse_(function() {
        index = self.$basicSize();
        newObject = __class__.$basicNew_(index);
        (function() {
            index > 0;
        }
        ).$whileTrue_(function() {
            newObject.$basicAt_put_(index, self.$basicAt_(index));
            index = index - 1;
        }
        );
    }
    , function() {
        newObject = __class__.$basicNew();
    }
    );
    index = __class__.$instSize();
    (function() {
        index > 0;
    }
    ).$whileTrue_(function() {
        newObject.$instVarAt_put_(index, self.$instVarAt_(index));
        index = index - 1;
    }
    );
    return newObject;
};
Object.prototype.$veryDeepCopy = function()
{
    var self = this;
    console.log('$veryDeepCopy');
    var copier = null
    var __new__ = null
    copier = DeepCopier.$new().$initialize_(self.$initialDeepCopierSize());
    __new__ = self.$veryDeepCopyWith_(copier);
    copier.$mapUniClasses();
    copier.$references().$associationsDo_(function(assoc) {
        assoc.$value().$veryDeepFixupWith_(copier);
    }
    );
    copier.$fixDependents();
    return __new__;
};
Object.prototype.$veryDeepCopySibling = function()
{
    var self = this;
    console.log('$veryDeepCopySibling');
    var copier = null
    var __new__ = null
    copier = DeepCopier.$new().$initialize_(self.$initialDeepCopierSize());
    copier.$newUniClasses_(false);
    __new__ = self.$veryDeepCopyWith_(copier);
    copier.$mapUniClasses();
    copier.$references().$associationsDo_(function(assoc) {
        assoc.$value().$veryDeepFixupWith_(copier);
    }
    );
    copier.$fixDependents();
    return __new__;
};
Object.prototype.$veryDeepCopyUsing_ = function(copier)
{
    var self = this;
    console.log('$veryDeepCopyUsing_');
    var __new__ = null
    var refs = null
    __new__ = self.$veryDeepCopyWith_(copier);
    copier.$mapUniClasses();
    copier.$references().$associationsDo_(function(assoc) {
        assoc.$value().$veryDeepFixupWith_(copier);
    }
    );
    refs = copier.$references();
    DependentsFields.$associationsDo_(function(pair) {
        pair.$value().$do_(function(dep) {
            var newDep = null;
            var newModel = null;
            (newDep = refs.$at_ifAbsent_(dep, function() {
                nil;
            }
            )).$ifNotNil_(function() {
                newModel = refs.$at_ifAbsent_(pair.$key(), function() {
                    pair.$key();
                }
                );
                newModel.$addDependent_(newDep);
            }
            );
        }
        );
    }
    );
    return __new__;
};
Object.prototype.$veryDeepCopyWith_ = function(deepCopier)
{
    var self = this;
    console.log('$veryDeepCopyWith_');
    var __class__ = null
    var index = null
    var sub = null
    var subAss = null
    var __new__ = null
    var uc = null
    var sup = null
    var has = null
    var mine = null
    deepCopier.$references().$at_ifPresent_(self, function(newer) {
        return newer;
    }
    );
    __class__ = self.$class();
    __class__.$isMeta().$ifTrue_(function() {
        return self;
    }
    );
    __new__ = self.$clone();
    __class__.$isSystemDefined().$not().$and_(function() {
        deepCopier.$newUniClasses();
    }
    ).$ifTrue_(function() {
        uc = deepCopier.$uniClasses().$at_ifAbsent_(__class__, function() {
            nil;
        }
        );
        uc.$ifNil_(function() {
            deepCopier.$uniClasses().$at_put_(__class__, uc = self.$copyUniClassWith_(deepCopier));
            deepCopier.$references().$at_put_(__class__, uc);
        }
        );
        __new__ = uc.$new();
        __new__.$copyFrom_(self);
    }
    );
    deepCopier.$references().$at_put_(self, __new__);
    __class__.$isVariable().$and_(function() {
        __class__.$isPointers();
    }
    ).$ifTrue_(function() {
        index = self.$basicSize();
        (function() {
            index > 0;
        }
        ).$whileTrue_(function() {
            sub = self.$basicAt_(index);
            (subAss = deepCopier.$references().$associationAt_ifAbsent_(sub, function() {
                nil;
            }
            )).$ifNil_ifNotNil_(function() {
                __new__.$basicAt_put_(index, sub.$veryDeepCopyWith_(deepCopier));
            }
            , function() {
                __new__.$basicAt_put_(index, subAss.$value());
            }
            );
            index = index - 1;
        }
        );
    }
    );
    __new__.$veryDeepInner_(deepCopier);
    sup = __class__;
    index = __class__.$instSize();
    (function() {
        has = sup.$compiledMethodAt_ifAbsent_('veryDeepInner:', function() {
            nil;
        }
        );
        has = has.$ifNil_ifNotNil_(function() {
            __class__.$isSystemDefined().$not();
        }
        , function() {
            true;
        }
        );
        mine = sup.$instVarNames();
        has.$ifTrue_ifFalse_(function() {
            index = index - mine.$size();
        }
        , function() {
            Number(1).$to_do_(mine.$size(), function(xx) {
                sub = self.$instVarAt_(index);
                (subAss = deepCopier.$references().$associationAt_ifAbsent_(sub, function() {
                    nil;
                }
                )).$ifNil_ifNotNil_(function() {
                    __new__.$instVarAt_put_(index, sub.$veryDeepCopyWith_(deepCopier));
                }
                , function() {
                    __new__.$instVarAt_put_(index, subAss.$value());
                }
                );
                index = index - 1;
            }
            );
        }
        );
        (sup = sup.$superclass()) == nil;
    }
    ).$whileFalse();
    __new__.$rehash();
    return __new__;
};
Object.prototype.$veryDeepFixupWith_ = function(deepCopier)
{
    var self = this;
    console.log('$veryDeepFixupWith_');
};
Object.prototype.$veryDeepInner_ = function(deepCopier)
{
    var self = this;
    console.log('$veryDeepInner_');
};
Object.prototype.$asMorph = function()
{
    var self = this;
    console.log('$asMorph');
    return self.$asStringMorph();
};
Object.prototype.$asStringMorph = function()
{
    var self = this;
    console.log('$asStringMorph');
    return self.$asStringOrText().$asStringMorph();
};
Object.prototype.$asTextMorph = function()
{
    var self = this;
    console.log('$asTextMorph');
    return TextMorph.$new().$contentsAsIs_(self.$asStringOrText());
};
Object.prototype.$openAsMorph = function()
{
    var self = this;
    console.log('$openAsMorph');
    return self.$asMorph().$openInHand();
};
Object.prototype.$haltIf_ = function(condition)
{
    var self = this;
    console.log('$haltIf_');
    var cntxt = null
    condition.$isSymbol().$ifTrue_(function() {
        cntxt = thisContext;
        (function() {
            cntxt.$sender().$isNil();
        }
        ).$whileFalse_(function() {
            cntxt = cntxt.$sender();
            (cntxt.$selector().$_equal_(condition)).$ifTrue_(function() {
                Halt.$signal();
            }
            );
        }
        );
        return self;
    }
    );
    condition.$isBlock().$ifTrue_ifFalse_(function() {
        condition.$valueWithPossibleArgument_(self);
    }
    , function() {
        condition;
    }
    ).$ifTrue_(function() {
        Halt.$signal();
    }
    );
};
Object.prototype.$needsWork = function()
{
    var self = this;
    console.log('$needsWork');
};
Object.prototype.$checkHaltCountExpired = function()
{
    var self = this;
    console.log('$checkHaltCountExpired');
    var counter = null
    counter = Smalltalk.$at_ifAbsent_('HaltCount', function() {
        0;
    }
    );
    return counter.$_equal_(0);
};
Object.prototype.$clearHaltOnce = function()
{
    var self = this;
    console.log('$clearHaltOnce');
    Smalltalk.$at_put_('HaltOnce', false);
};
Object.prototype.$decrementAndCheckHaltCount = function()
{
    var self = this;
    console.log('$decrementAndCheckHaltCount');
    self.$decrementHaltCount();
    return self.$checkHaltCountExpired();
};
Object.prototype.$decrementHaltCount = function()
{
    var self = this;
    console.log('$decrementHaltCount');
    var counter = null
    counter = Smalltalk.$at_ifAbsent_('HaltCount', function() {
        0;
    }
    );
    (counter > 0).$ifTrue_(function() {
        counter = counter - 1;
        self.$setHaltCountTo_(counter);
    }
    );
};
Object.prototype.$doExpiredHaltCount = function()
{
    var self = this;
    console.log('$doExpiredHaltCount');
    self.$clearHaltOnce();
    self.$removeHaltCount();
    self.$halt();
};
Object.prototype.$doExpiredHaltCount_ = function(aString)
{
    var self = this;
    console.log('$doExpiredHaltCount_');
    self.$clearHaltOnce();
    self.$removeHaltCount();
    self.$halt_(aString);
};
Object.prototype.$doExpiredInspectCount = function()
{
    var self = this;
    console.log('$doExpiredInspectCount');
    self.$clearHaltOnce();
    self.$removeHaltCount();
    self.$inspect();
};
Object.prototype.$haltOnCount_ = function(int)
{
    var self = this;
    console.log('$haltOnCount_');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$hasHaltCount().$ifTrue_ifFalse_(function() {
            self.$decrementAndCheckHaltCount().$ifTrue_(function() {
                self.$doExpiredHaltCount();
            }
            );
        }
        , function() {
            (int.$_equal_(1)).$ifTrue_ifFalse_(function() {
                self.$doExpiredHaltCount();
            }
            , function() {
                self.$setHaltCountTo_(int - 1);
            }
            );
        }
        );
    }
    );
};
Object.prototype.$haltOnce = function()
{
    var self = this;
    console.log('$haltOnce');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$clearHaltOnce();
        return self.$halt();
    }
    );
};
Object.prototype.$haltOnceEnabled = function()
{
    var self = this;
    console.log('$haltOnceEnabled');
    return Smalltalk.$at_ifAbsent_('HaltOnce', function() {
        false;
    }
    );
};
Object.prototype.$haltOnce_ = function(aString)
{
    var self = this;
    console.log('$haltOnce_');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$clearHaltOnce();
        return self.$halt_(aString);
    }
    );
};
Object.prototype.$halt_onCount_ = function(aString, int)
{
    var self = this;
    console.log('$halt_onCount_');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$hasHaltCount().$ifTrue_ifFalse_(function() {
            self.$decrementAndCheckHaltCount().$ifTrue_(function() {
                self.$doExpiredHaltCount_(aString);
            }
            );
        }
        , function() {
            (int.$_equal_(1)).$ifTrue_ifFalse_(function() {
                self.$doExpiredHaltCount_(aString);
            }
            , function() {
                self.$setHaltCountTo_(int - 1);
            }
            );
        }
        );
    }
    );
};
Object.prototype.$hasHaltCount = function()
{
    var self = this;
    console.log('$hasHaltCount');
    return self.$class().$environment().$includesKey_('HaltCount');
};
Object.prototype.$inspectOnCount_ = function(int)
{
    var self = this;
    console.log('$inspectOnCount_');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$hasHaltCount().$ifTrue_ifFalse_(function() {
            self.$decrementAndCheckHaltCount().$ifTrue_(function() {
                self.$doExpiredInspectCount();
            }
            );
        }
        , function() {
            (int.$_equal_(1)).$ifTrue_ifFalse_(function() {
                self.$doExpiredInspectCount();
            }
            , function() {
                self.$setHaltCountTo_(int - 1);
            }
            );
        }
        );
    }
    );
};
Object.prototype.$inspectOnce = function()
{
    var self = this;
    console.log('$inspectOnce');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$clearHaltOnce();
        return self.$inspect();
    }
    );
};
Object.prototype.$inspectUntilCount_ = function(int)
{
    var self = this;
    console.log('$inspectUntilCount_');
    self.$haltOnceEnabled().$ifTrue_(function() {
        self.$hasHaltCount().$ifTrue_ifFalse_(function() {
            self.$decrementAndCheckHaltCount().$ifTrue_ifFalse_(function() {
                self.$doExpiredInspectCount();
            }
            , function() {
                self.$inspect();
            }
            );
        }
        , function() {
            (int.$_equal_(1)).$ifTrue_ifFalse_(function() {
                self.$doExpiredInspectCount();
            }
            , function() {
                self.$setHaltCountTo_(int - 1);
            }
            );
        }
        );
    }
    );
};
Object.prototype.$removeHaltCount = function()
{
    var self = this;
    console.log('$removeHaltCount');
    self.$class().$environment().$includesKey_('HaltCount').$ifTrue_(function() {
        self.$class().$environment().$removeKey_('HaltCount');
    }
    );
};
Object.prototype.$setHaltCountTo_ = function(int)
{
    var self = this;
    console.log('$setHaltCountTo_');
    Smalltalk.$at_put_('HaltCount', int);
};
Object.prototype.$setHaltOnce = function()
{
    var self = this;
    console.log('$setHaltOnce');
    Smalltalk.$at_put_('HaltOnce', true);
};
Object.prototype.$toggleHaltOnce = function()
{
    var self = this;
    console.log('$toggleHaltOnce');
    self.$haltOnceEnabled().$ifTrue_ifFalse_(function() {
        self.$clearHaltOnce();
    }
    , function() {
        self.$setHaltOnce();
    }
    );
};
Object.prototype.$addDependent_ = function(anObject)
{
    var self = this;
    console.log('$addDependent_');
    var dependents = null
    dependents = self.$dependents();
    dependents.$includes_(anObject).$ifFalse_(function() {
        self.$myDependents_(dependents.$copyWithDependent_(anObject));
    }
    );
    return anObject;
};
Object.prototype.$breakDependents = function()
{
    var self = this;
    console.log('$breakDependents');
    self.$myDependents_(nil);
};
Object.prototype.$canDiscardEdits = function()
{
    var self = this;
    console.log('$canDiscardEdits');
    self.$dependents().$do_without_(function(each) {
        each.$canDiscardEdits().$ifFalse_(function() {
            return false;
        }
        );
    }
    , self);
    return true;
};
Object.prototype.$dependents = function()
{
    var self = this;
    console.log('$dependents');
    return self.$myDependents().$ifNil_(function() {
        [];
    }
    );
};
Object.prototype.$evaluate_wheneverChangeIn_ = function(actionBlock, aspectBlock)
{
    var self = this;
    console.log('$evaluate_wheneverChangeIn_');
    var viewerThenObject = null
    var objectThenViewer = null
    objectThenViewer = self;
    viewerThenObject = ObjectViewer.$on_(objectThenViewer);
    objectThenViewer.$become_(viewerThenObject);
    objectThenViewer.$xxxViewedObject_evaluate_wheneverChangeIn_(viewerThenObject, actionBlock, aspectBlock);
};
Object.prototype.$hasUnacceptedEdits = function()
{
    var self = this;
    console.log('$hasUnacceptedEdits');
    self.$dependents().$do_without_(function(each) {
        each.$hasUnacceptedEdits().$ifTrue_(function() {
            return true;
        }
        );
    }
    , self);
    return false;
};
Object.prototype.$myDependents = function()
{
    var self = this;
    console.log('$myDependents');
    return DependentsFields.$at_ifAbsent_(self, function() {
    }
    );
};
Object.prototype.$myDependents_ = function(aCollectionOrNil)
{
    var self = this;
    console.log('$myDependents_');
    aCollectionOrNil.$ifNil_ifNotNil_(function() {
        DependentsFields.$removeKey_ifAbsent_(self, function() {
        }
        );
    }
    , function() {
        DependentsFields.$at_put_(self, aCollectionOrNil);
    }
    );
};
Object.prototype.$release = function()
{
    var self = this;
    console.log('$release');
    self.$releaseActionMap();
};
Object.prototype.$removeDependent_ = function(anObject)
{
    var self = this;
    console.log('$removeDependent_');
    var dependents = null
    dependents = self.$dependents().$reject_(function(each) {
        each == anObject;
    }
    );
    self.$myDependents_(dependents.$isEmpty().$ifFalse_(function() {
        dependents;
    }
    ));
    return anObject;
};
Object.prototype.$acceptDroppingMorph_event_inMorph_ = function(transferMorph, evt, dstListMorph)
{
    var self = this;
    console.log('$acceptDroppingMorph_event_inMorph_');
    return false;
};
Object.prototype.$dragAnimationFor_transferMorph_ = function(item, transferMorph)
{
    var self = this;
    console.log('$dragAnimationFor_transferMorph_');
};
Object.prototype.$dragPassengerFor_inMorph_ = function(item, dragSource)
{
    var self = this;
    console.log('$dragPassengerFor_inMorph_');
    return item;
};
Object.prototype.$dragTransferType = function()
{
    var self = this;
    console.log('$dragTransferType');
    return nil;
};
Object.prototype.$dragTransferTypeForMorph_ = function(dragSource)
{
    var self = this;
    console.log('$dragTransferTypeForMorph_');
    return nil;
};
Object.prototype.$wantsDroppedMorph_event_inMorph_ = function(aMorph, anEvent, destinationLM)
{
    var self = this;
    console.log('$wantsDroppedMorph_event_inMorph_');
    return false;
};
Object.prototype.$assert_ = function(aBlock)
{
    var self = this;
    console.log('$assert_');
    aBlock.$value().$ifFalse_(function() {
        AssertionFailure.$signal_('Assertion failed');
    }
    );
};
Object.prototype.$assert_descriptionBlock_ = function(aBlock, descriptionBlock)
{
    var self = this;
    console.log('$assert_descriptionBlock_');
    aBlock.$value().$ifFalse_(function() {
        AssertionFailure.$signal_(descriptionBlock.$value().$asString());
    }
    );
};
Object.prototype.$assert_description_ = function(aBlock, aString)
{
    var self = this;
    console.log('$assert_description_');
    aBlock.$value().$ifFalse_(function() {
        AssertionFailure.$signal_(aString);
    }
    );
};
Object.prototype.$backwardCompatibilityOnly_ = function(anExplanationString)
{
    var self = this;
    console.log('$backwardCompatibilityOnly_');
    Preferences.$showDeprecationWarnings().$ifTrue_(function() {
        Deprecation.$signal_((thisContext.$sender().$printString() , ' has been deprecated (but will be kept for compatibility). ') , anExplanationString);
    }
    );
};
Object.prototype.$caseError = function()
{
    var self = this;
    console.log('$caseError');
    self.$error_((String('Case not found (') , self.$printString()) , '), and no otherwise clause');
};
Object.prototype.$confirm_ = function(queryString)
{
    var self = this;
    console.log('$confirm_');
    return UIManager.$default().$confirm_(queryString);
};
Object.prototype.$confirm_orCancel_ = function(aString, cancelBlock)
{
    var self = this;
    console.log('$confirm_orCancel_');
    return UIManager.$default().$confirm_orCancel_(aString, cancelBlock);
};
Object.prototype.$deprecated_ = function(anExplanationString)
{
    var self = this;
    console.log('$deprecated_');
    Preferences.$showDeprecationWarnings().$ifTrue_(function() {
        Deprecation.$signal_((thisContext.$sender().$printString() , ' has been deprecated. ') , anExplanationString);
    }
    );
};
Object.prototype.$deprecated_block_ = function(anExplanationString, aBlock)
{
    var self = this;
    console.log('$deprecated_block_');
    Preferences.$showDeprecationWarnings().$ifTrue_(function() {
        Deprecation.$signal_((thisContext.$sender().$printString() , ' has been deprecated. ') , anExplanationString);
    }
    );
    return aBlock.$value();
};
Object.prototype.$doesNotUnderstand_ = function(aMessage)
{
    var self = this;
    console.log('$doesNotUnderstand_');
    var exception = null
    var resumeValue = null
    Preferences.$autoAccessors().$and_(function() {
        self.$tryToDefineVariableAccess_(aMessage);
    }
    ).$ifTrue_(function() {
        return aMessage.$sentTo_(self);
    }
    );
    (function () {var _aux = (exception = MessageNotUnderstood.$new()).$message_(aMessage);return _aux;})().$receiver_(self);
    resumeValue = exception.$signal();
    return exception.$reachedDefaultHandler().$ifTrue_ifFalse_(function() {
        aMessage.$sentTo_(self);
    }
    , function() {
        resumeValue;
    }
    );
};
Object.prototype.$dpsTrace_ = function(reportObject)
{
    var self = this;
    console.log('$dpsTrace_');
    Transcript.$myDependents().$isNil().$ifTrue_(function() {
        return self;
    }
    );
    self.$dpsTrace_levels_withContext_(reportObject, 1, thisContext);
};
Object.prototype.$dpsTrace_levels_ = function(reportObject, anInt)
{
    var self = this;
    console.log('$dpsTrace_levels_');
    self.$dpsTrace_levels_withContext_(reportObject, anInt, thisContext);
};
Object.prototype.$dpsTrace_levels_withContext_ = function(reportObject, anInt, currentContext)
{
    var self = this;
    console.log('$dpsTrace_levels_withContext_');
    var reportString = null
    var context = null
    var displayCount = null
    reportString = reportObject.$respondsTo_('asString').$ifTrue_ifFalse_(function() {
        reportObject.$asString();
    }
    , function() {
        reportObject.$printString();
    }
    );
    Smalltalk.$at_ifAbsent_('Decompiler', function() {
        nil;
    }
    ).$ifNil_ifNotNil_(function() {
        (function () {var _aux = Transcript.$cr();return _aux;})().$show_(reportString);
    }
    , function() {
        context = currentContext;
        displayCount = anInt > 1;
        Number(1).$to_do_(anInt, function(count) {
            Transcript.$cr();
            displayCount.$ifTrue_(function() {
                Transcript.$show_(count.$printString() , ': ');
            }
            );
            reportString.$notNil().$ifTrue_ifFalse_(function() {
                Transcript.$show_(((((context.$home().$class().$name() , '/') , context.$sender().$selector()) , ' (') , reportString) , ')');
                context = context.$sender();
                reportString = nil;
            }
            , function() {
                context.$notNil().$and_(function() {
                    (context = context.$sender()).$notNil();
                }
                ).$ifTrue_(function() {
                    Transcript.$show_((context.$receiver().$class().$name() , '/') , context.$selector());
                }
                );
            }
            );
        }
        );
    }
    );
};
Object.prototype.$error = function()
{
    var self = this;
    console.log('$error');
    return self.$error_('Error!');
};
Object.prototype.$error_ = function(aString)
{
    var self = this;
    console.log('$error_');
    return Error.$new().$signal_(aString);
};
Object.prototype.$explicitRequirement = function()
{
    var self = this;
    console.log('$explicitRequirement');
    self.$error_('Explicitly required method');
};
Object.prototype.$halt = function()
{
    var self = this;
    console.log('$halt');
    Halt.$signal();
};
Object.prototype.$halt_ = function(aString)
{
    var self = this;
    console.log('$halt_');
    Halt.$new().$signal_(aString);
};
Object.prototype.$handles_ = function(exception)
{
    var self = this;
    console.log('$handles_');
    return false;
};
Object.prototype.$notifyWithLabel_ = function(aString)
{
    var self = this;
    console.log('$notifyWithLabel_');
    ToolSet.$debugContext_label_contents_(thisContext, aString, aString);
};
Object.prototype.$notify_ = function(aString)
{
    var self = this;
    console.log('$notify_');
    Warning.$signal_(aString);
};
Object.prototype.$notify_at_ = function(aString, location)
{
    var self = this;
    console.log('$notify_at_');
    self.$notify_(aString);
};
Object.prototype.$primitiveFailed = function()
{
    var self = this;
    console.log('$primitiveFailed');
    self.$primitiveFailed_(thisContext.$sender().$selector());
};
Object.prototype.$primitiveFailed_ = function(selector)
{
    var self = this;
    console.log('$primitiveFailed_');
    self.$error_(selector.$asString() , ' failed');
};
Object.prototype.$requirement = function()
{
    var self = this;
    console.log('$requirement');
    self.$error_('Implicitly required method');
};
Object.prototype.$shouldBeImplemented = function()
{
    var self = this;
    console.log('$shouldBeImplemented');
    self.$error_('This message should be implemented');
};
Object.prototype.$shouldNotImplement = function()
{
    var self = this;
    console.log('$shouldNotImplement');
    self.$error_('This message is not appropriate for this object');
};
Object.prototype.$subclassResponsibility = function()
{
    var self = this;
    console.log('$subclassResponsibility');
    self.$error_(String('My subclass should have overridden ') , thisContext.$sender().$selector().$printString());
};
Object.prototype.$traitConflict = function()
{
    var self = this;
    console.log('$traitConflict');
    self.$error_('A class or trait does not properly resolve a conflict between multiple traits it uses.');
};
Object.prototype.$value = function()
{
    var self = this;
    console.log('$value');
    return self;
};
Object.prototype.$valueWithArguments_ = function(aSequenceOfArguments)
{
    var self = this;
    console.log('$valueWithArguments_');
    return self;
};
Object.prototype.$actionForEvent_ = function(anEventSelector)
{
    var self = this;
    console.log('$actionForEvent_');
    var actions = null
    actions = self.$actionMap().$at_ifAbsent_(anEventSelector.$asSymbol(), function() {
        nil;
    }
    );
    actions.$ifNil_(function() {
        return nil;
    }
    );
    return actions.$asMinimalRepresentation();
};
Object.prototype.$actionForEvent_ifAbsent_ = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    console.log('$actionForEvent_ifAbsent_');
    var actions = null
    actions = self.$actionMap().$at_ifAbsent_(anEventSelector.$asSymbol(), function() {
        nil;
    }
    );
    actions.$ifNil_(function() {
        return anExceptionBlock.$value();
    }
    );
    return actions.$asMinimalRepresentation();
};
Object.prototype.$actionMap = function()
{
    var self = this;
    console.log('$actionMap');
    return EventManager.$actionMapFor_(self);
};
Object.prototype.$actionSequenceForEvent_ = function(anEventSelector)
{
    var self = this;
    console.log('$actionSequenceForEvent_');
    return self.$actionMap().$at_ifAbsent_(anEventSelector.$asSymbol(), function() {
        return WeakActionSequence.$new();
    }
    ).$asActionSequence();
};
Object.prototype.$actionsDo_ = function(aBlock)
{
    var self = this;
    console.log('$actionsDo_');
    self.$actionMap().$do_(aBlock);
};
Object.prototype.$createActionMap = function()
{
    var self = this;
    console.log('$createActionMap');
    return IdentityDictionary.$new();
};
Object.prototype.$hasActionForEvent_ = function(anEventSelector)
{
    var self = this;
    console.log('$hasActionForEvent_');
    return self.$actionForEvent_(anEventSelector).$notNil();
};
Object.prototype.$setActionSequence_forEvent_ = function(actionSequence, anEventSelector)
{
    var self = this;
    console.log('$setActionSequence_forEvent_');
    var action = null
    action = actionSequence.$asMinimalRepresentation();
    (action == nil).$ifTrue_ifFalse_(function() {
        self.$removeActionsForEvent_(anEventSelector);
    }
    , function() {
        self.$updateableActionMap().$at_put_(anEventSelector.$asSymbol(), action);
    }
    );
};
Object.prototype.$updateableActionMap = function()
{
    var self = this;
    console.log('$updateableActionMap');
    return EventManager.$updateableActionMapFor_(self);
};
Object.prototype.$when_evaluate_ = function(anEventSelector, anAction)
{
    var self = this;
    console.log('$when_evaluate_');
    var actions = null
    actions = self.$actionSequenceForEvent_(anEventSelector);
    actions.$includes_(anAction).$ifTrue_(function() {
        return self;
    }
    );
    self.$setActionSequence_forEvent_(actions.$copyWith_(anAction), anEventSelector);
};
Object.prototype.$when_send_to_ = function(anEventSelector, aMessageSelector, anObject)
{
    var self = this;
    console.log('$when_send_to_');
    self.$when_evaluate_(anEventSelector, WeakMessageSend.$receiver_selector_(anObject, aMessageSelector));
};
Object.prototype.$when_send_to_withArguments_ = function(anEventSelector, aMessageSelector, anObject, anArgArray)
{
    var self = this;
    console.log('$when_send_to_withArguments_');
    self.$when_evaluate_(anEventSelector, WeakMessageSend.$receiver_selector_arguments_(anObject, aMessageSelector, anArgArray));
};
Object.prototype.$when_send_to_with_ = function(anEventSelector, aMessageSelector, anObject, anArg)
{
    var self = this;
    console.log('$when_send_to_with_');
    self.$when_evaluate_(anEventSelector, WeakMessageSend.$receiver_selector_arguments_(anObject, aMessageSelector, Array.$with_(anArg)));
};
Object.prototype.$releaseActionMap = function()
{
    var self = this;
    console.log('$releaseActionMap');
    EventManager.$releaseActionMapFor_(self);
};
Object.prototype.$removeActionsForEvent_ = function(anEventSelector)
{
    var self = this;
    console.log('$removeActionsForEvent_');
    var map = null
    map = self.$actionMap();
    map.$removeKey_ifAbsent_(anEventSelector.$asSymbol(), function() {
    }
    );
    map.$isEmpty().$ifTrue_(function() {
        self.$releaseActionMap();
    }
    );
};
Object.prototype.$removeActionsSatisfying_ = function(aBlock)
{
    var self = this;
    console.log('$removeActionsSatisfying_');
    self.$actionMap().$keys().$do_(function(eachEventSelector) {
        self.$removeActionsSatisfying_forEvent_(aBlock, eachEventSelector);
    }
    );
};
Object.prototype.$removeActionsSatisfying_forEvent_ = function(aOneArgBlock, anEventSelector)
{
    var self = this;
    console.log('$removeActionsSatisfying_forEvent_');
    self.$setActionSequence_forEvent_(self.$actionSequenceForEvent_(anEventSelector).$reject_(function(anAction) {
        aOneArgBlock.$value_(anAction);
    }
    ), anEventSelector);
};
Object.prototype.$removeActionsWithReceiver_ = function(anObject)
{
    var self = this;
    console.log('$removeActionsWithReceiver_');
    self.$actionMap().$copy().$keysDo_(function(eachEventSelector) {
        self.$removeActionsSatisfying_forEvent_(function(anAction) {
            anAction.$receiver() == anObject;
        }
        , eachEventSelector);
    }
    );
};
Object.prototype.$removeActionsWithReceiver_forEvent_ = function(anObject, anEventSelector)
{
    var self = this;
    console.log('$removeActionsWithReceiver_forEvent_');
    self.$removeActionsSatisfying_forEvent_(function(anAction) {
        anAction.$receiver() == anObject;
    }
    , anEventSelector);
};
Object.prototype.$removeAction_forEvent_ = function(anAction, anEventSelector)
{
    var self = this;
    console.log('$removeAction_forEvent_');
    self.$removeActionsSatisfying_forEvent_(function(action) {
        action.$_equal_(anAction);
    }
    , anEventSelector);
};
Object.prototype.$triggerEvent_ = function(anEventSelector)
{
    var self = this;
    console.log('$triggerEvent_');
    return self.$actionForEvent_(anEventSelector).$value();
};
Object.prototype.$triggerEvent_ifNotHandled_ = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    console.log('$triggerEvent_ifNotHandled_');
    return self.$actionForEvent_ifAbsent_(anEventSelector, function() {
        return anExceptionBlock.$value();
    }
    ).$value();
};
Object.prototype.$triggerEvent_withArguments_ = function(anEventSelector, anArgumentList)
{
    var self = this;
    console.log('$triggerEvent_withArguments_');
    return self.$actionForEvent_(anEventSelector).$valueWithArguments_(anArgumentList);
};
Object.prototype.$triggerEvent_withArguments_ifNotHandled_ = function(anEventSelector, anArgumentList, anExceptionBlock)
{
    var self = this;
    console.log('$triggerEvent_withArguments_ifNotHandled_');
    return self.$actionForEvent_ifAbsent_(anEventSelector, function() {
        return anExceptionBlock.$value();
    }
    ).$valueWithArguments_(anArgumentList);
};
Object.prototype.$triggerEvent_with_ = function(anEventSelector, anObject)
{
    var self = this;
    console.log('$triggerEvent_with_');
    return self.$triggerEvent_withArguments_(anEventSelector, Array.$with_(anObject));
};
Object.prototype.$triggerEvent_with_ifNotHandled_ = function(anEventSelector, anObject, anExceptionBlock)
{
    var self = this;
    console.log('$triggerEvent_with_ifNotHandled_');
    return self.$triggerEvent_withArguments_ifNotHandled_(anEventSelector, Array.$with_(anObject), anExceptionBlock);
};
Object.prototype.$byteEncode_ = function(aStream)
{
    var self = this;
    console.log('$byteEncode_');
    self.$flattenOnStream_(aStream);
};
Object.prototype.$drawOnCanvas_ = function(aStream)
{
    var self = this;
    console.log('$drawOnCanvas_');
    self.$flattenOnStream_(aStream);
};
Object.prototype.$elementSeparator = function()
{
    var self = this;
    console.log('$elementSeparator');
    return nil;
};
Object.prototype.$encodePostscriptOn_ = function(aStream)
{
    var self = this;
    console.log('$encodePostscriptOn_');
    self.$byteEncode_(aStream);
};
Object.prototype.$flattenOnStream_ = function(aStream)
{
    var self = this;
    console.log('$flattenOnStream_');
    self.$writeOnFilterStream_(aStream);
};
Object.prototype.$fullDrawPostscriptOn_ = function(aStream)
{
    var self = this;
    console.log('$fullDrawPostscriptOn_');
    return aStream.$fullDraw_(self);
};
Object.prototype.$printOnStream_ = function(aStream)
{
    var self = this;
    console.log('$printOnStream_');
    self.$byteEncode_(aStream);
};
Object.prototype.$putOn_ = function(aStream)
{
    var self = this;
    console.log('$putOn_');
    return aStream.$nextPut_(self);
};
Object.prototype.$storeOnStream_ = function(aStream)
{
    var self = this;
    console.log('$storeOnStream_');
    self.$printOnStream_(aStream);
};
Object.prototype.$writeOnFilterStream_ = function(aStream)
{
    var self = this;
    console.log('$writeOnFilterStream_');
    aStream.$writeObject_(self);
};
Object.prototype.$actAsExecutor = function()
{
    var self = this;
    console.log('$actAsExecutor');
    self.$breakDependents();
};
Object.prototype.$executor = function()
{
    var self = this;
    console.log('$executor');
    return self.$shallowCopy().$actAsExecutor();
};
Object.prototype.$finalizationRegistry = function()
{
    var self = this;
    console.log('$finalizationRegistry');
    return WeakRegistry.$default();
};
Object.prototype.$finalize = function()
{
    var self = this;
    console.log('$finalize');
};
Object.prototype.$retryWithGC_until_ = function(execBlock, testBlock)
{
    var self = this;
    console.log('$retryWithGC_until_');
    var blockValue = null
    blockValue = execBlock.$value();
    testBlock.$value_(blockValue).$ifTrue_(function() {
        return blockValue;
    }
    );
    Smalltalk.$garbageCollectMost();
    blockValue = execBlock.$value();
    testBlock.$value_(blockValue).$ifTrue_(function() {
        return blockValue;
    }
    );
    Smalltalk.$garbageCollect();
    return execBlock.$value();
};
Object.prototype.$toFinalizeSend_to_with_ = function(aSelector, aFinalizer, aResourceHandle)
{
    var self = this;
    console.log('$toFinalizeSend_to_with_');
    (self == aFinalizer).$ifTrue_(function() {
        self.$error_('I cannot finalize myself');
    }
    );
    (self == aResourceHandle).$ifTrue_(function() {
        self.$error_('I cannot finalize myself');
    }
    );
    return self.$finalizationRegistry().$add_executor_(self, ObjectFinalizer.$receiver_selector_argument_(aFinalizer, aSelector, aResourceHandle));
};
Object.prototype.$isThisEverCalled = function()
{
    var self = this;
    console.log('$isThisEverCalled');
    return self.$isThisEverCalled_(thisContext.$sender().$printString());
};
Object.prototype.$isThisEverCalled_ = function(msg)
{
    var self = this;
    console.log('$isThisEverCalled_');
    self.$halt_(String('This is indeed called: ') , msg.$printString());
};
Object.prototype.$logEntry = function()
{
    var self = this;
    console.log('$logEntry');
    (function () {var _aux = Transcript.$show_(String('Entered ') , thisContext.$sender().$printString());return _aux;})().$cr();
};
Object.prototype.$logExecution = function()
{
    var self = this;
    console.log('$logExecution');
    (function () {var _aux = Transcript.$show_(String('Executing ') , thisContext.$sender().$printString());return _aux;})().$cr();
};
Object.prototype.$logExit = function()
{
    var self = this;
    console.log('$logExit');
    (function () {var _aux = Transcript.$show_(String('Exited ') , thisContext.$sender().$printString());return _aux;})().$cr();
};
Object.prototype.$addModelYellowButtonMenuItemsTo_forMorph_hand_ = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    console.log('$addModelYellowButtonMenuItemsTo_forMorph_hand_');
    Preferences.$cmdGesturesEnabled().$ifTrue_(function() {
        aCustomMenu.$add_target_action_(String('inspect model').$translated(), self, 'inspect');
    }
    );
    return aCustomMenu;
};
Object.prototype.$hasModelYellowButtonMenuItems = function()
{
    var self = this;
    console.log('$hasModelYellowButtonMenuItems');
    return Preferences.$cmdGesturesEnabled();
};
Object.prototype.$localeChanged = function()
{
    var self = this;
    console.log('$localeChanged');
    self.$shouldBeImplemented();
};
Object.prototype.$codeStrippedOut_ = function(messageString)
{
    var self = this;
    console.log('$codeStrippedOut_');
    self.$halt_((String('Code stripped out -- ') , messageString) , '-- do not proceed.');
};
Object.prototype.$contentsChanged = function()
{
    var self = this;
    console.log('$contentsChanged');
    self.$changed_('contents');
};
Object.prototype.$currentEvent = function()
{
    var self = this;
    console.log('$currentEvent');
    return ActiveEvent.$ifNil_(function() {
        self.$currentHand().$lastEvent();
    }
    );
};
Object.prototype.$currentHand = function()
{
    var self = this;
    console.log('$currentHand');
    return ActiveHand.$ifNil_(function() {
        self.$currentWorld().$primaryHand();
    }
    );
};
Object.prototype.$currentWorld = function()
{
    var self = this;
    console.log('$currentWorld');
    return ActiveWorld.$ifNil_(function() {
        World;
    }
    );
};
Object.prototype.$flash = function()
{
    var self = this;
    console.log('$flash');
};
Object.prototype.$instanceVariableValues = function()
{
    var self = this;
    console.log('$instanceVariableValues');
    var c = null
    c = OrderedCollection.$new();
    (self.$class().$superclass().$instSize() + 1).$to_do_(self.$class().$instSize(), function(i) {
        c.$add_(self.$instVarAt_(i));
    }
    );
    return c;
};
Object.prototype.$isUniversalTiles = function()
{
    var self = this;
    console.log('$isUniversalTiles');
    return Preferences.$universalTiles();
};
Object.prototype.$objectRepresented = function()
{
    var self = this;
    console.log('$objectRepresented');
    return self;
};
Object.prototype.$refusesToAcceptCode = function()
{
    var self = this;
    console.log('$refusesToAcceptCode');
    return false;
};
Object.prototype.$scriptPerformer = function()
{
    var self = this;
    console.log('$scriptPerformer');
    return self;
};
Object.prototype.$slotInfo = function()
{
    var self = this;
    console.log('$slotInfo');
    return Dictionary.$new();
};
Object.prototype.$executeMethod_ = function(compiledMethod)
{
    var self = this;
    console.log('$executeMethod_');
    return self.$withArgs_executeMethod_([], compiledMethod);
};
Object.prototype.$perform_ = function(aSymbol)
{
    var self = this;
    console.log('$perform_');
    var _primitive = Primitive83(self, aSymbol);
    if (_primitive) return _primitive.value;
    ;
    return self.$perform_withArguments_(aSymbol, Array.$new_(0));
};
Object.prototype.$perform_orSendTo_ = function(selector, otherTarget)
{
    var self = this;
    console.log('$perform_orSendTo_');
    return self.$respondsTo_(selector).$ifTrue_ifFalse_(function() {
        self.$perform_(selector);
    }
    , function() {
        otherTarget.$perform_(selector);
    }
    );
};
Object.prototype.$perform_withArguments_ = function(selector, argArray)
{
    var self = this;
    console.log('$perform_withArguments_');
    var _primitive = Primitive84(self, selector, argArray);
    if (_primitive) return _primitive.value;
    ;
    return self.$perform_withArguments_inSuperclass_(selector, argArray, self.$class());
};
Object.prototype.$perform_withArguments_inSuperclass_ = function(selector, argArray, lookupClass)
{
    var self = this;
    console.log('$perform_withArguments_inSuperclass_');
    var _primitive = Primitive100(self, selector, argArray, lookupClass);
    if (_primitive) return _primitive.value;
    ;
    selector.$isSymbol().$ifFalse_(function() {
        return self.$error_('selector argument must be a Symbol');
    }
    );
    (selector.$numArgs().$_equal_(argArray.$size())).$ifFalse_(function() {
        return self.$error_('incorrect number of arguments');
    }
    );
    (self.$class() == lookupClass).$or_(function() {
        self.$class().$inheritsFrom_(lookupClass);
    }
    ).$ifFalse_(function() {
        return self.$error_('lookupClass is not in my inheritance chain');
    }
    );
    self.$primitiveFailed();
};
Object.prototype.$perform_withEnoughArguments_ = function(selector, anArray)
{
    var self = this;
    console.log('$perform_withEnoughArguments_');
    var numArgs = null
    var args = null
    numArgs = selector.$numArgs();
    (anArray.$size() == numArgs).$ifTrue_(function() {
        return self.$perform_withArguments_(selector, anArray.$asArray());
    }
    );
    args = Array.$new_(numArgs);
    args.$replaceFrom_to_with_startingAt_(1, anArray.$size().$min_(args.$size()), anArray, 1);
    return self.$perform_withArguments_(selector, args);
};
Object.prototype.$perform_with_ = function(aSymbol, anObject)
{
    var self = this;
    console.log('$perform_with_');
    var _primitive = Primitive83(self, aSymbol, anObject);
    if (_primitive) return _primitive.value;
    ;
    return self.$perform_withArguments_(aSymbol, Array.$with_(anObject));
};
Object.prototype.$perform_with_with_ = function(aSymbol, firstObject, secondObject)
{
    var self = this;
    console.log('$perform_with_with_');
    var _primitive = Primitive83(self, aSymbol, firstObject, secondObject);
    if (_primitive) return _primitive.value;
    ;
    return self.$perform_withArguments_(aSymbol, Array.$with_with_(firstObject, secondObject));
};
Object.prototype.$perform_with_with_with_ = function(aSymbol, firstObject, secondObject, thirdObject)
{
    var self = this;
    console.log('$perform_with_with_with_');
    var _primitive = Primitive83(self, aSymbol, firstObject, secondObject, thirdObject);
    if (_primitive) return _primitive.value;
    ;
    return self.$perform_withArguments_(aSymbol, Array.$with_with_with_(firstObject, secondObject, thirdObject));
};
Object.prototype.$withArgs_executeMethod_ = function(argArray, compiledMethod)
{
    var self = this;
    console.log('$withArgs_executeMethod_');
    var selector = null
    var _primitive = Primitive188(self, argArray, compiledMethod);
    if (_primitive) return _primitive.value;
    ;
    selector = Symbol.$new();
    self.$class().$addSelectorSilently_withMethod_(selector, compiledMethod);
    return (function() {
        self.$perform_withArguments_(selector, argArray);
    }
    ).$ensure_(function() {
        self.$class().$basicRemoveSelector_(selector);
    }
    );
};
Object.prototype.$with_executeMethod_ = function(arg1, compiledMethod)
{
    var self = this;
    console.log('$with_executeMethod_');
    return self.$withArgs_executeMethod_([arg1], compiledMethod);
};
Object.prototype.$with_with_executeMethod_ = function(arg1, arg2, compiledMethod)
{
    var self = this;
    console.log('$with_with_executeMethod_');
    return self.$withArgs_executeMethod_([arg1, arg2], compiledMethod);
};
Object.prototype.$with_with_with_executeMethod_ = function(arg1, arg2, arg3, compiledMethod)
{
    var self = this;
    console.log('$with_with_with_executeMethod_');
    return self.$withArgs_executeMethod_([arg1, arg2, arg3], compiledMethod);
};
Object.prototype.$with_with_with_with_executeMethod_ = function(arg1, arg2, arg3, arg4, compiledMethod)
{
    var self = this;
    console.log('$with_with_with_with_executeMethod_');
    return self.$withArgs_executeMethod_([arg1, arg2, arg3, arg4], compiledMethod);
};
Object.prototype.$comeFullyUpOnReload_ = function(smartRefStream)
{
    var self = this;
    console.log('$comeFullyUpOnReload_');
    return self;
};
Object.prototype.$convertToCurrentVersion_refStream_ = function(varDict, smartRefStrm)
{
    var self = this;
    console.log('$convertToCurrentVersion_refStream_');
};
Object.prototype.$fixUponLoad_seg_ = function(aProject, anImageSegment)
{
    var self = this;
    console.log('$fixUponLoad_seg_');
};
Object.prototype.$indexIfCompact = function()
{
    var self = this;
    console.log('$indexIfCompact');
    return 0;
};
Object.prototype.$objectForDataStream_ = function(refStrm)
{
    var self = this;
    console.log('$objectForDataStream_');
    return self;
};
Object.prototype.$readDataFrom_size_ = function(aDataStream, varsOnDisk)
{
    var self = this;
    console.log('$readDataFrom_size_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = self.$class().$instSize();
    self.$class().$isVariable().$ifTrue_ifFalse_(function() {
        cntIndexedVars = varsOnDisk - cntInstVars;
        (cntIndexedVars < 0).$ifTrue_(function() {
            self.$error_('Class has changed too much.  Define a convertxxx method');
        }
        );
    }
    , function() {
        cntIndexedVars = 0;
        cntInstVars = varsOnDisk;
    }
    );
    aDataStream.$beginReference_(self);
    Number(1).$to_do_(cntInstVars, function(i) {
        self.$instVarAt_put_(i, aDataStream.$next());
    }
    );
    Number(1).$to_do_(cntIndexedVars, function(i) {
        self.$basicAt_put_(i, aDataStream.$next());
    }
    );
    return self;
};
Object.prototype.$saveOnFile = function()
{
    var self = this;
    console.log('$saveOnFile');
    var aFileName = null
    var fileStream = null
    aFileName = self.$class().$name().$asFileName();
    aFileName = UIManager.$default().$request_initialAnswer_(String('File name?').$translated(), aFileName);
    (aFileName.$size() == 0).$ifTrue_(function() {
        return Beeper.$beep();
    }
    );
    fileStream = FileStream.$newFileNamed_(aFileName.$asFileName());
    fileStream.$fileOutClass_andObject_(nil, self);
};
Object.prototype.$storeDataOn_ = function(aDataStream)
{
    var self = this;
    console.log('$storeDataOn_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = self.$class().$instSize();
    cntIndexedVars = self.$basicSize();
    aDataStream.$beginInstance_size_(self.$class(), cntInstVars + cntIndexedVars);
    Number(1).$to_do_(cntInstVars, function(i) {
        aDataStream.$nextPut_(self.$instVarAt_(i));
    }
    );
    (aDataStream.$byteStream().$class() == DummyStream).$and_(function() {
        self.$class().$isBits();
    }
    ).$ifFalse_(function() {
        Number(1).$to_do_(cntIndexedVars, function(i) {
            aDataStream.$nextPut_(self.$basicAt_(i));
        }
        );
    }
    );
};
Object.prototype.$descriptionForPartsBin = function()
{
    var self = this;
    console.log('$descriptionForPartsBin');
    return DescriptionForPartsBin.$formalName_categoryList_documentation_globalReceiverSymbol_nativitySelector_('PutFormalNameHere', ['PutACategoryHere', 'MaybePutAnotherCategoryHere'], 'Put the balloon help here', 'PutAGlobalHere', 'PutASelectorHere');
};
Object.prototype.$fullPrintString = function()
{
    var self = this;
    console.log('$fullPrintString');
    return String.$streamContents_(function(s) {
        self.$printOn_(s);
    }
    );
};
Object.prototype.$isLiteral = function()
{
    var self = this;
    console.log('$isLiteral');
    return false;
};
Object.prototype.$longPrintOn_ = function(aStream)
{
    var self = this;
    console.log('$longPrintOn_');
    self.$class().$allInstVarNames().$doWithIndex_(function(title, index) {
        (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = aStream.$nextPutAll_(title);return _aux;})().$nextPut_(':');return _aux;})().$space();return _aux;})().$tab();return _aux;})().$print_(self.$instVarAt_(index));return _aux;})().$cr();
    }
    );
};
Object.prototype.$longPrintOn_limitedTo_indent_ = function(aStream, sizeLimit, indent)
{
    var self = this;
    console.log('$longPrintOn_limitedTo_indent_');
    self.$class().$allInstVarNames().$doWithIndex_(function(title, index) {
        indent.$timesRepeat_(function() {
            aStream.$tab();
        }
        );
        (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = aStream.$nextPutAll_(title);return _aux;})().$nextPut_(':');return _aux;})().$space();return _aux;})().$tab();return _aux;})().$nextPutAll_(self.$instVarAt_(index).$printStringLimitedTo_(((sizeLimit - 3) - title.$size()).$max_(1)));return _aux;})().$cr();
    }
    );
};
Object.prototype.$longPrintString = function()
{
    var self = this;
    console.log('$longPrintString');
    var str = null
    str = String.$streamContents_(function(aStream) {
        self.$longPrintOn_(aStream);
    }
    );
    return str.$isEmpty().$ifTrue_ifFalse_(function() {
        self.$printString() , String.$cr();
    }
    , function() {
        str;
    }
    );
};
Object.prototype.$longPrintStringLimitedTo_ = function(aLimitValue)
{
    var self = this;
    console.log('$longPrintStringLimitedTo_');
    var str = null
    str = String.$streamContents_(function(aStream) {
        self.$longPrintOn_limitedTo_indent_(aStream, aLimitValue, 0);
    }
    );
    return str.$isEmpty().$ifTrue_ifFalse_(function() {
        self.$printString() , String.$cr();
    }
    , function() {
        str;
    }
    );
};
Object.prototype.$nominallyUnsent_ = function(aSelectorSymbol)
{
    var self = this;
    console.log('$nominallyUnsent_');
    Boolean(false).$ifTrue_(function() {
        self.$flag_('nominallyUnsent:');
    }
    );
};
Object.prototype.$printOn_ = function(aStream)
{
    var self = this;
    console.log('$printOn_');
    var title = null
    title = self.$class().$name();
    (function () {var _aux = aStream.$nextPutAll_(title.$first().$isVowel().$ifTrue_ifFalse_(function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ));return _aux;})().$nextPutAll_(title);
};
Object.prototype.$printString = function()
{
    var self = this;
    console.log('$printString');
    return self.$printStringLimitedTo_(50000);
};
Object.prototype.$printStringLimitedTo_ = function(limit)
{
    var self = this;
    console.log('$printStringLimitedTo_');
    var limitedString = null
    limitedString = String.$streamContents_limitedTo_(function(s) {
        self.$printOn_(s);
    }
    , limit);
    (limitedString.$size() < limit).$ifTrue_(function() {
        return limitedString;
    }
    );
    return limitedString , '...etc...';
};
Object.prototype.$printWithClosureAnalysisOn_ = function(aStream)
{
    var self = this;
    console.log('$printWithClosureAnalysisOn_');
    var title = null
    title = self.$class().$name();
    (function () {var _aux = aStream.$nextPutAll_(title.$first().$isVowel().$ifTrue_ifFalse_(function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ));return _aux;})().$nextPutAll_(title);
};
Object.prototype.$propertyList = function()
{
    var self = this;
    console.log('$propertyList');
    return PropertyListEncoder.$process_(self);
};
Object.prototype.$reportableSize = function()
{
    var self = this;
    console.log('$reportableSize');
    return (self.$basicSize() + self.$class().$instSize()).$printString();
};
Object.prototype.$storeOn_ = function(aStream)
{
    var self = this;
    console.log('$storeOn_');
    aStream.$nextPut_('(');
    self.$class().$isVariable().$ifTrue_ifFalse_(function() {
        (function () {var _aux = (function () {var _aux = aStream.$nextPutAll_((String('(') , self.$class().$name()) , ' basicNew: ');return _aux;})().$store_(self.$basicSize());return _aux;})().$nextPutAll_(') ');
    }
    , function() {
        aStream.$nextPutAll_(self.$class().$name() , ' basicNew');
    }
    );
    Number(1).$to_do_(self.$class().$instSize(), function(i) {
        (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = aStream.$nextPutAll_(' instVarAt: ');return _aux;})().$store_(i);return _aux;})().$nextPutAll_(' put: ');return _aux;})().$store_(self.$instVarAt_(i));return _aux;})().$nextPut_(';');
    }
    );
    Number(1).$to_do_(self.$basicSize(), function(i) {
        (function () {var _aux = (function () {var _aux = (function () {var _aux = (function () {var _aux = aStream.$nextPutAll_(' basicAt: ');return _aux;})().$store_(i);return _aux;})().$nextPutAll_(' put: ');return _aux;})().$store_(self.$basicAt_(i));return _aux;})().$nextPut_(';');
    }
    );
    aStream.$nextPutAll_(' yourself)');
};
Object.prototype.$storeString = function()
{
    var self = this;
    console.log('$storeString');
    return String.$streamContents_(function(s) {
        self.$storeOn_(s);
    }
    );
};
Object.prototype.$stringForReadout = function()
{
    var self = this;
    console.log('$stringForReadout');
    return self.$stringRepresentation();
};
Object.prototype.$stringRepresentation = function()
{
    var self = this;
    console.log('$stringRepresentation');
    return self.$printString();
};
Object.prototype.$adaptedToWorld_ = function(aWorld)
{
    var self = this;
    console.log('$adaptedToWorld_');
    return self;
};
Object.prototype.$defaultFloatPrecisionFor_ = function(aGetSelector)
{
    var self = this;
    console.log('$defaultFloatPrecisionFor_');
    return 1;
};
Object.prototype.$evaluateUnloggedForSelf_ = function(aCodeString)
{
    var self = this;
    console.log('$evaluateUnloggedForSelf_');
    return Compiler.$evaluate_for_logged_(aCodeString, self, false);
};
Object.prototype.$methodInterfacesForCategory_inVocabulary_limitClass_ = function(aCategorySymbol, aVocabulary, aLimitClass)
{
    var self = this;
    console.log('$methodInterfacesForCategory_inVocabulary_limitClass_');
    var categorySymbol = null
    categorySymbol = aCategorySymbol.$asSymbol();
    (categorySymbol == ScriptingSystem.$nameForInstanceVariablesCategory()).$ifTrue_(function() {
        return self.$methodInterfacesForInstanceVariablesCategoryIn_(aVocabulary);
    }
    );
    (categorySymbol == ScriptingSystem.$nameForScriptsCategory()).$ifTrue_(function() {
        return self.$methodInterfacesForScriptsCategoryIn_(aVocabulary);
    }
    );
    return self.$usableMethodInterfacesIn_(aVocabulary.$methodInterfacesInCategory_forInstance_ofClass_limitClass_(categorySymbol, self, self.$class(), aLimitClass));
};
Object.prototype.$methodInterfacesForInstanceVariablesCategoryIn_ = function(aVocabulary)
{
    var self = this;
    console.log('$methodInterfacesForInstanceVariablesCategoryIn_');
    return OrderedCollection.$new();
};
Object.prototype.$methodInterfacesForScriptsCategoryIn_ = function(aVocabulary)
{
    var self = this;
    console.log('$methodInterfacesForScriptsCategoryIn_');
    return OrderedCollection.$new();
};
Object.prototype.$selfWrittenAsIll = function()
{
    var self = this;
    console.log('$selfWrittenAsIll');
    return self;
};
Object.prototype.$selfWrittenAsIm = function()
{
    var self = this;
    console.log('$selfWrittenAsIm');
    return self;
};
Object.prototype.$selfWrittenAsMe = function()
{
    var self = this;
    console.log('$selfWrittenAsMe');
    return self;
};
Object.prototype.$selfWrittenAsMy = function()
{
    var self = this;
    console.log('$selfWrittenAsMy');
    return self;
};
Object.prototype.$selfWrittenAsThis = function()
{
    var self = this;
    console.log('$selfWrittenAsThis');
    return self;
};
Object.prototype.$asOop = function()
{
    var self = this;
    console.log('$asOop');
    return self.$identityHash();
};
Object.prototype.$becomeForward_ = function(otherObject)
{
    var self = this;
    console.log('$becomeForward_');
    Array.$with_(self).$elementsForwardIdentityTo_(Array.$with_(otherObject));
};
Object.prototype.$becomeForward_copyHash_ = function(otherObject, copyHash)
{
    var self = this;
    console.log('$becomeForward_copyHash_');
    Array.$with_(self).$elementsForwardIdentityTo_copyHash_(Array.$with_(otherObject), copyHash);
};
Object.prototype.$className = function()
{
    var self = this;
    console.log('$className');
    return self.$class().$name().$asString();
};
Object.prototype.$creationStamp = function()
{
    var self = this;
    console.log('$creationStamp');
    return '<no creation stamp>';
};
Object.prototype.$instVarAt_ = function(index)
{
    var self = this;
    console.log('$instVarAt_');
    var _primitive = Primitive73(self, index);
    if (_primitive) return _primitive.value;
    ;
    return self.$basicAt_(index - self.$class().$instSize());
};
Object.prototype.$instVarAt_put_ = function(anInteger, anObject)
{
    var self = this;
    console.log('$instVarAt_put_');
    var _primitive = Primitive74(self, anInteger, anObject);
    if (_primitive) return _primitive.value;
    ;
    return self.$basicAt_put_(anInteger - self.$class().$instSize(), anObject);
};
Object.prototype.$instVarNamed_ = function(aString)
{
    var self = this;
    console.log('$instVarNamed_');
    return self.$instVarAt_(self.$class().$instVarIndexFor_ifAbsent_(aString.$asString(), function() {
        self.$error_('no such inst var');
    }
    ));
};
Object.prototype.$instVarNamed_put_ = function(aString, aValue)
{
    var self = this;
    console.log('$instVarNamed_put_');
    return self.$instVarAt_put_(self.$class().$instVarIndexFor_ifAbsent_(aString.$asString(), function() {
        self.$error_('no such inst var');
    }
    ), aValue);
};
Object.prototype.$oopString = function()
{
    var self = this;
    console.log('$oopString');
    return self.$asOop().$printString();
};
Object.prototype.$primitiveChangeClassTo_ = function(anObject)
{
    var self = this;
    console.log('$primitiveChangeClassTo_');
    var _primitive = Primitive115(self, anObject);
    if (_primitive) return _primitive.value;
    ;
    self.$primitiveFailed();
};
Object.prototype.$rootStubInImageSegment_ = function(imageSegment)
{
    var self = this;
    console.log('$rootStubInImageSegment_');
    return ImageSegmentRootStub.$new().$xxSuperclass_format_segment_(nil, nil, imageSegment);
};
Object.prototype.$someObject = function()
{
    var self = this;
    console.log('$someObject');
    var _primitive = Primitive138(self);
    if (_primitive) return _primitive.value;
    ;
    self.$primitiveFailed();
};
Object.prototype.$beViewed = function()
{
    var self = this;
    console.log('$beViewed');
    self.$uniqueNameForReference();
    self.$presenter().$viewObject_(self);
};
Object.prototype.$belongsToUniClass = function()
{
    var self = this;
    console.log('$belongsToUniClass');
    return self.$class().$isUniClass();
};
Object.prototype.$costumes = function()
{
    var self = this;
    console.log('$costumes');
    return nil;
};
Object.prototype.$haltIfNil = function()
{
    var self = this;
    console.log('$haltIfNil');
};
Object.prototype.$hasLiteralSuchThat_ = function(testBlock)
{
    var self = this;
    console.log('$hasLiteralSuchThat_');
    return false;
};
Object.prototype.$hasLiteralThorough_ = function(literal)
{
    var self = this;
    console.log('$hasLiteralThorough_');
    return false;
};
Object.prototype.$isArray = function()
{
    var self = this;
    console.log('$isArray');
    return false;
};
Object.prototype.$isBehavior = function()
{
    var self = this;
    console.log('$isBehavior');
    return false;
};
Object.prototype.$isBlock = function()
{
    var self = this;
    console.log('$isBlock');
    return false;
};
Object.prototype.$isCharacter = function()
{
    var self = this;
    console.log('$isCharacter');
    return false;
};
Object.prototype.$isClosure = function()
{
    var self = this;
    console.log('$isClosure');
    return false;
};
Object.prototype.$isCollection = function()
{
    var self = this;
    console.log('$isCollection');
    return false;
};
Object.prototype.$isColor = function()
{
    var self = this;
    console.log('$isColor');
    return false;
};
Object.prototype.$isColorForm = function()
{
    var self = this;
    console.log('$isColorForm');
    return false;
};
Object.prototype.$isCompiledMethod = function()
{
    var self = this;
    console.log('$isCompiledMethod');
    return false;
};
Object.prototype.$isComplex = function()
{
    var self = this;
    console.log('$isComplex');
    return false;
};
Object.prototype.$isContext = function()
{
    var self = this;
    console.log('$isContext');
    return false;
};
Object.prototype.$isDictionary = function()
{
    var self = this;
    console.log('$isDictionary');
    return false;
};
Object.prototype.$isFloat = function()
{
    var self = this;
    console.log('$isFloat');
    return false;
};
Object.prototype.$isForm = function()
{
    var self = this;
    console.log('$isForm');
    return false;
};
Object.prototype.$isFraction = function()
{
    var self = this;
    console.log('$isFraction');
    return false;
};
Object.prototype.$isHeap = function()
{
    var self = this;
    console.log('$isHeap');
    return false;
};
Object.prototype.$isInteger = function()
{
    var self = this;
    console.log('$isInteger');
    return false;
};
Object.prototype.$isInterval = function()
{
    var self = this;
    console.log('$isInterval');
    return false;
};
Object.prototype.$isMessageSend = function()
{
    var self = this;
    console.log('$isMessageSend');
    return false;
};
Object.prototype.$isMethodContext = function()
{
    var self = this;
    console.log('$isMethodContext');
    return false;
};
Object.prototype.$isMethodProperties = function()
{
    var self = this;
    console.log('$isMethodProperties');
    return false;
};
Object.prototype.$isMorph = function()
{
    var self = this;
    console.log('$isMorph');
    return false;
};
Object.prototype.$isMorphicEvent = function()
{
    var self = this;
    console.log('$isMorphicEvent');
    return false;
};
Object.prototype.$isMorphicModel = function()
{
    var self = this;
    console.log('$isMorphicModel');
    return false;
};
Object.prototype.$isNumber = function()
{
    var self = this;
    console.log('$isNumber');
    return false;
};
Object.prototype.$isPlayer = function()
{
    var self = this;
    console.log('$isPlayer');
    return false;
};
Object.prototype.$isPoint = function()
{
    var self = this;
    console.log('$isPoint');
    return false;
};
Object.prototype.$isPseudoContext = function()
{
    var self = this;
    console.log('$isPseudoContext');
    return false;
};
Object.prototype.$isRectangle = function()
{
    var self = this;
    console.log('$isRectangle');
    return false;
};
Object.prototype.$isScriptEditorMorph = function()
{
    var self = this;
    console.log('$isScriptEditorMorph');
    return false;
};
Object.prototype.$isSketchMorph = function()
{
    var self = this;
    console.log('$isSketchMorph');
    return false;
};
Object.prototype.$isStream = function()
{
    var self = this;
    console.log('$isStream');
    return false;
};
Object.prototype.$isString = function()
{
    var self = this;
    console.log('$isString');
    return false;
};
Object.prototype.$isSymbol = function()
{
    var self = this;
    console.log('$isSymbol');
    return false;
};
Object.prototype.$isSystemWindow = function()
{
    var self = this;
    console.log('$isSystemWindow');
    return false;
};
Object.prototype.$isText = function()
{
    var self = this;
    console.log('$isText');
    return false;
};
Object.prototype.$isTextView = function()
{
    var self = this;
    console.log('$isTextView');
    return false;
};
Object.prototype.$isTrait = function()
{
    var self = this;
    console.log('$isTrait');
    return false;
};
Object.prototype.$isTransparent = function()
{
    var self = this;
    console.log('$isTransparent');
    return false;
};
Object.prototype.$isVariableBinding = function()
{
    var self = this;
    console.log('$isVariableBinding');
    return false;
};
Object.prototype.$isWebBrowser = function()
{
    var self = this;
    console.log('$isWebBrowser');
    return false;
};
Object.prototype.$isWindowForModel_ = function(aModel)
{
    var self = this;
    console.log('$isWindowForModel_');
    return false;
};
Object.prototype.$knownName = function()
{
    var self = this;
    console.log('$knownName');
    return Preferences.$capitalizedReferences().$ifTrue_ifFalse_(function() {
        References.$keyAtValue_ifAbsent_(self, function() {
            nil;
        }
        );
    }
    , function() {
        nil;
    }
    );
};
Object.prototype.$name = function()
{
    var self = this;
    console.log('$name');
    return self.$printString();
};
Object.prototype.$nameForViewer = function()
{
    var self = this;
    console.log('$nameForViewer');
    var aName = null
    (aName = self.$uniqueNameForReferenceOrNil()).$ifNotNil_(function() {
        return aName;
    }
    );
    (aName = self.$knownName()).$ifNotNil_(function() {
        return aName;
    }
    );
    return (function() {
        self.$asString().$copyWithout_(Character.$cr()).$truncateTo_(27);
    }
    ).$ifError_(function(msg, rcvr) {
        self.$class().$name().$printString();
    }
    );
};
Object.prototype.$notNil = function()
{
    var self = this;
    console.log('$notNil');
    return true;
};
Object.prototype.$renameInternal_ = function(newName)
{
    var self = this;
    console.log('$renameInternal_');
    return nil;
};
Object.prototype.$renameTo_ = function(newName)
{
    var self = this;
    console.log('$renameTo_');
};
Object.prototype.$showDiffs = function()
{
    var self = this;
    console.log('$showDiffs');
    return false;
};
Object.prototype.$stepAt_in_ = function(millisecondClockValue, aWindow)
{
    var self = this;
    console.log('$stepAt_in_');
    return self.$stepIn_(aWindow);
};
Object.prototype.$stepIn_ = function(aWindow)
{
    var self = this;
    console.log('$stepIn_');
    return self.$step();
};
Object.prototype.$stepTime = function()
{
    var self = this;
    console.log('$stepTime');
    return 1000;
};
Object.prototype.$stepTimeIn_ = function(aSystemWindow)
{
    var self = this;
    console.log('$stepTimeIn_');
    return 1000;
};
Object.prototype.$vocabularyDemanded = function()
{
    var self = this;
    console.log('$vocabularyDemanded');
    return nil;
};
Object.prototype.$wantsDiffFeedback = function()
{
    var self = this;
    console.log('$wantsDiffFeedback');
    return false;
};
Object.prototype.$wantsSteps = function()
{
    var self = this;
    console.log('$wantsSteps');
    return false;
};
Object.prototype.$wantsStepsIn_ = function(aSystemWindow)
{
    var self = this;
    console.log('$wantsStepsIn_');
    return self.$wantsSteps();
};
Object.prototype.$inline_ = function(inlineFlag)
{
    var self = this;
    console.log('$inline_');
};
Object.prototype.$var_declareC_ = function(varSymbol, declString)
{
    var self = this;
    console.log('$var_declareC_');
};
Object.prototype.$capturedState = function()
{
    var self = this;
    console.log('$capturedState');
    return self.$shallowCopy();
};
Object.prototype.$commandHistory = function()
{
    var self = this;
    console.log('$commandHistory');
    var w = null
    (w = self.$currentWorld()).$ifNotNil_(function() {
        return w.$commandHistory();
    }
    );
    return CommandHistory.$new();
};
Object.prototype.$purgeAllCommands = function()
{
    var self = this;
    console.log('$purgeAllCommands');
    Preferences.$useUndo().$ifFalse_(function() {
        return self;
    }
    );
    self.$commandHistory().$purgeAllCommandsSuchThat_(function(cmd) {
        cmd.$undoTarget() == self;
    }
    );
};
Object.prototype.$redoFromCapturedState_ = function(st)
{
    var self = this;
    console.log('$redoFromCapturedState_');
    self.$undoFromCapturedState_(st);
};
Object.prototype.$refineRedoTarget_selector_arguments_in_ = function(target, aSymbol, arguments, refineBlock)
{
    var self = this;
    console.log('$refineRedoTarget_selector_arguments_in_');
    return refineBlock.$value_value_value_(target, aSymbol, arguments);
};
Object.prototype.$refineUndoTarget_selector_arguments_in_ = function(target, aSymbol, arguments, refineBlock)
{
    var self = this;
    console.log('$refineUndoTarget_selector_arguments_in_');
    return refineBlock.$value_value_value_(target, aSymbol, arguments);
};
Object.prototype.$rememberCommand_ = function(aCommand)
{
    var self = this;
    console.log('$rememberCommand_');
    Preferences.$useUndo().$ifFalse_(function() {
        return self;
    }
    );
    return self.$commandHistory().$rememberCommand_(aCommand);
};
Object.prototype.$rememberUndoableAction_named_ = function(actionBlock, caption)
{
    var self = this;
    console.log('$rememberUndoableAction_named_');
    var cmd = null
    var result = null
    cmd = Command.$new().$cmdWording_(caption);
    cmd.$undoTarget_selector_argument_(self, 'undoFromCapturedState:', self.$capturedState());
    result = actionBlock.$value();
    cmd.$redoTarget_selector_argument_(self, 'redoFromCapturedState:', self.$capturedState());
    self.$rememberCommand_(cmd);
    return result;
};
Object.prototype.$undoFromCapturedState_ = function(st)
{
    var self = this;
    console.log('$undoFromCapturedState_');
    self.$copyFrom_(st);
};
Object.prototype.$changed = function()
{
    var self = this;
    console.log('$changed');
    self.$changed_(self);
};
Object.prototype.$changed_ = function(aParameter)
{
    var self = this;
    console.log('$changed_');
    self.$dependents().$do_(function(aDependent) {
        aDependent.$update_(aParameter);
    }
    );
};
Object.prototype.$changed_with_ = function(anAspect, anObject)
{
    var self = this;
    console.log('$changed_with_');
    self.$dependents().$do_(function(aDependent) {
        aDependent.$update_with_(anAspect, anObject);
    }
    );
};
Object.prototype.$handledListVerification = function()
{
    var self = this;
    console.log('$handledListVerification');
    return false;
};
Object.prototype.$noteSelectionIndex_for_ = function(anInteger, aSymbol)
{
    var self = this;
    console.log('$noteSelectionIndex_for_');
};
Object.prototype.$okToChange = function()
{
    var self = this;
    console.log('$okToChange');
    return true;
};
Object.prototype.$updateListsAndCodeIn_ = function(aWindow)
{
    var self = this;
    console.log('$updateListsAndCodeIn_');
    self.$canDiscardEdits().$ifFalse_(function() {
        return self;
    }
    );
    aWindow.$updatablePanes().$do_(function(aPane) {
        aPane.$verifyContents();
    }
    );
};
Object.prototype.$update_ = function(aParameter)
{
    var self = this;
    console.log('$update_');
    return self;
};
Object.prototype.$update_with_ = function(anAspect, anObject)
{
    var self = this;
    console.log('$update_with_');
    return self.$update_(anAspect);
};
Object.prototype.$windowIsClosing = function()
{
    var self = this;
    console.log('$windowIsClosing');
};
Object.prototype.$addModelItemsToWindowMenu_ = function(aMenu)
{
    var self = this;
    console.log('$addModelItemsToWindowMenu_');
};
Object.prototype.$addModelMenuItemsTo_forMorph_hand_ = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    console.log('$addModelMenuItemsTo_forMorph_hand_');
};
Object.prototype.$asExplorerString = function()
{
    var self = this;
    console.log('$asExplorerString');
    return self.$printString();
};
Object.prototype.$defaultBackgroundColor = function()
{
    var self = this;
    console.log('$defaultBackgroundColor');
    return Preferences.$windowColorFor_(self.$class().$name());
};
Object.prototype.$defaultLabelForInspector = function()
{
    var self = this;
    console.log('$defaultLabelForInspector');
    return self.$class().$name();
};
Object.prototype.$eToyStreamedRepresentationNotifying_ = function(aWidget)
{
    var self = this;
    console.log('$eToyStreamedRepresentationNotifying_');
    var outData = null
    (function() {
        outData = SmartRefStream.$streamedRepresentationOf_(self);
    }
    ).$on_do_(ProgressInitiationException, function(ex) {
        ex.$sendNotificationsTo_(function(min, max, curr) {
            aWidget.$ifNotNil_(function() {
                aWidget.$flashIndicator_('working');
            }
            );
        }
        );
    }
    );
    return outData;
};
Object.prototype.$explore = function()
{
    var self = this;
    console.log('$explore');
    return ToolSet.$explore_(self);
};
Object.prototype.$fullScreenSize = function()
{
    var self = this;
    console.log('$fullScreenSize');
    var adj = null
    adj = (Number(3) * Preferences.$scrollBarWidth()).$_at_(0);
    return Rectangle.$origin_extent_(adj, DisplayScreen.$actualScreenSize() - adj);
};
Object.prototype.$inform_ = function(aString)
{
    var self = this;
    console.log('$inform_');
    aString.$isEmptyOrNil().$ifFalse_(function() {
        UIManager.$default().$inform_(aString);
    }
    );
};
Object.prototype.$initialExtent = function()
{
    var self = this;
    console.log('$initialExtent');
    return RealEstateAgent.$standardWindowExtent();
};
Object.prototype.$inspectWithLabel_ = function(aLabel)
{
    var self = this;
    console.log('$inspectWithLabel_');
    return ToolSet.$inspect_label_(self, aLabel);
};
Object.prototype.$launchPartVia_ = function(aSelector)
{
    var self = this;
    console.log('$launchPartVia_');
    var aMorph = null
    aMorph = self.$perform_(aSelector);
    aMorph.$setProperty_toValue_('beFullyVisibleAfterDrop', true);
    aMorph.$openInHand();
};
Object.prototype.$launchPartVia_label_ = function(aSelector, aString)
{
    var self = this;
    console.log('$launchPartVia_label_');
    var aMorph = null
    aMorph = self.$perform_(aSelector);
    aMorph.$setNameTo_(ActiveWorld.$unusedMorphNameLike_(aString));
    aMorph.$setProperty_toValue_('beFullyVisibleAfterDrop', true);
    aMorph.$openInHand();
};
Object.prototype.$launchTileToRefer = function()
{
    var self = this;
    console.log('$launchTileToRefer');
    self.$currentHand().$attachMorph_(self.$tileToRefer());
};
Object.prototype.$modelSleep = function()
{
    var self = this;
    console.log('$modelSleep');
};
Object.prototype.$modelWakeUp = function()
{
    var self = this;
    console.log('$modelWakeUp');
};
Object.prototype.$modelWakeUpIn_ = function(aWindow)
{
    var self = this;
    console.log('$modelWakeUpIn_');
    self.$modelWakeUp();
};
Object.prototype.$mouseUpBalk_ = function(evt)
{
    var self = this;
    console.log('$mouseUpBalk_');
};
Object.prototype.$notYetImplemented = function()
{
    var self = this;
    console.log('$notYetImplemented');
    NotYetImplemented.$signal();
};
Object.prototype.$windowActiveOnFirstClick = function()
{
    var self = this;
    console.log('$windowActiveOnFirstClick');
    return false;
};
Object.prototype.$windowReqNewLabel_ = function(labelString)
{
    var self = this;
    console.log('$windowReqNewLabel_');
    return true;
};
Object.prototype.$isConflict = function()
{
    var self = this;
    console.log('$isConflict');
    return false;
};
Object.prototype.$requestor = function()
{
    var self = this;
    console.log('$requestor');
    return Requestor.$default();
};
Object.prototype.$systemNavigation = function()
{
    var self = this;
    console.log('$systemNavigation');
    return SystemNavigation.$default();
};
Object.prototype.$exploreAndYourself = function()
{
    var self = this;
    console.log('$exploreAndYourself');
    self.$explore();
    return self;
};
Object.prototype.$exploreWithLabel_ = function(label)
{
    var self = this;
    console.log('$exploreWithLabel_');
    return ObjectExplorer.$new().$openExplorerFor_withLabel_(self, label);
};
Object.prototype.$browse = function()
{
    var self = this;
    console.log('$browse');
    self.$systemNavigation().$browseClass_(self.$class());
};
Object.prototype.$browseHierarchy = function()
{
    var self = this;
    console.log('$browseHierarchy');
    self.$systemNavigation().$browseHierarchy_(self.$class());
};
Object.prototype.$errorImproperStore = function()
{
    var self = this;
    console.log('$errorImproperStore');
    self.$error_('Improper store into indexable object');
};
Object.prototype.$errorNonIntegerIndex = function()
{
    var self = this;
    console.log('$errorNonIntegerIndex');
    self.$error_('only integers should be used as indices');
};
Object.prototype.$errorNotIndexable = function()
{
    var self = this;
    console.log('$errorNotIndexable');
    self.$error_(String('Instances of {1} are not indexable').$translated().$format_([self.$class().$name()]));
};
Object.prototype.$errorSubscriptBounds_ = function(index)
{
    var self = this;
    console.log('$errorSubscriptBounds_');
    self.$error_(String('subscript is out of bounds: ') , index.$printString());
};
Object.prototype.$primitiveError_ = function(aString)
{
    var self = this;
    console.log('$primitiveError_');
    String.$streamContents_(function(s) {
        var context = null;
        s.$nextPutAll_('***System error handling failed***');
        (function () {var _aux = s.$cr();return _aux;})().$nextPutAll_(aString);
        context = thisContext.$sender().$sender();
        Number(20).$timesRepeat_(function() {
            (context == nil).$ifFalse_(function() {
                (function () {var _aux = s.$cr();return _aux;})().$print_(context = context.$sender());
            }
            );
        }
        );
        (function () {var _aux = s.$cr();return _aux;})().$nextPutAll_('-------------------------------');
        (function () {var _aux = s.$cr();return _aux;})().$nextPutAll_('Type CR to enter an emergency evaluator.');
        (function () {var _aux = s.$cr();return _aux;})().$nextPutAll_('Type any other character to restart.');
    }
    ).$displayAt_(Number(0).$_at_(0));
    (function() {
        Sensor.$keyboardPressed();
    }
    ).$whileFalse();
    (Sensor.$keyboard().$_equal_(Character.$cr())).$ifTrue_(function() {
        Transcripter.$emergencyEvaluator();
    }
    );
    Project.$current().$resetDisplay();
};
Object.prototype.$species = function()
{
    var self = this;
    console.log('$species');
    var _primitive = Primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    return self.$class();
};
Object.prototype.$storeAt_inTempFrame_ = function(offset, aContext)
{
    var self = this;
    console.log('$storeAt_inTempFrame_');
    return aContext.$tempAt_put_(offset, self);
};
Object.prototype.$isNonZero = function()
{
    var self = this;
    console.log('$isNonZero');
    return false;
};
Object.prototype.$actionsWithReceiver_forEvent_ = function(anObject, anEventSelector)
{
    var self = this;
    console.log('$actionsWithReceiver_forEvent_');
    return self.$actionSequenceForEvent_(anEventSelector).$select_(function(anAction) {
        anAction.$receiver() == anObject;
    }
    );
};
Object.prototype.$renameActionsWithReceiver_forEvent_toEvent_ = function(anObject, anEventSelector, newEvent)
{
    var self = this;
    console.log('$renameActionsWithReceiver_forEvent_toEvent_');
    var oldActions = null
    var newActions = null
    oldActions = Set.$new();
    newActions = Set.$new();
    self.$actionSequenceForEvent_(anEventSelector).$do_(function(action) {
        (action.$receiver() == anObject).$ifTrue_ifFalse_(function() {
            oldActions.$add_(anObject);
        }
        , function() {
            newActions.$add_(anObject);
        }
        );
    }
    );
    self.$setActionSequence_forEvent_(ActionSequence.$withAll_(newActions), anEventSelector);
    oldActions.$do_(function(act) {
        self.$when_evaluate_(newEvent, act);
    }
    );
};
Object.prototype.$basicInspect = function()
{
    var self = this;
    console.log('$basicInspect');
    return ToolSet.$basicInspect_(self);
};
Object.prototype.$inspect = function()
{
    var self = this;
    console.log('$inspect');
    ToolSet.$inspect_(self);
};
Object.prototype.$inspectorClass = function()
{
    var self = this;
    console.log('$inspectorClass');
    return Inspector;
};
Object.prototype.$iconOrThumbnailOfSize_ = function(aNumberOrPoint)
{
    var self = this;
    console.log('$iconOrThumbnailOfSize_');
    return nil;
};
Object.prototype.$break = function()
{
    var self = this;
    console.log('$break');
    BreakPoint.$signal();
};
Object.prototype.$isUPackage = function()
{
    var self = this;
    console.log('$isUPackage');
    return false;
};
Object.prototype.$isUPackageCategory = function()
{
    var self = this;
    console.log('$isUPackageCategory');
    return false;
};
Object.prototype.$hasContentsInExplorer = function()
{
    var self = this;
    console.log('$hasContentsInExplorer');
    return (self.$basicSize() > 0).$or_(function() {
        self.$class().$allInstVarNames().$isEmpty().$not();
    }
    );
};
Object.prototype.$future = function()
{
    var self = this;
    console.log('$future');
    return FutureMaker.$new().$setDeltaMSecs_(0);
    Number(0).$target_(self);
};
Object.prototype.$future_ = function(deltaMSecs)
{
    var self = this;
    console.log('$future_');
    return FutureMaker.$new().$setDeltaMSecs_target_(deltaMSecs, self);
};
Object.prototype.$futureDo_at_args_ = function(aSelector, deltaMSecs, args)
{
    var self = this;
    console.log('$futureDo_at_args_');
    Project.$current().$future_do_at_args_(self, aSelector, deltaMSecs, args);
    return nil;
};
Object.prototype.$futureSend_at_args_ = function(aSelector, deltaMSecs, args)
{
    var self = this;
    console.log('$futureSend_at_args_');
    return Project.$current().$future_send_at_args_(self, aSelector, deltaMSecs, args);
};
Object.prototype.$assureUniClass = function()
{
    var self = this;
    console.log('$assureUniClass');
    var anInstance = null
    self.$belongsToUniClass().$ifTrue_(function() {
        return self;
    }
    );
    anInstance = self.$class().$instanceOfUniqueClass();
    self.$become_(self.$as_(anInstance.$class()));
    return anInstance;
};
Object.prototype.$browseOwnClassSubProtocol = function()
{
    var self = this;
    console.log('$browseOwnClassSubProtocol');
    ProtocolBrowser.$openSubProtocolForClass_(self.$class());
};
Object.prototype.$categoriesForViewer_ = function(aViewer)
{
    var self = this;
    console.log('$categoriesForViewer_');
    return aViewer.$currentVocabulary().$categoryListForInstance_ofClass_limitClass_(self, self.$class(), aViewer.$limitClass());
};
Object.prototype.$categoriesForVocabulary_limitClass_ = function(aVocabulary, aLimitClass)
{
    var self = this;
    console.log('$categoriesForVocabulary_limitClass_');
    return aVocabulary.$categoryListForInstance_ofClass_limitClass_(self, self.$class(), aLimitClass);
};
Object.prototype.$chooseNewNameForReference = function()
{
    var self = this;
    console.log('$chooseNewNameForReference');
    var nameSym = null
    var current = null
    var newName = null
    current = References.$keyAtValue_ifAbsent_(self, function() {
        return self.$error_('not found in References');
    }
    );
    newName = UIManager.$default().$request_initialAnswer_('Please enter new name', current);
    newName.$isEmpty().$ifTrue_(function() {
        return nil;
    }
    );
    Scanner.$isLiteralSymbol_(newName).$and_(function() {
        newName.$includes_(':').$not();
    }
    ).$ifTrue_(function() {
        nameSym = newName.$capitalized().$asSymbol();
        References.$includesKey_(nameSym).$not().$and_(function() {
            Smalltalk.$includesKey_(nameSym).$not();
        }
        ).$and_(function() {
            ScriptingSystem.$allKnownClassVariableNames().$includes_(nameSym).$not();
        }
        ).$ifTrue_(function() {
            References.$associationAt_(current).$key_(nameSym);
            References.$rehash();
            return nameSym;
        }
        );
    }
    );
    self.$inform_('Sorry, that name is not available.');
    return nil;
};
Object.prototype.$defaultLimitClassForVocabulary_ = function(aVocabulary)
{
    var self = this;
    console.log('$defaultLimitClassForVocabulary_');
    return aVocabulary.$isKindOf_(FullVocabulary).$ifTrue_ifFalse_(function() {
        (self.$class().$superclass() == Object).$ifTrue_ifFalse_(function() {
            self.$class();
        }
        , function() {
            self.$class().$superclass();
        }
        );
    }
    , function() {
        ProtoObject;
    }
    );
};
Object.prototype.$defaultNameStemForInstances = function()
{
    var self = this;
    console.log('$defaultNameStemForInstances');
    return self.$class().$defaultNameStemForInstances();
};
Object.prototype.$elementTypeFor_vocabulary_ = function(aStringOrSymbol, aVocabulary)
{
    var self = this;
    console.log('$elementTypeFor_vocabulary_');
    self.$flag_('deferred');
    return 'systemScript';
};
Object.prototype.$externalName = function()
{
    var self = this;
    console.log('$externalName');
    return self.$nameForViewer();
};
Object.prototype.$graphicForViewerTab = function()
{
    var self = this;
    console.log('$graphicForViewerTab');
    return ScriptingSystem.$formAtKey_('Image');
};
Object.prototype.$hasUserDefinedSlots = function()
{
    var self = this;
    console.log('$hasUserDefinedSlots');
    return false;
};
Object.prototype.$infoFor_inViewer_ = function(anElement, aViewer)
{
    var self = this;
    console.log('$infoFor_inViewer_');
    var aMenu = null
    var elementType = null
    elementType = self.$elementTypeFor_vocabulary_(anElement, aViewer.$currentVocabulary());
    ((elementType.$_equal_('systemSlot')) | elementType == 'userSlot').$ifTrue_(function() {
        return self.$slotInfoButtonHitFor_inViewer_(anElement, aViewer);
    }
    );
    self.$flag_('deferred');
    aMenu = MenuMorph.$new().$defaultTarget_(aViewer);
    [['implementors', 'browseImplementorsOf:'], ['senders', 'browseSendersOf:'], ['versions', 'browseVersionsOf:'], '-', ['browse full', 'browseMethodFull:'], ['inheritance', 'browseMethodInheritance:'], '-', ['about this method', 'aboutMethod:']].$do_(function(pair) {
        (pair.$_equal_('-')).$ifTrue_ifFalse_(function() {
            aMenu.$addLine();
        }
        , function() {
            aMenu.$add_target_selector_argument_(pair.$first(), aViewer, pair.$second(), anElement);
        }
        );
    }
    );
    aMenu.$addLine();
    aMenu.$defaultTarget_(self);
    [['destroy script', 'removeScript:'], ['rename script', 'renameScript:'], ['pacify script', 'pacifyScript:']].$do_(function(pair) {
        aMenu.$add_target_selector_argument_(pair.$first(), self, pair.$second(), anElement);
    }
    );
    aMenu.$addLine();
    aMenu.$add_target_selector_argument_('show categories....', aViewer, 'showCategoriesFor:', anElement);
    (aMenu.$items().$size() == 0).$ifTrue_(function() {
        aMenu.$add_action_('ok', nil);
    }
    );
    aMenu.$addTitle_(((anElement.$asString() , ' (') , elementType) , ')');
    aMenu.$popUpInWorld_(self.$currentWorld());
};
Object.prototype.$initialTypeForSlotNamed_ = function(aName)
{
    var self = this;
    console.log('$initialTypeForSlotNamed_');
    return 'Object';
};
Object.prototype.$isPlayerLike = function()
{
    var self = this;
    console.log('$isPlayerLike');
    return false;
};
Object.prototype.$methodInterfacesInPresentationOrderFrom_forCategory_ = function(interfaceList, aCategory)
{
    var self = this;
    console.log('$methodInterfacesInPresentationOrderFrom_forCategory_');
    var masterOrder = null
    var ordered = null
    var unordered = null
    masterOrder = Vocabulary.$eToyVocabulary().$masterOrderingOfPhraseSymbols();
    ordered = SortedCollection.$sortBlock_(function(a, b) {
        a.$key() < b.$key();
    }
    );
    unordered = SortedCollection.$sortBlock_(function(a, b) {
        a.$wording() < b.$wording();
    }
    );
    interfaceList.$do_(function(interface) {
        var index = null;
        index = masterOrder.$indexOf_(interface.$elementSymbol());
        index.$isZero().$ifTrue_ifFalse_(function() {
            unordered.$add_(interface);
        }
        , function() {
            ordered.$add_(index.$_assoc_(interface));
        }
        );
    }
    );
    return Array.$streamContents_(function(stream) {
        ordered.$do_(function(assoc) {
            stream.$nextPut_(assoc.$value());
        }
        );
        stream.$nextPutAll_(unordered);
    }
    );
};
Object.prototype.$newScriptorAround_ = function(aPhraseTileMorph)
{
    var self = this;
    console.log('$newScriptorAround_');
    return nil;
};
Object.prototype.$newTileMorphRepresentative = function()
{
    var self = this;
    console.log('$newTileMorphRepresentative');
    return TileMorph.$new().$setLiteral_(self);
};
Object.prototype.$offerViewerMenuFor_event_ = function(aViewer, evt)
{
    var self = this;
    console.log('$offerViewerMenuFor_event_');
    var aMenu = null
    aMenu = MenuMorph.$new().$defaultTarget_(self);
    aMenu.$addStayUpItem();
    aMenu.$title_(String('**CAUTION -- UNDER CONSTRUCTION!**\rMany things may not work!\r') , self.$nameForViewer());
    aViewer.$affordsUniclass().$and_(function() {
        self.$belongsToUniClass().$not();
    }
    ).$ifTrue_(function() {
        aMenu.$add_action_('give me a Uniclass', 'assureUniClass');
        aMenu.$addLine();
    }
    );
    aMenu.$add_target_action_('choose vocabulary...', aViewer, 'chooseVocabulary');
    aMenu.$add_target_action_('choose limit class...', aViewer, 'chooseLimitClass');
    aMenu.$add_target_action_('add search pane', aViewer, 'addSearchPane');
    aMenu.$balloonTextForLastItem_('Specify which class should be the most generic one to have its methods shown in this Viewer');
    aMenu.$addLine();
    self.$belongsToUniClass().$ifTrue_(function() {
        aMenu.$add_target_selector_argument_('add a new instance variable', self, 'addInstanceVariableIn:', aViewer);
        aMenu.$add_target_selector_argument_('add a new script', aViewer, 'newPermanentScriptIn:', aViewer);
        aMenu.$addLine();
        aMenu.$add_target_selector_argument_('make my class be first-class', self, 'makeFirstClassClassIn:', aViewer);
        aMenu.$add_target_action_('move my changes up to my superclass', self, 'promoteChangesToSuperclass');
        aMenu.$addLine();
    }
    );
    aMenu.$add_target_selector_('tear off a tile', self, 'launchTileToRefer');
    aMenu.$addLine();
    aMenu.$add_target_selector_('inspect me', self, 'inspect');
    aMenu.$add_target_action_('inspect my class', self.$class(), 'inspect');
    aMenu.$addLine();
    aMenu.$add_action_('browse vocabulary', 'haveFullProtocolBrowsed');
    aMenu.$add_target_action_('inspect this Viewer', aViewer, 'inspect');
    aMenu.$popUpEvent_in_(evt, aViewer.$currentWorld());
};
Object.prototype.$offerViewerMenuForEvt_morph_ = function(anEvent, aMorph)
{
    var self = this;
    console.log('$offerViewerMenuForEvt_morph_');
    self.$offerViewerMenuFor_event_(aMorph.$ownerThatIsA_(StandardViewer), anEvent);
};
Object.prototype.$renameScript_ = function(oldSelector)
{
    var self = this;
    console.log('$renameScript_');
    self.$notYetImplemented();
};
Object.prototype.$tilePhrasesForCategory_inViewer_ = function(aCategorySymbol, aViewer)
{
    var self = this;
    console.log('$tilePhrasesForCategory_inViewer_');
    var interfaces = null
    interfaces = self.$methodInterfacesForCategory_inVocabulary_limitClass_(aCategorySymbol, aViewer.$currentVocabulary(), aViewer.$limitClass());
    interfaces = self.$methodInterfacesInPresentationOrderFrom_forCategory_(interfaces, aCategorySymbol);
    return self.$tilePhrasesForMethodInterfaces_inViewer_(interfaces, aViewer);
};
Object.prototype.$tilePhrasesForMethodInterfaces_inViewer_ = function(methodInterfaceList, aViewer)
{
    var self = this;
    console.log('$tilePhrasesForMethodInterfaces_inViewer_');
    var toSuppress = null
    var interfaces = null
    toSuppress = aViewer.$currentVocabulary().$phraseSymbolsToSuppress();
    interfaces = methodInterfaceList.$reject_(function(int) {
        toSuppress.$includes_(int.$selector());
    }
    );
    Preferences.$universalTiles().$ifFalse_(function() {
        interfaces = interfaces.$select_(function(int) {
            var itsSelector = null;
            itsSelector = int.$selector();
            (itsSelector.$numArgs() < 2).$or_(function() {
                ['color:', 'sees:'].$includes_(itsSelector);
            }
            );
        }
        );
    }
    );
    return interfaces.$collect_(function(aMethodInterface) {
        var resultType = null;
        (resultType = aMethodInterface.$resultType()).$notNil().$and_(function() {
            resultType !== 'unknown';
        }
        ).$ifTrue_ifFalse_(function() {
            aViewer.$phraseForVariableFrom_(aMethodInterface);
        }
        , function() {
            aViewer.$phraseForCommandFrom_(aMethodInterface);
        }
        );
    }
    );
};
Object.prototype.$tilePhrasesForSelectorList_inViewer_ = function(aList, aViewer)
{
    var self = this;
    console.log('$tilePhrasesForSelectorList_inViewer_');
    var interfaces = null
    var aVocab = null
    aVocab = aViewer.$currentVocabulary();
    interfaces = self.$methodInterfacesInPresentationOrderFrom_forCategory_(aList.$collect_(function(aSel) {
        aVocab.$methodInterfaceForSelector_class_(aSel, self.$class());
    }
    ), 'search');
    return self.$tilePhrasesForMethodInterfaces_inViewer_(interfaces, aViewer);
};
Object.prototype.$tileToRefer = function()
{
    var self = this;
    console.log('$tileToRefer');
    return TileMorph.$new().$setToReferTo_(self);
};
Object.prototype.$uniqueInstanceVariableNameLike_excluding_ = function(aString, takenNames)
{
    var self = this;
    console.log('$uniqueInstanceVariableNameLike_excluding_');
    var okBase = null
    var uniqueName = null
    var usedNames = null
    usedNames = self.$class().$allInstVarNamesEverywhere();
    usedNames.$removeAllFoundIn_(self.$class().$instVarNames());
    usedNames.$addAll_(takenNames);
    okBase = Scanner.$wellFormedInstanceVariableNameFrom_(aString);
    uniqueName = Utilities.$keyLike_satisfying_(okBase, function(aKey) {
        usedNames.$includes_(aKey).$not();
    }
    );
    return uniqueName;
};
Object.prototype.$uniqueNameForReference = function()
{
    var self = this;
    console.log('$uniqueNameForReference');
    var aName = null
    var stem = null
    var knownClassVars = null
    (aName = self.$uniqueNameForReferenceOrNil()).$ifNotNil_(function() {
        return aName;
    }
    );
    (stem = self.$knownName()).$ifNil_(function() {
        stem = self.$defaultNameStemForInstances().$asString();
    }
    );
    stem = stem.$select_(function(ch) {
        ch.$isLetter().$or_(function() {
            ch.$isDigit();
        }
        );
    }
    );
    (stem.$size() == 0).$ifTrue_(function() {
        stem = 'A';
    }
    );
    stem.$first().$isLetter().$ifFalse_(function() {
        stem = String('A') , stem;
    }
    );
    stem = stem.$capitalized();
    knownClassVars = ScriptingSystem.$allKnownClassVariableNames();
    aName = Utilities.$keyLike_satisfying_(stem, function(jinaLake) {
        var nameSym = null;
        nameSym = jinaLake.$asSymbol();
        References.$includesKey_(nameSym).$not().$and_(function() {
            Smalltalk.$includesKey_(nameSym).$not();
        }
        ).$and_(function() {
            knownClassVars.$includes_(nameSym).$not();
        }
        );
    }
    );
    References.$at_put_(aName = aName.$asSymbol(), self);
    return aName;
};
Object.prototype.$uniqueNameForReferenceFrom_ = function(proposedName)
{
    var self = this;
    console.log('$uniqueNameForReferenceFrom_');
    var aName = null
    var stem = null
    (proposedName.$_equal_(self.$uniqueNameForReferenceOrNil())).$ifTrue_(function() {
        return proposedName;
    }
    );
    stem = proposedName.$select_(function(ch) {
        ch.$isLetter().$or_(function() {
            ch.$isDigit();
        }
        );
    }
    );
    (stem.$size() == 0).$ifTrue_(function() {
        stem = 'A';
    }
    );
    stem.$first().$isLetter().$ifFalse_(function() {
        stem = String('A') , stem;
    }
    );
    stem = stem.$capitalized();
    aName = Utilities.$keyLike_satisfying_(stem, function(jinaLake) {
        var nameSym = null;
        var okay = null;
        nameSym = jinaLake.$asSymbol();
        okay = true;
        self.$class().$bindingOf_(nameSym).$ifNotNil_(function() {
            okay = false;
        }
        );
        okay;
    }
    );
    return aName.$asSymbol();
};
Object.prototype.$uniqueNameForReferenceOrNil = function()
{
    var self = this;
    console.log('$uniqueNameForReferenceOrNil');
    return References.$keyAtValue_ifAbsent_(self, function() {
        nil;
    }
    );
};
Object.prototype.$updateThresholdForGraphicInViewerTab = function()
{
    var self = this;
    console.log('$updateThresholdForGraphicInViewerTab');
    return 20;
};
Object.prototype.$usableMethodInterfacesIn_ = function(aListOfMethodInterfaces)
{
    var self = this;
    console.log('$usableMethodInterfacesIn_');
    return aListOfMethodInterfaces;
};
Object.prototype.$currentVocabulary = function()
{
    var self = this;
    console.log('$currentVocabulary');
    return Project.$current().$currentVocabulary();
};
Object.prototype.$haveFullProtocolBrowsed = function()
{
    var self = this;
    console.log('$haveFullProtocolBrowsed');
    return self.$haveFullProtocolBrowsedShowingSelector_(nil);
};
Object.prototype.$haveFullProtocolBrowsedShowingSelector_ = function(aSelector)
{
    var self = this;
    console.log('$haveFullProtocolBrowsedShowingSelector_');
    var aBrowser = null
    aBrowser = Smalltalk.$at_ifAbsent_('InstanceBrowser', function() {
        return nil;
    }
    ).$new().$useVocabulary_(Vocabulary.$fullVocabulary());
    aBrowser.$openOnObject_inWorld_showingSelector_(self, ActiveWorld, aSelector);
};
Object.prototype.$basicType = function()
{
    var self = this;
    console.log('$basicType');
    return 'Object';
};
Object.prototype.$browseAllCallsOn_ = function(selectorSymbol)
{
    var self = this;
    console.log('$browseAllCallsOn_');
    self.$systemNavigation().$browseAllCallsOn_(selectorSymbol);
};
Object.prototype.$browseAllImplementorsOf_ = function(selectorSymbol)
{
    var self = this;
    console.log('$browseAllImplementorsOf_');
    self.$systemNavigation().$browseAllImplementorsOf_(selectorSymbol);
};
ObjectClass.prototype.$flushDependents = function()
{
    var self = this;
    console.log('$flushDependents');
    DependentsFields.$keysAndValuesDo_(function(key, dep) {
        key.$ifNotNil_(function() {
            key.$removeDependent_(nil);
        }
        );
    }
    );
    DependentsFields.$finalizeValues();
};
ObjectClass.prototype.$flushEvents = function()
{
    var self = this;
    console.log('$flushEvents');
    EventManager.$flushEvents();
};
ObjectClass.prototype.$initialize = function()
{
    var self = this;
    console.log('$initialize');
    DependentsFields.$ifNil_(function() {
        self.$initializeDependentsFields();
    }
    );
};
ObjectClass.prototype.$initializeDependentsFields = function()
{
    var self = this;
    console.log('$initializeDependentsFields');
    DependentsFields = WeakIdentityKeyDictionary.$new();
};
ObjectClass.prototype.$reInitializeDependentsFields = function()
{
    var self = this;
    console.log('$reInitializeDependentsFields');
    var oldFields = null
    oldFields = DependentsFields;
    DependentsFields = WeakIdentityKeyDictionary.$new();
    oldFields.$keysAndValuesDo_(function(obj, deps) {
        deps.$do_(function(d) {
            obj.$addDependent_(d);
        }
        );
    }
    );
};
ObjectClass.prototype.$howToModifyPrimitives = function()
{
    var self = this;
    console.log('$howToModifyPrimitives');
    self.$error_('comment only');
};
ObjectClass.prototype.$whatIsAPrimitive = function()
{
    var self = this;
    console.log('$whatIsAPrimitive');
    self.$error_('comment only');
};
ObjectClass.prototype.$fileReaderServicesForDirectory_ = function(aFileDirectory)
{
    var self = this;
    console.log('$fileReaderServicesForDirectory_');
    return [];
};
ObjectClass.prototype.$fileReaderServicesForFile_suffix_ = function(fullName, suffix)
{
    var self = this;
    console.log('$fileReaderServicesForFile_suffix_');
    return [];
};
ObjectClass.prototype.$services = function()
{
    var self = this;
    console.log('$services');
    return [];
};
ObjectClass.prototype.$categoryForUniclasses = function()
{
    var self = this;
    console.log('$categoryForUniclasses');
    return 'UserObjects';
};
ObjectClass.prototype.$chooseUniqueClassName = function()
{
    var self = this;
    console.log('$chooseUniqueClassName');
    var i = null
    var className = null
    i = 1;
    (function() {
        className = (self.$name() , i.$printString()).$asSymbol();
        Smalltalk.$includesKey_(className);
    }
    ).$whileTrue_(function() {
        i = i + 1;
    }
    );
    return className;
};
ObjectClass.prototype.$initialInstance = function()
{
    var self = this;
    console.log('$initialInstance');
    return self.$new();
};
ObjectClass.prototype.$initializedInstance = function()
{
    var self = this;
    console.log('$initializedInstance');
    return self.$new();
};
ObjectClass.prototype.$instanceOfUniqueClass = function()
{
    var self = this;
    console.log('$instanceOfUniqueClass');
    return self.$instanceOfUniqueClassWithInstVarString_andClassInstVarString_('', '');
};
ObjectClass.prototype.$instanceOfUniqueClassWithInstVarString_andClassInstVarString_ = function(instVarString, classInstVarString)
{
    var self = this;
    console.log('$instanceOfUniqueClassWithInstVarString_andClassInstVarString_');
    return self.$newUniqueClassInstVars_classInstVars_(instVarString, classInstVarString).$initialInstance();
};
ObjectClass.prototype.$isUniClass = function()
{
    var self = this;
    console.log('$isUniClass');
    return false;
};
ObjectClass.prototype.$newFrom_ = function(aSimilarObject)
{
    var self = this;
    console.log('$newFrom_');
    return self.$isVariable().$ifTrue_ifFalse_(function() {
        self.$basicNew_(aSimilarObject.$basicSize());
    }
    , function() {
        self.$basicNew();
    }
    ).$copySameFrom_(aSimilarObject);
};
ObjectClass.prototype.$newUniqueClassInstVars_classInstVars_ = function(instVarString, classInstVarString)
{
    var self = this;
    console.log('$newUniqueClassInstVars_classInstVars_');
    var aName = null
    var aClass = null
    self.$isSystemDefined().$ifFalse_(function() {
        return superclass.$newUniqueClassInstVars_classInstVars_(instVarString, classInstVarString);
    }
    );
    aName = self.$chooseUniqueClassName();
    aClass = self.$subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_(aName, instVarString, '', '', self.$categoryForUniclasses());
    (classInstVarString.$size() > 0).$ifTrue_(function() {
        aClass.$class().$instanceVariableNames_(classInstVarString);
    }
    );
    return aClass;
};
ObjectClass.prototype.$newUserInstance = function()
{
    var self = this;
    console.log('$newUserInstance');
    return self.$instanceOfUniqueClass();
};
ObjectClass.prototype.$readCarefullyFrom_ = function(textStringOrStream)
{
    var self = this;
    console.log('$readCarefullyFrom_');
    var object = null
    Compiler.$couldEvaluate_(textStringOrStream).$ifFalse_(function() {
        return self.$error_('expected String, Stream, or Text');
    }
    );
    object = Compiler.$evaluate_for_notifying_logged_(textStringOrStream, nil, 'error:', false);
    object.$isKindOf_(self).$ifFalse_(function() {
        self.$error_(self.$name() , ' expected');
    }
    );
    return object;
};
ObjectClass.prototype.$readFrom_ = function(textStringOrStream)
{
    var self = this;
    console.log('$readFrom_');
    var object = null
    Compiler.$couldEvaluate_(textStringOrStream).$ifFalse_(function() {
        return self.$error_('expected String, Stream, or Text');
    }
    );
    object = Compiler.$evaluate_(textStringOrStream);
    object.$isKindOf_(self).$ifFalse_(function() {
        self.$error_(self.$name() , ' expected');
    }
    );
    return object;
};
ObjectClass.prototype.$createFrom_size_version_ = function(aSmartRefStream, varsOnDisk, instVarList)
{
    var self = this;
    console.log('$createFrom_size_version_');
    return self.$isVariable().$ifFalse_ifTrue_(function() {
        self.$basicNew();
    }
    , function() {
        self.$basicNew_(varsOnDisk - instVarList.$size() - 1);
    }
    );
};
ObjectClass.prototype.$windowColorSpecification = function()
{
    var self = this;
    console.log('$windowColorSpecification');
    return WindowColorSpec.$classSymbol_wording_brightColor_pastelColor_helpMessage_(self.$name(), 'Default', 'white', 'white', 'Other windows without color preferences.');
};
ObjectClass.prototype.$releaseExternalSettings = function()
{
    var self = this;
    console.log('$releaseExternalSettings');
};

exports.Object = Object;
