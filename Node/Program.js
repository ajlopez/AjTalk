var base = require('./js/ajtalk-base.js');
var send = base.send;
var sendSuper = base.sendSuper;
var primitives = require('./js/ajtalk-primitives.js');
function ProtoObjectClass()
{
}
function ProtoObject()
{
}
ProtoObject.prototype.__class = ProtoObjectClass.prototype;
ProtoObject.classPrototype = ProtoObjectClass.prototype;
ProtoObjectClass.prototype['_basicNew'] = function() { return new ProtoObject(); };
ProtoObject.prototype['executeMethod_'] = function(compiledMethod)
{
    var self = this;
    console.log('executeMethod_');
    send(self, 'deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, 'withArgs_executeMethod_', [[], compiledMethod]);
};
ProtoObject.prototype['with_executeMethod_'] = function(arg1, compiledMethod)
{
    var self = this;
    console.log('with_executeMethod_');
    send(self, 'deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, 'withArgs_executeMethod_', [[arg1], compiledMethod]);
};
ProtoObject.prototype['with_with_executeMethod_'] = function(arg1, arg2, compiledMethod)
{
    var self = this;
    console.log('with_with_executeMethod_');
    send(self, 'deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, 'withArgs_executeMethod_', [[arg1, arg2], compiledMethod]);
};
ProtoObject.prototype['with_with_with_executeMethod_'] = function(arg1, arg2, arg3, compiledMethod)
{
    var self = this;
    console.log('with_with_with_executeMethod_');
    send(self, 'deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, 'withArgs_executeMethod_', [[arg1, arg2, arg3], compiledMethod]);
};
ProtoObject.prototype['with_with_with_with_executeMethod_'] = function(arg1, arg2, arg3, arg4, compiledMethod)
{
    var self = this;
    console.log('with_with_with_with_executeMethod_');
    send(self, 'deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, 'withArgs_executeMethod_', [[arg1, arg2, arg3, arg4], compiledMethod]);
};
ProtoObject.prototype['tryNamedPrimitive'] = function()
{
    var self = this;
    console.log('tryNamedPrimitive');
    var _primitive = primitives.primitive0(self);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_'] = function(arg1)
{
    var self = this;
    console.log('tryNamedPrimitive_');
    var _primitive = primitives.primitive0(self, arg1);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_'] = function(arg1, arg2)
{
    var self = this;
    console.log('tryNamedPrimitive_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_with_'] = function(arg1, arg2, arg3, arg4)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryNamedPrimitive_with_with_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
{
    var self = this;
    console.log('tryNamedPrimitive_with_with_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['tryPrimitive_withArgs_'] = function(primIndex, argumentArray)
{
    var self = this;
    console.log('tryPrimitive_withArgs_');
    var _primitive = primitives.primitive118(self, primIndex, argumentArray);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, 'primitiveFailToken');
};
ProtoObject.prototype['=='] = function(anObject)
{
    var self = this;
    console.log('==');
    var _primitive = primitives.primitive110(self, anObject);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
ProtoObject.prototype['identityHash'] = function()
{
    var self = this;
    console.log('identityHash');
    return send(send(self, 'basicIdentityHash'), 'bitShift_', [18]);
};
ProtoObject.prototype['~~'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('~~');
    send(send(self, '==', [anObject]), 'ifTrue_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ProtoObject.prototype['doOnlyOnce_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('doOnlyOnce_');
    send(send(send(Smalltalk.classPrototype, 'globals'), 'at_ifAbsent_', ['OneShotArmed', function() {
        true;
    }
    ]), 'ifTrue_', [function() {
        send(send(Smalltalk.classPrototype, 'globals'), 'at_put_', ['OneShotArmed', false]);
        if (__context.return) return __context.value;
        send(aBlock, 'value');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ProtoObject.prototype['flag_'] = function(aSymbol)
{
    var self = this;
    console.log('flag_');
};
ProtoObject.prototype['rearmOneShot'] = function()
{
    var self = this;
    console.log('rearmOneShot');
    send(send(Smalltalk.classPrototype, 'globals'), 'at_put_', ['OneShotArmed', true]);
};
ProtoObject.prototype['withArgs_executeMethod_'] = function(argArray, compiledMethod)
{
    var self = this;
    console.log('withArgs_executeMethod_');
    var _primitive = primitives.primitive188(self, argArray, compiledMethod);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
ProtoObject.prototype['initialize'] = function()
{
    var self = this;
    console.log('initialize');
    return self;
};
ProtoObject.prototype['rehash'] = function()
{
    var self = this;
    console.log('rehash');
};
ProtoObject.prototype['basicIdentityHash'] = function()
{
    var self = this;
    console.log('basicIdentityHash');
    var _primitive = primitives.primitive75(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
ProtoObject.prototype['become_'] = function(otherObject)
{
    var self = this;
    console.log('become_');
    send(send(Array.classPrototype, 'with_', [self]), 'elementsExchangeIdentityWith_', [send(Array.classPrototype, 'with_', [otherObject])]);
};
ProtoObject.prototype['cannotInterpret_'] = function(aMessage)
{
    var self = this;
    var __context = {};
    console.log('cannotInterpret_');
    send(send(send(send(self, 'class'), 'lookupSelector_', [send(aMessage, 'selector')]), '==', [nil]), 'ifFalse_', [function() {
        __context.value = send(aMessage, 'sentTo_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Error.classPrototype, 'signal_', ['MethodDictionary fault']);
    if (__context.return) return __context.value;
    return send(aMessage, 'sentTo_', [self]);
};
ProtoObject.prototype['doesNotUnderstand_'] = function(aMessage)
{
    var self = this;
    console.log('doesNotUnderstand_');
    return send((function () {var _aux = send((function () {var _aux = send(send(MessageNotUnderstood.classPrototype, 'new'), 'message_', [aMessage]);return _aux;})(), 'receiver_', [self]);return _aux;})(), 'signal');
};
ProtoObject.prototype['nextInstance'] = function()
{
    var self = this;
    console.log('nextInstance');
    var _primitive = primitives.primitive78(self);
    if (_primitive) return _primitive.value;
    ;
    return nil;
};
ProtoObject.prototype['nextObject'] = function()
{
    var self = this;
    console.log('nextObject');
    var _primitive = primitives.primitive139(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
ProtoObject.prototype['ifNil_'] = function(nilBlock)
{
    var self = this;
    console.log('ifNil_');
    return self;
};
ProtoObject.prototype['ifNil_ifNotNil_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('ifNil_ifNotNil_');
    return send(ifNotNilBlock, 'cull_', [self]);
};
ProtoObject.prototype['ifNotNil_'] = function(ifNotNilBlock)
{
    var self = this;
    console.log('ifNotNil_');
    return send(ifNotNilBlock, 'cull_', [self]);
};
ProtoObject.prototype['ifNotNil_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('ifNotNil_ifNil_');
    return send(ifNotNilBlock, 'cull_', [self]);
};
ProtoObject.prototype['isNil'] = function()
{
    var self = this;
    console.log('isNil');
    return false;
};
ProtoObject.prototype['pointersTo'] = function()
{
    var self = this;
    console.log('pointersTo');
    return send(self, 'pointersToExcept_', [[]]);
};
ProtoObject.prototype['pointersToExcept_'] = function(objectsToExclude)
{
    var self = this;
    var __context = {};
    console.log('pointersToExcept_');
    var results = null
    var anObj = null
    send(Smalltalk.classPrototype, 'garbageCollect');
    if (__context.return) return __context.value;
    results = send(OrderedCollection.classPrototype, 'new_', [1000]);
    anObj = send(self, 'someObject');
    send(function() {
        send(0, '==', [anObj]);
        if (__context.return) return __context.value;
    }
    , 'whileFalse_', [function() {
        send(send(anObj, 'pointsTo_', [self]), 'ifTrue_', [function() {
            send(send(send(anObj, '~~', [send(results, 'collector')]), 'and_', [function() {
                send(send(anObj, '~~', [objectsToExclude]), 'and_', [function() {
                    send(send(anObj, '~~', [thisContext]), 'and_', [function() {
                        send(send(anObj, '~~', [send(thisContext, 'sender')]), 'and_', [function() {
                            send(anObj, '~~', [send(send(thisContext, 'sender'), 'sender')]);
                            if (__context.return) return __context.value;
                        }
                        ]);
                        if (__context.return) return __context.value;
                    }
                    ]);
                    if (__context.return) return __context.value;
                }
                ]);
                if (__context.return) return __context.value;
            }
            ]), 'ifTrue_', [function() {
                send(results, 'add_', [anObj]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        anObj = send(anObj, 'nextObject');
    }
    ]);
    if (__context.return) return __context.value;
    send(objectsToExclude, 'do_', [function(obj) {
        send(results, 'removeAllSuchThat_', [function(el) {
            send(el, '==', [obj]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(results, 'asArray');
};
ProtoObject.prototype['pointsTo_'] = function(anObject)
{
    var self = this;
    console.log('pointsTo_');
    var _primitive = primitives.primitive132(self, anObject);
    if (_primitive) return _primitive.value;
    ;
};
function ObjectClass()
{
}
function Object()
{
}
Object.prototype.__class = ObjectClass.prototype;
Object.classPrototype = ObjectClass.prototype;
ObjectClass.prototype['_basicNew'] = function() { return new Object(); };
ObjectClass.prototype.__proto__ = ProtoObjectClass.prototype;
Object.prototype.__proto__ = ProtoObject.prototype;
ObjectClass.__super = ProtoObjectClass;
Object.__super = ProtoObject;
ObjectClass.$DependentsFields = null;
Object.prototype['printDirectlyToDisplay'] = function()
{
    var self = this;
    console.log('printDirectlyToDisplay');
    send(send(self, 'asString'), 'displayAt_', [send(0, '@', [100])]);
};
Object.prototype['addModelYellowButtonMenuItemsTo_forMorph_hand_'] = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    var __context = {};
    console.log('addModelYellowButtonMenuItemsTo_forMorph_hand_');
    send(send(Morph.classPrototype, 'cmdGesturesEnabled'), 'ifTrue_', [function() {
        send(aCustomMenu, 'add_target_action_', [send('inspect model', 'translated'), self, 'inspect']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return aCustomMenu;
};
Object.prototype['asDraggableMorph'] = function()
{
    var self = this;
    console.log('asDraggableMorph');
    return send((function () {var _aux = send(send(StringMorph.classPrototype, 'contents_', [send(self, 'printString')]), 'color_', [send(Color.classPrototype, 'white')]);return _aux;})(), 'yourself');
};
Object.prototype['asMorph'] = function()
{
    var self = this;
    console.log('asMorph');
    return send(self, 'asStringMorph');
};
Object.prototype['asStringMorph'] = function()
{
    var self = this;
    console.log('asStringMorph');
    return send(send(self, 'asStringOrText'), 'asStringMorph');
};
Object.prototype['asTextMorph'] = function()
{
    var self = this;
    console.log('asTextMorph');
    return send(send(TextMorph.classPrototype, 'new'), 'contentsAsIs_', [send(self, 'asStringOrText')]);
};
Object.prototype['currentEvent'] = function()
{
    var self = this;
    console.log('currentEvent');
    return send(ActiveEvent.classPrototype, 'ifNil_', [function() {
        send(send(self, 'currentHand'), 'lastEvent');
    }
    ]);
};
Object.prototype['currentHand'] = function()
{
    var self = this;
    console.log('currentHand');
    return send(ActiveHand.classPrototype, 'ifNil_', [function() {
        send(send(self, 'currentWorld'), 'primaryHand');
    }
    ]);
};
Object.prototype['currentWorld'] = function()
{
    var self = this;
    console.log('currentWorld');
    return send(send(UIManager.classPrototype, 'default'), 'currentWorld');
};
Object.prototype['externalName'] = function()
{
    var self = this;
    console.log('externalName');
    return send(function() {
        send(send(send(self, 'asString'), 'copyWithout_', [send(Character.classPrototype, 'cr')]), 'truncateTo_', [27]);
    }
    , 'ifError_', [function() {
        __context.value = send(send(send(self, 'class'), 'name'), 'printString');
        __context.return = true;
        return __context.value;
    }
    ]);
};
Object.prototype['hasModelYellowButtonMenuItems'] = function()
{
    var self = this;
    console.log('hasModelYellowButtonMenuItems');
    return send(Morph.classPrototype, 'cmdGesturesEnabled');
};
Object.prototype['iconOrThumbnailOfSize_'] = function(aNumberOrPoint)
{
    var self = this;
    console.log('iconOrThumbnailOfSize_');
    return nil;
};
Object.prototype['openAsMorph'] = function()
{
    var self = this;
    console.log('openAsMorph');
    return send(send(self, 'asMorph'), 'openInHand');
};
Object.prototype['when_send_to_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, aValueHolder)
{
    var self = this;
    console.log('when_send_to_exclusive_');
    send(self, 'when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, 'receiver_selector_', [anObject, aMessageSelector]), 'basicExecuting_', [aValueHolder])]);
};
Object.prototype['when_send_to_with_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, anArg, aValueHolder)
{
    var self = this;
    console.log('when_send_to_with_exclusive_');
    send(self, 'when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, 'with_', [anArg])]), 'basicExecuting_', [aValueHolder])]);
};
Object.prototype['when_send_to_withArguments_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray, aValueHolder)
{
    var self = this;
    console.log('when_send_to_withArguments_exclusive_');
    send(self, 'when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray]), 'basicExecuting_', [aValueHolder])]);
};
Object.prototype['when_sendOnce_to_'] = function(anEventSelector, aMessageSelector, anObject)
{
    var self = this;
    console.log('when_sendOnce_to_');
    send(self, 'when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, 'receiver_selector_', [anObject, aMessageSelector])]);
};
Object.prototype['when_sendOnce_to_with_'] = function(anEventSelector, aMessageSelector, anObject, anArg)
{
    var self = this;
    console.log('when_sendOnce_to_with_');
    send(self, 'when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, 'with_', [anArg])])]);
};
Object.prototype['when_sendOnce_to_withArguments_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray)
{
    var self = this;
    console.log('when_sendOnce_to_withArguments_');
    send(self, 'when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray])]);
};
Object.prototype['okToClose'] = function()
{
    var self = this;
    console.log('okToClose');
    return true;
};
Object.prototype['taskbarIcon'] = function()
{
    var self = this;
    console.log('taskbarIcon');
    return send(send(self, 'class'), 'taskbarIcon');
};
Object.prototype['taskbarLabel'] = function()
{
    var self = this;
    console.log('taskbarLabel');
    return send(send(self, 'class'), 'taskbarLabel');
};
Object.prototype['windowActiveOnFirstClick'] = function()
{
    var self = this;
    console.log('windowActiveOnFirstClick');
    return true;
};
Object.prototype['comeFullyUpOnReload_'] = function(smartRefStream)
{
    var self = this;
    console.log('comeFullyUpOnReload_');
    return self;
};
Object.prototype['indexIfCompact'] = function()
{
    var self = this;
    console.log('indexIfCompact');
    return 0;
};
Object.prototype['objectForDataStream_'] = function(refStrm)
{
    var self = this;
    console.log('objectForDataStream_');
    return self;
};
Object.prototype['readDataFrom_size_'] = function(aDataStream, varsOnDisk)
{
    var self = this;
    var __context = {};
    console.log('readDataFrom_size_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = send(send(self, 'class'), 'instSize');
    send(send(send(self, 'class'), 'isVariable'), 'ifTrue_ifFalse_', [function() {
        cntIndexedVars = send(varsOnDisk, '-', [cntInstVars]);
        send(send(cntIndexedVars, '<', [0]), 'ifTrue_', [function() {
            send(self, 'error_', ['Class has changed too much.  Define a convertxxx method']);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        cntIndexedVars = 0;
        cntInstVars = varsOnDisk;
    }
    ]);
    if (__context.return) return __context.value;
    send(aDataStream, 'beginReference_', [self]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [cntInstVars, function(i) {
        send(self, 'instVarAt_put_', [i, send(aDataStream, 'next')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [cntIndexedVars, function(i) {
        send(self, 'basicAt_put_', [i, send(aDataStream, 'next')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return self;
};
Object.prototype['rootStubInImageSegment_'] = function(imageSegment)
{
    var self = this;
    console.log('rootStubInImageSegment_');
    return send(send(ImageSegmentRootStub.classPrototype, 'new'), 'xxSuperclass_format_segment_', [nil, nil, imageSegment]);
};
Object.prototype['storeDataOn_'] = function(aDataStream)
{
    var self = this;
    var __context = {};
    console.log('storeDataOn_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = send(send(self, 'class'), 'instSize');
    cntIndexedVars = send(self, 'basicSize');
    send(aDataStream, 'beginInstance_size_', [send(self, 'class'), send(cntInstVars, '+', [cntIndexedVars])]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [cntInstVars, function(i) {
        send(aDataStream, 'nextPut_', [send(self, 'instVarAt_', [i])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(send(aDataStream, 'byteStream'), 'class'), '==', [DummyStream]), 'and_', [function() {
        send(send(self, 'class'), 'isBits');
        if (__context.return) return __context.value;
    }
    ]), 'ifFalse_', [function() {
        send(1, 'to_do_', [cntIndexedVars, function(i) {
            send(aDataStream, 'nextPut_', [send(self, 'basicAt_', [i])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['settingFixedDomainValueNodeFrom_'] = function(aSettingNode)
{
    var self = this;
    console.log('settingFixedDomainValueNodeFrom_');
    return send(aSettingNode, 'fixedDomainValueNodeForObject_', [self]);
};
Object.prototype['settingStoreOn_'] = function(aStream)
{
    var self = this;
    console.log('settingStoreOn_');
    return send(self, 'storeOn_', [aStream]);
};
Object.prototype['systemNavigation'] = function()
{
    var self = this;
    console.log('systemNavigation');
    return send(SystemNavigation.classPrototype, 'default');
};
Object.prototype['defaultBackgroundColor'] = function()
{
    var self = this;
    console.log('defaultBackgroundColor');
    return send(send(UITheme.classPrototype, 'current'), 'windowColorFor_', [self]);
};
Object.prototype['showDiffs'] = function()
{
    var self = this;
    console.log('showDiffs');
    return false;
};
Object.prototype['updateListsAndCodeIn_'] = function(aWindow)
{
    var self = this;
    var __context = {};
    console.log('updateListsAndCodeIn_');
    send(send(self, 'canDiscardEdits'), 'ifFalse_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(aWindow, 'updatablePanes'), 'do_', [function(aPane) {
        send(aPane, 'verifyContents');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['browse'] = function()
{
    var self = this;
    console.log('browse');
    send(send(self, 'systemNavigation'), 'browseClass_', [send(self, 'class')]);
};
Object.prototype['browseHierarchy'] = function()
{
    var self = this;
    console.log('browseHierarchy');
    send(send(self, 'systemNavigation'), 'browseHierarchy_', [send(self, 'class')]);
};
Object.prototype['asExplorerString'] = function()
{
    var self = this;
    console.log('asExplorerString');
    return send(self, 'printString');
};
Object.prototype['customizeExplorerContents'] = function()
{
    var self = this;
    console.log('customizeExplorerContents');
    return false;
};
Object.prototype['explore'] = function()
{
    var self = this;
    console.log('explore');
    return send(send(Smalltalk.classPrototype, 'tools'), 'explore_', [self]);
};
Object.prototype['hasContentsInExplorer'] = function()
{
    var self = this;
    console.log('hasContentsInExplorer');
    return send(send(send(self, 'basicSize'), '>', [0]), 'or_', [function() {
        send(send(send(self, 'class'), 'allInstVarNames'), 'notEmpty');
    }
    ]);
};
Object.prototype['basicInspect'] = function()
{
    var self = this;
    console.log('basicInspect');
    return send(send(Smalltalk.classPrototype, 'tools'), 'basicInspect_', [self]);
};
Object.prototype['defaultLabelForInspector'] = function()
{
    var self = this;
    console.log('defaultLabelForInspector');
    return send(send(self, 'class'), 'name');
};
Object.prototype['doExpiredInspectCount'] = function()
{
    var self = this;
    console.log('doExpiredInspectCount');
    send(self, 'clearHaltOnce');
    send(self, 'removeHaltCount');
    send(self, 'inspect');
};
Object.prototype['inspect'] = function()
{
    var self = this;
    console.log('inspect');
    send(send(Smalltalk.classPrototype, 'tools'), 'inspect_', [self]);
};
Object.prototype['inspectOnCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('inspectOnCount_');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(send(self, 'hasHaltCount'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'decrementAndCheckHaltCount'), 'ifTrue_', [function() {
                send(self, 'doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), 'ifTrue_ifFalse_', [function() {
                send(self, 'doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'setHaltCountTo_', [send(int, '-', [1])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['inspectOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('inspectOnce');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(self, 'clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, 'inspect');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['inspectUntilCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('inspectUntilCount_');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(send(self, 'hasHaltCount'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'decrementAndCheckHaltCount'), 'ifTrue_ifFalse_', [function() {
                send(self, 'doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'inspect');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), 'ifTrue_ifFalse_', [function() {
                send(self, 'doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'setHaltCountTo_', [send(int, '-', [1])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['inspectWithLabel_'] = function(aLabel)
{
    var self = this;
    console.log('inspectWithLabel_');
    return send(send(Smalltalk.classPrototype, 'tools'), 'inspect_label_', [self, aLabel]);
};
Object.prototype['inspectorClass'] = function()
{
    var self = this;
    console.log('inspectorClass');
    return send(send(Smalltalk.classPrototype, 'tools'), 'inspector');
};
Object.prototype['confirm_'] = function(queryString)
{
    var self = this;
    console.log('confirm_');
    return send(send(UIManager.classPrototype, 'default'), 'confirm_', [queryString]);
};
Object.prototype['inform_'] = function(aString)
{
    var self = this;
    var __context = {};
    console.log('inform_');
    send(send(aString, 'isEmptyOrNil'), 'ifFalse_', [function() {
        send(send(UIManager.classPrototype, 'default'), 'inform_', [aString]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['primitiveError_'] = function(aString)
{
    var self = this;
    console.log('primitiveError_');
    send(send(UIManager.classPrototype, 'default'), 'onPrimitiveError_', [aString]);
};
Object.prototype['inline_'] = function(inlineFlag)
{
    var self = this;
    console.log('inline_');
    send(self, 'deprecated_on_in_', ['Tag with the equivalent <inline::> pragma which is understood in recent VMMakers instead', '25 October 2010', 'Pharo1.2']);
};
Object.prototype['var_declareC_'] = function(varSymbol, declString)
{
    var self = this;
    console.log('var_declareC_');
    send(self, 'deprecated_on_in_', ['Tag with the equivalent <var:declareC:> pragma which is understood in recent VMMakers instead', '25 October 2010', 'Pharo1.2']);
};
Object.prototype['exploreWithLabel_'] = function(label)
{
    var self = this;
    console.log('exploreWithLabel_');
    return send(send(send(send(Smalltalk.classPrototype, 'tools'), 'objectExplorer'), 'new'), 'openExplorerFor_withLabel_', [self, label]);
};
Object.prototype['notifyWithLabel_'] = function(aString)
{
    var self = this;
    console.log('notifyWithLabel_');
    send(self, 'deprecated_on_in_', ['Do not use this method, instead use Warning or UIManager API', '28 January 2011', 'Pharo1.3']);
    return send(Warning.classPrototype, 'signal_', [aString]);
};
Object.prototype['convertToCurrentVersion_refStream_'] = function(varDict, smartRefStrm)
{
    var self = this;
    console.log('convertToCurrentVersion_refStream_');
};
Object.prototype['at_'] = function(t1)
{
    var self = this;
    var __context = {};
    console.log('at_');
    var _primitive = primitives.primitive60(self, t1);
    if (_primitive) return _primitive.value;
    ;
    send(send(t1, 'isInteger'), 'ifTrue_', [function() {
        send(send(send(self, 'class'), 'isVariable'), 'ifTrue_ifFalse_', [function() {
            send(self, 'errorSubscriptBounds_', [t1]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, 'errorNotIndexable');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(t1, 'isNumber'), 'ifTrue_', [function() {
        __context.value = send(self, 'at_', [send(t1, 'asInteger')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'errorNonIntegerIndex');
    if (__context.return) return __context.value;
};
Object.prototype['at_modify_'] = function(index, aBlock)
{
    var self = this;
    console.log('at_modify_');
    return send(self, 'at_put_', [index, send(aBlock, 'value_', [send(self, 'at_', [index])])]);
};
Object.prototype['at_put_'] = function(t1, t2)
{
    var self = this;
    var __context = {};
    console.log('at_put_');
    var _primitive = primitives.primitive61(self, t1, t2);
    if (_primitive) return _primitive.value;
    ;
    send(send(t1, 'isInteger'), 'ifTrue_', [function() {
        send(send(send(self, 'class'), 'isVariable'), 'ifTrue_ifFalse_', [function() {
            send(send(send(t1, '>=', [1]), 'and_', [function() {
                send(t1, '<=', [send(self, 'size')]);
                if (__context.return) return __context.value;
            }
            ]), 'ifTrue_ifFalse_', [function() {
                send(self, 'errorImproperStore');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'errorSubscriptBounds_', [t1]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, 'errorNotIndexable');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(t1, 'isNumber'), 'ifTrue_', [function() {
        __context.value = send(self, 'at_put_', [send(t1, 'asInteger'), t2]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'errorNonIntegerIndex');
    if (__context.return) return __context.value;
};
Object.prototype['basicAt_'] = function(index)
{
    var self = this;
    var __context = {};
    console.log('basicAt_');
    var _primitive = primitives.primitive60(self, index);
    if (_primitive) return _primitive.value;
    ;
    send(send(index, 'isInteger'), 'ifTrue_', [function() {
        send(self, 'errorSubscriptBounds_', [index]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(index, 'isNumber'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(self, 'basicAt_', [send(index, 'asInteger')]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        send(self, 'errorNonIntegerIndex');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['basicAt_put_'] = function(index, value)
{
    var self = this;
    var __context = {};
    console.log('basicAt_put_');
    var _primitive = primitives.primitive61(self, index, value);
    if (_primitive) return _primitive.value;
    ;
    send(send(index, 'isInteger'), 'ifTrue_', [function() {
        send(send(send(index, '>=', [1]), 'and_', [function() {
            send(index, '<=', [send(self, 'size')]);
            if (__context.return) return __context.value;
        }
        ]), 'ifTrue_ifFalse_', [function() {
            send(self, 'errorImproperStore');
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, 'errorSubscriptBounds_', [index]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(index, 'isNumber'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(self, 'basicAt_put_', [send(index, 'asInteger'), value]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        send(self, 'errorNonIntegerIndex');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['basicSize'] = function()
{
    var self = this;
    console.log('basicSize');
    var _primitive = primitives.primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    return 0;
};
Object.prototype['enclosedSetElement'] = function()
{
    var self = this;
    console.log('enclosedSetElement');
};
Object.prototype['ifNil_ifNotNilDo_'] = function(nilBlock, aBlock)
{
    var self = this;
    console.log('ifNil_ifNotNilDo_');
    return send(aBlock, 'value_', [self]);
};
Object.prototype['ifNotNilDo_'] = function(aBlock)
{
    var self = this;
    console.log('ifNotNilDo_');
    return send(aBlock, 'value_', [self]);
};
Object.prototype['ifNotNilDo_ifNil_'] = function(aBlock, nilBlock)
{
    var self = this;
    console.log('ifNotNilDo_ifNil_');
    return send(aBlock, 'value_', [self]);
};
Object.prototype['in_'] = function(aBlock)
{
    var self = this;
    console.log('in_');
    return send(aBlock, 'value_', [self]);
};
Object.prototype['readFromString_'] = function(aString)
{
    var self = this;
    console.log('readFromString_');
    return send(self, 'readFrom_', [send(aString, 'readStream')]);
};
Object.prototype['size'] = function()
{
    var self = this;
    var __context = {};
    console.log('size');
    var _primitive = primitives.primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    send(send(send(self, 'class'), 'isVariable'), 'ifFalse_', [function() {
        send(self, 'errorNotIndexable');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return 0;
};
Object.prototype['yourself'] = function()
{
    var self = this;
    console.log('yourself');
    return self;
};
Object.prototype['->'] = function(anObject)
{
    var self = this;
    console.log('->');
    return send(send(Association.classPrototype, 'basicNew'), 'key_value_', [self, anObject]);
};
Object.prototype['bindingOf_'] = function(aString)
{
    var self = this;
    console.log('bindingOf_');
    return nil;
};
Object.prototype['break'] = function()
{
    var self = this;
    console.log('break');
    send(BreakPoint.classPrototype, 'signal');
};
Object.prototype['caseOf_'] = function(aBlockAssociationCollection)
{
    var self = this;
    console.log('caseOf_');
    return send(self, 'caseOf_otherwise_', [aBlockAssociationCollection, function() {
        send(self, 'caseError');
    }
    ]);
};
Object.prototype['caseOf_otherwise_'] = function(aBlockAssociationCollection, aBlock)
{
    var self = this;
    var __context = {};
    console.log('caseOf_otherwise_');
    send(aBlockAssociationCollection, 'associationsDo_', [function(assoc) {
        send(send(send(send(assoc, 'key'), 'value'), '=', [self]), 'ifTrue_', [function() {
            __context.value = send(send(assoc, 'value'), 'value');
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(aBlock, 'value');
};
Object.prototype['class'] = function()
{
    var self = this;
    console.log('class');
    var _primitive = primitives.primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
Object.prototype['isKindOf_'] = function(aClass)
{
    var self = this;
    var __context = {};
    console.log('isKindOf_');
    send(send(send(self, 'class'), '==', [aClass]), 'ifTrue_ifFalse_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(send(self, 'class'), 'inheritsFrom_', [aClass]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['isMemberOf_'] = function(aClass)
{
    var self = this;
    console.log('isMemberOf_');
    return send(send(self, 'class'), '==', [aClass]);
};
Object.prototype['respondsTo_'] = function(aSymbol)
{
    var self = this;
    console.log('respondsTo_');
    return send(send(self, 'class'), 'canUnderstand_', [aSymbol]);
};
Object.prototype['xxxClass'] = function()
{
    var self = this;
    console.log('xxxClass');
    return send(self, 'class');
};
Object.prototype['closeTo_'] = function(anObject)
{
    var self = this;
    console.log('closeTo_');
    return send(function() {
        send(self, '=', [anObject]);
    }
    , 'ifError_', [function() {
        false;
    }
    ]);
};
Object.prototype['hash'] = function()
{
    var self = this;
    console.log('hash');
    return send(self, 'identityHash');
};
Object.prototype['identityHashPrintString'] = function()
{
    var self = this;
    console.log('identityHashPrintString');
    return send(send('(', ',', [send(send(self, 'identityHash'), 'printString')]), ',', [')']);
};
Object.prototype['literalEqual_'] = function(other)
{
    var self = this;
    console.log('literalEqual_');
    return send(send(send(self, 'class'), '==', [send(other, 'class')]), 'and_', [function() {
        send(self, '=', [other]);
    }
    ]);
};
Object.prototype['='] = function(t1)
{
    var self = this;
    console.log('=');
    return send(self, '==', [t1]);
};
Object.prototype['~='] = function(anObject)
{
    var self = this;
    console.log('~=');
    return send(send(self, '=', [anObject]), '==', [false]);
};
Object.prototype['adaptToFloat_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToFloat_andCompare_');
    return send(self, 'adaptToFloat_andSend_', [rcvr, selector]);
};
Object.prototype['adaptToFloat_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToFloat_andSend_');
    return send(self, 'adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['adaptToFraction_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToFraction_andCompare_');
    return send(self, 'adaptToFraction_andSend_', [rcvr, selector]);
};
Object.prototype['adaptToFraction_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToFraction_andSend_');
    return send(self, 'adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['adaptToInteger_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToInteger_andCompare_');
    return send(self, 'adaptToInteger_andSend_', [rcvr, selector]);
};
Object.prototype['adaptToInteger_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToInteger_andSend_');
    return send(self, 'adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['asActionSequence'] = function()
{
    var self = this;
    console.log('asActionSequence');
    return send(WeakActionSequence.classPrototype, 'with_', [self]);
};
Object.prototype['asActionSequenceTrappingErrors'] = function()
{
    var self = this;
    console.log('asActionSequenceTrappingErrors');
    return send(WeakActionSequenceTrappingErrors.classPrototype, 'with_', [self]);
};
Object.prototype['asLink'] = function()
{
    var self = this;
    console.log('asLink');
    return send(ValueLink.classPrototype, 'value_', [self]);
};
Object.prototype['asOrderedCollection'] = function()
{
    var self = this;
    console.log('asOrderedCollection');
    return send(OrderedCollection.classPrototype, 'with_', [self]);
};
Object.prototype['asSetElement'] = function()
{
    var self = this;
    console.log('asSetElement');
};
Object.prototype['asString'] = function()
{
    var self = this;
    console.log('asString');
    return send(self, 'printString');
};
Object.prototype['asStringOrText'] = function()
{
    var self = this;
    console.log('asStringOrText');
    return send(self, 'printString');
};
Object.prototype['as_'] = function(aSimilarClass)
{
    var self = this;
    console.log('as_');
    return send(aSimilarClass, 'newFrom_', [self]);
};
Object.prototype['complexContents'] = function()
{
    var self = this;
    console.log('complexContents');
    return self;
};
Object.prototype['mustBeBoolean'] = function()
{
    var self = this;
    console.log('mustBeBoolean');
    return send(self, 'mustBeBooleanIn_', [send(thisContext, 'sender')]);
};
Object.prototype['mustBeBooleanIn_'] = function(context)
{
    var self = this;
    console.log('mustBeBooleanIn_');
    var proceedValue = null
    send(context, 'skipBackBeforeJump');
    proceedValue = send((function () {var _aux = send(send(NonBooleanReceiver.classPrototype, 'new'), 'object_', [self]);return _aux;})(), 'signal_', ['proceed for truth.']);
    return send(proceedValue, '~~', [false]);
};
Object.prototype['withoutListWrapper'] = function()
{
    var self = this;
    console.log('withoutListWrapper');
    return self;
};
Object.prototype['copy'] = function()
{
    var self = this;
    console.log('copy');
    return send(send(self, 'shallowCopy'), 'postCopy');
};
Object.prototype['copyFrom_'] = function(anotherObject)
{
    var self = this;
    var __context = {};
    console.log('copyFrom_');
    var mine = null
    var his = null
    var _primitive = primitives.primitive168(self, anotherObject);
    if (_primitive) return _primitive.value;
    ;
    mine = send(send(self, 'class'), 'allInstVarNames');
    his = send(send(anotherObject, 'class'), 'allInstVarNames');
    send(1, 'to_do_', [send(send(mine, 'size'), 'min_', [send(his, 'size')]), function(ind) {
        send(send(send(mine, 'at_', [ind]), '=', [send(his, 'at_', [ind])]), 'ifTrue_', [function() {
            send(self, 'instVarAt_put_', [ind, send(anotherObject, 'instVarAt_', [ind])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, 'class'), 'isVariable'), '&', [send(send(anotherObject, 'class'), 'isVariable')]), 'ifTrue_', [function() {
        send(1, 'to_do_', [send(send(self, 'basicSize'), 'min_', [send(anotherObject, 'basicSize')]), function(ind) {
            send(self, 'basicAt_put_', [ind, send(anotherObject, 'basicAt_', [ind])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['copySameFrom_'] = function(otherObject)
{
    var self = this;
    var __context = {};
    console.log('copySameFrom_');
    var myInstVars = null
    var otherInstVars = null
    myInstVars = send(send(self, 'class'), 'allInstVarNames');
    otherInstVars = send(send(otherObject, 'class'), 'allInstVarNames');
    send(myInstVars, 'doWithIndex_', [function(each, index) {
        var match = null;
        send(send(match = send(otherInstVars, 'indexOf_', [each]), '>', [0]), 'ifTrue_', [function() {
            send(self, 'instVarAt_put_', [index, send(otherObject, 'instVarAt_', [match])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [send(send(self, 'basicSize'), 'min_', [send(otherObject, 'basicSize')]), function(i) {
        send(self, 'basicAt_put_', [i, send(otherObject, 'basicAt_', [i])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['copyTwoLevel'] = function()
{
    var self = this;
    var __context = {};
    console.log('copyTwoLevel');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = send(self, 'class');
    newObject = send(self, 'shallowCopy');
    send(send(newObject, '==', [self]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(__class__, 'isVariable'), 'ifTrue_', [function() {
        index = send(self, 'basicSize');
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , 'whileTrue_', [function() {
            send(newObject, 'basicAt_put_', [index, send(send(self, 'basicAt_', [index]), 'shallowCopy')]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, 'instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , 'whileTrue_', [function() {
        send(newObject, 'instVarAt_put_', [index, send(send(self, 'instVarAt_', [index]), 'shallowCopy')]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['deepCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('deepCopy');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = send(self, 'class');
    send(send(__class__, '==', [Object]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(__class__, 'isVariable'), 'ifTrue_ifFalse_', [function() {
        index = send(self, 'basicSize');
        newObject = send(__class__, 'basicNew_', [index]);
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , 'whileTrue_', [function() {
            send(newObject, 'basicAt_put_', [index, send(send(self, 'basicAt_', [index]), 'deepCopy')]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        newObject = send(__class__, 'basicNew');
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, 'instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , 'whileTrue_', [function() {
        send(newObject, 'instVarAt_put_', [index, send(send(self, 'instVarAt_', [index]), 'deepCopy')]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['postCopy'] = function()
{
    var self = this;
    console.log('postCopy');
    return self;
};
Object.prototype['shallowCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('shallowCopy');
    var __class__ = null
    var newObject = null
    var index = null
    var _primitive = primitives.primitive148(self);
    if (_primitive) return _primitive.value;
    ;
    __class__ = send(self, 'class');
    send(send(__class__, 'isVariable'), 'ifTrue_ifFalse_', [function() {
        index = send(self, 'basicSize');
        newObject = send(__class__, 'basicNew_', [index]);
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , 'whileTrue_', [function() {
            send(newObject, 'basicAt_put_', [index, send(self, 'basicAt_', [index])]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        newObject = send(__class__, 'basicNew');
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, 'instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , 'whileTrue_', [function() {
        send(newObject, 'instVarAt_put_', [index, send(self, 'instVarAt_', [index])]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['veryDeepCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('veryDeepCopy');
    var copier = null
    var __new__ = null
    copier = send(send(DeepCopier.classPrototype, 'new'), 'initialize_', [4096]);
    __new__ = send(self, 'veryDeepCopyWith_', [copier]);
    send(send(copier, 'references'), 'associationsDo_', [function(assoc) {
        send(send(assoc, 'value'), 'veryDeepFixupWith_', [copier]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(copier, 'fixDependents');
    if (__context.return) return __context.value;
    return __new__;
};
Object.prototype['veryDeepCopyUsing_'] = function(copier)
{
    var self = this;
    var __context = {};
    console.log('veryDeepCopyUsing_');
    var __new__ = null
    var refs = null
    __new__ = send(self, 'veryDeepCopyWith_', [copier]);
    send(send(copier, 'references'), 'associationsDo_', [function(assoc) {
        send(send(assoc, 'value'), 'veryDeepFixupWith_', [copier]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    refs = send(copier, 'references');
    send(DependentsFields.classPrototype, 'associationsDo_', [function(pair) {
        send(send(pair, 'value'), 'do_', [function(dep) {
            var newModel = null;
            var newDep = null;
            send(newDep = send(refs, 'at_ifAbsent_', [dep, function() {
                nil;
            }
            ]), 'ifNotNil_', [function() {
                newModel = send(refs, 'at_ifAbsent_', [send(pair, 'key'), function() {
                    send(pair, 'key');
                    if (__context.return) return __context.value;
                }
                ]);
                send(newModel, 'addDependent_', [newDep]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return __new__;
};
Object.prototype['veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    var __context = {};
    console.log('veryDeepCopyWith_');
    var __class__ = null
    var index = null
    var sub = null
    var subAss = null
    var __new__ = null
    var sup = null
    var has = null
    var mine = null
    send(send(deepCopier, 'references'), 'at_ifPresent_', [self, function(newer) {
        __context.value = newer;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    __class__ = send(self, 'class');
    send(send(__class__, 'isMeta'), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    __new__ = send(self, 'shallowCopy');
    send(send(deepCopier, 'references'), 'at_put_', [self, __new__]);
    if (__context.return) return __context.value;
    send(send(send(__class__, 'isVariable'), 'and_', [function() {
        send(__class__, 'isPointers');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        index = send(self, 'basicSize');
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , 'whileTrue_', [function() {
            sub = send(self, 'basicAt_', [index]);
            send(subAss = send(send(deepCopier, 'references'), 'associationAt_ifAbsent_', [sub, function() {
                nil;
            }
            ]), 'ifNil_ifNotNil_', [function() {
                send(__new__, 'basicAt_put_', [index, send(sub, 'veryDeepCopyWith_', [deepCopier])]);
                if (__context.return) return __context.value;
            }
            , function() {
                send(__new__, 'basicAt_put_', [index, send(subAss, 'value')]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(__new__, 'veryDeepInner_', [deepCopier]);
    if (__context.return) return __context.value;
    sup = __class__;
    index = send(__class__, 'instSize');
    send(function() {
        has = send(sup, 'compiledMethodAt_ifAbsent_', ['veryDeepInner:', function() {
            nil;
        }
        ]);
        has = send(has, 'ifNil_ifNotNil_', [function() {
            false;
        }
        , function() {
            true;
        }
        ]);
        mine = send(sup, 'instVarNames');
        send(has, 'ifTrue_ifFalse_', [function() {
            index = send(index, '-', [send(mine, 'size')]);
        }
        , function() {
            send(1, 'to_do_', [send(mine, 'size'), function(xx) {
                sub = send(self, 'instVarAt_', [index]);
                send(subAss = send(send(deepCopier, 'references'), 'associationAt_ifAbsent_', [sub, function() {
                    nil;
                }
                ]), 'ifNil_ifNotNil_', [function() {
                    send(__new__, 'instVarAt_put_', [index, send(sub, 'veryDeepCopyWith_', [deepCopier])]);
                    if (__context.return) return __context.value;
                }
                , function() {
                    send(__new__, 'instVarAt_put_', [index, send(subAss, 'value')]);
                    if (__context.return) return __context.value;
                }
                ]);
                if (__context.return) return __context.value;
                index = send(index, '-', [1]);
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(sup = send(sup, 'superclass'), '==', [nil]);
        if (__context.return) return __context.value;
    }
    , 'whileFalse');
    if (__context.return) return __context.value;
    send(__new__, 'rehash');
    if (__context.return) return __context.value;
    return __new__;
};
Object.prototype['veryDeepFixupWith_'] = function(deepCopier)
{
    var self = this;
    console.log('veryDeepFixupWith_');
};
Object.prototype['veryDeepInner_'] = function(deepCopier)
{
    var self = this;
    console.log('veryDeepInner_');
};
Object.prototype['haltIf_'] = function(condition)
{
    var self = this;
    var __context = {};
    console.log('haltIf_');
    var cntxt = null
    send(send(condition, 'isSymbol'), 'ifTrue_', [function() {
        cntxt = thisContext;
        send(function() {
            send(send(cntxt, 'sender'), 'isNil');
            if (__context.return) return __context.value;
        }
        , 'whileFalse_', [function() {
            cntxt = send(cntxt, 'sender');
            send(send(send(cntxt, 'selector'), '=', [condition]), 'ifTrue_', [function() {
                send(Halt.classPrototype, 'signal');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(condition, 'isBlock'), 'ifTrue_ifFalse_', [function() {
        send(condition, 'cull_', [self]);
        if (__context.return) return __context.value;
    }
    , function() {
        condition;
    }
    ]), 'ifTrue_', [function() {
        send(Halt.classPrototype, 'signal');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['needsWork'] = function()
{
    var self = this;
    console.log('needsWork');
};
Object.prototype['checkHaltCountExpired'] = function()
{
    var self = this;
    console.log('checkHaltCountExpired');
    var counter = null
    counter = send(send(Smalltalk.classPrototype, 'globals'), 'at_ifAbsent_', ['HaltCount', function() {
        0;
    }
    ]);
    return send(counter, '=', [0]);
};
Object.prototype['clearHaltOnce'] = function()
{
    var self = this;
    console.log('clearHaltOnce');
    send(send(Smalltalk.classPrototype, 'globals'), 'at_put_', ['HaltOnce', false]);
};
Object.prototype['decrementAndCheckHaltCount'] = function()
{
    var self = this;
    console.log('decrementAndCheckHaltCount');
    send(self, 'decrementHaltCount');
    return send(self, 'checkHaltCountExpired');
};
Object.prototype['decrementHaltCount'] = function()
{
    var self = this;
    var __context = {};
    console.log('decrementHaltCount');
    var counter = null
    counter = send(send(Smalltalk.classPrototype, 'globals'), 'at_ifAbsent_', ['HaltCount', function() {
        0;
    }
    ]);
    send(send(counter, '>', [0]), 'ifTrue_', [function() {
        counter = send(counter, '-', [1]);
        send(self, 'setHaltCountTo_', [counter]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['doExpiredHaltCount'] = function()
{
    var self = this;
    console.log('doExpiredHaltCount');
    send(self, 'clearHaltOnce');
    send(self, 'removeHaltCount');
    send(self, 'halt');
};
Object.prototype['doExpiredHaltCount_'] = function(aString)
{
    var self = this;
    console.log('doExpiredHaltCount_');
    send(self, 'clearHaltOnce');
    send(self, 'removeHaltCount');
    send(self, 'halt_', [aString]);
};
Object.prototype['halt_onCount_'] = function(aString, int)
{
    var self = this;
    var __context = {};
    console.log('halt_onCount_');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(send(self, 'hasHaltCount'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'decrementAndCheckHaltCount'), 'ifTrue_', [function() {
                send(self, 'doExpiredHaltCount_', [aString]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), 'ifTrue_ifFalse_', [function() {
                send(self, 'doExpiredHaltCount_', [aString]);
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'setHaltCountTo_', [send(int, '-', [1])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['haltOnCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('haltOnCount_');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(send(self, 'hasHaltCount'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'decrementAndCheckHaltCount'), 'ifTrue_', [function() {
                send(self, 'doExpiredHaltCount');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), 'ifTrue_ifFalse_', [function() {
                send(self, 'doExpiredHaltCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, 'setHaltCountTo_', [send(int, '-', [1])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['haltOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('haltOnce');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(self, 'clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, 'halt');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['haltOnce_'] = function(aString)
{
    var self = this;
    var __context = {};
    console.log('haltOnce_');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_', [function() {
        send(self, 'clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, 'halt_', [aString]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['haltOnceEnabled'] = function()
{
    var self = this;
    console.log('haltOnceEnabled');
    return send(send(Smalltalk.classPrototype, 'globals'), 'at_ifAbsent_', ['HaltOnce', function() {
        false;
    }
    ]);
};
Object.prototype['hasHaltCount'] = function()
{
    var self = this;
    console.log('hasHaltCount');
    return send(send(Smalltalk.classPrototype, 'globals'), 'includesKey_', ['HaltCount']);
};
Object.prototype['removeHaltCount'] = function()
{
    var self = this;
    var __context = {};
    console.log('removeHaltCount');
    send(send(send(Smalltalk.classPrototype, 'globals'), 'includesKey_', ['HaltCount']), 'ifTrue_', [function() {
        send(send(Smalltalk.classPrototype, 'globals'), 'removeKey_', ['HaltCount']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['setHaltCountTo_'] = function(int)
{
    var self = this;
    console.log('setHaltCountTo_');
    send(send(Smalltalk.classPrototype, 'globals'), 'at_put_', ['HaltCount', int]);
};
Object.prototype['setHaltOnce'] = function()
{
    var self = this;
    console.log('setHaltOnce');
    send(send(Smalltalk.classPrototype, 'globals'), 'at_put_', ['HaltOnce', true]);
};
Object.prototype['toggleHaltOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('toggleHaltOnce');
    send(send(self, 'haltOnceEnabled'), 'ifTrue_ifFalse_', [function() {
        send(self, 'clearHaltOnce');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self, 'setHaltOnce');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['addDependent_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('addDependent_');
    var dependents = null
    dependents = send(self, 'dependents');
    send(send(dependents, 'includes_', [anObject]), 'ifFalse_', [function() {
        send(self, 'myDependents_', [send(dependents, 'copyWithDependent_', [anObject])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return anObject;
};
Object.prototype['breakDependents'] = function()
{
    var self = this;
    console.log('breakDependents');
    send(self, 'myDependents_', [nil]);
};
Object.prototype['canDiscardEdits'] = function()
{
    var self = this;
    var __context = {};
    console.log('canDiscardEdits');
    send(send(self, 'dependents'), 'do_without_', [function(each) {
        send(send(each, 'canDiscardEdits'), 'ifFalse_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , self]);
    if (__context.return) return __context.value;
    return true;
};
Object.prototype['dependents'] = function()
{
    var self = this;
    console.log('dependents');
    return send(send(self, 'myDependents'), 'ifNil_', [function() {
        [];
    }
    ]);
};
Object.prototype['hasUnacceptedEdits'] = function()
{
    var self = this;
    var __context = {};
    console.log('hasUnacceptedEdits');
    send(send(self, 'dependents'), 'do_without_', [function(each) {
        send(send(each, 'hasUnacceptedEdits'), 'ifTrue_', [function() {
            __context.value = true;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , self]);
    if (__context.return) return __context.value;
    return false;
};
Object.prototype['myDependents'] = function()
{
    var self = this;
    console.log('myDependents');
    return send(DependentsFields.classPrototype, 'at_ifAbsent_', [self, function() {
    }
    ]);
};
Object.prototype['myDependents_'] = function(aCollectionOrNil)
{
    var self = this;
    var __context = {};
    console.log('myDependents_');
    send(aCollectionOrNil, 'ifNil_ifNotNil_', [function() {
        send(DependentsFields.classPrototype, 'removeKey_ifAbsent_', [self, function() {
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(DependentsFields.classPrototype, 'at_put_', [self, aCollectionOrNil]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['release'] = function()
{
    var self = this;
    console.log('release');
    send(self, 'releaseActionMap');
};
Object.prototype['removeDependent_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('removeDependent_');
    var dependents = null
    dependents = send(send(self, 'dependents'), 'reject_', [function(each) {
        send(each, '==', [anObject]);
        if (__context.return) return __context.value;
    }
    ]);
    send(self, 'myDependents_', [send(send(dependents, 'isEmpty'), 'ifFalse_', [function() {
        dependents;
    }
    ])]);
    if (__context.return) return __context.value;
    return anObject;
};
Object.prototype['acceptDroppingMorph_event_inMorph_'] = function(transferMorph, evt, dstListMorph)
{
    var self = this;
    console.log('acceptDroppingMorph_event_inMorph_');
    return false;
};
Object.prototype['dragPassengerFor_inMorph_'] = function(item, dragSource)
{
    var self = this;
    console.log('dragPassengerFor_inMorph_');
    return item;
};
Object.prototype['dragTransferType'] = function()
{
    var self = this;
    console.log('dragTransferType');
    return nil;
};
Object.prototype['dragTransferTypeForMorph_'] = function(dragSource)
{
    var self = this;
    console.log('dragTransferTypeForMorph_');
    return nil;
};
Object.prototype['wantsDroppedMorph_event_inMorph_'] = function(aMorph, anEvent, destinationLM)
{
    var self = this;
    console.log('wantsDroppedMorph_event_inMorph_');
    return false;
};
Object.prototype['assert_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('assert_');
    send(send(aBlock, 'value'), 'ifFalse_', [function() {
        send(AssertionFailure.classPrototype, 'signal_', ['Assertion failed']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['assert_descriptionBlock_'] = function(aBlock, descriptionBlock)
{
    var self = this;
    var __context = {};
    console.log('assert_descriptionBlock_');
    send(send(aBlock, 'value'), 'ifFalse_', [function() {
        send(AssertionFailure.classPrototype, 'signal_', [send(send(descriptionBlock, 'value'), 'asString')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['assert_description_'] = function(aBlock, aString)
{
    var self = this;
    var __context = {};
    console.log('assert_description_');
    send(send(aBlock, 'value'), 'ifFalse_', [function() {
        send(AssertionFailure.classPrototype, 'signal_', [aString]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['caseError'] = function()
{
    var self = this;
    console.log('caseError');
    send(self, 'error_', [send(send('Case not found (', ',', [send(self, 'printString')]), ',', ['), and no otherwise clause'])]);
};
Object.prototype['confirm_orCancel_'] = function(aString, cancelBlock)
{
    var self = this;
    console.log('confirm_orCancel_');
    return send(send(UIManager.classPrototype, 'default'), 'confirm_orCancel_', [aString, cancelBlock]);
};
Object.prototype['deprecated_'] = function(anExplanationString)
{
    var self = this;
    console.log('deprecated_');
    send(send(Deprecation.classPrototype, 'method_explanation_on_in_', [send(send(thisContext, 'sender'), 'method'), anExplanationString, nil, nil]), 'signal');
};
Object.prototype['deprecated_on_in_'] = function(anExplanationString, date, version)
{
    var self = this;
    console.log('deprecated_on_in_');
    send(send(Deprecation.classPrototype, 'method_explanation_on_in_', [send(send(thisContext, 'sender'), 'method'), anExplanationString, date, version]), 'signal');
};
Object.prototype['doesNotUnderstand_'] = function(aMessage)
{
    var self = this;
    console.log('doesNotUnderstand_');
    var exception = null
    var resumeValue = null
    send((function () {var _aux = send(exception = send(MessageNotUnderstood.classPrototype, 'new'), 'message_', [aMessage]);return _aux;})(), 'receiver_', [self]);
    resumeValue = send(exception, 'signal');
    return send(send(exception, 'reachedDefaultHandler'), 'ifTrue_ifFalse_', [function() {
        send(aMessage, 'sentTo_', [self]);
    }
    , function() {
        resumeValue;
    }
    ]);
};
Object.prototype['dpsTrace_'] = function(reportObject)
{
    var self = this;
    var __context = {};
    console.log('dpsTrace_');
    send(send(send(Transcript.classPrototype, 'myDependents'), 'isNil'), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'dpsTrace_levels_withContext_', [reportObject, 1, thisContext]);
    if (__context.return) return __context.value;
};
Object.prototype['dpsTrace_levels_'] = function(reportObject, anInt)
{
    var self = this;
    console.log('dpsTrace_levels_');
    send(self, 'dpsTrace_levels_withContext_', [reportObject, anInt, thisContext]);
};
Object.prototype['dpsTrace_levels_withContext_'] = function(reportObject, anInt, currentContext)
{
    var self = this;
    var __context = {};
    console.log('dpsTrace_levels_withContext_');
    var reportString = null
    var context = null
    var displayCount = null
    reportString = send(send(reportObject, 'respondsTo_', ['asString']), 'ifTrue_ifFalse_', [function() {
        send(reportObject, 'asString');
        if (__context.return) return __context.value;
    }
    , function() {
        send(reportObject, 'printString');
        if (__context.return) return __context.value;
    }
    ]);
    send(send(send(Smalltalk.classPrototype, 'globals'), 'at_ifAbsent_', ['Decompiler', function() {
        nil;
    }
    ]), 'ifNil_ifNotNil_', [function() {
        send((function () {var _aux = send(Transcript.classPrototype, 'cr');return _aux;})(), 'show_', [reportString]);
        if (__context.return) return __context.value;
    }
    , function() {
        context = currentContext;
        displayCount = send(anInt, '>', [1]);
        send(1, 'to_do_', [anInt, function(count) {
            send(Transcript.classPrototype, 'cr');
            if (__context.return) return __context.value;
            send(displayCount, 'ifTrue_', [function() {
                send(Transcript.classPrototype, 'show_', [send(send(count, 'printString'), ',', [': '])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
            send(send(reportString, 'notNil'), 'ifTrue_ifFalse_', [function() {
                send(Transcript.classPrototype, 'show_', [send(send(send(send(send(send(send(send(context, 'home'), 'class'), 'name'), ',', ['/']), ',', [send(send(context, 'sender'), 'selector')]), ',', [' (']), ',', [reportString]), ',', [')'])]);
                if (__context.return) return __context.value;
                context = send(context, 'sender');
                reportString = nil;
            }
            , function() {
                send(send(send(context, 'notNil'), 'and_', [function() {
                    send(context = send(context, 'sender'), 'notNil');
                    if (__context.return) return __context.value;
                }
                ]), 'ifTrue_', [function() {
                    send(Transcript.classPrototype, 'show_', [send(send(send(send(send(context, 'receiver'), 'class'), 'name'), ',', ['/']), ',', [send(context, 'selector')])]);
                    if (__context.return) return __context.value;
                }
                ]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['error'] = function()
{
    var self = this;
    console.log('error');
    return send(self, 'error_', ['Error!']);
};
Object.prototype['error_'] = function(aString)
{
    var self = this;
    console.log('error_');
    return send(send(Error.classPrototype, 'new'), 'signal_', [aString]);
};
Object.prototype['explicitRequirement'] = function()
{
    var self = this;
    console.log('explicitRequirement');
    send(self, 'error_', ['Explicitly required method']);
};
Object.prototype['halt'] = function()
{
    var self = this;
    console.log('halt');
    send(Halt.classPrototype, 'signal');
};
Object.prototype['halt_'] = function(aString)
{
    var self = this;
    console.log('halt_');
    send(send(Halt.classPrototype, 'new'), 'signal_', [aString]);
};
Object.prototype['haltIfShiftPressed'] = function()
{
    var self = this;
    var __context = {};
    console.log('haltIfShiftPressed');
    send(self, 'haltIf_', [function() {
        send(Sensor.classPrototype, 'shiftPressed');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['handles_'] = function(exception)
{
    var self = this;
    console.log('handles_');
    return false;
};
Object.prototype['notify_'] = function(aString)
{
    var self = this;
    console.log('notify_');
    send(Warning.classPrototype, 'signal_', [aString]);
};
Object.prototype['notify_at_'] = function(aString, location)
{
    var self = this;
    console.log('notify_at_');
    send(self, 'notify_', [aString]);
};
Object.prototype['primitiveFail'] = function()
{
    var self = this;
    console.log('primitiveFail');
    return send(self, 'primitiveFailed');
};
Object.prototype['primitiveFailed'] = function()
{
    var self = this;
    console.log('primitiveFailed');
    send(self, 'primitiveFailed_', [send(send(thisContext, 'sender'), 'selector')]);
};
Object.prototype['primitiveFailed_'] = function(selector)
{
    var self = this;
    console.log('primitiveFailed_');
    send(PrimitiveFailed.classPrototype, 'signalFor_', [selector]);
};
Object.prototype['requirement'] = function()
{
    var self = this;
    console.log('requirement');
    send(self, 'error_', ['Implicitly required method']);
};
Object.prototype['shouldBeImplemented'] = function()
{
    var self = this;
    console.log('shouldBeImplemented');
    send(ShouldBeImplemented.classPrototype, 'signalFor_', [send(send(thisContext, 'sender'), 'selector')]);
};
Object.prototype['shouldNotImplement'] = function()
{
    var self = this;
    console.log('shouldNotImplement');
    send(ShouldNotImplement.classPrototype, 'signalFor_', [send(send(thisContext, 'sender'), 'selector')]);
};
Object.prototype['subclassResponsibility'] = function()
{
    var self = this;
    console.log('subclassResponsibility');
    send(SubclassResponsibility.classPrototype, 'signalFor_', [send(send(thisContext, 'sender'), 'selector')]);
};
Object.prototype['traitConflict'] = function()
{
    var self = this;
    console.log('traitConflict');
    send(self, 'error_', ['A class or trait does not properly resolve a conflict between multiple traits it uses.']);
};
Object.prototype['value'] = function()
{
    var self = this;
    console.log('value');
    return self;
};
Object.prototype['valueWithArguments_'] = function(aSequenceOfArguments)
{
    var self = this;
    console.log('valueWithArguments_');
    return self;
};
Object.prototype['actionForEvent_'] = function(anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('actionForEvent_');
    var actions = null
    actions = send(send(self, 'actionMap'), 'at_ifAbsent_', [send(anEventSelector, 'asSymbol'), function() {
        nil;
    }
    ]);
    send(actions, 'ifNil_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(actions, 'asMinimalRepresentation');
};
Object.prototype['actionForEvent_ifAbsent_'] = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    var __context = {};
    console.log('actionForEvent_ifAbsent_');
    var actions = null
    actions = send(send(self, 'actionMap'), 'at_ifAbsent_', [send(anEventSelector, 'asSymbol'), function() {
        nil;
    }
    ]);
    send(actions, 'ifNil_', [function() {
        __context.value = send(anExceptionBlock, 'value');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(actions, 'asMinimalRepresentation');
};
Object.prototype['actionMap'] = function()
{
    var self = this;
    console.log('actionMap');
    return send(EventManager.classPrototype, 'actionMapFor_', [self]);
};
Object.prototype['actionSequenceForEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('actionSequenceForEvent_');
    return send(send(send(self, 'actionMap'), 'at_ifAbsent_', [send(anEventSelector, 'asSymbol'), function() {
        __context.value = send(WeakActionSequence.classPrototype, 'new');
        __context.return = true;
        return __context.value;
    }
    ]), 'asActionSequence');
};
Object.prototype['actionsDo_'] = function(aBlock)
{
    var self = this;
    console.log('actionsDo_');
    send(send(self, 'actionMap'), 'do_', [aBlock]);
};
Object.prototype['createActionMap'] = function()
{
    var self = this;
    console.log('createActionMap');
    return send(IdentityDictionary.classPrototype, 'new');
};
Object.prototype['hasActionForEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('hasActionForEvent_');
    return send(send(self, 'actionForEvent_', [anEventSelector]), 'notNil');
};
Object.prototype['hasActionsWithReceiver_'] = function(anObject)
{
    var self = this;
    console.log('hasActionsWithReceiver_');
    return send(send(send(self, 'actionMap'), 'keys'), 'anySatisfy_', [function(eachEventSelector) {
        send(send(self, 'actionSequenceForEvent_', [eachEventSelector]), 'anySatisfy_', [function(anAction) {
            send(send(anAction, 'receiver'), '==', [anObject]);
        }
        ]);
    }
    ]);
};
Object.prototype['setActionSequence_forEvent_'] = function(actionSequence, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('setActionSequence_forEvent_');
    var action = null
    action = send(actionSequence, 'asMinimalRepresentation');
    send(send(action, '==', [nil]), 'ifTrue_ifFalse_', [function() {
        send(self, 'removeActionsForEvent_', [anEventSelector]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(self, 'updateableActionMap'), 'at_put_', [send(anEventSelector, 'asSymbol'), action]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['updateableActionMap'] = function()
{
    var self = this;
    console.log('updateableActionMap');
    return send(EventManager.classPrototype, 'updateableActionMapFor_', [self]);
};
Object.prototype['when_evaluate_'] = function(anEventSelector, anAction)
{
    var self = this;
    var __context = {};
    console.log('when_evaluate_');
    var actions = null
    actions = send(self, 'actionSequenceForEvent_', [anEventSelector]);
    send(send(actions, 'includes_', [anAction]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'setActionSequence_forEvent_', [send(actions, 'copyWith_', [anAction]), anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['when_send_to_'] = function(anEventSelector, aMessageSelector, anObject)
{
    var self = this;
    console.log('when_send_to_');
    send(self, 'when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, 'receiver_selector_', [anObject, aMessageSelector])]);
};
Object.prototype['when_send_to_withArguments_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray)
{
    var self = this;
    console.log('when_send_to_withArguments_');
    send(self, 'when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray])]);
};
Object.prototype['when_send_to_with_'] = function(anEventSelector, aMessageSelector, anObject, anArg)
{
    var self = this;
    console.log('when_send_to_with_');
    send(self, 'when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, 'receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, 'with_', [anArg])])]);
};
Object.prototype['releaseActionMap'] = function()
{
    var self = this;
    console.log('releaseActionMap');
    send(EventManager.classPrototype, 'releaseActionMapFor_', [self]);
};
Object.prototype['removeActionsForEvent_'] = function(anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('removeActionsForEvent_');
    var map = null
    map = send(self, 'actionMap');
    send(map, 'removeKey_ifAbsent_', [send(anEventSelector, 'asSymbol'), function() {
    }
    ]);
    if (__context.return) return __context.value;
    send(send(map, 'isEmpty'), 'ifTrue_', [function() {
        send(self, 'releaseActionMap');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['removeActionsSatisfying_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('removeActionsSatisfying_');
    send(send(send(self, 'actionMap'), 'keys'), 'do_', [function(eachEventSelector) {
        send(self, 'removeActionsSatisfying_forEvent_', [aBlock, eachEventSelector]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['removeActionsSatisfying_forEvent_'] = function(aOneArgBlock, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('removeActionsSatisfying_forEvent_');
    send(self, 'setActionSequence_forEvent_', [send(send(self, 'actionSequenceForEvent_', [anEventSelector]), 'reject_', [function(anAction) {
        send(aOneArgBlock, 'value_', [anAction]);
        if (__context.return) return __context.value;
    }
    ]), anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['removeActionsWithReceiver_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('removeActionsWithReceiver_');
    send(send(send(self, 'actionMap'), 'copy'), 'keysDo_', [function(eachEventSelector) {
        send(self, 'removeActionsSatisfying_forEvent_', [function(anAction) {
            send(send(anAction, 'receiver'), '==', [anObject]);
            if (__context.return) return __context.value;
        }
        , eachEventSelector]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['removeActionsWithReceiver_forEvent_'] = function(anObject, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('removeActionsWithReceiver_forEvent_');
    send(self, 'removeActionsSatisfying_forEvent_', [function(anAction) {
        send(send(anAction, 'receiver'), '==', [anObject]);
        if (__context.return) return __context.value;
    }
    , anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['removeAction_forEvent_'] = function(anAction, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('removeAction_forEvent_');
    send(self, 'removeActionsSatisfying_forEvent_', [function(action) {
        send(action, '=', [anAction]);
        if (__context.return) return __context.value;
    }
    , anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['triggerEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('triggerEvent_');
    return send(send(self, 'actionForEvent_', [anEventSelector]), 'value');
};
Object.prototype['triggerEvent_ifNotHandled_'] = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    console.log('triggerEvent_ifNotHandled_');
    return send(send(self, 'actionForEvent_ifAbsent_', [anEventSelector, function() {
        __context.value = send(anExceptionBlock, 'value');
        __context.return = true;
        return __context.value;
    }
    ]), 'value');
};
Object.prototype['triggerEvent_withArguments_'] = function(anEventSelector, anArgumentList)
{
    var self = this;
    console.log('triggerEvent_withArguments_');
    return send(send(self, 'actionForEvent_', [anEventSelector]), 'valueWithArguments_', [anArgumentList]);
};
Object.prototype['triggerEvent_withArguments_ifNotHandled_'] = function(anEventSelector, anArgumentList, anExceptionBlock)
{
    var self = this;
    console.log('triggerEvent_withArguments_ifNotHandled_');
    return send(send(self, 'actionForEvent_ifAbsent_', [anEventSelector, function() {
        __context.value = send(anExceptionBlock, 'value');
        __context.return = true;
        return __context.value;
    }
    ]), 'valueWithArguments_', [anArgumentList]);
};
Object.prototype['triggerEvent_with_'] = function(anEventSelector, anObject)
{
    var self = this;
    console.log('triggerEvent_with_');
    return send(self, 'triggerEvent_withArguments_', [anEventSelector, send(Array.classPrototype, 'with_', [anObject])]);
};
Object.prototype['triggerEvent_with_ifNotHandled_'] = function(anEventSelector, anObject, anExceptionBlock)
{
    var self = this;
    console.log('triggerEvent_with_ifNotHandled_');
    return send(self, 'triggerEvent_withArguments_ifNotHandled_', [anEventSelector, send(Array.classPrototype, 'with_', [anObject]), anExceptionBlock]);
};
Object.prototype['drawOnCanvas_'] = function(aStream)
{
    var self = this;
    console.log('drawOnCanvas_');
    send(self, 'flattenOnStream_', [aStream]);
};
Object.prototype['elementSeparator'] = function()
{
    var self = this;
    console.log('elementSeparator');
    return nil;
};
Object.prototype['flattenOnStream_'] = function(aStream)
{
    var self = this;
    console.log('flattenOnStream_');
    send(self, 'writeOnFilterStream_', [aStream]);
};
Object.prototype['putOn_'] = function(aStream)
{
    var self = this;
    console.log('putOn_');
    return send(aStream, 'nextPut_', [self]);
};
Object.prototype['writeOnFilterStream_'] = function(aStream)
{
    var self = this;
    console.log('writeOnFilterStream_');
    send(aStream, 'writeObject_', [self]);
};
Object.prototype['actAsExecutor'] = function()
{
    var self = this;
    console.log('actAsExecutor');
    send(self, 'breakDependents');
};
Object.prototype['executor'] = function()
{
    var self = this;
    console.log('executor');
    return send(send(self, 'shallowCopy'), 'actAsExecutor');
};
Object.prototype['finalizationRegistry'] = function()
{
    var self = this;
    console.log('finalizationRegistry');
    return send(WeakRegistry.classPrototype, 'default');
};
Object.prototype['finalize'] = function()
{
    var self = this;
    console.log('finalize');
};
Object.prototype['hasMultipleExecutors'] = function()
{
    var self = this;
    console.log('hasMultipleExecutors');
    return false;
};
Object.prototype['retryWithGC_until_'] = function(execBlock, testBlock)
{
    var self = this;
    var __context = {};
    console.log('retryWithGC_until_');
    var blockValue = null
    blockValue = send(execBlock, 'value');
    send(send(testBlock, 'value_', [blockValue]), 'ifTrue_', [function() {
        __context.value = blockValue;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Smalltalk.classPrototype, 'garbageCollectMost');
    if (__context.return) return __context.value;
    blockValue = send(execBlock, 'value');
    send(send(testBlock, 'value_', [blockValue]), 'ifTrue_', [function() {
        __context.value = blockValue;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Smalltalk.classPrototype, 'garbageCollect');
    if (__context.return) return __context.value;
    return send(execBlock, 'value');
};
Object.prototype['toFinalizeSend_to_with_'] = function(aSelector, aFinalizer, aResourceHandle)
{
    var self = this;
    var __context = {};
    console.log('toFinalizeSend_to_with_');
    send(send(self, '==', [aFinalizer]), 'ifTrue_', [function() {
        send(self, 'error_', ['I cannot finalize myself']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(self, '==', [aResourceHandle]), 'ifTrue_', [function() {
        send(self, 'error_', ['I cannot finalize myself']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'finalizationRegistry'), 'add_executor_', [self, send(send(ObjectFinalizer.classPrototype, 'new'), 'receiver_selector_argument_', [aFinalizer, aSelector, aResourceHandle])]);
};
Object.prototype['isThisEverCalled'] = function()
{
    var self = this;
    console.log('isThisEverCalled');
    return send(self, 'isThisEverCalled_', [send(send(thisContext, 'sender'), 'printString')]);
};
Object.prototype['isThisEverCalled_'] = function(msg)
{
    var self = this;
    console.log('isThisEverCalled_');
    send(self, 'halt_', [send('This is indeed called: ', ',', [send(msg, 'printString')])]);
};
Object.prototype['logEntry'] = function()
{
    var self = this;
    console.log('logEntry');
    send((function () {var _aux = send(Transcript.classPrototype, 'show_', [send('Entered ', ',', [send(send(thisContext, 'sender'), 'printString')])]);return _aux;})(), 'cr');
};
Object.prototype['logExecution'] = function()
{
    var self = this;
    console.log('logExecution');
    send((function () {var _aux = send(Transcript.classPrototype, 'show_', [send('Executing ', ',', [send(send(thisContext, 'sender'), 'printString')])]);return _aux;})(), 'cr');
};
Object.prototype['logExit'] = function()
{
    var self = this;
    console.log('logExit');
    send((function () {var _aux = send(Transcript.classPrototype, 'show_', [send('Exited ', ',', [send(send(thisContext, 'sender'), 'printString')])]);return _aux;})(), 'cr');
};
Object.prototype['crLog_'] = function(aString)
{
    var self = this;
    console.log('crLog_');
    send((function () {var _aux = send(Transcript.classPrototype, 'cr');return _aux;})(), 'show_', [aString]);
};
Object.prototype['log_'] = function(aString)
{
    var self = this;
    console.log('log_');
    send(Transcript.classPrototype, 'show_', [aString]);
};
Object.prototype['logCr_'] = function(aString)
{
    var self = this;
    console.log('logCr_');
    send((function () {var _aux = send(Transcript.classPrototype, 'show_', [aString]);return _aux;})(), 'cr');
};
Object.prototype['logCrTab_'] = function(aString)
{
    var self = this;
    console.log('logCrTab_');
    send((function () {var _aux = send((function () {var _aux = send(Transcript.classPrototype, 'show_', [aString]);return _aux;})(), 'cr');return _aux;})(), 'tab');
};
Object.prototype['contentsChanged'] = function()
{
    var self = this;
    console.log('contentsChanged');
    send(self, 'changed_', ['contents']);
};
Object.prototype['flash'] = function()
{
    var self = this;
    console.log('flash');
};
Object.prototype['refusesToAcceptCode'] = function()
{
    var self = this;
    console.log('refusesToAcceptCode');
    return false;
};
Object.prototype['sizeInMemory'] = function()
{
    var self = this;
    var __context = {};
    console.log('sizeInMemory');
    var isCompact = null
    var headerBytes = null
    var contentBytes = null
    contentBytes = send(send(send(self, 'class'), 'instSize'), '*', [send(Smalltalk.classPrototype, 'wordSize')]);
    send(send(send(self, 'class'), 'isVariable'), 'ifTrue_', [function() {
        var bytesPerElement = null;
        bytesPerElement = send(send(send(self, 'class'), 'isBytes'), 'ifTrue_ifFalse_', [function() {
            1;
        }
        , function() {
            4;
        }
        ]);
        contentBytes = send(contentBytes, '+', [send(send(self, 'basicSize'), '*', [bytesPerElement])]);
    }
    ]);
    if (__context.return) return __context.value;
    isCompact = send(send(send(self, 'class'), 'indexIfCompact'), '>', [0]);
    headerBytes = send(send(contentBytes, '>', [255]), 'ifTrue_ifFalse_', [function() {
        send(3, '*', [send(Smalltalk.classPrototype, 'wordSize')]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(isCompact, 'ifTrue_ifFalse_', [function() {
            send(Smalltalk.classPrototype, 'wordSize');
            if (__context.return) return __context.value;
        }
        , function() {
            send(2, '*', [send(Smalltalk.classPrototype, 'wordSize')]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    return send(headerBytes, '+', [contentBytes]);
};
Object.prototype['perform_'] = function(aSymbol)
{
    var self = this;
    console.log('perform_');
    var _primitive = primitives.primitive83(self, aSymbol);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'perform_withArguments_', [aSymbol, send(Array.classPrototype, 'new_', [0])]);
};
Object.prototype['perform_orSendTo_'] = function(selector, otherTarget)
{
    var self = this;
    console.log('perform_orSendTo_');
    return send(send(self, 'respondsTo_', [selector]), 'ifTrue_ifFalse_', [function() {
        send(self, 'perform_', [selector]);
    }
    , function() {
        send(otherTarget, 'perform_', [selector]);
    }
    ]);
};
Object.prototype['perform_withArguments_'] = function(selector, argArray)
{
    var self = this;
    console.log('perform_withArguments_');
    var _primitive = primitives.primitive84(self, selector, argArray);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'perform_withArguments_inSuperclass_', [selector, argArray, send(self, 'class')]);
};
Object.prototype['perform_withArguments_inSuperclass_'] = function(selector, argArray, lookupClass)
{
    var self = this;
    var __context = {};
    console.log('perform_withArguments_inSuperclass_');
    var _primitive = primitives.primitive100(self, selector, argArray, lookupClass);
    if (_primitive) return _primitive.value;
    ;
    send(send(selector, 'isSymbol'), 'ifFalse_', [function() {
        __context.value = send(self, 'error_', ['selector argument must be a Symbol']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(selector, 'numArgs'), '=', [send(argArray, 'size')]), 'ifFalse_', [function() {
        __context.value = send(self, 'error_', ['incorrect number of arguments']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, 'class'), '==', [lookupClass]), 'or_', [function() {
        send(send(self, 'class'), 'inheritsFrom_', [lookupClass]);
        if (__context.return) return __context.value;
    }
    ]), 'ifFalse_', [function() {
        __context.value = send(self, 'error_', ['lookupClass is not in my inheritance chain']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'primitiveFailed');
    if (__context.return) return __context.value;
};
Object.prototype['perform_withEnoughArguments_'] = function(selector, anArray)
{
    var self = this;
    var __context = {};
    console.log('perform_withEnoughArguments_');
    var numArgs = null
    var args = null
    numArgs = send(selector, 'numArgs');
    send(send(send(anArray, 'size'), '==', [numArgs]), 'ifTrue_', [function() {
        __context.value = send(self, 'perform_withArguments_', [selector, send(anArray, 'asArray')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    args = send(Array.classPrototype, 'new_', [numArgs]);
    send(args, 'replaceFrom_to_with_startingAt_', [1, send(send(anArray, 'size'), 'min_', [send(args, 'size')]), anArray, 1]);
    if (__context.return) return __context.value;
    return send(self, 'perform_withArguments_', [selector, args]);
};
Object.prototype['perform_with_'] = function(aSymbol, anObject)
{
    var self = this;
    console.log('perform_with_');
    var _primitive = primitives.primitive83(self, aSymbol, anObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'perform_withArguments_', [aSymbol, send(Array.classPrototype, 'with_', [anObject])]);
};
Object.prototype['perform_with_with_'] = function(aSymbol, firstObject, secondObject)
{
    var self = this;
    console.log('perform_with_with_');
    var _primitive = primitives.primitive83(self, aSymbol, firstObject, secondObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'perform_withArguments_', [aSymbol, send(Array.classPrototype, 'with_with_', [firstObject, secondObject])]);
};
Object.prototype['perform_with_with_with_'] = function(aSymbol, firstObject, secondObject, thirdObject)
{
    var self = this;
    console.log('perform_with_with_with_');
    var _primitive = primitives.primitive83(self, aSymbol, firstObject, secondObject, thirdObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'perform_withArguments_', [aSymbol, send(Array.classPrototype, 'with_with_with_', [firstObject, secondObject, thirdObject])]);
};
Object.prototype['fullPrintString'] = function()
{
    var self = this;
    console.log('fullPrintString');
    return send(String.classPrototype, 'streamContents_', [function(s) {
        send(self, 'printOn_', [s]);
    }
    ]);
};
Object.prototype['isLiteral'] = function()
{
    var self = this;
    console.log('isLiteral');
    return false;
};
Object.prototype['longPrintOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('longPrintOn_');
    send(send(send(self, 'class'), 'allInstVarNames'), 'doWithIndex_', [function(title, index) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, 'nextPutAll_', [title]);return _aux;})(), 'nextPut_', [':']);return _aux;})(), 'space');return _aux;})(), 'tab');return _aux;})(), 'print_', [send(self, 'instVarAt_', [index])]);return _aux;})(), 'cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['longPrintOn_limitedTo_indent_'] = function(aStream, sizeLimit, indent)
{
    var self = this;
    var __context = {};
    console.log('longPrintOn_limitedTo_indent_');
    send(send(send(self, 'class'), 'allInstVarNames'), 'doWithIndex_', [function(title, index) {
        send(indent, 'timesRepeat_', [function() {
            send(aStream, 'tab');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, 'nextPutAll_', [title]);return _aux;})(), 'nextPut_', [':']);return _aux;})(), 'space');return _aux;})(), 'tab');return _aux;})(), 'nextPutAll_', [send(send(self, 'instVarAt_', [index]), 'printStringLimitedTo_', [send(send(send(sizeLimit, '-', [3]), '-', [send(title, 'size')]), 'max_', [1])])]);return _aux;})(), 'cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['longPrintString'] = function()
{
    var self = this;
    console.log('longPrintString');
    var str = null
    str = send(String.classPrototype, 'streamContents_', [function(aStream) {
        send(self, 'longPrintOn_', [aStream]);
    }
    ]);
    return send(send(str, 'isEmpty'), 'ifTrue_ifFalse_', [function() {
        send(send(self, 'printString'), ',', [send(String.classPrototype, 'cr')]);
    }
    , function() {
        str;
    }
    ]);
};
Object.prototype['longPrintStringLimitedTo_'] = function(aLimitValue)
{
    var self = this;
    console.log('longPrintStringLimitedTo_');
    var str = null
    str = send(String.classPrototype, 'streamContents_', [function(aStream) {
        send(self, 'longPrintOn_limitedTo_indent_', [aStream, aLimitValue, 0]);
    }
    ]);
    return send(send(str, 'isEmpty'), 'ifTrue_ifFalse_', [function() {
        send(send(self, 'printString'), ',', [send(String.classPrototype, 'cr')]);
    }
    , function() {
        str;
    }
    ]);
};
Object.prototype['nominallyUnsent_'] = function(aSelectorSymbol)
{
    var self = this;
    var __context = {};
    console.log('nominallyUnsent_');
    send(false, 'ifTrue_', [function() {
        send(self, 'flag_', ['nominallyUnsent:']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['printOn_'] = function(t1)
{
    var self = this;
    console.log('printOn_');
    var t2 = null
    t2 = send(send(self, 'class'), 'name');
    send((function () {var _aux = send(t1, 'nextPutAll_', [send(send(send(t2, 'first'), 'isVowel'), 'ifTrue_ifFalse_', [function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ])]);return _aux;})(), 'nextPutAll_', [t2]);
};
Object.prototype['printString'] = function()
{
    var self = this;
    console.log('printString');
    return send(self, 'printStringLimitedTo_', [50000]);
};
Object.prototype['printStringLimitedTo_'] = function(limit)
{
    var self = this;
    var __context = {};
    console.log('printStringLimitedTo_');
    var limitedString = null
    limitedString = send(String.classPrototype, 'streamContents_limitedTo_', [function(s) {
        send(self, 'printOn_', [s]);
        if (__context.return) return __context.value;
    }
    , limit]);
    send(send(send(limitedString, 'size'), '<', [limit]), 'ifTrue_', [function() {
        __context.value = limitedString;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(limitedString, ',', ['...etc...']);
};
Object.prototype['printWithClosureAnalysisOn_'] = function(aStream)
{
    var self = this;
    console.log('printWithClosureAnalysisOn_');
    var title = null
    title = send(send(self, 'class'), 'name');
    send((function () {var _aux = send(aStream, 'nextPutAll_', [send(send(send(title, 'first'), 'isVowel'), 'ifTrue_ifFalse_', [function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ])]);return _aux;})(), 'nextPutAll_', [title]);
};
Object.prototype['storeOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('storeOn_');
    send(aStream, 'nextPut_', ['(']);
    if (__context.return) return __context.value;
    send(send(send(self, 'class'), 'isVariable'), 'ifTrue_ifFalse_', [function() {
        send((function () {var _aux = send((function () {var _aux = send(aStream, 'nextPutAll_', [send(send('(', ',', [send(send(self, 'class'), 'name')]), ',', [' basicNew: '])]);return _aux;})(), 'store_', [send(self, 'basicSize')]);return _aux;})(), 'nextPutAll_', [') ']);
        if (__context.return) return __context.value;
    }
    , function() {
        send(aStream, 'nextPutAll_', [send(send(send(self, 'class'), 'name'), ',', [' basicNew'])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [send(send(self, 'class'), 'instSize'), function(i) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, 'nextPutAll_', [' instVarAt: ']);return _aux;})(), 'store_', [i]);return _aux;})(), 'nextPutAll_', [' put: ']);return _aux;})(), 'store_', [send(self, 'instVarAt_', [i])]);return _aux;})(), 'nextPut_', [';']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, 'to_do_', [send(self, 'basicSize'), function(i) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, 'nextPutAll_', [' basicAt: ']);return _aux;})(), 'store_', [i]);return _aux;})(), 'nextPutAll_', [' put: ']);return _aux;})(), 'store_', [send(self, 'basicAt_', [i])]);return _aux;})(), 'nextPut_', [';']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, 'nextPutAll_', [' yourself)']);
    if (__context.return) return __context.value;
};
Object.prototype['storeString'] = function()
{
    var self = this;
    console.log('storeString');
    return send(String.classPrototype, 'streamContents_', [function(s) {
        send(self, 'storeOn_', [s]);
    }
    ]);
};
Object.prototype['isSelfEvaluating'] = function()
{
    var self = this;
    console.log('isSelfEvaluating');
    return send(self, 'isLiteral');
};
Object.prototype['appendTo_'] = function(aCollection)
{
    var self = this;
    console.log('appendTo_');
    return send(aCollection, 'addLast_', [self]);
};
Object.prototype['join_'] = function(aSequenceableCollection)
{
    var self = this;
    console.log('join_');
    return send(send(Array.classPrototype, 'with_', [self]), 'join_', [aSequenceableCollection]);
};
Object.prototype['joinTo_'] = function(stream)
{
    var self = this;
    console.log('joinTo_');
    return send(stream, 'nextPut_', [self]);
};
Object.prototype['split_'] = function(aSequenceableCollection)
{
    var self = this;
    console.log('split_');
    return send(send(Array.classPrototype, 'with_', [self]), 'split_', [aSequenceableCollection]);
};
Object.prototype['becomeForward_'] = function(otherObject)
{
    var self = this;
    console.log('becomeForward_');
    send(send(Array.classPrototype, 'with_', [self]), 'elementsForwardIdentityTo_', [send(Array.classPrototype, 'with_', [otherObject])]);
};
Object.prototype['becomeForward_copyHash_'] = function(otherObject, copyHash)
{
    var self = this;
    console.log('becomeForward_copyHash_');
    send(send(Array.classPrototype, 'with_', [self]), 'elementsForwardIdentityTo_copyHash_', [send(Array.classPrototype, 'with_', [otherObject]), copyHash]);
};
Object.prototype['className'] = function()
{
    var self = this;
    console.log('className');
    return send(send(send(self, 'class'), 'name'), 'asString');
};
Object.prototype['instVarAt_'] = function(index)
{
    var self = this;
    console.log('instVarAt_');
    var _primitive = primitives.primitive73(self, index);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'basicAt_', [send(index, '-', [send(send(self, 'class'), 'instSize')])]);
};
Object.prototype['instVarAt_put_'] = function(anInteger, anObject)
{
    var self = this;
    console.log('instVarAt_put_');
    var _primitive = primitives.primitive74(self, anInteger, anObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'basicAt_put_', [send(anInteger, '-', [send(send(self, 'class'), 'instSize')]), anObject]);
};
Object.prototype['instVarNamed_'] = function(aString)
{
    var self = this;
    console.log('instVarNamed_');
    return send(self, 'instVarAt_', [send(send(self, 'class'), 'instVarIndexFor_ifAbsent_', [send(aString, 'asString'), function() {
        send(self, 'error_', ['no such inst var']);
    }
    ])]);
};
Object.prototype['instVarNamed_put_'] = function(aString, aValue)
{
    var self = this;
    console.log('instVarNamed_put_');
    return send(self, 'instVarAt_put_', [send(send(self, 'class'), 'instVarIndexFor_ifAbsent_', [send(aString, 'asString'), function() {
        send(self, 'error_', ['no such inst var']);
    }
    ]), aValue]);
};
Object.prototype['primitiveChangeClassTo_'] = function(anObject)
{
    var self = this;
    console.log('primitiveChangeClassTo_');
    var _primitive = primitives.primitive115(self, anObject);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
Object.prototype['someObject'] = function()
{
    var self = this;
    console.log('someObject');
    var _primitive = primitives.primitive138(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, 'primitiveFailed');
};
Object.prototype['haltIfNil'] = function()
{
    var self = this;
    console.log('haltIfNil');
};
Object.prototype['hasLiteralSuchThat_'] = function(testBlock)
{
    var self = this;
    console.log('hasLiteralSuchThat_');
    return false;
};
Object.prototype['is_'] = function(t1)
{
    var self = this;
    console.log('is_');
    return false;
};
Object.prototype['isArray'] = function()
{
    var self = this;
    console.log('isArray');
    return false;
};
Object.prototype['isBehavior'] = function()
{
    var self = this;
    console.log('isBehavior');
    return false;
};
Object.prototype['isBlock'] = function()
{
    var self = this;
    console.log('isBlock');
    return false;
};
Object.prototype['isCharacter'] = function()
{
    var self = this;
    console.log('isCharacter');
    return false;
};
Object.prototype['isClosure'] = function()
{
    var self = this;
    console.log('isClosure');
    return false;
};
Object.prototype['isCollection'] = function()
{
    var self = this;
    console.log('isCollection');
    return false;
};
Object.prototype['isColor'] = function()
{
    var self = this;
    console.log('isColor');
    return false;
};
Object.prototype['isColorForm'] = function()
{
    var self = this;
    console.log('isColorForm');
    return false;
};
Object.prototype['isCompiledMethod'] = function()
{
    var self = this;
    console.log('isCompiledMethod');
    return false;
};
Object.prototype['isComplex'] = function()
{
    var self = this;
    console.log('isComplex');
    return false;
};
Object.prototype['isContext'] = function()
{
    var self = this;
    console.log('isContext');
    return false;
};
Object.prototype['isDictionary'] = function()
{
    var self = this;
    console.log('isDictionary');
    return false;
};
Object.prototype['isFloat'] = function()
{
    var self = this;
    console.log('isFloat');
    return false;
};
Object.prototype['isForm'] = function()
{
    var self = this;
    console.log('isForm');
    return false;
};
Object.prototype['isFraction'] = function()
{
    var self = this;
    console.log('isFraction');
    return false;
};
Object.prototype['isHeap'] = function()
{
    var self = this;
    console.log('isHeap');
    return false;
};
Object.prototype['isInteger'] = function()
{
    var self = this;
    console.log('isInteger');
    return false;
};
Object.prototype['isInterval'] = function()
{
    var self = this;
    console.log('isInterval');
    return false;
};
Object.prototype['isMessageSend'] = function()
{
    var self = this;
    console.log('isMessageSend');
    return false;
};
Object.prototype['isMethodProperties'] = function()
{
    var self = this;
    console.log('isMethodProperties');
    return false;
};
Object.prototype['isMorph'] = function()
{
    var self = this;
    console.log('isMorph');
    return false;
};
Object.prototype['isMorphicEvent'] = function()
{
    var self = this;
    console.log('isMorphicEvent');
    return false;
};
Object.prototype['isMorphicModel'] = function()
{
    var self = this;
    console.log('isMorphicModel');
    return false;
};
Object.prototype['isNumber'] = function()
{
    var self = this;
    console.log('isNumber');
    return false;
};
Object.prototype['isPoint'] = function()
{
    var self = this;
    console.log('isPoint');
    return false;
};
Object.prototype['isPseudoContext'] = function()
{
    var self = this;
    console.log('isPseudoContext');
    return false;
};
Object.prototype['isRectangle'] = function()
{
    var self = this;
    console.log('isRectangle');
    return false;
};
Object.prototype['isStream'] = function()
{
    var self = this;
    console.log('isStream');
    return false;
};
Object.prototype['isString'] = function()
{
    var self = this;
    console.log('isString');
    return false;
};
Object.prototype['isSymbol'] = function()
{
    var self = this;
    console.log('isSymbol');
    return false;
};
Object.prototype['isSystemWindow'] = function()
{
    var self = this;
    console.log('isSystemWindow');
    return false;
};
Object.prototype['isText'] = function()
{
    var self = this;
    console.log('isText');
    return false;
};
Object.prototype['isTrait'] = function()
{
    var self = this;
    console.log('isTrait');
    return false;
};
Object.prototype['isVariableBinding'] = function()
{
    var self = this;
    console.log('isVariableBinding');
    return false;
};
Object.prototype['name'] = function()
{
    var self = this;
    console.log('name');
    return send(self, 'printString');
};
Object.prototype['notNil'] = function()
{
    var self = this;
    console.log('notNil');
    return true;
};
Object.prototype['refersToLiteral_'] = function(literal)
{
    var self = this;
    console.log('refersToLiteral_');
    return false;
};
Object.prototype['stepAt_in_'] = function(millisecondClockValue, aWindow)
{
    var self = this;
    console.log('stepAt_in_');
    return send(self, 'stepIn_', [aWindow]);
};
Object.prototype['stepIn_'] = function(aWindow)
{
    var self = this;
    console.log('stepIn_');
    return send(self, 'step');
};
Object.prototype['stepTime'] = function()
{
    var self = this;
    console.log('stepTime');
    return 1000;
};
Object.prototype['stepTimeIn_'] = function(aSystemWindow)
{
    var self = this;
    console.log('stepTimeIn_');
    return 1000;
};
Object.prototype['wantsDiffFeedback'] = function()
{
    var self = this;
    console.log('wantsDiffFeedback');
    return false;
};
Object.prototype['wantsSteps'] = function()
{
    var self = this;
    console.log('wantsSteps');
    return false;
};
Object.prototype['wantsStepsIn_'] = function(aSystemWindow)
{
    var self = this;
    console.log('wantsStepsIn_');
    return send(self, 'wantsSteps');
};
Object.prototype['changed'] = function()
{
    var self = this;
    console.log('changed');
    send(self, 'changed_', [self]);
};
Object.prototype['changed_'] = function(aParameter)
{
    var self = this;
    var __context = {};
    console.log('changed_');
    send(send(self, 'dependents'), 'do_', [function(aDependent) {
        send(aDependent, 'update_', [aParameter]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['changed_with_'] = function(anAspect, anObject)
{
    var self = this;
    var __context = {};
    console.log('changed_with_');
    send(send(self, 'dependents'), 'do_', [function(aDependent) {
        send(aDependent, 'update_with_', [anAspect, anObject]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['noteSelectionIndex_for_'] = function(anInteger, aSymbol)
{
    var self = this;
    console.log('noteSelectionIndex_for_');
};
Object.prototype['okToChange'] = function()
{
    var self = this;
    console.log('okToChange');
    return true;
};
Object.prototype['update_'] = function(aParameter)
{
    var self = this;
    console.log('update_');
    return self;
};
Object.prototype['update_with_'] = function(anAspect, anObject)
{
    var self = this;
    console.log('update_with_');
    return send(self, 'update_', [anAspect]);
};
Object.prototype['windowIsClosing'] = function()
{
    var self = this;
    console.log('windowIsClosing');
    return self;
};
Object.prototype['addModelItemsToWindowMenu_'] = function(aMenu)
{
    var self = this;
    console.log('addModelItemsToWindowMenu_');
};
Object.prototype['addModelMenuItemsTo_forMorph_hand_'] = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    console.log('addModelMenuItemsTo_forMorph_hand_');
};
Object.prototype['modelSleep'] = function()
{
    var self = this;
    console.log('modelSleep');
};
Object.prototype['modelWakeUp'] = function()
{
    var self = this;
    console.log('modelWakeUp');
};
Object.prototype['modelWakeUpIn_'] = function(aWindow)
{
    var self = this;
    console.log('modelWakeUpIn_');
    send(self, 'modelWakeUp');
};
Object.prototype['mouseUpBalk_'] = function(evt)
{
    var self = this;
    console.log('mouseUpBalk_');
};
Object.prototype['notYetImplemented'] = function()
{
    var self = this;
    console.log('notYetImplemented');
    send(self, 'inform_', [send(send('Not yet implemented (', ',', [send(send(thisContext, 'sender'), 'printString')]), ',', [')'])]);
};
Object.prototype['windowReqNewLabel_'] = function(labelString)
{
    var self = this;
    console.log('windowReqNewLabel_');
    return true;
};
Object.prototype['errorImproperStore'] = function()
{
    var self = this;
    console.log('errorImproperStore');
    send(self, 'error_', ['Improper store into indexable object']);
};
Object.prototype['errorNonIntegerIndex'] = function()
{
    var self = this;
    console.log('errorNonIntegerIndex');
    send(self, 'error_', ['only integers should be used as indices']);
};
Object.prototype['errorNotIndexable'] = function()
{
    var self = this;
    console.log('errorNotIndexable');
    send(self, 'error_', [send(send('Instances of {1} are not indexable', 'translated'), 'format_', [[send(send(self, 'class'), 'name')]])]);
};
Object.prototype['errorSubscriptBounds_'] = function(index)
{
    var self = this;
    console.log('errorSubscriptBounds_');
    send(SubscriptOutOfBounds.classPrototype, 'signalFor_', [index]);
};
Object.prototype['species'] = function()
{
    var self = this;
    console.log('species');
    var _primitive = primitives.primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    return send(self, 'class');
};
Object.prototype['storeAt_inTempFrame_'] = function(offset, aContext)
{
    var self = this;
    console.log('storeAt_inTempFrame_');
    return send(aContext, 'tempAt_put_', [offset, self]);
};
ObjectClass.prototype['readFrom_'] = function(t1)
{
    var self = this;
    var __context = {};
    console.log('readFrom_');
    var t2 = null
    send(send(Compiler.classPrototype, 'couldEvaluate_', [t1]), 'ifFalse_', [function() {
        __context.value = send(self, 'error_', ['expected String, Stream, or Text']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    t2 = send(Compiler.classPrototype, 'evaluate_', [t1]);
    send(send(t2, 'isKindOf_', [self]), 'ifFalse_', [function() {
        send(self, 'error_', [send(send(self, 'name'), ',', [' expected'])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return t2;
};
ObjectClass.prototype['taskbarIcon'] = function()
{
    var self = this;
    console.log('taskbarIcon');
    return nil;
};
ObjectClass.prototype['taskbarLabel'] = function()
{
    var self = this;
    console.log('taskbarLabel');
    return nil;
};
ObjectClass.prototype['registerToolsOn_'] = function(t1)
{
    var self = this;
    console.log('registerToolsOn_');
    return self;
};
ObjectClass.prototype['services'] = function()
{
    var self = this;
    console.log('services');
    return [];
};
ObjectClass.prototype['flushDependents'] = function()
{
    var self = this;
    var __context = {};
    console.log('flushDependents');
    send(DependentsFields.classPrototype, 'keysAndValuesDo_', [function(key, dep) {
        send(key, 'ifNotNil_', [function() {
            send(key, 'removeDependent_', [nil]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(DependentsFields.classPrototype, 'finalizeValues');
    if (__context.return) return __context.value;
};
ObjectClass.prototype['flushEvents'] = function()
{
    var self = this;
    console.log('flushEvents');
    send(EventManager.classPrototype, 'flushEvents');
};
ObjectClass.prototype['initialize'] = function()
{
    var self = this;
    var __context = {};
    console.log('initialize');
    send(DependentsFields.classPrototype, 'ifNil_', [function() {
        send(self, 'initializeDependentsFields');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ObjectClass.prototype['initializeDependentsFields'] = function()
{
    var self = this;
    console.log('initializeDependentsFields');
    DependentsFields = send(WeakIdentityKeyDictionary.classPrototype, 'new');
};
ObjectClass.prototype['reInitializeDependentsFields'] = function()
{
    var self = this;
    var __context = {};
    console.log('reInitializeDependentsFields');
    var oldFields = null
    oldFields = DependentsFields;
    DependentsFields = send(WeakIdentityKeyDictionary.classPrototype, 'new');
    send(oldFields, 'keysAndValuesDo_', [function(obj, deps) {
        send(deps, 'do_', [function(d) {
            send(obj, 'addDependent_', [d]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ObjectClass.prototype['howToModifyPrimitives'] = function()
{
    var self = this;
    console.log('howToModifyPrimitives');
    send(self, 'error_', ['comment only']);
};
ObjectClass.prototype['whatIsAPrimitive'] = function()
{
    var self = this;
    console.log('whatIsAPrimitive');
    send(self, 'error_', ['comment only']);
};
ObjectClass.prototype['fileReaderServicesForDirectory_'] = function(aFileDirectory)
{
    var self = this;
    console.log('fileReaderServicesForDirectory_');
    return [];
};
ObjectClass.prototype['fileReaderServicesForFile_suffix_'] = function(fullName, suffix)
{
    var self = this;
    console.log('fileReaderServicesForFile_suffix_');
    return [];
};
ObjectClass.prototype['newFrom_'] = function(aSimilarObject)
{
    var self = this;
    console.log('newFrom_');
    return send(send(send(self, 'isVariable'), 'ifTrue_ifFalse_', [function() {
        send(self, 'basicNew_', [send(aSimilarObject, 'basicSize')]);
    }
    , function() {
        send(self, 'basicNew');
    }
    ]), 'copySameFrom_', [aSimilarObject]);
};
ObjectClass.prototype['createFrom_size_version_'] = function(aSmartRefStream, varsOnDisk, instVarList)
{
    var self = this;
    console.log('createFrom_size_version_');
    return send(send(self, 'isVariable'), 'ifFalse_ifTrue_', [function() {
        send(self, 'basicNew');
    }
    , function() {
        send(self, 'basicNew_', [send(varsOnDisk, '-', [send(send(instVarList, 'size'), '-', [1])])]);
    }
    ]);
};
ObjectClass.prototype['releaseExternalSettings'] = function()
{
    var self = this;
    console.log('releaseExternalSettings');
};
function MessageSendClass()
{
}
function MessageSend()
{
}
MessageSend.prototype.__class = MessageSendClass.prototype;
MessageSend.classPrototype = MessageSendClass.prototype;
MessageSendClass.prototype['_basicNew'] = function() { return new MessageSend(); };
MessageSendClass.prototype.__proto__ = ObjectClass.prototype;
MessageSend.prototype.__proto__ = Object.prototype;
MessageSend.prototype.$receiver = null;
MessageSend.prototype.$selector = null;
MessageSend.prototype.$arguments = null;
MessageSendClass.__super = ObjectClass;
MessageSend.__super = Object;
MessageSend.prototype['arguments'] = function()
{
    var self = this;
    console.log('arguments');
    return self.$arguments;
};
MessageSend.prototype['arguments_'] = function(anArray)
{
    var self = this;
    console.log('arguments_');
    self.$arguments = anArray;
};
MessageSend.prototype['numArgs'] = function()
{
    var self = this;
    console.log('numArgs');
    return send(self.$arguments, 'size');
};
MessageSend.prototype['receiver'] = function()
{
    var self = this;
    console.log('receiver');
    return self.$receiver;
};
MessageSend.prototype['receiver_'] = function(anObject)
{
    var self = this;
    console.log('receiver_');
    self.$receiver = anObject;
};
MessageSend.prototype['selector'] = function()
{
    var self = this;
    console.log('selector');
    return self.$selector;
};
MessageSend.prototype['selector_'] = function(aSymbol)
{
    var self = this;
    console.log('selector_');
    self.$selector = aSymbol;
};
MessageSend.prototype['='] = function(anObject)
{
    var self = this;
    console.log('=');
    return send(send(send(anObject, 'species'), '==', [send(self, 'species')]), 'and_', [function() {
        send(send(self.$receiver, '==', [send(anObject, 'receiver')]), 'and_', [function() {
            send(send(self.$selector, '==', [send(anObject, 'selector')]), 'and_', [function() {
                send(self.$arguments, '=', [send(anObject, 'arguments')]);
            }
            ]);
        }
        ]);
    }
    ]);
};
MessageSend.prototype['hash'] = function()
{
    var self = this;
    console.log('hash');
    return send(send(self.$receiver, 'hash'), 'bitXor_', [send(self.$selector, 'hash')]);
};
MessageSend.prototype['asMinimalRepresentation'] = function()
{
    var self = this;
    console.log('asMinimalRepresentation');
    return self;
};
MessageSend.prototype['asWeakMessageSend'] = function()
{
    var self = this;
    console.log('asWeakMessageSend');
    return send(WeakMessageSend.classPrototype, 'receiver_selector_arguments_', [self.$receiver, self.$selector, send(self.$arguments, 'copy')]);
};
MessageSend.prototype['cull_'] = function(arg)
{
    var self = this;
    console.log('cull_');
    return send(send(send(self.$selector, 'numArgs'), '=', [0]), 'ifTrue_ifFalse_', [function() {
        send(self, 'value');
    }
    , function() {
        send(self, 'value_', [arg]);
    }
    ]);
};
MessageSend.prototype['cull_cull_'] = function(arg1, arg2)
{
    var self = this;
    console.log('cull_cull_');
    return send(send(send(self.$selector, 'numArgs'), '<', [2]), 'ifTrue_ifFalse_', [function() {
        send(self, 'cull_', [arg1]);
    }
    , function() {
        send(self, 'value_value_', [arg1, arg2]);
    }
    ]);
};
MessageSend.prototype['cull_cull_cull_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('cull_cull_cull_');
    return send(send(send(self.$selector, 'numArgs'), '<', [3]), 'ifTrue_ifFalse_', [function() {
        send(self, 'cull_cull_', [arg1, arg2]);
    }
    , function() {
        send(self, 'value_value_value_', [arg1, arg2, arg3]);
    }
    ]);
};
MessageSend.prototype['value'] = function()
{
    var self = this;
    var __context = {};
    console.log('value');
    send(self.$arguments, 'ifNil_', [function() {
        __context.value = send(self.$receiver, 'perform_', [self.$selector]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(self.$receiver, 'perform_withArguments_', [self.$selector, send(self, 'collectArguments_', [self.$arguments])]);
};
MessageSend.prototype['value_'] = function(anObject)
{
    var self = this;
    console.log('value_');
    return send(self.$receiver, 'perform_with_', [self.$selector, anObject]);
};
MessageSend.prototype['value_value_'] = function(anObject1, anObject2)
{
    var self = this;
    console.log('value_value_');
    return send(self.$receiver, 'perform_with_with_', [self.$selector, anObject1, anObject2]);
};
MessageSend.prototype['value_value_value_'] = function(anObject1, anObject2, anObject3)
{
    var self = this;
    console.log('value_value_value_');
    return send(self.$receiver, 'perform_with_with_with_', [self.$selector, anObject1, anObject2, anObject3]);
};
MessageSend.prototype['valueWithArguments_'] = function(anArray)
{
    var self = this;
    console.log('valueWithArguments_');
    return send(self.$receiver, 'perform_withArguments_', [self.$selector, send(self, 'collectArguments_', [anArray])]);
};
MessageSend.prototype['valueWithEnoughArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('valueWithEnoughArguments_');
    var args = null
    args = send(Array.classPrototype, 'new_', [send(self.$selector, 'numArgs')]);
    send(args, 'replaceFrom_to_with_startingAt_', [1, send(send(self.$arguments, 'size'), 'min_', [send(args, 'size')]), self.$arguments, 1]);
    if (__context.return) return __context.value;
    send(send(send(args, 'size'), '>', [send(self.$arguments, 'size')]), 'ifTrue_', [function() {
        send(args, 'replaceFrom_to_with_startingAt_', [send(send(self.$arguments, 'size'), '+', [1]), send(send(send(self.$arguments, 'size'), '+', [send(anArray, 'size')]), 'min_', [send(args, 'size')]), anArray, 1]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(self.$receiver, 'perform_withArguments_', [self.$selector, args]);
};
MessageSend.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send((function () {var _aux = send(aStream, 'nextPutAll_', [send(send(self, 'class'), 'name')]);return _aux;})(), 'nextPut_', ['(']);
    send(self.$selector, 'printOn_', [aStream]);
    send(aStream, 'nextPutAll_', [' -> ']);
    send(self.$receiver, 'printOn_', [aStream]);
    send(aStream, 'nextPut_', [')']);
};
MessageSend.prototype['isMessageSend'] = function()
{
    var self = this;
    console.log('isMessageSend');
    return true;
};
MessageSend.prototype['isValid'] = function()
{
    var self = this;
    console.log('isValid');
    return true;
};
MessageSend.prototype['collectArguments_'] = function(anArgArray)
{
    var self = this;
    console.log('collectArguments_');
    var staticArgs = null
    staticArgs = send(self, 'arguments');
    return send(send(send(anArgArray, 'size'), '=', [send(staticArgs, 'size')]), 'ifTrue_ifFalse_', [function() {
        anArgArray;
    }
    , function() {
        send(send(send(staticArgs, 'isEmpty'), 'ifTrue_ifFalse_', [function() {
            staticArgs = send(Array.classPrototype, 'new_', [send(self.$selector, 'numArgs')]);
        }
        , function() {
            send(staticArgs, 'copy');
        }
        ]), 'replaceFrom_to_with_startingAt_', [1, send(send(anArgArray, 'size'), 'min_', [send(staticArgs, 'size')]), anArgArray, 1]);
    }
    ]);
};
MessageSendClass.prototype['receiver_selector_'] = function(anObject, aSymbol)
{
    var self = this;
    console.log('receiver_selector_');
    return send(self, 'receiver_selector_arguments_', [anObject, aSymbol, []]);
};
MessageSendClass.prototype['receiver_selector_argument_'] = function(anObject, aSymbol, aParameter)
{
    var self = this;
    console.log('receiver_selector_argument_');
    return send(self, 'receiver_selector_arguments_', [anObject, aSymbol, send(Array.classPrototype, 'with_', [aParameter])]);
};
MessageSendClass.prototype['receiver_selector_arguments_'] = function(anObject, aSymbol, anArray)
{
    var self = this;
    console.log('receiver_selector_arguments_');
    return send((function () {var _aux = send((function () {var _aux = send(send(self, 'new'), 'receiver_', [anObject]);return _aux;})(), 'selector_', [aSymbol]);return _aux;})(), 'arguments_', [anArray]);
};
function UndefinedObjectClass()
{
}
function UndefinedObject()
{
}
UndefinedObject.prototype.__class = UndefinedObjectClass.prototype;
UndefinedObject.classPrototype = UndefinedObjectClass.prototype;
UndefinedObjectClass.prototype['_basicNew'] = function() { return new UndefinedObject(); };
UndefinedObjectClass.prototype.__proto__ = ObjectClass.prototype;
UndefinedObject.prototype.__proto__ = Object.prototype;
UndefinedObjectClass.__super = ObjectClass;
UndefinedObject.__super = Object;
UndefinedObject.prototype['parserClass'] = function()
{
    var self = this;
    console.log('parserClass');
    return send(Compiler.classPrototype, 'parserClass');
};
UndefinedObject.prototype['canHandleSignal_'] = function(exception)
{
    var self = this;
    console.log('canHandleSignal_');
    return false;
};
UndefinedObject.prototype['handleSignal_'] = function(exception)
{
    var self = this;
    console.log('handleSignal_');
    return send(exception, 'resumeUnchecked_', [send(exception, 'defaultAction')]);
};
UndefinedObject.prototype['addSubclass_'] = function(aClass)
{
    var self = this;
    console.log('addSubclass_');
};
UndefinedObject.prototype['allSuperclassesDo_'] = function(aBlockContext)
{
    var self = this;
    console.log('allSuperclassesDo_');
    send(self, 'shouldBeImplemented');
};
UndefinedObject.prototype['environment'] = function()
{
    var self = this;
    console.log('environment');
    return send(send(self, 'class'), 'environment');
};
UndefinedObject.prototype['literalScannedAs_notifying_'] = function(scannedLiteral, requestor)
{
    var self = this;
    console.log('literalScannedAs_notifying_');
    return scannedLiteral;
};
UndefinedObject.prototype['removeObsoleteSubclass_'] = function(aClass)
{
    var self = this;
    console.log('removeObsoleteSubclass_');
};
UndefinedObject.prototype['removeSubclass_'] = function(aClass)
{
    var self = this;
    console.log('removeSubclass_');
};
UndefinedObject.prototype['subclassDefinerClass'] = function()
{
    var self = this;
    console.log('subclassDefinerClass');
    return Compiler;
};
UndefinedObject.prototype['subclasses'] = function()
{
    var self = this;
    var __context = {};
    console.log('subclasses');
    var classList = null
    classList = send(send(Array.classPrototype, 'new'), 'writeStream');
    send(self, 'subclassesDo_', [function(clazz) {
        send(classList, 'nextPut_', [clazz]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(classList, 'contents');
};
UndefinedObject.prototype['subclassesDo_'] = function(aBlock)
{
    var self = this;
    console.log('subclassesDo_');
    return send(Class.classPrototype, 'subclassesDo_', [function(cl) {
        send(send(cl, 'isMeta'), 'ifTrue_', [function() {
            send(aBlock, 'value_', [send(cl, 'soleInstance')]);
        }
        ]);
    }
    ]);
};
UndefinedObject.prototype['subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_'] = function(nameOfClass, instVarNames, classVarNames, poolDictnames, category)
{
    var self = this;
    console.log('subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_');
    send(self, 'logCr_', [send(send('Attempt to create ', ',', [nameOfClass]), ',', [' as a subclass of nil.  Possibly a class is being loaded before its superclass.'])]);
    return send(ProtoObject.classPrototype, 'subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_', [nameOfClass, instVarNames, classVarNames, poolDictnames, category]);
};
UndefinedObject.prototype['typeOfClass'] = function()
{
    var self = this;
    console.log('typeOfClass');
    return 'normal';
};
UndefinedObject.prototype['deepCopy'] = function()
{
    var self = this;
    console.log('deepCopy');
};
UndefinedObject.prototype['shallowCopy'] = function()
{
    var self = this;
    console.log('shallowCopy');
};
UndefinedObject.prototype['veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('veryDeepCopyWith_');
};
UndefinedObject.prototype['addDependent_'] = function(ignored)
{
    var self = this;
    console.log('addDependent_');
    send(self, 'error_', ['Nil should not have dependents']);
};
UndefinedObject.prototype['release'] = function()
{
    var self = this;
    console.log('release');
};
UndefinedObject.prototype['suspend'] = function()
{
    var self = this;
    console.log('suspend');
    send(Processor.classPrototype, 'terminateActive');
};
UndefinedObject.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send(aStream, 'nextPutAll_', ['nil']);
};
UndefinedObject.prototype['storeOn_'] = function(aStream)
{
    var self = this;
    console.log('storeOn_');
    send(aStream, 'nextPutAll_', ['nil']);
};
UndefinedObject.prototype['asSetElement'] = function()
{
    var self = this;
    console.log('asSetElement');
    return send(SetElement.classPrototype, 'withNil');
};
UndefinedObject.prototype['haltIfNil'] = function()
{
    var self = this;
    console.log('haltIfNil');
    send(self, 'halt');
};
UndefinedObject.prototype['ifNil_'] = function(aBlock)
{
    var self = this;
    console.log('ifNil_');
    return send(aBlock, 'value');
};
UndefinedObject.prototype['ifNil_ifNotNilDo_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('ifNil_ifNotNilDo_');
    return send(nilBlock, 'value');
};
UndefinedObject.prototype['ifNil_ifNotNil_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('ifNil_ifNotNil_');
    return send(nilBlock, 'value');
};
UndefinedObject.prototype['ifNotNilDo_'] = function(aBlock)
{
    var self = this;
    console.log('ifNotNilDo_');
    return self;
};
UndefinedObject.prototype['ifNotNilDo_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('ifNotNilDo_ifNil_');
    return send(nilBlock, 'value');
};
UndefinedObject.prototype['ifNotNil_'] = function(aBlock)
{
    var self = this;
    console.log('ifNotNil_');
    return self;
};
UndefinedObject.prototype['ifNotNil_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('ifNotNil_ifNil_');
    return send(nilBlock, 'value');
};
UndefinedObject.prototype['isEmptyOrNil'] = function()
{
    var self = this;
    console.log('isEmptyOrNil');
    return true;
};
UndefinedObject.prototype['isLiteral'] = function()
{
    var self = this;
    console.log('isLiteral');
    return true;
};
UndefinedObject.prototype['isNil'] = function()
{
    var self = this;
    console.log('isNil');
    return true;
};
UndefinedObject.prototype['notNil'] = function()
{
    var self = this;
    console.log('notNil');
    return false;
};
UndefinedObjectClass.prototype['allInstances'] = function()
{
    var self = this;
    console.log('allInstances');
    return send(Array.classPrototype, 'with_', [nil]);
};
UndefinedObjectClass.prototype['allInstancesDo_'] = function(aBlock)
{
    var self = this;
    console.log('allInstancesDo_');
    send(aBlock, 'value_', [nil]);
};
UndefinedObjectClass.prototype['new'] = function()
{
    var self = this;
    console.log('new');
    send(self, 'error_', ['You may not create any more undefined objects--use nil']);
};
function BooleanClass()
{
}
function Boolean()
{
}
Boolean.prototype.__class = BooleanClass.prototype;
Boolean.classPrototype = BooleanClass.prototype;
BooleanClass.prototype['_basicNew'] = function() { return new Boolean(); };
BooleanClass.prototype.__proto__ = ObjectClass.prototype;
Boolean.prototype.__proto__ = Object.prototype;
BooleanClass.__super = ObjectClass;
Boolean.__super = Object;
Boolean.prototype['and_and_'] = function(block1, block2)
{
    var self = this;
    var __context = {};
    console.log('and_and_');
    send(self, 'deprecated_', ['use and:']);
    if (__context.return) return __context.value;
    send(self, 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['and_and_and_'] = function(block1, block2, block3)
{
    var self = this;
    var __context = {};
    console.log('and_and_and_');
    send(self, 'deprecated_', ['Use and: instead']);
    if (__context.return) return __context.value;
    send(self, 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['and_and_and_and_'] = function(block1, block2, block3, block4)
{
    var self = this;
    var __context = {};
    console.log('and_and_and_and_');
    send(self, 'deprecated_', ['Use and: instead']);
    if (__context.return) return __context.value;
    send(self, 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block4, 'value'), 'ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['or_or_'] = function(block1, block2)
{
    var self = this;
    var __context = {};
    console.log('or_or_');
    send(self, 'deprecated_', ['use a or:[b or:[c]] instead']);
    if (__context.return) return __context.value;
    send(self, 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['or_or_or_'] = function(block1, block2, block3)
{
    var self = this;
    var __context = {};
    console.log('or_or_or_');
    send(self, 'deprecated_', ['use a or:[b or:[c or:[d]]] instead']);
    if (__context.return) return __context.value;
    send(self, 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['or_or_or_or_'] = function(block1, block2, block3, block4)
{
    var self = this;
    var __context = {};
    console.log('or_or_or_or_');
    send(self, 'deprecated_', ['use a or:[b or:[c or:[d or:[e]]]] instead']);
    if (__context.return) return __context.value;
    send(self, 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block4, 'value'), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('and_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifFalse_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('ifFalse_ifTrue_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifTrue_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('ifTrue_ifFalse_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('or_');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['deepCopy'] = function()
{
    var self = this;
    console.log('deepCopy');
};
Boolean.prototype['shallowCopy'] = function()
{
    var self = this;
    console.log('shallowCopy');
};
Boolean.prototype['veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('veryDeepCopyWith_');
};
Boolean.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['==>'] = function(aBlock)
{
    var self = this;
    console.log('==>');
    return send(send(self, 'not'), 'or_', [function() {
        send(aBlock, 'value');
    }
    ]);
};
Boolean.prototype['eqv_'] = function(aBoolean)
{
    var self = this;
    console.log('eqv_');
    return send(self, '==', [aBoolean]);
};
Boolean.prototype['not'] = function()
{
    var self = this;
    console.log('not');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    send(self, 'subclassResponsibility');
};
Boolean.prototype['isLiteral'] = function()
{
    var self = this;
    console.log('isLiteral');
    return true;
};
Boolean.prototype['storeOn_'] = function(aStream)
{
    var self = this;
    console.log('storeOn_');
    send(self, 'printOn_', [aStream]);
};
Boolean.prototype['isSelfEvaluating'] = function()
{
    var self = this;
    console.log('isSelfEvaluating');
    return true;
};
BooleanClass.prototype['settingInputWidgetForNode_'] = function(aSettingNode)
{
    var self = this;
    console.log('settingInputWidgetForNode_');
    return send(aSettingNode, 'inputWidgetForBoolean');
};
BooleanClass.prototype['new'] = function()
{
    var self = this;
    console.log('new');
    send(self, 'error_', ['You may not create any more Booleans - this is two-valued logic']);
};
function FalseClass()
{
}
function False()
{
}
False.prototype.__class = FalseClass.prototype;
False.classPrototype = FalseClass.prototype;
FalseClass.prototype['_basicNew'] = function() { return new False(); };
FalseClass.prototype.__proto__ = BooleanClass.prototype;
False.prototype.__proto__ = Boolean.prototype;
FalseClass.__super = BooleanClass;
False.__super = Boolean;
False.prototype['and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('and_');
    return self;
};
False.prototype['ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifFalse_');
    return send(alternativeBlock, 'value');
};
False.prototype['ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('ifFalse_ifTrue_');
    return send(falseAlternativeBlock, 'value');
};
False.prototype['ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifTrue_');
    return nil;
};
False.prototype['ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('ifTrue_ifFalse_');
    return send(falseAlternativeBlock, 'value');
};
False.prototype['or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('or_');
    return send(alternativeBlock, 'value');
};
False.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    return self;
};
False.prototype['not'] = function()
{
    var self = this;
    console.log('not');
    return true;
};
False.prototype['xor_'] = function(aBoolean)
{
    var self = this;
    console.log('xor_');
    return send(aBoolean, 'value');
};
False.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    return aBoolean;
};
False.prototype['asBit'] = function()
{
    var self = this;
    console.log('asBit');
    return 0;
};
False.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send(aStream, 'nextPutAll_', ['false']);
};
function TrueClass()
{
}
function True()
{
}
True.prototype.__class = TrueClass.prototype;
True.classPrototype = TrueClass.prototype;
TrueClass.prototype['_basicNew'] = function() { return new True(); };
TrueClass.prototype.__proto__ = BooleanClass.prototype;
True.prototype.__proto__ = Boolean.prototype;
TrueClass.__super = BooleanClass;
True.__super = Boolean;
True.prototype['and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('and_');
    return send(alternativeBlock, 'value');
};
True.prototype['ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifFalse_');
    return nil;
};
True.prototype['ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('ifFalse_ifTrue_');
    return send(trueAlternativeBlock, 'value');
};
True.prototype['ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('ifTrue_');
    return send(alternativeBlock, 'value');
};
True.prototype['ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('ifTrue_ifFalse_');
    return send(trueAlternativeBlock, 'value');
};
True.prototype['or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('or_');
    return self;
};
True.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    return aBoolean;
};
True.prototype['not'] = function()
{
    var self = this;
    console.log('not');
    return false;
};
True.prototype['xor_'] = function(aBoolean)
{
    var self = this;
    console.log('xor_');
    return send(send(aBoolean, 'value'), 'not');
};
True.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    return self;
};
True.prototype['asBit'] = function()
{
    var self = this;
    console.log('asBit');
    return 1;
};
True.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send(aStream, 'nextPutAll_', ['true']);
};
function WeakMessageSendClass()
{
}
function WeakMessageSend()
{
}
WeakMessageSend.prototype.__class = WeakMessageSendClass.prototype;
WeakMessageSend.classPrototype = WeakMessageSendClass.prototype;
WeakMessageSendClass.prototype['_basicNew'] = function() { return new WeakMessageSend(); };
WeakMessageSendClass.prototype.__proto__ = ObjectClass.prototype;
WeakMessageSend.prototype.__proto__ = Object.prototype;
WeakMessageSend.prototype.$selector = null;
WeakMessageSend.prototype.$shouldBeNil = null;
WeakMessageSend.prototype.$arguments = null;
WeakMessageSendClass.__super = ObjectClass;
WeakMessageSend.__super = Object;
WeakMessageSend.prototype['arguments'] = function()
{
    var self = this;
    console.log('arguments');
    return send(self.$arguments, 'ifNil_', [function() {
        send(Array.classPrototype, 'new');
    }
    ]);
};
WeakMessageSend.prototype['arguments_'] = function(anArray)
{
    var self = this;
    console.log('arguments_');
    self.$arguments = send(WeakArray.classPrototype, 'withAll_', [anArray]);
    self.$shouldBeNil = send(Array.classPrototype, 'withAll_', [send(anArray, 'collect_', [function(ea) {
        send(ea, 'isNil');
    }
    ])]);
};
WeakMessageSend.prototype['receiver'] = function()
{
    var self = this;
    console.log('receiver');
    return send(self, 'at_', [1]);
};
WeakMessageSend.prototype['receiver_'] = function(anObject)
{
    var self = this;
    console.log('receiver_');
    send(self, 'at_put_', [1, anObject]);
};
WeakMessageSend.prototype['selector'] = function()
{
    var self = this;
    console.log('selector');
    return self.$selector;
};
WeakMessageSend.prototype['selector_'] = function(aSymbol)
{
    var self = this;
    console.log('selector_');
    self.$selector = aSymbol;
};
WeakMessageSend.prototype['='] = function(anObject)
{
    var self = this;
    console.log('=');
    return send(send(anObject, 'isMessageSend'), 'and_', [function() {
        send(send(send(self, 'receiver'), '==', [send(anObject, 'receiver')]), 'and_', [function() {
            send(send(self.$selector, '==', [send(anObject, 'selector')]), 'and_', [function() {
                send(send(Array.classPrototype, 'withAll_', [self.$arguments]), '=', [send(Array.classPrototype, 'withAll_', [send(anObject, 'arguments')])]);
            }
            ]);
        }
        ]);
    }
    ]);
};
WeakMessageSend.prototype['hash'] = function()
{
    var self = this;
    console.log('hash');
    return send(send(send(self, 'receiver'), 'hash'), 'bitXor_', [send(self.$selector, 'hash')]);
};
WeakMessageSend.prototype['asMessageSend'] = function()
{
    var self = this;
    console.log('asMessageSend');
    return send(MessageSend.classPrototype, 'receiver_selector_arguments_', [send(self, 'receiver'), self.$selector, send(Array.classPrototype, 'withAll_', [send(self, 'arguments')])]);
};
WeakMessageSend.prototype['asMinimalRepresentation'] = function()
{
    var self = this;
    var __context = {};
    console.log('asMinimalRepresentation');
    send(send(self, 'isReceiverOrAnyArgumentGarbage'), 'ifTrue_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
WeakMessageSend.prototype['cull_'] = function(arg)
{
    var self = this;
    console.log('cull_');
    return send(send(send(self.$selector, 'numArgs'), '=', [0]), 'ifTrue_ifFalse_', [function() {
        send(self, 'value');
    }
    , function() {
        send(self, 'value_', [arg]);
    }
    ]);
};
WeakMessageSend.prototype['cull_cull_'] = function(arg1, arg2)
{
    var self = this;
    console.log('cull_cull_');
    return send(send(send(self.$selector, 'numArgs'), '<', [2]), 'ifTrue_ifFalse_', [function() {
        send(self, 'cull_', [arg1]);
    }
    , function() {
        send(self, 'value_value_', [arg1, arg2]);
    }
    ]);
};
WeakMessageSend.prototype['cull_cull_cull_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('cull_cull_cull_');
    return send(send(send(self.$selector, 'numArgs'), '<', [3]), 'ifTrue_ifFalse_', [function() {
        send(self, 'cull_cull_', [arg1, arg2]);
    }
    , function() {
        send(self, 'value_value_value_', [arg1, arg2, arg3]);
    }
    ]);
};
WeakMessageSend.prototype['value'] = function()
{
    var self = this;
    console.log('value');
    return send(send(self.$arguments, 'isNil'), 'ifTrue_ifFalse_', [function() {
        send(send(self, 'ensureReceiver'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'receiver'), 'perform_', [self.$selector]);
        }
        , function() {
        }
        ]);
    }
    , function() {
        send(send(self, 'ensureReceiverAndArguments'), 'ifTrue_ifFalse_', [function() {
            send(send(self, 'receiver'), 'perform_withArguments_', [self.$selector, send(Array.classPrototype, 'withAll_', [self.$arguments])]);
        }
        , function() {
        }
        ]);
    }
    ]);
};
WeakMessageSend.prototype['value_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('value_');
    send(send(self, 'ensureReceiver'), 'ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'receiver'), 'perform_with_', [self.$selector, anObject]);
};
WeakMessageSend.prototype['value_value_'] = function(anObject1, anObject2)
{
    var self = this;
    var __context = {};
    console.log('value_value_');
    send(send(self, 'ensureReceiver'), 'ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'receiver'), 'perform_with_with_', [self.$selector, anObject1, anObject2]);
};
WeakMessageSend.prototype['value_value_value_'] = function(anObject1, anObject2, anObject3)
{
    var self = this;
    var __context = {};
    console.log('value_value_value_');
    send(send(self, 'ensureReceiver'), 'ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'receiver'), 'perform_with_with_with_', [self.$selector, anObject1, anObject2, anObject3]);
};
WeakMessageSend.prototype['valueWithArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('valueWithArguments_');
    send(send(self, 'ensureReceiverAndArguments'), 'ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'receiver'), 'perform_withArguments_', [self.$selector, send(self, 'collectArguments_', [anArray])]);
};
WeakMessageSend.prototype['valueWithEnoughArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('valueWithEnoughArguments_');
    var args = null
    send(send(self, 'ensureReceiverAndArguments'), 'ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    args = send(Array.classPrototype, 'new_', [send(self.$selector, 'numArgs')]);
    send(args, 'replaceFrom_to_with_startingAt_', [1, send(send(self.$arguments, 'size'), 'min_', [send(args, 'size')]), self.$arguments, 1]);
    if (__context.return) return __context.value;
    send(send(send(args, 'size'), '>', [send(self.$arguments, 'size')]), 'ifTrue_', [function() {
        send(args, 'replaceFrom_to_with_startingAt_', [send(send(self.$arguments, 'size'), '+', [1]), send(send(send(self.$arguments, 'size'), '+', [send(anArray, 'size')]), 'min_', [send(args, 'size')]), anArray, 1]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'receiver'), 'perform_withArguments_', [self.$selector, args]);
};
WeakMessageSend.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send((function () {var _aux = send(aStream, 'nextPutAll_', [send(send(self, 'class'), 'name')]);return _aux;})(), 'nextPut_', ['(']);
    send(self.$selector, 'printOn_', [aStream]);
    send(aStream, 'nextPutAll_', [' -> ']);
    send(send(self, 'receiver'), 'printOn_', [aStream]);
    send(aStream, 'nextPut_', [')']);
};
WeakMessageSend.prototype['isMessageSend'] = function()
{
    var self = this;
    console.log('isMessageSend');
    return true;
};
WeakMessageSend.prototype['isValid'] = function()
{
    var self = this;
    console.log('isValid');
    return send(send(self, 'isReceiverOrAnyArgumentGarbage'), 'not');
};
WeakMessageSend.prototype['collectArguments_'] = function(anArgArray)
{
    var self = this;
    console.log('collectArguments_');
    var staticArgs = null
    staticArgs = send(self, 'arguments');
    return send(send(send(anArgArray, 'size'), '=', [send(staticArgs, 'size')]), 'ifTrue_ifFalse_', [function() {
        anArgArray;
    }
    , function() {
        send(send(send(staticArgs, 'isEmpty'), 'ifTrue_ifFalse_', [function() {
            staticArgs = send(Array.classPrototype, 'new_', [send(self.$selector, 'numArgs')]);
        }
        , function() {
            send(staticArgs, 'copy');
        }
        ]), 'replaceFrom_to_with_startingAt_', [1, send(send(anArgArray, 'size'), 'min_', [send(staticArgs, 'size')]), anArgArray, 1]);
    }
    ]);
};
WeakMessageSend.prototype['ensureArguments'] = function()
{
    var self = this;
    var __context = {};
    console.log('ensureArguments');
    send(self.$arguments, 'ifNotNil_', [function() {
        send(self.$arguments, 'with_do_', [self.$shouldBeNil, function(arg, flag) {
            send(arg, 'ifNil_', [function() {
                send(flag, 'ifFalse_', [function() {
                    __context.value = false;
                    __context.return = true;
                    return __context.value;
                }
                ]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
WeakMessageSend.prototype['ensureReceiver'] = function()
{
    var self = this;
    console.log('ensureReceiver');
    return send(send(self, 'receiver'), 'notNil');
};
WeakMessageSend.prototype['ensureReceiverAndArguments'] = function()
{
    var self = this;
    var __context = {};
    console.log('ensureReceiverAndArguments');
    send(send(self, 'receiver'), 'ifNil_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self.$arguments, 'ifNotNil_', [function() {
        send(self.$arguments, 'with_do_', [self.$shouldBeNil, function(arg, flag) {
            send(arg, 'ifNil_', [function() {
                send(flag, 'ifFalse_', [function() {
                    __context.value = false;
                    __context.return = true;
                    return __context.value;
                }
                ]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
WeakMessageSend.prototype['isAnyArgumentGarbage'] = function()
{
    var self = this;
    var __context = {};
    console.log('isAnyArgumentGarbage');
    send(self.$arguments, 'ifNotNil_', [function() {
        send(self.$arguments, 'with_do_', [self.$shouldBeNil, function(arg, flag) {
            send(send(send(flag, 'not'), 'and_', [function() {
                send(arg, 'isNil');
                if (__context.return) return __context.value;
            }
            ]), 'ifTrue_', [function() {
                __context.value = true;
                __context.return = true;
                return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
WeakMessageSend.prototype['isReceiverGarbage'] = function()
{
    var self = this;
    console.log('isReceiverGarbage');
    return send(send(self, 'receiver'), 'isNil');
};
WeakMessageSend.prototype['isReceiverOrAnyArgumentGarbage'] = function()
{
    var self = this;
    console.log('isReceiverOrAnyArgumentGarbage');
    return send(send(self, 'isReceiverGarbage'), 'or_', [function() {
        send(self, 'isAnyArgumentGarbage');
    }
    ]);
};
WeakMessageSendClass.prototype['new'] = function()
{
    var self = this;
    console.log('new');
    return send(self, 'new_', [1]);
};
WeakMessageSendClass.prototype['receiver_selector_'] = function(anObject, aSymbol)
{
    var self = this;
    console.log('receiver_selector_');
    return send(self, 'receiver_selector_arguments_', [anObject, aSymbol, []]);
};
WeakMessageSendClass.prototype['receiver_selector_argument_'] = function(anObject, aSymbol, aParameter)
{
    var self = this;
    console.log('receiver_selector_argument_');
    return send(self, 'receiver_selector_arguments_', [anObject, aSymbol, send(Array.classPrototype, 'with_', [aParameter])]);
};
WeakMessageSendClass.prototype['receiver_selector_arguments_'] = function(anObject, aSymbol, anArray)
{
    var self = this;
    console.log('receiver_selector_arguments_');
    return send((function () {var _aux = send((function () {var _aux = send(send(self, 'new'), 'receiver_', [anObject]);return _aux;})(), 'selector_', [aSymbol]);return _aux;})(), 'arguments_', [anArray]);
};
function WeakActionSequenceClass()
{
}
function WeakActionSequence()
{
}
WeakActionSequence.prototype.__class = WeakActionSequenceClass.prototype;
WeakActionSequence.classPrototype = WeakActionSequenceClass.prototype;
WeakActionSequenceClass.prototype['_basicNew'] = function() { return new WeakActionSequence(); };
WeakActionSequence.prototype['asActionSequence'] = function()
{
    var self = this;
    console.log('asActionSequence');
    return self;
};
WeakActionSequence.prototype['asActionSequenceTrappingErrors'] = function()
{
    var self = this;
    console.log('asActionSequenceTrappingErrors');
    return send(WeakActionSequenceTrappingErrors.classPrototype, 'withAll_', [self]);
};
WeakActionSequence.prototype['asMinimalRepresentation'] = function()
{
    var self = this;
    var __context = {};
    console.log('asMinimalRepresentation');
    var valid = null
    valid = send(self, 'select_', [function(e) {
        send(e, 'isValid');
        if (__context.return) return __context.value;
    }
    ]);
    send(send(send(valid, 'size'), '=', [0]), 'ifTrue_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(valid, 'size'), '=', [1]), 'ifTrue_', [function() {
        __context.value = send(valid, 'first');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return valid;
};
WeakActionSequence.prototype['value'] = function()
{
    var self = this;
    var __context = {};
    console.log('value');
    var answer = null
    send(self, 'do_', [function(each) {
        send(send(each, 'isValid'), 'ifTrue_', [function() {
            answer = send(each, 'value');
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return answer;
};
WeakActionSequence.prototype['valueWithArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('valueWithArguments_');
    var answer = null
    send(self, 'do_', [function(each) {
        send(send(each, 'isValid'), 'ifTrue_', [function() {
            answer = send(each, 'valueWithArguments_', [anArray]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return answer;
};
WeakActionSequence.prototype['printOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('printOn_');
    send(send(send(self, 'size'), '<', [2]), 'ifTrue_', [function() {
        __context.value = sendSuper(self, WeakActionSequence, 'printOn_', [aStream]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, 'nextPutAll_', ['#(']);
    if (__context.return) return __context.value;
    send(self, 'do_separatedBy_', [function(each) {
        send(each, 'printOn_', [aStream]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(aStream, 'cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, 'nextPut_', [')']);
    if (__context.return) return __context.value;
};
function PointClass()
{
}
function Point()
{
}
Point.prototype.__class = PointClass.prototype;
Point.classPrototype = PointClass.prototype;
PointClass.prototype['_basicNew'] = function() { return new Point(); };
PointClass.prototype.__proto__ = ObjectClass.prototype;
Point.prototype.__proto__ = Object.prototype;
Point.prototype.$x = null;
Point.prototype.$y = null;
PointClass.__super = ObjectClass;
Point.__super = Object;
Point.prototype['directionToLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('directionToLineFrom_to_');
    return send(send(send(send(p2, 'x'), '-', [send(p1, 'x')]), '*', [send(send(self, 'y'), '-', [send(p1, 'y')])]), '-', [send(send(send(self, 'x'), '-', [send(p1, 'x')]), '*', [send(send(p2, 'y'), '-', [send(p1, 'y')])])]);
};
Point.prototype['angle'] = function()
{
    var self = this;
    console.log('angle');
    return send(send(self, 'y'), 'arcTan_', [send(self, 'x')]);
};
Point.prototype['angleWith_'] = function(aPoint)
{
    var self = this;
    console.log('angleWith_');
    var ar = null
    var ap = null
    ar = send(self, 'angle');
    ap = send(aPoint, 'angle');
    return send(send(ap, '>=', [ar]), 'ifTrue_ifFalse_', [function() {
        send(ap, '-', [ar]);
    }
    , function() {
        send(send(send(send(Float.classPrototype, 'pi'), '*', [2]), '-', [ar]), '+', [ap]);
    }
    ]);
};
Point.prototype['max'] = function()
{
    var self = this;
    console.log('max');
    return send(send(self, 'x'), 'max_', [send(self, 'y')]);
};
Point.prototype['min'] = function()
{
    var self = this;
    console.log('min');
    return send(send(self, 'x'), 'min_', [send(self, 'y')]);
};
Point.prototype['reflectedAbout_'] = function(aPoint)
{
    var self = this;
    console.log('reflectedAbout_');
    return send(send(send(self, '-', [aPoint]), 'negated'), '+', [aPoint]);
};
Point.prototype['x'] = function()
{
    var self = this;
    console.log('x');
    return self.$x;
};
Point.prototype['y'] = function()
{
    var self = this;
    console.log('y');
    return self.$y;
};
Point.prototype['*'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('*');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '*', [send(arg, 'x')]), '@', [send(self.$y, '*', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '*']);
};
Point.prototype['+'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('+');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '+', [send(arg, 'x')]), '@', [send(self.$y, '+', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '+']);
};
Point.prototype['-'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('-');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '-', [send(arg, 'x')]), '@', [send(self.$y, '-', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '-']);
};
Point.prototype['/'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('/');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '/', [send(arg, 'x')]), '@', [send(self.$y, '/', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '/']);
};
Point.prototype['//'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('//');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '//', [send(arg, 'x')]), '@', [send(self.$y, '//', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '//']);
};
Point.prototype['\\'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('\\');
    send(send(arg, 'isPoint'), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, '\\', [send(arg, 'x')]), '@', [send(self.$y, '\\', [send(arg, 'y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, 'adaptToPoint_andSend_', [self, '\\']);
};
Point.prototype['abs'] = function()
{
    var self = this;
    console.log('abs');
    return send(send(self.$x, 'abs'), '@', [send(self.$y, 'abs')]);
};
Point.prototype['reciprocal'] = function()
{
    var self = this;
    console.log('reciprocal');
    return send(send(self.$x, 'reciprocal'), '@', [send(self.$y, 'reciprocal')]);
};
Point.prototype['<'] = function(aPoint)
{
    var self = this;
    console.log('<');
    return send(send(self.$x, '<', [send(aPoint, 'x')]), 'and_', [function() {
        send(self.$y, '<', [send(aPoint, 'y')]);
    }
    ]);
};
Point.prototype['<='] = function(aPoint)
{
    var self = this;
    console.log('<=');
    return send(send(self.$x, '<=', [send(aPoint, 'x')]), 'and_', [function() {
        send(self.$y, '<=', [send(aPoint, 'y')]);
    }
    ]);
};
Point.prototype['='] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('=');
    send(send(send(self, 'species'), '=', [send(aPoint, 'species')]), 'ifTrue_ifFalse_', [function() {
        __context.value = send(send(self.$x, '=', [send(aPoint, 'x')]), 'and_', [function() {
            send(self.$y, '=', [send(aPoint, 'y')]);
            if (__context.return) return __context.value;
        }
        ]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['>'] = function(aPoint)
{
    var self = this;
    console.log('>');
    return send(send(self.$x, '>', [send(aPoint, 'x')]), 'and_', [function() {
        send(self.$y, '>', [send(aPoint, 'y')]);
    }
    ]);
};
Point.prototype['>='] = function(aPoint)
{
    var self = this;
    console.log('>=');
    return send(send(self.$x, '>=', [send(aPoint, 'x')]), 'and_', [function() {
        send(self.$y, '>=', [send(aPoint, 'y')]);
    }
    ]);
};
Point.prototype['closeTo_'] = function(aPoint)
{
    var self = this;
    console.log('closeTo_');
    return send(send(self.$x, 'closeTo_', [send(aPoint, 'x')]), 'and_', [function() {
        send(self.$y, 'closeTo_', [send(aPoint, 'y')]);
    }
    ]);
};
Point.prototype['hash'] = function()
{
    var self = this;
    console.log('hash');
    return send(send(send(send(self.$x, 'hash'), 'hashMultiply'), '+', [send(self.$y, 'hash')]), 'hashMultiply');
};
Point.prototype['max_'] = function(aPoint)
{
    var self = this;
    console.log('max_');
    return send(send(self.$x, 'max_', [send(aPoint, 'x')]), '@', [send(self.$y, 'max_', [send(aPoint, 'y')])]);
};
Point.prototype['min_'] = function(aPoint)
{
    var self = this;
    console.log('min_');
    return send(send(self.$x, 'min_', [send(aPoint, 'x')]), '@', [send(self.$y, 'min_', [send(aPoint, 'y')])]);
};
Point.prototype['min_max_'] = function(aMin, aMax)
{
    var self = this;
    console.log('min_max_');
    return send(send(self, 'min_', [aMin]), 'max_', [aMax]);
};
Point.prototype['adaptToCollection_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToCollection_andSend_');
    return send(rcvr, 'collect_', [function(element) {
        send(element, 'perform_with_', [selector, self]);
    }
    ]);
};
Point.prototype['adaptToNumber_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToNumber_andSend_');
    return send(send(rcvr, '@', [rcvr]), 'perform_with_', [selector, self]);
};
Point.prototype['adaptToString_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('adaptToString_andSend_');
    return send(send(rcvr, 'asNumber'), 'perform_with_', [selector, self]);
};
Point.prototype['asFloatPoint'] = function()
{
    var self = this;
    console.log('asFloatPoint');
    return send(send(self.$x, 'asFloat'), '@', [send(self.$y, 'asFloat')]);
};
Point.prototype['asIntegerPoint'] = function()
{
    var self = this;
    console.log('asIntegerPoint');
    return send(send(self.$x, 'asInteger'), '@', [send(self.$y, 'asInteger')]);
};
Point.prototype['asNonFractionalPoint'] = function()
{
    var self = this;
    var __context = {};
    console.log('asNonFractionalPoint');
    send(send(send(self.$x, 'isFraction'), 'or_', [function() {
        send(self.$y, 'isFraction');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = send(send(self.$x, 'asFloat'), '@', [send(self.$y, 'asFloat')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['asPoint'] = function()
{
    var self = this;
    console.log('asPoint');
    return self;
};
Point.prototype['corner_'] = function(aPoint)
{
    var self = this;
    console.log('corner_');
    return send(Rectangle.classPrototype, 'origin_corner_', [self, aPoint]);
};
Point.prototype['extent_'] = function(aPoint)
{
    var self = this;
    console.log('extent_');
    return send(Rectangle.classPrototype, 'origin_extent_', [self, aPoint]);
};
Point.prototype['isPoint'] = function()
{
    var self = this;
    console.log('isPoint');
    return true;
};
Point.prototype['rect_'] = function(aPoint)
{
    var self = this;
    console.log('rect_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self, 'min_', [aPoint]), send(self, 'max_', [aPoint])]);
};
Point.prototype['deepCopy'] = function()
{
    var self = this;
    console.log('deepCopy');
    return send(send(self.$x, 'deepCopy'), '@', [send(self.$y, 'deepCopy')]);
};
Point.prototype['veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('veryDeepCopyWith_');
};
Point.prototype['guarded'] = function()
{
    var self = this;
    console.log('guarded');
    send(self, 'max_', [send(1, '@', [1])]);
};
Point.prototype['scaleTo_'] = function(anExtent)
{
    var self = this;
    var __context = {};
    console.log('scaleTo_');
    var factor = null
    var sX = null
    var sY = null
    factor = send(3, 'reciprocal');
    sX = send(send(anExtent, 'x'), '/', [send(send(self, 'x'), 'asFloat')]);
    sY = send(send(anExtent, 'y'), '/', [send(send(self, 'y'), 'asFloat')]);
    send(send(sX, '=', [sY]), 'ifTrue_', [function() {
        __context.value = send(sX, '@', [sY]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(sX, '<', [sY]), 'ifTrue_ifFalse_', [function() {
        send(sX, '@', [send(sX, 'max_', [send(sY, '*', [factor])])]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(sY, 'max_', [send(sX, '*', [factor])]), '@', [sY]);
        if (__context.return) return __context.value;
    }
    ]);
};
Point.prototype['isInsideCircle_with_with_'] = function(a, b, c)
{
    var self = this;
    console.log('isInsideCircle_with_with_');
    return send(send(send(send(send(send(a, 'dotProduct_', [a]), '*', [send(b, 'triangleArea_with_', [c, self])]), '-', [send(send(b, 'dotProduct_', [b]), '*', [send(a, 'triangleArea_with_', [c, self])])]), '+', [send(send(c, 'dotProduct_', [c]), '*', [send(a, 'triangleArea_with_', [b, self])])]), '-', [send(send(self, 'dotProduct_', [self]), '*', [send(a, 'triangleArea_with_', [b, c])])]), '>', [0]);
};
Point.prototype['sideOf_'] = function(otherPoint)
{
    var self = this;
    console.log('sideOf_');
    var side = null
    side = send(send(self, 'crossProduct_', [otherPoint]), 'sign');
    return send(['right', 'center', 'left'], 'at_', [send(side, '+', [2])]);
};
Point.prototype['to_intersects_to_'] = function(end1, start2, end2)
{
    var self = this;
    var __context = {};
    console.log('to_intersects_to_');
    var start1 = null
    var sideStart = null
    var sideEnd = null
    start1 = self;
    send(send(send(send(send(start1, '=', [start2]), 'or_', [function() {
        send(end1, '=', [end2]);
        if (__context.return) return __context.value;
    }
    ]), 'or_', [function() {
        send(start1, '=', [end2]);
        if (__context.return) return __context.value;
    }
    ]), 'or_', [function() {
        send(start2, '=', [end1]);
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    sideStart = send(start1, 'to_sideOf_', [end1, start2]);
    sideEnd = send(start1, 'to_sideOf_', [end1, end2]);
    send(send(sideStart, '=', [sideEnd]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    sideStart = send(start2, 'to_sideOf_', [end2, start1]);
    sideEnd = send(start2, 'to_sideOf_', [end2, end1]);
    send(send(sideStart, '=', [sideEnd]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Point.prototype['to_sideOf_'] = function(end, otherPoint)
{
    var self = this;
    console.log('to_sideOf_');
    return send(send(end, '-', [self]), 'sideOf_', [send(otherPoint, '-', [self])]);
};
Point.prototype['triangleArea_with_'] = function(b, c)
{
    var self = this;
    console.log('triangleArea_with_');
    return send(send(send(send(b, 'x'), '-', [send(self, 'x')]), '*', [send(send(c, 'y'), '-', [send(self, 'y')])]), '-', [send(send(send(b, 'y'), '-', [send(self, 'y')]), '*', [send(send(c, 'x'), '-', [send(self, 'x')])])]);
};
Point.prototype['interpolateTo_at_'] = function(end, amountDone)
{
    var self = this;
    console.log('interpolateTo_at_');
    return send(self, '+', [send(send(end, '-', [self]), '*', [amountDone])]);
};
Point.prototype['bearingToPoint_'] = function(anotherPoint)
{
    var self = this;
    var __context = {};
    console.log('bearingToPoint_');
    var deltaX = null
    var deltaY = null
    deltaX = send(send(anotherPoint, 'x'), '-', [self.$x]);
    deltaY = send(send(anotherPoint, 'y'), '-', [self.$y]);
    send(send(send(deltaX, 'abs'), '<', [0.001]), 'ifTrue_', [function() {
        __context.value = send(send(deltaY, '>', [0]), 'ifTrue_ifFalse_', [function() {
            180;
        }
        , function() {
            0;
        }
        ]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(send(send(deltaX, '>=', [0]), 'ifTrue_ifFalse_', [function() {
        90;
    }
    , function() {
        270;
    }
    ]), '-', [send(send(send(send(deltaY, '/', [deltaX]), 'arcTan'), 'negated'), 'radiansToDegrees')]), 'rounded');
};
Point.prototype['crossProduct_'] = function(aPoint)
{
    var self = this;
    console.log('crossProduct_');
    return send(send(self.$x, '*', [send(aPoint, 'y')]), '-', [send(self.$y, '*', [send(aPoint, 'x')])]);
};
Point.prototype['dist_'] = function(aPoint)
{
    var self = this;
    console.log('dist_');
    var dx = null
    var dy = null
    dx = send(send(aPoint, 'x'), '-', [self.$x]);
    dy = send(send(aPoint, 'y'), '-', [self.$y]);
    return send(send(send(dx, '*', [dx]), '+', [send(dy, '*', [dy])]), 'sqrt');
};
Point.prototype['dotProduct_'] = function(aPoint)
{
    var self = this;
    console.log('dotProduct_');
    return send(send(self.$x, '*', [send(aPoint, 'x')]), '+', [send(self.$y, '*', [send(aPoint, 'y')])]);
};
Point.prototype['eightNeighbors'] = function()
{
    var self = this;
    console.log('eightNeighbors');
    return [send(self, '+', [send(1, '@', [0])]), send(self, '+', [send(1, '@', [1])]), send(self, '+', [send(0, '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [0])]), send(self, '+', [send(send(1, '-'), '@', [send(1, '-')])]), send(self, '+', [send(0, '@', [send(1, '-')])]), send(self, '+', [send(1, '@', [send(1, '-')])])];
};
Point.prototype['flipBy_centerAt_'] = function(direction, c)
{
    var self = this;
    var __context = {};
    console.log('flipBy_centerAt_');
    send(send(direction, '==', ['vertical']), 'ifTrue_', [function() {
        __context.value = send(self.$x, '@', [send(send(send(c, 'y'), '*', [2]), '-', [self.$y])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['horizontal']), 'ifTrue_', [function() {
        __context.value = send(send(send(send(c, 'x'), '*', [2]), '-', [self.$x]), '@', [self.$y]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'error_', ['unrecognizable direction']);
    if (__context.return) return __context.value;
};
Point.prototype['fourDirections'] = function()
{
    var self = this;
    console.log('fourDirections');
    return send(Array.classPrototype, 'with_with_with_with_', [send(self, 'leftRotated'), send(self, 'negated'), send(self, 'rightRotated'), self]);
};
Point.prototype['fourNeighbors'] = function()
{
    var self = this;
    console.log('fourNeighbors');
    return send(Array.classPrototype, 'with_with_with_with_', [send(self, '+', [send(1, '@', [0])]), send(self, '+', [send(0, '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [0])]), send(self, '+', [send(0, '@', [send(1, '-')])])]);
};
Point.prototype['grid_'] = function(aPoint)
{
    var self = this;
    console.log('grid_');
    var newX = null
    var newY = null
    newX = send(send(self.$x, '+', [send(send(aPoint, 'x'), '//', [2])]), 'truncateTo_', [send(aPoint, 'x')]);
    newY = send(send(self.$y, '+', [send(send(aPoint, 'y'), '//', [2])]), 'truncateTo_', [send(aPoint, 'y')]);
    return send(newX, '@', [newY]);
};
Point.prototype['insideTriangle_with_with_'] = function(p1, p2, p3)
{
    var self = this;
    var __context = {};
    console.log('insideTriangle_with_with_');
    var p0 = null
    var b0 = null
    var b1 = null
    var b2 = null
    var b3 = null
    p0 = self;
    b0 = send(send(send(send(p2, 'x'), '-', [send(p1, 'x')]), '*', [send(send(p3, 'y'), '-', [send(p1, 'y')])]), '-', [send(send(send(p3, 'x'), '-', [send(p1, 'x')]), '*', [send(send(p2, 'y'), '-', [send(p1, 'y')])])]);
    send(send(b0, 'isZero'), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    b0 = send(1, '/', [b0]);
    b1 = send(send(send(send(send(p2, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p3, 'y'), '-', [send(p0, 'y')])]), '-', [send(send(send(p3, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p2, 'y'), '-', [send(p0, 'y')])])]), '*', [b0]);
    b2 = send(send(send(send(send(p3, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p1, 'y'), '-', [send(p0, 'y')])]), '-', [send(send(send(p1, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p3, 'y'), '-', [send(p0, 'y')])])]), '*', [b0]);
    b3 = send(send(send(send(send(p1, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p2, 'y'), '-', [send(p0, 'y')])]), '-', [send(send(send(p2, 'x'), '-', [send(p0, 'x')]), '*', [send(send(p1, 'y'), '-', [send(p0, 'y')])])]), '*', [b0]);
    send(send(b1, '<', [0]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(b2, '<', [0]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(b3, '<', [0]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Point.prototype['leftRotated'] = function()
{
    var self = this;
    console.log('leftRotated');
    return send(self.$y, '@', [send(self.$x, 'negated')]);
};
Point.prototype['nearestPointAlongLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    var __context = {};
    console.log('nearestPointAlongLineFrom_to_');
    var x21 = null
    var y21 = null
    var t = null
    var x1 = null
    var y1 = null
    send(send(send(p1, 'x'), '=', [send(p2, 'x')]), 'ifTrue_', [function() {
        __context.value = send(send(p1, 'x'), '@', [self.$y]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(p1, 'y'), '=', [send(p2, 'y')]), 'ifTrue_', [function() {
        __context.value = send(self.$x, '@', [send(p1, 'y')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    x1 = send(send(p1, 'x'), 'asFloat');
    y1 = send(send(p1, 'y'), 'asFloat');
    x21 = send(send(send(p2, 'x'), 'asFloat'), '-', [x1]);
    y21 = send(send(send(p2, 'y'), 'asFloat'), '-', [y1]);
    t = send(send(send(send(send(self.$y, 'asFloat'), '-', [y1]), '/', [x21]), '+', [send(send(send(self.$x, 'asFloat'), '-', [x1]), '/', [y21])]), '/', [send(send(x21, '/', [y21]), '+', [send(y21, '/', [x21])])]);
    return send(send(x1, '+', [send(t, '*', [x21])]), '@', [send(y1, '+', [send(t, '*', [y21])])]);
};
Point.prototype['nearestPointOnLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('nearestPointOnLineFrom_to_');
    return send(send(self, 'nearestPointAlongLineFrom_to_', [p1, p2]), 'adhereTo_', [send(p1, 'rect_', [p2])]);
};
Point.prototype['normal'] = function()
{
    var self = this;
    var __context = {};
    console.log('normal');
    var n = null
    var d = null
    n = send(send(self.$y, 'negated'), '@', [self.$x]);
    send(send(d = send(send(send(n, 'x'), '*', [send(n, 'x')]), '+', [send(send(n, 'y'), '*', [send(n, 'y')])]), '=', [0]), 'ifTrue_', [function() {
        __context.value = send(send(1, '-'), '@', [0]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(n, '/', [send(d, 'sqrt')]);
};
Point.prototype['normalized'] = function()
{
    var self = this;
    console.log('normalized');
    var r = null
    r = send(send(send(self.$x, '*', [self.$x]), '+', [send(self.$y, '*', [self.$y])]), 'sqrt');
    return send(send(self.$x, '/', [r]), '@', [send(self.$y, '/', [r])]);
};
Point.prototype['octantOf_'] = function(otherPoint)
{
    var self = this;
    var __context = {};
    console.log('octantOf_');
    var quad = null
    var moreHoriz = null
    send(send(send(self.$x, '=', [send(otherPoint, 'x')]), 'and_', [function() {
        send(self.$y, '>', [send(otherPoint, 'y')]);
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = 6;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self.$y, '=', [send(otherPoint, 'y')]), 'and_', [function() {
        send(self.$x, '<', [send(otherPoint, 'x')]);
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = 8;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    quad = send(self, 'quadrantOf_', [otherPoint]);
    moreHoriz = send(send(send(self.$x, '-', [send(otherPoint, 'x')]), 'abs'), '>=', [send(send(self.$y, '-', [send(otherPoint, 'y')]), 'abs')]);
    send(send(send(quad, 'even'), 'eqv_', [moreHoriz]), 'ifTrue_ifFalse_', [function() {
        __context.value = send(quad, '*', [2]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(send(quad, '*', [2]), '-', [1]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['onLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('onLineFrom_to_');
    return send(self, 'onLineFrom_to_within_', [p1, p2, 2]);
};
Point.prototype['onLineFrom_to_within_'] = function(p1, p2, epsilon)
{
    var self = this;
    var __context = {};
    console.log('onLineFrom_to_within_');
    send(send(send(p1, 'x'), '<', [send(p2, 'x')]), 'ifTrue_ifFalse_', [function() {
        send(send(send(self.$x, '<', [send(send(p1, 'x'), '-', [epsilon])]), 'or_', [function() {
            send(self.$x, '>', [send(send(p2, 'x'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), 'ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(send(self.$x, '<', [send(send(p2, 'x'), '-', [epsilon])]), 'or_', [function() {
            send(self.$x, '>', [send(send(p1, 'x'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), 'ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(p1, 'y'), '<', [send(p2, 'y')]), 'ifTrue_ifFalse_', [function() {
        send(send(send(self.$y, '<', [send(send(p1, 'y'), '-', [epsilon])]), 'or_', [function() {
            send(self.$y, '>', [send(send(p2, 'y'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), 'ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(send(self.$y, '<', [send(send(p2, 'y'), '-', [epsilon])]), 'or_', [function() {
            send(self.$y, '>', [send(send(p1, 'y'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), 'ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, 'dist_', [send(self, 'nearestPointAlongLineFrom_to_', [p1, p2])]), '<=', [epsilon]);
};
Point.prototype['quadrantOf_'] = function(otherPoint)
{
    var self = this;
    console.log('quadrantOf_');
    return send(send(self.$x, '<=', [send(otherPoint, 'x')]), 'ifTrue_ifFalse_', [function() {
        send(send(self.$y, '<', [send(otherPoint, 'y')]), 'ifTrue_ifFalse_', [function() {
            1;
        }
        , function() {
            4;
        }
        ]);
    }
    , function() {
        send(send(self.$y, '<=', [send(otherPoint, 'y')]), 'ifTrue_ifFalse_', [function() {
            2;
        }
        , function() {
            3;
        }
        ]);
    }
    ]);
};
Point.prototype['rightRotated'] = function()
{
    var self = this;
    console.log('rightRotated');
    return send(send(self.$y, 'negated'), '@', [self.$x]);
};
Point.prototype['rotateBy_centerAt_'] = function(direction, c)
{
    var self = this;
    var __context = {};
    console.log('rotateBy_centerAt_');
    var offset = null
    offset = send(self, '-', [c]);
    send(send(direction, '==', ['right']), 'ifTrue_', [function() {
        __context.value = send(send(send(send(offset, 'y'), 'negated'), '@', [send(offset, 'x')]), '+', [c]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['left']), 'ifTrue_', [function() {
        __context.value = send(send(send(offset, 'y'), '@', [send(send(offset, 'x'), 'negated')]), '+', [c]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['pi']), 'ifTrue_', [function() {
        __context.value = send(c, '-', [offset]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, 'error_', ['unrecognizable direction']);
    if (__context.return) return __context.value;
};
Point.prototype['sign'] = function()
{
    var self = this;
    console.log('sign');
    return send(send(self.$x, 'sign'), '@', [send(self.$y, 'sign')]);
};
Point.prototype['sortsBefore_'] = function(otherPoint)
{
    var self = this;
    console.log('sortsBefore_');
    return send(send(self.$y, '=', [send(otherPoint, 'y')]), 'ifTrue_ifFalse_', [function() {
        send(self.$x, '<=', [send(otherPoint, 'x')]);
    }
    , function() {
        send(self.$y, '<=', [send(otherPoint, 'y')]);
    }
    ]);
};
Point.prototype['squaredDistanceTo_'] = function(aPoint)
{
    var self = this;
    console.log('squaredDistanceTo_');
    var delta = null
    delta = send(aPoint, '-', [self]);
    return send(delta, 'dotProduct_', [delta]);
};
Point.prototype['transposed'] = function()
{
    var self = this;
    console.log('transposed');
    return send(self.$y, '@', [self.$x]);
};
Point.prototype['degrees'] = function()
{
    var self = this;
    var __context = {};
    console.log('degrees');
    var tan = null
    var theta = null
    send(send(self.$x, '=', [0]), 'ifTrue_ifFalse_', [function() {
        send(send(self.$y, '>=', [0]), 'ifTrue_ifFalse_', [function() {
            __context.value = 90;
            __context.return = true;
            return __context.value;
        }
        , function() {
            __context.value = 270;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        tan = send(send(self.$y, 'asFloat'), '/', [send(self.$x, 'asFloat')]);
        theta = send(tan, 'arcTan');
        send(send(self.$x, '>=', [0]), 'ifTrue_ifFalse_', [function() {
            send(send(self.$y, '>=', [0]), 'ifTrue_ifFalse_', [function() {
                __context.value = send(theta, 'radiansToDegrees');
                __context.return = true;
                return __context.value;
            }
            , function() {
                __context.value = send(360, '+', [send(theta, 'radiansToDegrees')]);
                __context.return = true;
                return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            __context.value = send(180, '+', [send(theta, 'radiansToDegrees')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['r'] = function()
{
    var self = this;
    console.log('r');
    return send(send(self, 'dotProduct_', [self]), 'sqrt');
};
Point.prototype['theta'] = function()
{
    var self = this;
    var __context = {};
    console.log('theta');
    var tan = null
    var theta = null
    send(send(self.$x, '=', [0]), 'ifTrue_ifFalse_', [function() {
        send(send(self.$y, '>=', [0]), 'ifTrue_ifFalse_', [function() {
            __context.value = 1.5707963267949;
            __context.return = true;
            return __context.value;
        }
        , function() {
            __context.value = 4.71238898038469;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        tan = send(send(self.$y, 'asFloat'), '/', [send(self.$x, 'asFloat')]);
        theta = send(tan, 'arcTan');
        send(send(self.$x, '>=', [0]), 'ifTrue_ifFalse_', [function() {
            send(send(self.$y, '>=', [0]), 'ifTrue_ifFalse_', [function() {
                __context.value = theta;
                __context.return = true;
                return __context.value;
            }
            , function() {
                __context.value = send(6.28318530717959, '+', [theta]);
                __context.return = true;
                return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            __context.value = send(3.14159265358979, '+', [theta]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['printOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('printOn_');
    send(self.$x, 'printOn_', [aStream]);
    if (__context.return) return __context.value;
    send(aStream, 'nextPut_', ['@']);
    if (__context.return) return __context.value;
    send(send(send(self.$y, 'notNil'), 'and_', [function() {
        send(self.$y, 'negative');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        send(aStream, 'space');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self.$y, 'printOn_', [aStream]);
    if (__context.return) return __context.value;
};
Point.prototype['storeOn_'] = function(aStream)
{
    var self = this;
    console.log('storeOn_');
    send(aStream, 'nextPut_', ['(']);
    send(self, 'printOn_', [aStream]);
    send(aStream, 'nextPut_', [')']);
};
Point.prototype['isSelfEvaluating'] = function()
{
    var self = this;
    console.log('isSelfEvaluating');
    return send(send(self, 'class'), '==', [Point]);
};
Point.prototype['isZero'] = function()
{
    var self = this;
    console.log('isZero');
    return send(send(self.$x, 'isZero'), 'and_', [function() {
        send(self.$y, 'isZero');
    }
    ]);
};
Point.prototype['adhereTo_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('adhereTo_');
    send(send(aRectangle, 'containsPoint_', [self]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(send(self.$x, 'max_', [send(aRectangle, 'left')]), 'min_', [send(aRectangle, 'right')]), '@', [send(send(self.$y, 'max_', [send(aRectangle, 'top')]), 'min_', [send(aRectangle, 'bottom')])]);
};
Point.prototype['negated'] = function()
{
    var self = this;
    console.log('negated');
    return send(send(0, '-', [self.$x]), '@', [send(0, '-', [self.$y])]);
};
Point.prototype['rotateBy_about_'] = function(angle, center)
{
    var self = this;
    console.log('rotateBy_about_');
    var p = null
    var r = null
    var theta = null
    p = send(self, '-', [center]);
    r = send(p, 'r');
    theta = send(send(angle, 'asFloat'), '-', [send(p, 'theta')]);
    return send(send(send(send(center, 'x'), 'asFloat'), '+', [send(r, '*', [send(theta, 'cos')])]), '@', [send(send(send(center, 'y'), 'asFloat'), '-', [send(r, '*', [send(theta, 'sin')])])]);
};
Point.prototype['scaleBy_'] = function(factor)
{
    var self = this;
    console.log('scaleBy_');
    return send(send(send(factor, 'x'), '*', [self.$x]), '@', [send(send(factor, 'y'), '*', [self.$y])]);
};
Point.prototype['scaleFrom_to_'] = function(rect1, rect2)
{
    var self = this;
    console.log('scaleFrom_to_');
    return send(send(rect2, 'topLeft'), '+', [send(send(send(send(self.$x, '-', [send(rect1, 'left')]), '*', [send(rect2, 'width')]), '//', [send(rect1, 'width')]), '@', [send(send(send(self.$y, '-', [send(rect1, 'top')]), '*', [send(rect2, 'height')]), '//', [send(rect1, 'height')])])]);
};
Point.prototype['translateBy_'] = function(delta)
{
    var self = this;
    console.log('translateBy_');
    return send(send(send(delta, 'x'), '+', [self.$x]), '@', [send(send(delta, 'y'), '+', [self.$y])]);
};
Point.prototype['rounded'] = function()
{
    var self = this;
    var __context = {};
    console.log('rounded');
    send(send(send(self.$x, 'isInteger'), 'and_', [function() {
        send(self.$y, 'isInteger');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$x, 'rounded'), '@', [send(self.$y, 'rounded')]);
};
Point.prototype['roundTo_'] = function(grid)
{
    var self = this;
    console.log('roundTo_');
    var gridPoint = null
    gridPoint = send(grid, 'asPoint');
    return send(send(self.$x, 'roundTo_', [send(gridPoint, 'x')]), '@', [send(self.$y, 'roundTo_', [send(gridPoint, 'y')])]);
};
Point.prototype['truncateTo_'] = function(grid)
{
    var self = this;
    console.log('truncateTo_');
    var gridPoint = null
    gridPoint = send(grid, 'asPoint');
    return send(send(self.$x, 'truncateTo_', [send(gridPoint, 'x')]), '@', [send(self.$y, 'truncateTo_', [send(gridPoint, 'y')])]);
};
Point.prototype['truncated'] = function()
{
    var self = this;
    var __context = {};
    console.log('truncated');
    send(send(send(self.$x, 'isInteger'), 'and_', [function() {
        send(self.$y, 'isInteger');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$x, 'truncated'), '@', [send(self.$y, 'truncated')]);
};
Point.prototype['ceiling'] = function()
{
    var self = this;
    var __context = {};
    console.log('ceiling');
    send(send(send(self.$x, 'isInteger'), 'and_', [function() {
        send(self.$y, 'isInteger');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$x, 'ceiling'), '@', [send(self.$y, 'ceiling')]);
};
Point.prototype['floor'] = function()
{
    var self = this;
    var __context = {};
    console.log('floor');
    send(send(send(self.$x, 'isInteger'), 'and_', [function() {
        send(self.$y, 'isInteger');
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$x, 'floor'), '@', [send(self.$y, 'floor')]);
};
Point.prototype['isIntegerPoint'] = function()
{
    var self = this;
    console.log('isIntegerPoint');
    return send(send(self.$x, 'isInteger'), 'and_', [function() {
        send(self.$y, 'isInteger');
    }
    ]);
};
Point.prototype['roundDownTo_'] = function(grid)
{
    var self = this;
    console.log('roundDownTo_');
    var gridPoint = null
    gridPoint = send(grid, 'asPoint');
    return send(send(self.$x, 'roundDownTo_', [send(gridPoint, 'x')]), '@', [send(self.$y, 'roundDownTo_', [send(gridPoint, 'y')])]);
};
Point.prototype['roundUpTo_'] = function(grid)
{
    var self = this;
    console.log('roundUpTo_');
    var gridPoint = null
    gridPoint = send(grid, 'asPoint');
    return send(send(self.$x, 'roundUpTo_', [send(gridPoint, 'x')]), '@', [send(self.$y, 'roundUpTo_', [send(gridPoint, 'y')])]);
};
Point.prototype['bitShiftPoint_'] = function(bits)
{
    var self = this;
    console.log('bitShiftPoint_');
    self.$x = send(self.$x, 'bitShift_', [bits]);
    self.$y = send(self.$y, 'bitShift_', [bits]);
};
Point.prototype['setR_degrees_'] = function(rho, degrees)
{
    var self = this;
    console.log('setR_degrees_');
    var radians = null
    radians = send(send(degrees, 'asFloat'), 'degreesToRadians');
    self.$x = send(send(rho, 'asFloat'), '*', [send(radians, 'cos')]);
    self.$y = send(send(rho, 'asFloat'), '*', [send(radians, 'sin')]);
};
Point.prototype['setX_setY_'] = function(xValue, yValue)
{
    var self = this;
    console.log('setX_setY_');
    self.$x = xValue;
    self.$y = yValue;
};
PointClass.prototype['settingInputWidgetForNode_'] = function(aSettingNode)
{
    var self = this;
    console.log('settingInputWidgetForNode_');
    return send(aSettingNode, 'inputWidgetForPoint');
};
PointClass.prototype['fromUser'] = function()
{
    var self = this;
    console.log('fromUser');
    send(Sensor.classPrototype, 'waitNoButton');
    send(send(Cursor.classPrototype, 'crossHair'), 'show');
    send(Sensor.classPrototype, 'waitButton');
    send(send(Cursor.classPrototype, 'normal'), 'show');
    return send(Sensor.classPrototype, 'cursorPoint');
};
PointClass.prototype['fromUserWithCursor_'] = function(aCursor)
{
    var self = this;
    var __context = {};
    console.log('fromUserWithCursor_');
    send(Sensor.classPrototype, 'waitNoButton');
    if (__context.return) return __context.value;
    send(aCursor, 'showWhile_', [function() {
        send(Sensor.classPrototype, 'waitButton');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Sensor.classPrototype, 'cursorPoint');
};
PointClass.prototype['r_degrees_'] = function(rho, degrees)
{
    var self = this;
    console.log('r_degrees_');
    return send(send(self, 'basicNew'), 'setR_degrees_', [rho, degrees]);
};
PointClass.prototype['x_y_'] = function(xInteger, yInteger)
{
    var self = this;
    console.log('x_y_');
    return send(send(self, 'basicNew'), 'setX_setY_', [xInteger, yInteger]);
};
function RectangleClass()
{
}
function Rectangle()
{
}
Rectangle.prototype.__class = RectangleClass.prototype;
Rectangle.classPrototype = RectangleClass.prototype;
RectangleClass.prototype['_basicNew'] = function() { return new Rectangle(); };
RectangleClass.prototype.__proto__ = ObjectClass.prototype;
Rectangle.prototype.__proto__ = Object.prototype;
Rectangle.prototype.$origin = null;
Rectangle.prototype.$corner = null;
RectangleClass.__super = ObjectClass;
Rectangle.__super = Object;
Rectangle.prototype['aboveCenter'] = function()
{
    var self = this;
    console.log('aboveCenter');
    return send(send(send(self, 'topLeft'), '+', [send(self, 'bottomRight')]), '//', [send(2, '@', [3])]);
};
Rectangle.prototype['area'] = function()
{
    var self = this;
    var __context = {};
    console.log('area');
    var w = null
    send(send(w = send(self, 'width'), '<=', [0]), 'ifTrue_', [function() {
        __context.value = 0;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(w, '*', [send(self, 'height')]), 'max_', [0]);
};
Rectangle.prototype['bottom'] = function()
{
    var self = this;
    console.log('bottom');
    return send(self.$corner, 'y');
};
Rectangle.prototype['bottom_'] = function(aNumber)
{
    var self = this;
    console.log('bottom_');
    return send(self.$origin, 'corner_', [send(send(self.$corner, 'x'), '@', [aNumber])]);
};
Rectangle.prototype['bottomCenter'] = function()
{
    var self = this;
    console.log('bottomCenter');
    return send(send(send(self, 'center'), 'x'), '@', [send(self, 'bottom')]);
};
Rectangle.prototype['bottomLeft'] = function()
{
    var self = this;
    console.log('bottomLeft');
    return send(send(self.$origin, 'x'), '@', [send(self.$corner, 'y')]);
};
Rectangle.prototype['bottomRight'] = function()
{
    var self = this;
    console.log('bottomRight');
    return self.$corner;
};
Rectangle.prototype['boundingBox'] = function()
{
    var self = this;
    console.log('boundingBox');
    return self;
};
Rectangle.prototype['center'] = function()
{
    var self = this;
    console.log('center');
    return send(send(send(self, 'topLeft'), '+', [send(self, 'bottomRight')]), '//', [2]);
};
Rectangle.prototype['corner'] = function()
{
    var self = this;
    console.log('corner');
    return self.$corner;
};
Rectangle.prototype['corners'] = function()
{
    var self = this;
    console.log('corners');
    return send(Array.classPrototype, 'with_with_with_with_', [send(self, 'topLeft'), send(self, 'bottomLeft'), send(self, 'bottomRight'), send(self, 'topRight')]);
};
Rectangle.prototype['extent'] = function()
{
    var self = this;
    console.log('extent');
    return send(self.$corner, '-', [self.$origin]);
};
Rectangle.prototype['height'] = function()
{
    var self = this;
    console.log('height');
    return send(send(self.$corner, 'y'), '-', [send(self.$origin, 'y')]);
};
Rectangle.prototype['innerCorners'] = function()
{
    var self = this;
    console.log('innerCorners');
    var r1 = null
    r1 = send(send(self, 'topLeft'), 'corner_', [send(send(self, 'bottomRight'), '-', [send(1, '@', [1])])]);
    return send(Array.classPrototype, 'with_with_with_with_', [send(r1, 'topLeft'), send(r1, 'bottomLeft'), send(r1, 'bottomRight'), send(r1, 'topRight')]);
};
Rectangle.prototype['left'] = function()
{
    var self = this;
    console.log('left');
    return send(self.$origin, 'x');
};
Rectangle.prototype['left_'] = function(aNumber)
{
    var self = this;
    console.log('left_');
    return send(send(aNumber, '@', [send(self.$origin, 'y')]), 'corner_', [self.$corner]);
};
Rectangle.prototype['leftCenter'] = function()
{
    var self = this;
    console.log('leftCenter');
    return send(send(self, 'left'), '@', [send(send(self, 'center'), 'y')]);
};
Rectangle.prototype['origin'] = function()
{
    var self = this;
    console.log('origin');
    return self.$origin;
};
Rectangle.prototype['pointAtSideOrCorner_'] = function(loc)
{
    var self = this;
    console.log('pointAtSideOrCorner_');
    return send(self, 'perform_', [send(['topLeft', 'topCenter', 'topRight', 'rightCenter', 'bottomRight', 'bottomCenter', 'bottomLeft', 'leftCenter'], 'at_', [send(['topLeft', 'top', 'topRight', 'right', 'bottomRight', 'bottom', 'bottomLeft', 'left'], 'indexOf_', [loc])])]);
};
Rectangle.prototype['right'] = function()
{
    var self = this;
    console.log('right');
    return send(self.$corner, 'x');
};
Rectangle.prototype['right_'] = function(aNumber)
{
    var self = this;
    console.log('right_');
    return send(self.$origin, 'corner_', [send(aNumber, '@', [send(self.$corner, 'y')])]);
};
Rectangle.prototype['rightCenter'] = function()
{
    var self = this;
    console.log('rightCenter');
    return send(send(self, 'right'), '@', [send(send(self, 'center'), 'y')]);
};
Rectangle.prototype['top'] = function()
{
    var self = this;
    console.log('top');
    return send(self.$origin, 'y');
};
Rectangle.prototype['top_'] = function(aNumber)
{
    var self = this;
    console.log('top_');
    return send(send(send(self.$origin, 'x'), '@', [aNumber]), 'corner_', [self.$corner]);
};
Rectangle.prototype['topCenter'] = function()
{
    var self = this;
    console.log('topCenter');
    return send(send(send(self, 'center'), 'x'), '@', [send(self, 'top')]);
};
Rectangle.prototype['topLeft'] = function()
{
    var self = this;
    console.log('topLeft');
    return self.$origin;
};
Rectangle.prototype['topRight'] = function()
{
    var self = this;
    console.log('topRight');
    return send(send(self.$corner, 'x'), '@', [send(self.$origin, 'y')]);
};
Rectangle.prototype['width'] = function()
{
    var self = this;
    console.log('width');
    return send(send(self.$corner, 'x'), '-', [send(self.$origin, 'x')]);
};
Rectangle.prototype['='] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('=');
    send(send(send(self, 'species'), '=', [send(aRectangle, 'species')]), 'ifTrue_ifFalse_', [function() {
        __context.value = send(send(self.$origin, '=', [send(aRectangle, 'origin')]), 'and_', [function() {
            send(self.$corner, '=', [send(aRectangle, 'corner')]);
            if (__context.return) return __context.value;
        }
        ]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['hash'] = function()
{
    var self = this;
    console.log('hash');
    return send(send(self.$origin, 'hash'), 'bitXor_', [send(self.$corner, 'hash')]);
};
Rectangle.prototype['deltaToEnsureInOrCentered_extra_'] = function(r, aNumber)
{
    var self = this;
    var __context = {};
    console.log('deltaToEnsureInOrCentered_extra_');
    var dX = null
    var dY = null
    var halfXDiff = null
    var halfYDiff = null
    dX = dY = 0;
    halfXDiff = send(send(send(send(r, 'width'), '-', [send(self, 'width')]), '*', [aNumber]), 'truncated');
    halfYDiff = send(send(send(send(r, 'height'), '-', [send(self, 'height')]), '*', [aNumber]), 'truncated');
    send(send(send(self, 'left'), '<', [send(r, 'left')]), 'ifTrue_ifFalse_', [function() {
        dX = send(send(send(self, 'left'), '-', [send(r, 'left')]), '-', [halfXDiff]);
    }
    , function() {
        send(send(send(self, 'right'), '>', [send(r, 'right')]), 'ifTrue_', [function() {
            dX = send(send(send(self, 'right'), '-', [send(r, 'right')]), '+', [halfXDiff]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self, 'top'), '<', [send(r, 'top')]), 'ifTrue_ifFalse_', [function() {
        dY = send(send(send(self, 'top'), '-', [send(r, 'top')]), '-', [halfYDiff]);
    }
    , function() {
        send(send(send(self, 'bottom'), '>', [send(r, 'bottom')]), 'ifTrue_', [function() {
            dY = send(send(send(self, 'bottom'), '-', [send(r, 'bottom')]), '+', [halfYDiff]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(dX, '@', [dY]);
};
Rectangle.prototype['printOn_'] = function(aStream)
{
    var self = this;
    console.log('printOn_');
    send(self.$origin, 'printOn_', [aStream]);
    send(aStream, 'nextPutAll_', [' corner: ']);
    send(self.$corner, 'printOn_', [aStream]);
};
Rectangle.prototype['storeOn_'] = function(aStream)
{
    var self = this;
    console.log('storeOn_');
    send(aStream, 'nextPut_', ['(']);
    send(self, 'printOn_', [aStream]);
    send(aStream, 'nextPut_', [')']);
};
Rectangle.prototype['adjustTo_along_'] = function(newRect, side)
{
    var self = this;
    var __context = {};
    console.log('adjustTo_along_');
    send(send(side, '=', ['left']), 'ifTrue_', [function() {
        __context.value = send(self, 'withRight_', [send(newRect, 'left')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['right']), 'ifTrue_', [function() {
        __context.value = send(self, 'withLeft_', [send(newRect, 'right')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['top']), 'ifTrue_', [function() {
        __context.value = send(self, 'withBottom_', [send(newRect, 'top')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottom']), 'ifTrue_', [function() {
        __context.value = send(self, 'withTop_', [send(newRect, 'bottom')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['allAreasOutsideList_do_'] = function(aCollection, aBlock)
{
    var self = this;
    console.log('allAreasOutsideList_do_');
    return send(self, 'allAreasOutsideList_startingAt_do_', [aCollection, 1, aBlock]);
};
Rectangle.prototype['allAreasOutsideList_startingAt_do_'] = function(aCollection, startIndex, aBlock)
{
    var self = this;
    var __context = {};
    console.log('allAreasOutsideList_startingAt_do_');
    var yOrigin = null
    var yCorner = null
    var aRectangle = null
    var index = null
    var rr = null
    index = startIndex;
    send(function() {
        send(send(index, '<=', [send(aCollection, 'size')]), 'ifFalse_', [function() {
            __context.value = send(aBlock, 'value_', [self]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        aRectangle = send(aCollection, 'at_', [index]);
        send(send(self.$origin, '<=', [send(aRectangle, 'corner')]), 'and_', [function() {
            send(send(aRectangle, 'origin'), '<=', [self.$corner]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , 'whileFalse_', [function() {
        index = send(index, '+', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'origin'), 'y'), '>', [send(self.$origin, 'y')]), 'ifTrue_ifFalse_', [function() {
        rr = send(self.$origin, 'corner_', [send(send(self.$corner, 'x'), '@', [yOrigin = send(send(aRectangle, 'origin'), 'y')])]);
        send(rr, 'allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    , function() {
        yOrigin = send(self.$origin, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'corner'), 'y'), '<', [send(self.$corner, 'y')]), 'ifTrue_ifFalse_', [function() {
        rr = send(send(send(self.$origin, 'x'), '@', [yCorner = send(send(aRectangle, 'corner'), 'y')]), 'corner_', [self.$corner]);
        send(rr, 'allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    , function() {
        yCorner = send(self.$corner, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'origin'), 'x'), '>', [send(self.$origin, 'x')]), 'ifTrue_', [function() {
        rr = send(send(send(self.$origin, 'x'), '@', [yOrigin]), 'corner_', [send(send(send(aRectangle, 'origin'), 'x'), '@', [yCorner])]);
        send(rr, 'allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'corner'), 'x'), '<', [send(self.$corner, 'x')]), 'ifTrue_', [function() {
        rr = send(send(send(send(aRectangle, 'corner'), 'x'), '@', [yOrigin]), 'corner_', [send(send(self.$corner, 'x'), '@', [yCorner])]);
        send(rr, 'allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['amountToTranslateWithin_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('amountToTranslateWithin_');
    var dx = null
    var dy = null
    dx = 0;
    dy = 0;
    send(send(send(self, 'right'), '>', [send(aRectangle, 'right')]), 'ifTrue_', [function() {
        dx = send(send(aRectangle, 'right'), '-', [send(self, 'right')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self, 'bottom'), '>', [send(aRectangle, 'bottom')]), 'ifTrue_', [function() {
        dy = send(send(aRectangle, 'bottom'), '-', [send(self, 'bottom')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, 'left'), '+', [dx]), '<', [send(aRectangle, 'left')]), 'ifTrue_', [function() {
        dx = send(send(aRectangle, 'left'), '-', [send(self, 'left')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, 'top'), '+', [dy]), '<', [send(aRectangle, 'top')]), 'ifTrue_', [function() {
        dy = send(send(aRectangle, 'top'), '-', [send(self, 'top')]);
    }
    ]);
    if (__context.return) return __context.value;
    return send(dx, '@', [dy]);
};
Rectangle.prototype['areasOutside_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('areasOutside_');
    var areas = null
    var yOrigin = null
    var yCorner = null
    send(send(self, 'intersects_', [aRectangle]), 'ifFalse_', [function() {
        __context.value = send(Array.classPrototype, 'with_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    areas = send(OrderedCollection.classPrototype, 'new');
    send(send(send(send(aRectangle, 'origin'), 'y'), '>', [send(self.$origin, 'y')]), 'ifTrue_ifFalse_', [function() {
        send(areas, 'addLast_', [send(self.$origin, 'corner_', [send(send(self.$corner, 'x'), '@', [yOrigin = send(send(aRectangle, 'origin'), 'y')])])]);
        if (__context.return) return __context.value;
    }
    , function() {
        yOrigin = send(self.$origin, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'corner'), 'y'), '<', [send(self.$corner, 'y')]), 'ifTrue_ifFalse_', [function() {
        send(areas, 'addLast_', [send(send(send(self.$origin, 'x'), '@', [yCorner = send(send(aRectangle, 'corner'), 'y')]), 'corner_', [self.$corner])]);
        if (__context.return) return __context.value;
    }
    , function() {
        yCorner = send(self.$corner, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'origin'), 'x'), '>', [send(self.$origin, 'x')]), 'ifTrue_', [function() {
        send(areas, 'addLast_', [send(send(send(self.$origin, 'x'), '@', [yOrigin]), 'corner_', [send(send(send(aRectangle, 'origin'), 'x'), '@', [yCorner])])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, 'corner'), 'x'), '<', [send(self.$corner, 'x')]), 'ifTrue_', [function() {
        send(areas, 'addLast_', [send(send(send(send(aRectangle, 'corner'), 'x'), '@', [yOrigin]), 'corner_', [send(send(self.$corner, 'x'), '@', [yCorner])])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return areas;
};
Rectangle.prototype['bordersOn_along_'] = function(her, herSide)
{
    var self = this;
    var __context = {};
    console.log('bordersOn_along_');
    send(send(send(send(herSide, '=', ['right']), 'and_', [function() {
        send(send(self, 'left'), '=', [send(her, 'right')]);
        if (__context.return) return __context.value;
    }
    ]), '|', [send(send(herSide, '=', ['left']), 'and_', [function() {
        send(send(self, 'right'), '=', [send(her, 'left')]);
        if (__context.return) return __context.value;
    }
    ])]), 'ifTrue_', [function() {
        __context.value = send(send(send(self, 'top'), 'max_', [send(her, 'top')]), '<', [send(send(self, 'bottom'), 'min_', [send(her, 'bottom')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(herSide, '=', ['bottom']), 'and_', [function() {
        send(send(self, 'top'), '=', [send(her, 'bottom')]);
        if (__context.return) return __context.value;
    }
    ]), '|', [send(send(herSide, '=', ['top']), 'and_', [function() {
        send(send(self, 'bottom'), '=', [send(her, 'top')]);
        if (__context.return) return __context.value;
    }
    ])]), 'ifTrue_', [function() {
        __context.value = send(send(send(self, 'left'), 'max_', [send(her, 'left')]), '<', [send(send(self, 'right'), 'min_', [send(her, 'right')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Rectangle.prototype['encompass_'] = function(aPoint)
{
    var self = this;
    console.log('encompass_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'min_', [aPoint]), send(self.$corner, 'max_', [aPoint])]);
};
Rectangle.prototype['expandBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('expandBy_');
    send(send(delta, 'isRectangle'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '-', [send(delta, 'origin')]), send(self.$corner, '+', [send(delta, 'corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '-', [delta]), send(self.$corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['extendBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('extendBy_');
    send(send(delta, 'isRectangle'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [self.$origin, send(self.$corner, '+', [send(delta, 'corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [self.$origin, send(self.$corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['forPoint_closestSideDistLen_'] = function(aPoint, sideDistLenBlock)
{
    var self = this;
    var __context = {};
    console.log('forPoint_closestSideDistLen_');
    var side = null
    side = send(self, 'sideNearestTo_', [aPoint]);
    send(send(side, '==', ['right']), 'ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, 'value_value_value_', [side, send(send(send(self, 'right'), '-', [send(aPoint, 'x')]), 'abs'), send(send(send(aPoint, 'y'), 'between_and_', [send(self, 'top'), send(self, 'bottom')]), 'ifTrue_ifFalse_', [function() {
            send(self, 'height');
            if (__context.return) return __context.value;
        }
        , function() {
            0;
        }
        ])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '==', ['left']), 'ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, 'value_value_value_', [side, send(send(send(self, 'left'), '-', [send(aPoint, 'x')]), 'abs'), send(send(send(aPoint, 'y'), 'between_and_', [send(self, 'top'), send(self, 'bottom')]), 'ifTrue_ifFalse_', [function() {
            send(self, 'height');
            if (__context.return) return __context.value;
        }
        , function() {
            0;
        }
        ])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '==', ['bottom']), 'ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, 'value_value_value_', [side, send(send(send(self, 'bottom'), '-', [send(aPoint, 'y')]), 'abs'), send(send(send(aPoint, 'x'), 'between_and_', [send(self, 'left'), send(self, 'right')]), 'ifTrue_ifFalse_', [function() {
            send(self, 'width');
            if (__context.return) return __context.value;
        }
        , function() {
            0;
        }
        ])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '==', ['top']), 'ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, 'value_value_value_', [side, send(send(send(self, 'top'), '-', [send(aPoint, 'y')]), 'abs'), send(send(send(aPoint, 'x'), 'between_and_', [send(self, 'left'), send(self, 'right')]), 'ifTrue_ifFalse_', [function() {
            send(self, 'width');
            if (__context.return) return __context.value;
        }
        , function() {
            0;
        }
        ])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['insetBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('insetBy_');
    send(send(delta, 'isRectangle'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '+', [send(delta, 'origin')]), send(self.$corner, '-', [send(delta, 'corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '+', [delta]), send(self.$corner, '-', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['insetOriginBy_cornerBy_'] = function(originDeltaPoint, cornerDeltaPoint)
{
    var self = this;
    console.log('insetOriginBy_cornerBy_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '+', [originDeltaPoint]), send(self.$corner, '-', [cornerDeltaPoint])]);
};
Rectangle.prototype['intersect_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('intersect_');
    var aPoint = null
    var left = null
    var right = null
    var top = null
    var bottom = null
    aPoint = send(aRectangle, 'origin');
    send(send(send(aPoint, 'x'), '>', [send(self.$origin, 'x')]), 'ifTrue_ifFalse_', [function() {
        left = send(aPoint, 'x');
    }
    , function() {
        left = send(self.$origin, 'x');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(aPoint, 'y'), '>', [send(self.$origin, 'y')]), 'ifTrue_ifFalse_', [function() {
        top = send(aPoint, 'y');
    }
    , function() {
        top = send(self.$origin, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    aPoint = send(aRectangle, 'corner');
    send(send(send(aPoint, 'x'), '<', [send(self.$corner, 'x')]), 'ifTrue_ifFalse_', [function() {
        right = send(aPoint, 'x');
    }
    , function() {
        right = send(self.$corner, 'x');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(aPoint, 'y'), '<', [send(self.$corner, 'y')]), 'ifTrue_ifFalse_', [function() {
        bottom = send(aPoint, 'y');
    }
    , function() {
        bottom = send(self.$corner, 'y');
    }
    ]);
    if (__context.return) return __context.value;
    return send(Rectangle.classPrototype, 'origin_corner_', [send(left, '@', [top]), send(right, '@', [bottom])]);
};
Rectangle.prototype['merge_'] = function(aRectangle)
{
    var self = this;
    console.log('merge_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'min_', [send(aRectangle, 'origin')]), send(self.$corner, 'max_', [send(aRectangle, 'corner')])]);
};
Rectangle.prototype['outsetBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('outsetBy_');
    send(send(delta, 'isRectangle'), 'ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '-', [send(delta, 'origin')]), send(self.$corner, '+', [send(delta, 'corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '-', [delta]), send(self.$corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['pointNearestTo_'] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('pointNearestTo_');
    var side = null
    send(send(self, 'containsPoint_', [aPoint]), 'ifTrue_ifFalse_', [function() {
        side = send(self, 'sideNearestTo_', [aPoint]);
        send(send(side, '==', ['right']), 'ifTrue_', [function() {
            __context.value = send(send(self, 'right'), '@', [send(aPoint, 'y')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['left']), 'ifTrue_', [function() {
            __context.value = send(send(self, 'left'), '@', [send(aPoint, 'y')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['bottom']), 'ifTrue_', [function() {
            __context.value = send(send(aPoint, 'x'), '@', [send(self, 'bottom')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['top']), 'ifTrue_', [function() {
            __context.value = send(send(aPoint, 'x'), '@', [send(self, 'top')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        __context.value = send(aPoint, 'adhereTo_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['quickMerge_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('quickMerge_');
    var useRcvr = null
    var rOrigin = null
    var rCorner = null
    var minX = null
    var maxX = null
    var minY = null
    var maxY = null
    send(aRectangle, 'ifNil_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    useRcvr = true;
    rOrigin = send(aRectangle, 'topLeft');
    rCorner = send(aRectangle, 'bottomRight');
    minX = send(send(send(rOrigin, 'x'), '<', [send(self.$origin, 'x')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rOrigin, 'x');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.$origin, 'x');
        if (__context.return) return __context.value;
    }
    ]);
    maxX = send(send(send(rCorner, 'x'), '>', [send(self.$corner, 'x')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rCorner, 'x');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.$corner, 'x');
        if (__context.return) return __context.value;
    }
    ]);
    minY = send(send(send(rOrigin, 'y'), '<', [send(self.$origin, 'y')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rOrigin, 'y');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.$origin, 'y');
        if (__context.return) return __context.value;
    }
    ]);
    maxY = send(send(send(rCorner, 'y'), '>', [send(self.$corner, 'y')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rCorner, 'y');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.$corner, 'y');
        if (__context.return) return __context.value;
    }
    ]);
    send(useRcvr, 'ifTrue_ifFalse_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, 'origin_corner_', [send(minX, '@', [minY]), send(maxX, '@', [maxY])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['rectanglesAt_height_'] = function(y, ht)
{
    var self = this;
    var __context = {};
    console.log('rectanglesAt_height_');
    send(send(send(y, '+', [ht]), '>', [send(self, 'bottom')]), 'ifTrue_', [function() {
        __context.value = send(Array.classPrototype, 'new');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Array.classPrototype, 'with_', [send(send(send(self.$origin, 'x'), '@', [y]), 'corner_', [send(send(self.$corner, 'x'), '@', [send(y, '+', [ht])])])]);
};
Rectangle.prototype['sideNearestTo_'] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('sideNearestTo_');
    var distToLeft = null
    var distToRight = null
    var distToTop = null
    var distToBottom = null
    var closest = null
    var side = null
    distToLeft = send(send(aPoint, 'x'), '-', [send(self, 'left')]);
    distToRight = send(send(self, 'right'), '-', [send(aPoint, 'x')]);
    distToTop = send(send(aPoint, 'y'), '-', [send(self, 'top')]);
    distToBottom = send(send(self, 'bottom'), '-', [send(aPoint, 'y')]);
    closest = distToLeft;
    side = 'left';
    send(send(distToRight, '<', [closest]), 'ifTrue_', [function() {
        closest = distToRight;
        side = 'right';
    }
    ]);
    if (__context.return) return __context.value;
    send(send(distToTop, '<', [closest]), 'ifTrue_', [function() {
        closest = distToTop;
        side = 'top';
    }
    ]);
    if (__context.return) return __context.value;
    send(send(distToBottom, '<', [closest]), 'ifTrue_', [function() {
        closest = distToBottom;
        side = 'bottom';
    }
    ]);
    if (__context.return) return __context.value;
    return side;
};
Rectangle.prototype['translatedToBeWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('translatedToBeWithin_');
    return send(self, 'translateBy_', [send(self, 'amountToTranslateWithin_', [aRectangle])]);
};
Rectangle.prototype['withBottom_'] = function(y)
{
    var self = this;
    console.log('withBottom_');
    return send(send(send(self.$origin, 'x'), '@', [send(self.$origin, 'y')]), 'corner_', [send(send(self.$corner, 'x'), '@', [y])]);
};
Rectangle.prototype['withHeight_'] = function(height)
{
    var self = this;
    console.log('withHeight_');
    return send(self.$origin, 'corner_', [send(send(self.$corner, 'x'), '@', [send(send(self.$origin, 'y'), '+', [height])])]);
};
Rectangle.prototype['withLeft_'] = function(x)
{
    var self = this;
    console.log('withLeft_');
    return send(send(x, '@', [send(self.$origin, 'y')]), 'corner_', [send(send(self.$corner, 'x'), '@', [send(self.$corner, 'y')])]);
};
Rectangle.prototype['withRight_'] = function(x)
{
    var self = this;
    console.log('withRight_');
    return send(send(send(self.$origin, 'x'), '@', [send(self.$origin, 'y')]), 'corner_', [send(x, '@', [send(self.$corner, 'y')])]);
};
Rectangle.prototype['withSide_setTo_'] = function(side, value)
{
    var self = this;
    console.log('withSide_setTo_');
    return send(self, 'perform_with_', [send(['withLeft:', 'withRight:', 'withTop:', 'withBottom:'], 'at_', [send(['left', 'right', 'top', 'bottom'], 'indexOf_', [side])]), value]);
};
Rectangle.prototype['withSideOrCorner_setToPoint_'] = function(side, newPoint)
{
    var self = this;
    console.log('withSideOrCorner_setToPoint_');
    return send(self, 'withSideOrCorner_setToPoint_minExtent_', [side, newPoint, send(0, '@', [0])]);
};
Rectangle.prototype['withSideOrCorner_setToPoint_minExtent_'] = function(side, newPoint, minExtent)
{
    var self = this;
    console.log('withSideOrCorner_setToPoint_minExtent_');
    return send(self, 'withSideOrCorner_setToPoint_minExtent_limit_', [side, newPoint, minExtent, send(send(['left', 'top'], 'includes_', [side]), 'ifTrue_ifFalse_', [function() {
        send(SmallInteger.classPrototype, 'minVal');
    }
    , function() {
        send(SmallInteger.classPrototype, 'maxVal');
    }
    ])]);
};
Rectangle.prototype['withSideOrCorner_setToPoint_minExtent_limit_'] = function(side, newPoint, minExtent, limit)
{
    var self = this;
    var __context = {};
    console.log('withSideOrCorner_setToPoint_minExtent_limit_');
    send(send(side, '=', ['top']), 'ifTrue_', [function() {
        __context.value = send(self, 'withTop_', [send(send(newPoint, 'y'), 'min_max_', [send(send(self.$corner, 'y'), '-', [send(minExtent, 'y')]), send(limit, '+', [send(minExtent, 'y')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottom']), 'ifTrue_', [function() {
        __context.value = send(self, 'withBottom_', [send(send(newPoint, 'y'), 'min_max_', [send(limit, '-', [send(minExtent, 'y')]), send(send(self.$origin, 'y'), '+', [send(minExtent, 'y')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['left']), 'ifTrue_', [function() {
        __context.value = send(self, 'withLeft_', [send(send(newPoint, 'x'), 'min_max_', [send(send(self.$corner, 'x'), '-', [send(minExtent, 'x')]), send(limit, '+', [send(minExtent, 'x')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['right']), 'ifTrue_', [function() {
        __context.value = send(self, 'withRight_', [send(send(newPoint, 'x'), 'min_max_', [send(limit, '-', [send(minExtent, 'x')]), send(send(self.$origin, 'x'), '+', [send(minExtent, 'x')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['topLeft']), 'ifTrue_', [function() {
        __context.value = send(send(newPoint, 'min_', [send(self.$corner, '-', [minExtent])]), 'corner_', [send(self, 'bottomRight')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottomRight']), 'ifTrue_', [function() {
        __context.value = send(send(self, 'topLeft'), 'corner_', [send(newPoint, 'max_', [send(self.$origin, '+', [minExtent])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottomLeft']), 'ifTrue_', [function() {
        __context.value = send(send(self, 'topRight'), 'rect_', [send(send(send(newPoint, 'x'), 'min_', [send(send(self.$corner, 'x'), '-', [send(minExtent, 'x')])]), '@', [send(send(newPoint, 'y'), 'max_', [send(send(self.$origin, 'y'), '+', [send(minExtent, 'y')])])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['topRight']), 'ifTrue_', [function() {
        __context.value = send(send(self, 'bottomLeft'), 'rect_', [send(send(send(newPoint, 'x'), 'max_', [send(send(self.$origin, 'x'), '+', [send(minExtent, 'x')])]), '@', [send(send(newPoint, 'y'), 'min_', [send(send(self.$corner, 'y'), '-', [send(minExtent, 'y')])])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['withTop_'] = function(y)
{
    var self = this;
    console.log('withTop_');
    return send(send(send(self.$origin, 'x'), '@', [y]), 'corner_', [send(send(self.$corner, 'x'), '@', [send(self.$corner, 'y')])]);
};
Rectangle.prototype['withWidth_'] = function(width)
{
    var self = this;
    console.log('withWidth_');
    return send(self.$origin, 'corner_', [send(send(send(self.$origin, 'x'), '+', [width]), '@', [send(self.$corner, 'y')])]);
};
Rectangle.prototype['isSelfEvaluating'] = function()
{
    var self = this;
    console.log('isSelfEvaluating');
    return send(send(self, 'class'), '==', [Rectangle]);
};
Rectangle.prototype['containsPoint_'] = function(aPoint)
{
    var self = this;
    console.log('containsPoint_');
    return send(send(self.$origin, '<=', [aPoint]), 'and_', [function() {
        send(aPoint, '<', [self.$corner]);
    }
    ]);
};
Rectangle.prototype['containsRect_'] = function(aRect)
{
    var self = this;
    console.log('containsRect_');
    return send(send(send(aRect, 'origin'), '>=', [self.$origin]), 'and_', [function() {
        send(send(aRect, 'corner'), '<=', [self.$corner]);
    }
    ]);
};
Rectangle.prototype['hasPositiveExtent'] = function()
{
    var self = this;
    console.log('hasPositiveExtent');
    return send(send(send(self.$corner, 'x'), '>', [send(self.$origin, 'x')]), 'and_', [function() {
        send(send(self.$corner, 'y'), '>', [send(self.$origin, 'y')]);
    }
    ]);
};
Rectangle.prototype['intersects_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('intersects_');
    var rOrigin = null
    var rCorner = null
    rOrigin = send(aRectangle, 'origin');
    rCorner = send(aRectangle, 'corner');
    send(send(send(rCorner, 'x'), '<=', [send(self.$origin, 'x')]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rCorner, 'y'), '<=', [send(self.$origin, 'y')]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rOrigin, 'x'), '>=', [send(self.$corner, 'x')]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rOrigin, 'y'), '>=', [send(self.$corner, 'y')]), 'ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Rectangle.prototype['isRectangle'] = function()
{
    var self = this;
    console.log('isRectangle');
    return true;
};
Rectangle.prototype['isTall'] = function()
{
    var self = this;
    console.log('isTall');
    return send(send(self, 'height'), '>', [send(self, 'width')]);
};
Rectangle.prototype['isWide'] = function()
{
    var self = this;
    console.log('isWide');
    return send(send(self, 'width'), '>', [send(self, 'height')]);
};
Rectangle.prototype['isZero'] = function()
{
    var self = this;
    console.log('isZero');
    return send(send(self.$origin, 'isZero'), 'and_', [function() {
        send(self.$corner, 'isZero');
    }
    ]);
};
Rectangle.prototype['align_with_'] = function(aPoint1, aPoint2)
{
    var self = this;
    console.log('align_with_');
    return send(self, 'translateBy_', [send(aPoint2, '-', [aPoint1])]);
};
Rectangle.prototype['centeredBeneath_'] = function(aRectangle)
{
    var self = this;
    console.log('centeredBeneath_');
    return send(self, 'align_with_', [send(self, 'topCenter'), send(aRectangle, 'bottomCenter')]);
};
Rectangle.prototype['flipBy_centerAt_'] = function(direction, aPoint)
{
    var self = this;
    console.log('flipBy_centerAt_');
    return send(send(self.$origin, 'flipBy_centerAt_', [direction, aPoint]), 'rect_', [send(self.$corner, 'flipBy_centerAt_', [direction, aPoint])]);
};
Rectangle.prototype['interpolateTo_at_'] = function(end, amountDone)
{
    var self = this;
    console.log('interpolateTo_at_');
    return send(send(send(self, 'origin'), 'interpolateTo_at_', [send(end, 'origin'), amountDone]), 'corner_', [send(send(self, 'corner'), 'interpolateTo_at_', [send(end, 'corner'), amountDone])]);
};
Rectangle.prototype['newRectButtonPressedDo_'] = function(newRectBlock)
{
    var self = this;
    var __context = {};
    console.log('newRectButtonPressedDo_');
    var rect = null
    var newRect = null
    var buttonNow = null
    var delay = null
    delay = send(Delay.classPrototype, 'forMilliseconds_', [10]);
    buttonNow = send(Sensor.classPrototype, 'anyButtonPressed');
    rect = self;
    send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
    if (__context.return) return __context.value;
    send(function() {
        buttonNow;
    }
    , 'whileTrue_', [function() {
        send(delay, 'wait');
        if (__context.return) return __context.value;
        send(function() {
            send(send(Sensor.classPrototype, 'nextEvent'), 'isNil');
            if (__context.return) return __context.value;
        }
        , 'whileFalse');
        if (__context.return) return __context.value;
        buttonNow = send(Sensor.classPrototype, 'anyButtonPressed');
        newRect = send(newRectBlock, 'value_', [rect]);
        send(send(newRect, '=', [rect]), 'ifFalse_', [function() {
            send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
            if (__context.return) return __context.value;
            send(Display.classPrototype, 'border_width_rule_fillColor_', [newRect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
            if (__context.return) return __context.value;
            rect = newRect;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
    if (__context.return) return __context.value;
    send((function () {var _aux = send(send(World.classPrototype, 'activeHand'), 'newMouseFocus_', [nil]);return _aux;})(), 'showTemporaryCursor_', [nil]);
    if (__context.return) return __context.value;
    return rect;
};
Rectangle.prototype['newRectFrom_'] = function(newRectBlock)
{
    var self = this;
    var __context = {};
    console.log('newRectFrom_');
    var rect = null
    var newRect = null
    var buttonStart = null
    var buttonNow = null
    var delay = null
    delay = send(Delay.classPrototype, 'forMilliseconds_', [10]);
    buttonStart = buttonNow = send(Sensor.classPrototype, 'anyButtonPressed');
    rect = self;
    send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
    if (__context.return) return __context.value;
    send(function() {
        send(buttonNow, '==', [buttonStart]);
        if (__context.return) return __context.value;
    }
    , 'whileTrue_', [function() {
        send(delay, 'wait');
        if (__context.return) return __context.value;
        send(function() {
            send(send(Sensor.classPrototype, 'nextEvent'), 'isNil');
            if (__context.return) return __context.value;
        }
        , 'whileFalse');
        if (__context.return) return __context.value;
        buttonNow = send(Sensor.classPrototype, 'anyButtonPressed');
        newRect = send(newRectBlock, 'value_', [rect]);
        send(send(newRect, '=', [rect]), 'ifFalse_', [function() {
            send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
            if (__context.return) return __context.value;
            send(Display.classPrototype, 'border_width_rule_fillColor_', [newRect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
            if (__context.return) return __context.value;
            rect = newRect;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Display.classPrototype, 'border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, 'reverse'), send(Color.classPrototype, 'gray')]);
    if (__context.return) return __context.value;
    send((function () {var _aux = send(send(World.classPrototype, 'activeHand'), 'newMouseFocus_', [nil]);return _aux;})(), 'showTemporaryCursor_', [nil]);
    if (__context.return) return __context.value;
    return rect;
};
Rectangle.prototype['quickMergePoint_'] = function(aPoint)
{
    var self = this;
    console.log('quickMergePoint_');
    var useRcvr = null
    var minX = null
    var maxX = null
    var minY = null
    var maxY = null
    useRcvr = true;
    minX = send(send(send(aPoint, 'x'), '<', [send(self.$origin, 'x')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(aPoint, 'x');
    }
    , function() {
        send(self.$origin, 'x');
    }
    ]);
    maxX = send(send(send(aPoint, 'x'), '>=', [send(self.$corner, 'x')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(send(aPoint, 'x'), '+', [1]);
    }
    , function() {
        send(self.$corner, 'x');
    }
    ]);
    minY = send(send(send(aPoint, 'y'), '<', [send(self.$origin, 'y')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(aPoint, 'y');
    }
    , function() {
        send(self.$origin, 'y');
    }
    ]);
    maxY = send(send(send(aPoint, 'y'), '>=', [send(self.$corner, 'y')]), 'ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(send(aPoint, 'y'), '+', [1]);
    }
    , function() {
        send(self.$corner, 'y');
    }
    ]);
    return send(useRcvr, 'ifTrue_ifFalse_', [function() {
        self;
    }
    , function() {
        send(send(minX, '@', [minY]), 'corner_', [send(maxX, '@', [maxY])]);
    }
    ]);
};
Rectangle.prototype['rotateBy_centerAt_'] = function(direction, aPoint)
{
    var self = this;
    console.log('rotateBy_centerAt_');
    return send(send(self.$origin, 'rotateBy_centerAt_', [direction, aPoint]), 'rect_', [send(self.$corner, 'rotateBy_centerAt_', [direction, aPoint])]);
};
Rectangle.prototype['scaleBy_'] = function(scale)
{
    var self = this;
    console.log('scaleBy_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '*', [scale]), send(self.$corner, '*', [scale])]);
};
Rectangle.prototype['scaleFrom_to_'] = function(rect1, rect2)
{
    var self = this;
    console.log('scaleFrom_to_');
    return send(send(self.$origin, 'scaleFrom_to_', [rect1, rect2]), 'corner_', [send(self.$corner, 'scaleFrom_to_', [rect1, rect2])]);
};
Rectangle.prototype['scaledAndCenteredIn_'] = function(aRect)
{
    var self = this;
    console.log('scaledAndCenteredIn_');
    return send(send(send(send(self, 'width'), '/', [send(aRect, 'width')]), '>', [send(send(self, 'height'), '/', [send(aRect, 'height')])]), 'ifTrue_ifFalse_', [function() {
        send(send(send(aRect, 'left'), '@', [send(send(send(aRect, 'leftCenter'), 'y'), '-', [send(send(send(self, 'height'), '*', [send(send(aRect, 'width'), '/', [send(self, 'width')])]), '/', [2])])]), 'corner_', [send(send(aRect, 'right'), '@', [send(send(send(aRect, 'rightCenter'), 'y'), '+', [send(send(send(self, 'height'), '*', [send(send(aRect, 'width'), '/', [send(self, 'width')])]), '/', [2])])])]);
    }
    , function() {
        send(send(send(send(send(aRect, 'topCenter'), 'x'), '-', [send(send(send(self, 'width'), '*', [send(send(aRect, 'height'), '/', [send(self, 'height')])]), '/', [2])]), '@', [send(aRect, 'top')]), 'corner_', [send(send(send(send(aRect, 'topCenter'), 'x'), '+', [send(send(send(self, 'width'), '*', [send(send(aRect, 'height'), '/', [send(self, 'height')])]), '/', [2])]), '@', [send(aRect, 'bottom')])]);
    }
    ]);
};
Rectangle.prototype['squishedWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('squishedWithin_');
    return send(self.$origin, 'corner_', [send(self.$corner, 'min_', [send(aRectangle, 'bottomRight')])]);
};
Rectangle.prototype['translateBy_'] = function(factor)
{
    var self = this;
    console.log('translateBy_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, '+', [factor]), send(self.$corner, '+', [factor])]);
};
Rectangle.prototype['translatedAndSquishedToBeWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('translatedAndSquishedToBeWithin_');
    return send(send(self, 'translatedToBeWithin_', [aRectangle]), 'squishedWithin_', [aRectangle]);
};
Rectangle.prototype['rounded'] = function()
{
    var self = this;
    console.log('rounded');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'rounded'), send(self.$corner, 'rounded')]);
};
Rectangle.prototype['truncateTo_'] = function(grid)
{
    var self = this;
    console.log('truncateTo_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'truncateTo_', [grid]), send(self.$corner, 'truncateTo_', [grid])]);
};
Rectangle.prototype['truncated'] = function()
{
    var self = this;
    var __context = {};
    console.log('truncated');
    send(send(send(send(self.$origin, 'x'), 'isInteger'), 'and_', [function() {
        send(send(send(self.$origin, 'y'), 'isInteger'), 'and_', [function() {
            send(send(send(self.$corner, 'x'), 'isInteger'), 'and_', [function() {
                send(send(self.$corner, 'y'), 'isInteger');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'truncated'), send(self.$corner, 'truncated')]);
};
Rectangle.prototype['ceiling'] = function()
{
    var self = this;
    var __context = {};
    console.log('ceiling');
    send(send(self, 'isIntegerRectangle'), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$origin, 'ceiling'), 'corner_', [send(self.$corner, 'ceiling')]);
};
Rectangle.prototype['compressTo_'] = function(grid)
{
    var self = this;
    console.log('compressTo_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'roundUpTo_', [grid]), send(self.$corner, 'roundDownTo_', [grid])]);
};
Rectangle.prototype['compressed'] = function()
{
    var self = this;
    console.log('compressed');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'ceiling'), send(self.$corner, 'floor')]);
};
Rectangle.prototype['expandTo_'] = function(grid)
{
    var self = this;
    console.log('expandTo_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'roundDownTo_', [grid]), send(self.$corner, 'roundUpTo_', [grid])]);
};
Rectangle.prototype['expanded'] = function()
{
    var self = this;
    console.log('expanded');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'floor'), send(self.$corner, 'ceiling')]);
};
Rectangle.prototype['floor'] = function()
{
    var self = this;
    var __context = {};
    console.log('floor');
    send(send(self, 'isIntegerRectangle'), 'ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.$origin, 'floor'), 'corner_', [send(self.$corner, 'floor')]);
};
Rectangle.prototype['isIntegerRectangle'] = function()
{
    var self = this;
    console.log('isIntegerRectangle');
    return send(send(self.$origin, 'isIntegerPoint'), 'and_', [function() {
        send(self.$corner, 'isIntegerPoint');
    }
    ]);
};
Rectangle.prototype['roundTo_'] = function(grid)
{
    var self = this;
    console.log('roundTo_');
    return send(Rectangle.classPrototype, 'origin_corner_', [send(self.$origin, 'roundTo_', [grid]), send(self.$corner, 'roundTo_', [grid])]);
};
Rectangle.prototype['setOrigin_corner_'] = function(topLeft, bottomRight)
{
    var self = this;
    console.log('setOrigin_corner_');
    self.$origin = topLeft;
    self.$corner = bottomRight;
};
RectangleClass.prototype['fromUser'] = function()
{
    var self = this;
    console.log('fromUser');
    return send(self, 'fromUser_', [send(1, '@', [1])]);
};
RectangleClass.prototype['fromUser_'] = function(gridPoint)
{
    var self = this;
    console.log('fromUser_');
    var originRect = null
    originRect = send(send(Cursor.classPrototype, 'origin'), 'showWhile_', [function() {
        send(send(send(send(Sensor.classPrototype, 'cursorPoint'), 'grid_', [gridPoint]), 'extent_', [send(0, '@', [0])]), 'newRectFrom_', [function(f) {
            send(send(send(Sensor.classPrototype, 'cursorPoint'), 'grid_', [gridPoint]), 'extent_', [send(0, '@', [0])]);
        }
        ]);
    }
    ]);
    return send(send(Cursor.classPrototype, 'corner'), 'showWhile_', [function() {
        send(originRect, 'newRectFrom_', [function(f) {
            send(send(f, 'origin'), 'corner_', [send(send(Sensor.classPrototype, 'cursorPoint'), 'grid_', [gridPoint])]);
        }
        ]);
    }
    ]);
};
RectangleClass.prototype['originFromUser_'] = function(extentPoint)
{
    var self = this;
    console.log('originFromUser_');
    return send(self, 'originFromUser_grid_', [extentPoint, send(1, '@', [1])]);
};
RectangleClass.prototype['originFromUser_grid_'] = function(extentPoint, gridPoint)
{
    var self = this;
    console.log('originFromUser_grid_');
    return send(send(Cursor.classPrototype, 'origin'), 'showWhile_', [function() {
        send(send(send(send(Sensor.classPrototype, 'cursorPoint'), 'grid_', [gridPoint]), 'extent_', [extentPoint]), 'newRectFrom_', [function(f) {
            send(send(send(Sensor.classPrototype, 'cursorPoint'), 'grid_', [gridPoint]), 'extent_', [extentPoint]);
        }
        ]);
    }
    ]);
};
RectangleClass.prototype['center_extent_'] = function(centerPoint, extentPoint)
{
    var self = this;
    console.log('center_extent_');
    return send(self, 'origin_extent_', [send(centerPoint, '-', [send(extentPoint, '//', [2])]), extentPoint]);
};
RectangleClass.prototype['encompassing_'] = function(listOfPoints)
{
    var self = this;
    var __context = {};
    console.log('encompassing_');
    var topLeft = null
    var bottomRight = null
    topLeft = bottomRight = nil;
    send(listOfPoints, 'do_', [function(p) {
        send(send(topLeft, '==', [nil]), 'ifTrue_ifFalse_', [function() {
            topLeft = bottomRight = p;
        }
        , function() {
            topLeft = send(topLeft, 'min_', [p]);
            bottomRight = send(bottomRight, 'max_', [p]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(topLeft, 'corner_', [bottomRight]);
};
RectangleClass.prototype['left_right_top_bottom_'] = function(leftNumber, rightNumber, topNumber, bottomNumber)
{
    var self = this;
    console.log('left_right_top_bottom_');
    return send(send(self, 'basicNew'), 'setOrigin_corner_', [send(leftNumber, '@', [topNumber]), send(rightNumber, '@', [bottomNumber])]);
};
RectangleClass.prototype['merging_'] = function(listOfRects)
{
    var self = this;
    var __context = {};
    console.log('merging_');
    var minX = null
    var minY = null
    var maxX = null
    var maxY = null
    send(listOfRects, 'do_', [function(r) {
        send(minX, 'ifNil_ifNotNil_', [function() {
            minX = send(send(r, 'topLeft'), 'x');
            minY = send(send(r, 'topLeft'), 'y');
            maxX = send(send(r, 'bottomRight'), 'x');
            maxY = send(send(r, 'bottomRight'), 'y');
        }
        , function() {
            minX = send(minX, 'min_', [send(send(r, 'topLeft'), 'x')]);
            minY = send(minY, 'min_', [send(send(r, 'topLeft'), 'y')]);
            maxX = send(maxX, 'max_', [send(send(r, 'bottomRight'), 'x')]);
            maxY = send(maxY, 'max_', [send(send(r, 'bottomRight'), 'y')]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(minX, '@', [minY]), 'corner_', [send(maxX, '@', [maxY])]);
};
RectangleClass.prototype['origin_corner_'] = function(originPoint, cornerPoint)
{
    var self = this;
    console.log('origin_corner_');
    return send(send(self, 'basicNew'), 'setOrigin_corner_', [originPoint, cornerPoint]);
};
RectangleClass.prototype['origin_extent_'] = function(originPoint, extentPoint)
{
    var self = this;
    console.log('origin_extent_');
    return send(send(self, 'basicNew'), 'setOrigin_corner_', [originPoint, send(originPoint, '+', [extentPoint])]);
};
function HtmlCanvasClass()
{
}
function HtmlCanvas()
{
}
HtmlCanvas.prototype.__class = HtmlCanvasClass.prototype;
HtmlCanvas.classPrototype = HtmlCanvasClass.prototype;
HtmlCanvasClass.prototype['_basicNew'] = function() { return new HtmlCanvas(); };
HtmlCanvasClass.prototype.__proto__ = ObjectClass.prototype;
HtmlCanvas.prototype.__proto__ = Object.prototype;
HtmlCanvas.prototype.$response = null;
HtmlCanvasClass.__super = ObjectClass;
HtmlCanvas.__super = Object;
HtmlCanvas.prototype['write_'] = function(text)
{
    var self = this;
    console.log('write_');
    send(self.$response, 'write_', [text]);
};
HtmlCanvas.prototype['h1_'] = function(content)
{
    var self = this;
    console.log('h1_');
    send(self, 'write_', ['<h1>']);
    send(self, 'write_', [content]);
    send(self, 'write_', ['</h1>']);
};
HtmlCanvas.prototype['image_'] = function(url)
{
    var self = this;
    console.log('image_');
    send(self.$response, 'write_', ['<img src="']);
    send(self.$response, 'write_', [url]);
    send(self.$response, 'write_', ['">']);
};
function HtmlPageClass()
{
}
function HtmlPage()
{
}
HtmlPage.prototype.__class = HtmlPageClass.prototype;
HtmlPage.classPrototype = HtmlPageClass.prototype;
HtmlPageClass.prototype['_basicNew'] = function() { return new HtmlPage(); };
HtmlPageClass.prototype.__proto__ = ObjectClass.prototype;
HtmlPage.prototype.__proto__ = Object.prototype;
HtmlPageClass.__super = ObjectClass;
HtmlPage.__super = Object;
HtmlPage.prototype['render_'] = function(html)
{
    var self = this;
    console.log('render_');
    send(html, 'h1_', ['Hello, world']);
    send(html, 'image_', ['http://www.ajlopez.com/images/imagen.jpg']);
};

exports.ProtoObject = ProtoObject;
exports.Object = Object;
exports.MessageSend = MessageSend;
exports.UndefinedObject = UndefinedObject;
exports.Boolean = Boolean;
exports.False = False;
exports.True = True;
exports.WeakMessageSend = WeakMessageSend;
exports.WeakActionSequence = WeakActionSequence;
exports.Point = Point;
exports.Rectangle = Rectangle;
exports.HtmlCanvas = HtmlCanvas;
exports.HtmlPage = HtmlPage;
