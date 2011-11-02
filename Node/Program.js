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
ProtoObject.prototype['_executeMethod_'] = function(compiledMethod)
{
    var self = this;
    console.log('_executeMethod_');
    send(self, '_deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, '_withArgs_executeMethod_', [[], compiledMethod]);
};
ProtoObject.prototype['_with_executeMethod_'] = function(arg1, compiledMethod)
{
    var self = this;
    console.log('_with_executeMethod_');
    send(self, '_deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, '_withArgs_executeMethod_', [[arg1], compiledMethod]);
};
ProtoObject.prototype['_with_with_executeMethod_'] = function(arg1, arg2, compiledMethod)
{
    var self = this;
    console.log('_with_with_executeMethod_');
    send(self, '_deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, '_withArgs_executeMethod_', [[arg1, arg2], compiledMethod]);
};
ProtoObject.prototype['_with_with_with_executeMethod_'] = function(arg1, arg2, arg3, compiledMethod)
{
    var self = this;
    console.log('_with_with_with_executeMethod_');
    send(self, '_deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, '_withArgs_executeMethod_', [[arg1, arg2, arg3], compiledMethod]);
};
ProtoObject.prototype['_with_with_with_with_executeMethod_'] = function(arg1, arg2, arg3, arg4, compiledMethod)
{
    var self = this;
    console.log('_with_with_with_with_executeMethod_');
    send(self, '_deprecated_on_in_', ['use #withArgs:executeMethod:', '2011-04-27', 'Pharo1.3']);
    return send(self, '_withArgs_executeMethod_', [[arg1, arg2, arg3, arg4], compiledMethod]);
};
ProtoObject.prototype['_tryNamedPrimitive'] = function()
{
    var self = this;
    console.log('_tryNamedPrimitive');
    var _primitive = primitives.primitive0(self);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_'] = function(arg1)
{
    var self = this;
    console.log('_tryNamedPrimitive_');
    var _primitive = primitives.primitive0(self, arg1);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_'] = function(arg1, arg2)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_with_'] = function(arg1, arg2, arg3, arg4)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryNamedPrimitive_with_with_with_with_with_with_with_'] = function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)
{
    var self = this;
    console.log('_tryNamedPrimitive_with_with_with_with_with_with_with_');
    var _primitive = primitives.primitive0(self, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['_tryPrimitive_withArgs_'] = function(primIndex, argumentArray)
{
    var self = this;
    console.log('_tryPrimitive_withArgs_');
    var _primitive = primitives.primitive118(self, primIndex, argumentArray);
    if (_primitive) return _primitive.value;
    ;
    return send(ContextPart.classPrototype, '_primitiveFailToken');
};
ProtoObject.prototype['=='] = function(anObject)
{
    var self = this;
    console.log('==');
    var _primitive = primitives.primitive110(self, anObject);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
ProtoObject.prototype['_identityHash'] = function()
{
    var self = this;
    console.log('_identityHash');
    return send(send(self, '_basicIdentityHash'), '_bitShift_', [18]);
};
ProtoObject.prototype['~~'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('~~');
    send(send(self, '==', [anObject]), '_ifTrue_ifFalse_', [function() {
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
ProtoObject.prototype['_doOnlyOnce_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('_doOnlyOnce_');
    send(send(send(Smalltalk.classPrototype, '_globals'), '_at_ifAbsent_', ['OneShotArmed', function() {
        true;
    }
    ]), '_ifTrue_', [function() {
        send(send(Smalltalk.classPrototype, '_globals'), '_at_put_', ['OneShotArmed', false]);
        if (__context.return) return __context.value;
        send(aBlock, '_value');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ProtoObject.prototype['_flag_'] = function(aSymbol)
{
    var self = this;
    console.log('_flag_');
};
ProtoObject.prototype['_rearmOneShot'] = function()
{
    var self = this;
    console.log('_rearmOneShot');
    send(send(Smalltalk.classPrototype, '_globals'), '_at_put_', ['OneShotArmed', true]);
};
ProtoObject.prototype['_withArgs_executeMethod_'] = function(argArray, compiledMethod)
{
    var self = this;
    console.log('_withArgs_executeMethod_');
    var _primitive = primitives.primitive188(self, argArray, compiledMethod);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
ProtoObject.prototype['_initialize'] = function()
{
    var self = this;
    console.log('_initialize');
    return self;
};
ProtoObject.prototype['_rehash'] = function()
{
    var self = this;
    console.log('_rehash');
};
ProtoObject.prototype['_basicIdentityHash'] = function()
{
    var self = this;
    console.log('_basicIdentityHash');
    var _primitive = primitives.primitive75(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
ProtoObject.prototype['_become_'] = function(otherObject)
{
    var self = this;
    console.log('_become_');
    send(send(Array.classPrototype, '_with_', [self]), '_elementsExchangeIdentityWith_', [send(Array.classPrototype, '_with_', [otherObject])]);
};
ProtoObject.prototype['_cannotInterpret_'] = function(aMessage)
{
    var self = this;
    var __context = {};
    console.log('_cannotInterpret_');
    send(send(send(send(self, '_class'), '_lookupSelector_', [send(aMessage, '_selector')]), '==', [nil]), '_ifFalse_', [function() {
        __context.value = send(aMessage, '_sentTo_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Error.classPrototype, '_signal_', ['MethodDictionary fault']);
    if (__context.return) return __context.value;
    return send(aMessage, '_sentTo_', [self]);
};
ProtoObject.prototype['_doesNotUnderstand_'] = function(aMessage)
{
    var self = this;
    console.log('_doesNotUnderstand_');
    return send((function () {var _aux = send((function () {var _aux = send(send(MessageNotUnderstood.classPrototype, '_new'), '_message_', [aMessage]);return _aux;})(), '_receiver_', [self]);return _aux;})(), '_signal');
};
ProtoObject.prototype['_nextInstance'] = function()
{
    var self = this;
    console.log('_nextInstance');
    var _primitive = primitives.primitive78(self);
    if (_primitive) return _primitive.value;
    ;
    return nil;
};
ProtoObject.prototype['_nextObject'] = function()
{
    var self = this;
    console.log('_nextObject');
    var _primitive = primitives.primitive139(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
ProtoObject.prototype['_ifNil_'] = function(nilBlock)
{
    var self = this;
    console.log('_ifNil_');
    return self;
};
ProtoObject.prototype['_ifNil_ifNotNil_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('_ifNil_ifNotNil_');
    return send(ifNotNilBlock, '_cull_', [self]);
};
ProtoObject.prototype['_ifNotNil_'] = function(ifNotNilBlock)
{
    var self = this;
    console.log('_ifNotNil_');
    return send(ifNotNilBlock, '_cull_', [self]);
};
ProtoObject.prototype['_ifNotNil_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('_ifNotNil_ifNil_');
    return send(ifNotNilBlock, '_cull_', [self]);
};
ProtoObject.prototype['_isNil'] = function()
{
    var self = this;
    console.log('_isNil');
    return false;
};
ProtoObject.prototype['_pointersTo'] = function()
{
    var self = this;
    console.log('_pointersTo');
    return send(self, '_pointersToExcept_', [[]]);
};
ProtoObject.prototype['_pointersToExcept_'] = function(objectsToExclude)
{
    var self = this;
    var __context = {};
    console.log('_pointersToExcept_');
    var results = null
    var anObj = null
    send(Smalltalk.classPrototype, '_garbageCollect');
    if (__context.return) return __context.value;
    results = send(OrderedCollection.classPrototype, '_new_', [1000]);
    anObj = send(self, '_someObject');
    send(function() {
        send(0, '==', [anObj]);
        if (__context.return) return __context.value;
    }
    , '_whileFalse_', [function() {
        send(send(anObj, '_pointsTo_', [self]), '_ifTrue_', [function() {
            send(send(send(anObj, '~~', [send(results, '_collector')]), '_and_', [function() {
                send(send(anObj, '~~', [objectsToExclude]), '_and_', [function() {
                    send(send(anObj, '~~', [thisContext]), '_and_', [function() {
                        send(send(anObj, '~~', [send(thisContext, '_sender')]), '_and_', [function() {
                            send(anObj, '~~', [send(send(thisContext, '_sender'), '_sender')]);
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
            ]), '_ifTrue_', [function() {
                send(results, '_add_', [anObj]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        anObj = send(anObj, '_nextObject');
    }
    ]);
    if (__context.return) return __context.value;
    send(objectsToExclude, '_do_', [function(obj) {
        send(results, '_removeAllSuchThat_', [function(el) {
            send(el, '==', [obj]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(results, '_asArray');
};
ProtoObject.prototype['_pointsTo_'] = function(anObject)
{
    var self = this;
    console.log('_pointsTo_');
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
ObjectClass.DependentsFields = null;
Object.prototype['_printDirectlyToDisplay'] = function()
{
    var self = this;
    console.log('_printDirectlyToDisplay');
    send(send(self, '_asString'), '_displayAt_', [send(0, '@', [100])]);
};
Object.prototype['_addModelYellowButtonMenuItemsTo_forMorph_hand_'] = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    var __context = {};
    console.log('_addModelYellowButtonMenuItemsTo_forMorph_hand_');
    send(send(Morph.classPrototype, '_cmdGesturesEnabled'), '_ifTrue_', [function() {
        send(aCustomMenu, '_add_target_action_', [send('inspect model', '_translated'), self, 'inspect']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return aCustomMenu;
};
Object.prototype['_asDraggableMorph'] = function()
{
    var self = this;
    console.log('_asDraggableMorph');
    return send((function () {var _aux = send(send(StringMorph.classPrototype, '_contents_', [send(self, '_printString')]), '_color_', [send(Color.classPrototype, '_white')]);return _aux;})(), '_yourself');
};
Object.prototype['_asMorph'] = function()
{
    var self = this;
    console.log('_asMorph');
    return send(self, '_asStringMorph');
};
Object.prototype['_asStringMorph'] = function()
{
    var self = this;
    console.log('_asStringMorph');
    return send(send(self, '_asStringOrText'), '_asStringMorph');
};
Object.prototype['_asTextMorph'] = function()
{
    var self = this;
    console.log('_asTextMorph');
    return send(send(TextMorph.classPrototype, '_new'), '_contentsAsIs_', [send(self, '_asStringOrText')]);
};
Object.prototype['_currentEvent'] = function()
{
    var self = this;
    console.log('_currentEvent');
    return send(ActiveEvent.classPrototype, '_ifNil_', [function() {
        send(send(self, '_currentHand'), '_lastEvent');
    }
    ]);
};
Object.prototype['_currentHand'] = function()
{
    var self = this;
    console.log('_currentHand');
    return send(ActiveHand.classPrototype, '_ifNil_', [function() {
        send(send(self, '_currentWorld'), '_primaryHand');
    }
    ]);
};
Object.prototype['_currentWorld'] = function()
{
    var self = this;
    console.log('_currentWorld');
    return send(send(UIManager.classPrototype, '_default'), '_currentWorld');
};
Object.prototype['_externalName'] = function()
{
    var self = this;
    console.log('_externalName');
    return send(function() {
        send(send(send(self, '_asString'), '_copyWithout_', [send(Character.classPrototype, '_cr')]), '_truncateTo_', [27]);
    }
    , '_ifError_', [function() {
        __context.value = send(send(send(self, '_class'), '_name'), '_printString');
        __context.return = true;
        return __context.value;
    }
    ]);
};
Object.prototype['_hasModelYellowButtonMenuItems'] = function()
{
    var self = this;
    console.log('_hasModelYellowButtonMenuItems');
    return send(Morph.classPrototype, '_cmdGesturesEnabled');
};
Object.prototype['_iconOrThumbnailOfSize_'] = function(aNumberOrPoint)
{
    var self = this;
    console.log('_iconOrThumbnailOfSize_');
    return nil;
};
Object.prototype['_openAsMorph'] = function()
{
    var self = this;
    console.log('_openAsMorph');
    return send(send(self, '_asMorph'), '_openInHand');
};
Object.prototype['_when_send_to_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, aValueHolder)
{
    var self = this;
    console.log('_when_send_to_exclusive_');
    send(self, '_when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, '_receiver_selector_', [anObject, aMessageSelector]), '_basicExecuting_', [aValueHolder])]);
};
Object.prototype['_when_send_to_with_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, anArg, aValueHolder)
{
    var self = this;
    console.log('_when_send_to_with_exclusive_');
    send(self, '_when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, '_with_', [anArg])]), '_basicExecuting_', [aValueHolder])]);
};
Object.prototype['_when_send_to_withArguments_exclusive_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray, aValueHolder)
{
    var self = this;
    console.log('_when_send_to_withArguments_exclusive_');
    send(self, '_when_evaluate_', [anEventSelector, send(send(ExclusiveWeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray]), '_basicExecuting_', [aValueHolder])]);
};
Object.prototype['_when_sendOnce_to_'] = function(anEventSelector, aMessageSelector, anObject)
{
    var self = this;
    console.log('_when_sendOnce_to_');
    send(self, '_when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, '_receiver_selector_', [anObject, aMessageSelector])]);
};
Object.prototype['_when_sendOnce_to_with_'] = function(anEventSelector, aMessageSelector, anObject, anArg)
{
    var self = this;
    console.log('_when_sendOnce_to_with_');
    send(self, '_when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, '_with_', [anArg])])]);
};
Object.prototype['_when_sendOnce_to_withArguments_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray)
{
    var self = this;
    console.log('_when_sendOnce_to_withArguments_');
    send(self, '_when_evaluate_', [anEventSelector, send(NonReentrantWeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray])]);
};
Object.prototype['_okToClose'] = function()
{
    var self = this;
    console.log('_okToClose');
    return true;
};
Object.prototype['_taskbarIcon'] = function()
{
    var self = this;
    console.log('_taskbarIcon');
    return send(send(self, '_class'), '_taskbarIcon');
};
Object.prototype['_taskbarLabel'] = function()
{
    var self = this;
    console.log('_taskbarLabel');
    return send(send(self, '_class'), '_taskbarLabel');
};
Object.prototype['_windowActiveOnFirstClick'] = function()
{
    var self = this;
    console.log('_windowActiveOnFirstClick');
    return true;
};
Object.prototype['_comeFullyUpOnReload_'] = function(smartRefStream)
{
    var self = this;
    console.log('_comeFullyUpOnReload_');
    return self;
};
Object.prototype['_indexIfCompact'] = function()
{
    var self = this;
    console.log('_indexIfCompact');
    return 0;
};
Object.prototype['_objectForDataStream_'] = function(refStrm)
{
    var self = this;
    console.log('_objectForDataStream_');
    return self;
};
Object.prototype['_readDataFrom_size_'] = function(aDataStream, varsOnDisk)
{
    var self = this;
    var __context = {};
    console.log('_readDataFrom_size_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = send(send(self, '_class'), '_instSize');
    send(send(send(self, '_class'), '_isVariable'), '_ifTrue_ifFalse_', [function() {
        cntIndexedVars = send(varsOnDisk, '-', [cntInstVars]);
        send(send(cntIndexedVars, '<', [0]), '_ifTrue_', [function() {
            send(self, '_error_', ['Class has changed too much.  Define a convertxxx method']);
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
    send(aDataStream, '_beginReference_', [self]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [cntInstVars, function(i) {
        send(self, '_instVarAt_put_', [i, send(aDataStream, '_next')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [cntIndexedVars, function(i) {
        send(self, '_basicAt_put_', [i, send(aDataStream, '_next')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return self;
};
Object.prototype['_rootStubInImageSegment_'] = function(imageSegment)
{
    var self = this;
    console.log('_rootStubInImageSegment_');
    return send(send(ImageSegmentRootStub.classPrototype, '_new'), '_xxSuperclass_format_segment_', [nil, nil, imageSegment]);
};
Object.prototype['_storeDataOn_'] = function(aDataStream)
{
    var self = this;
    var __context = {};
    console.log('_storeDataOn_');
    var cntInstVars = null
    var cntIndexedVars = null
    cntInstVars = send(send(self, '_class'), '_instSize');
    cntIndexedVars = send(self, '_basicSize');
    send(aDataStream, '_beginInstance_size_', [send(self, '_class'), send(cntInstVars, '+', [cntIndexedVars])]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [cntInstVars, function(i) {
        send(aDataStream, '_nextPut_', [send(self, '_instVarAt_', [i])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(send(aDataStream, '_byteStream'), '_class'), '==', [DummyStream]), '_and_', [function() {
        send(send(self, '_class'), '_isBits');
        if (__context.return) return __context.value;
    }
    ]), '_ifFalse_', [function() {
        send(1, '_to_do_', [cntIndexedVars, function(i) {
            send(aDataStream, '_nextPut_', [send(self, '_basicAt_', [i])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_settingFixedDomainValueNodeFrom_'] = function(aSettingNode)
{
    var self = this;
    console.log('_settingFixedDomainValueNodeFrom_');
    return send(aSettingNode, '_fixedDomainValueNodeForObject_', [self]);
};
Object.prototype['_settingStoreOn_'] = function(aStream)
{
    var self = this;
    console.log('_settingStoreOn_');
    return send(self, '_storeOn_', [aStream]);
};
Object.prototype['_systemNavigation'] = function()
{
    var self = this;
    console.log('_systemNavigation');
    return send(SystemNavigation.classPrototype, '_default');
};
Object.prototype['_defaultBackgroundColor'] = function()
{
    var self = this;
    console.log('_defaultBackgroundColor');
    return send(send(UITheme.classPrototype, '_current'), '_windowColorFor_', [self]);
};
Object.prototype['_showDiffs'] = function()
{
    var self = this;
    console.log('_showDiffs');
    return false;
};
Object.prototype['_updateListsAndCodeIn_'] = function(aWindow)
{
    var self = this;
    var __context = {};
    console.log('_updateListsAndCodeIn_');
    send(send(self, '_canDiscardEdits'), '_ifFalse_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(aWindow, '_updatablePanes'), '_do_', [function(aPane) {
        send(aPane, '_verifyContents');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_browse'] = function()
{
    var self = this;
    console.log('_browse');
    send(send(self, '_systemNavigation'), '_browseClass_', [send(self, '_class')]);
};
Object.prototype['_browseHierarchy'] = function()
{
    var self = this;
    console.log('_browseHierarchy');
    send(send(self, '_systemNavigation'), '_browseHierarchy_', [send(self, '_class')]);
};
Object.prototype['_asExplorerString'] = function()
{
    var self = this;
    console.log('_asExplorerString');
    return send(self, '_printString');
};
Object.prototype['_customizeExplorerContents'] = function()
{
    var self = this;
    console.log('_customizeExplorerContents');
    return false;
};
Object.prototype['_explore'] = function()
{
    var self = this;
    console.log('_explore');
    return send(send(Smalltalk.classPrototype, '_tools'), '_explore_', [self]);
};
Object.prototype['_hasContentsInExplorer'] = function()
{
    var self = this;
    console.log('_hasContentsInExplorer');
    return send(send(send(self, '_basicSize'), '>', [0]), '_or_', [function() {
        send(send(send(self, '_class'), '_allInstVarNames'), '_notEmpty');
    }
    ]);
};
Object.prototype['_basicInspect'] = function()
{
    var self = this;
    console.log('_basicInspect');
    return send(send(Smalltalk.classPrototype, '_tools'), '_basicInspect_', [self]);
};
Object.prototype['_defaultLabelForInspector'] = function()
{
    var self = this;
    console.log('_defaultLabelForInspector');
    return send(send(self, '_class'), '_name');
};
Object.prototype['_doExpiredInspectCount'] = function()
{
    var self = this;
    console.log('_doExpiredInspectCount');
    send(self, '_clearHaltOnce');
    send(self, '_removeHaltCount');
    send(self, '_inspect');
};
Object.prototype['_inspect'] = function()
{
    var self = this;
    console.log('_inspect');
    send(send(Smalltalk.classPrototype, '_tools'), '_inspect_', [self]);
};
Object.prototype['_inspectOnCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('_inspectOnCount_');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(send(self, '_hasHaltCount'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_decrementAndCheckHaltCount'), '_ifTrue_', [function() {
                send(self, '_doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), '_ifTrue_ifFalse_', [function() {
                send(self, '_doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_setHaltCountTo_', [send(int, '-', [1])]);
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
Object.prototype['_inspectOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('_inspectOnce');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(self, '_clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, '_inspect');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_inspectUntilCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('_inspectUntilCount_');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(send(self, '_hasHaltCount'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_decrementAndCheckHaltCount'), '_ifTrue_ifFalse_', [function() {
                send(self, '_doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_inspect');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), '_ifTrue_ifFalse_', [function() {
                send(self, '_doExpiredInspectCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_setHaltCountTo_', [send(int, '-', [1])]);
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
Object.prototype['_inspectWithLabel_'] = function(aLabel)
{
    var self = this;
    console.log('_inspectWithLabel_');
    return send(send(Smalltalk.classPrototype, '_tools'), '_inspect_label_', [self, aLabel]);
};
Object.prototype['_inspectorClass'] = function()
{
    var self = this;
    console.log('_inspectorClass');
    return send(send(Smalltalk.classPrototype, '_tools'), '_inspector');
};
Object.prototype['_confirm_'] = function(queryString)
{
    var self = this;
    console.log('_confirm_');
    return send(send(UIManager.classPrototype, '_default'), '_confirm_', [queryString]);
};
Object.prototype['_inform_'] = function(aString)
{
    var self = this;
    var __context = {};
    console.log('_inform_');
    send(send(aString, '_isEmptyOrNil'), '_ifFalse_', [function() {
        send(send(UIManager.classPrototype, '_default'), '_inform_', [aString]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_primitiveError_'] = function(aString)
{
    var self = this;
    console.log('_primitiveError_');
    send(send(UIManager.classPrototype, '_default'), '_onPrimitiveError_', [aString]);
};
Object.prototype['_inline_'] = function(inlineFlag)
{
    var self = this;
    console.log('_inline_');
    send(self, '_deprecated_on_in_', ['Tag with the equivalent <inline::> pragma which is understood in recent VMMakers instead', '25 October 2010', 'Pharo1.2']);
};
Object.prototype['_var_declareC_'] = function(varSymbol, declString)
{
    var self = this;
    console.log('_var_declareC_');
    send(self, '_deprecated_on_in_', ['Tag with the equivalent <var:declareC:> pragma which is understood in recent VMMakers instead', '25 October 2010', 'Pharo1.2']);
};
Object.prototype['_exploreWithLabel_'] = function(label)
{
    var self = this;
    console.log('_exploreWithLabel_');
    return send(send(send(send(Smalltalk.classPrototype, '_tools'), '_objectExplorer'), '_new'), '_openExplorerFor_withLabel_', [self, label]);
};
Object.prototype['_notifyWithLabel_'] = function(aString)
{
    var self = this;
    console.log('_notifyWithLabel_');
    send(self, '_deprecated_on_in_', ['Do not use this method, instead use Warning or UIManager API', '28 January 2011', 'Pharo1.3']);
    return send(Warning.classPrototype, '_signal_', [aString]);
};
Object.prototype['_convertToCurrentVersion_refStream_'] = function(varDict, smartRefStrm)
{
    var self = this;
    console.log('_convertToCurrentVersion_refStream_');
};
Object.prototype['_at_'] = function(t1)
{
    var self = this;
    var __context = {};
    console.log('_at_');
    var _primitive = primitives.primitive60(self, t1);
    if (_primitive) return _primitive.value;
    ;
    send(send(t1, '_isInteger'), '_ifTrue_', [function() {
        send(send(send(self, '_class'), '_isVariable'), '_ifTrue_ifFalse_', [function() {
            send(self, '_errorSubscriptBounds_', [t1]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, '_errorNotIndexable');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(t1, '_isNumber'), '_ifTrue_', [function() {
        __context.value = send(self, '_at_', [send(t1, '_asInteger')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_errorNonIntegerIndex');
    if (__context.return) return __context.value;
};
Object.prototype['_at_modify_'] = function(index, aBlock)
{
    var self = this;
    console.log('_at_modify_');
    return send(self, '_at_put_', [index, send(aBlock, '_value_', [send(self, '_at_', [index])])]);
};
Object.prototype['_at_put_'] = function(t1, t2)
{
    var self = this;
    var __context = {};
    console.log('_at_put_');
    var _primitive = primitives.primitive61(self, t1, t2);
    if (_primitive) return _primitive.value;
    ;
    send(send(t1, '_isInteger'), '_ifTrue_', [function() {
        send(send(send(self, '_class'), '_isVariable'), '_ifTrue_ifFalse_', [function() {
            send(send(send(t1, '>=', [1]), '_and_', [function() {
                send(t1, '<=', [send(self, '_size')]);
                if (__context.return) return __context.value;
            }
            ]), '_ifTrue_ifFalse_', [function() {
                send(self, '_errorImproperStore');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_errorSubscriptBounds_', [t1]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, '_errorNotIndexable');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(t1, '_isNumber'), '_ifTrue_', [function() {
        __context.value = send(self, '_at_put_', [send(t1, '_asInteger'), t2]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_errorNonIntegerIndex');
    if (__context.return) return __context.value;
};
Object.prototype['_basicAt_'] = function(index)
{
    var self = this;
    var __context = {};
    console.log('_basicAt_');
    var _primitive = primitives.primitive60(self, index);
    if (_primitive) return _primitive.value;
    ;
    send(send(index, '_isInteger'), '_ifTrue_', [function() {
        send(self, '_errorSubscriptBounds_', [index]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(index, '_isNumber'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(self, '_basicAt_', [send(index, '_asInteger')]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        send(self, '_errorNonIntegerIndex');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_basicAt_put_'] = function(index, value)
{
    var self = this;
    var __context = {};
    console.log('_basicAt_put_');
    var _primitive = primitives.primitive61(self, index, value);
    if (_primitive) return _primitive.value;
    ;
    send(send(index, '_isInteger'), '_ifTrue_', [function() {
        send(send(send(index, '>=', [1]), '_and_', [function() {
            send(index, '<=', [send(self, '_size')]);
            if (__context.return) return __context.value;
        }
        ]), '_ifTrue_ifFalse_', [function() {
            send(self, '_errorImproperStore');
            if (__context.return) return __context.value;
        }
        , function() {
            send(self, '_errorSubscriptBounds_', [index]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(index, '_isNumber'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(self, '_basicAt_put_', [send(index, '_asInteger'), value]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        send(self, '_errorNonIntegerIndex');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_basicSize'] = function()
{
    var self = this;
    console.log('_basicSize');
    var _primitive = primitives.primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    return 0;
};
Object.prototype['_enclosedSetElement'] = function()
{
    var self = this;
    console.log('_enclosedSetElement');
};
Object.prototype['_ifNil_ifNotNilDo_'] = function(nilBlock, aBlock)
{
    var self = this;
    console.log('_ifNil_ifNotNilDo_');
    return send(aBlock, '_value_', [self]);
};
Object.prototype['_ifNotNilDo_'] = function(aBlock)
{
    var self = this;
    console.log('_ifNotNilDo_');
    return send(aBlock, '_value_', [self]);
};
Object.prototype['_ifNotNilDo_ifNil_'] = function(aBlock, nilBlock)
{
    var self = this;
    console.log('_ifNotNilDo_ifNil_');
    return send(aBlock, '_value_', [self]);
};
Object.prototype['_in_'] = function(aBlock)
{
    var self = this;
    console.log('_in_');
    return send(aBlock, '_value_', [self]);
};
Object.prototype['_readFromString_'] = function(aString)
{
    var self = this;
    console.log('_readFromString_');
    return send(self, '_readFrom_', [send(aString, '_readStream')]);
};
Object.prototype['_size'] = function()
{
    var self = this;
    var __context = {};
    console.log('_size');
    var _primitive = primitives.primitive62(self);
    if (_primitive) return _primitive.value;
    ;
    send(send(send(self, '_class'), '_isVariable'), '_ifFalse_', [function() {
        send(self, '_errorNotIndexable');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return 0;
};
Object.prototype['_yourself'] = function()
{
    var self = this;
    console.log('_yourself');
    return self;
};
Object.prototype['->'] = function(anObject)
{
    var self = this;
    console.log('->');
    return send(send(Association.classPrototype, '_basicNew'), '_key_value_', [self, anObject]);
};
Object.prototype['_bindingOf_'] = function(aString)
{
    var self = this;
    console.log('_bindingOf_');
    return nil;
};
Object.prototype['_break'] = function()
{
    var self = this;
    console.log('_break');
    send(BreakPoint.classPrototype, '_signal');
};
Object.prototype['_caseOf_'] = function(aBlockAssociationCollection)
{
    var self = this;
    console.log('_caseOf_');
    return send(self, '_caseOf_otherwise_', [aBlockAssociationCollection, function() {
        send(self, '_caseError');
    }
    ]);
};
Object.prototype['_caseOf_otherwise_'] = function(aBlockAssociationCollection, aBlock)
{
    var self = this;
    var __context = {};
    console.log('_caseOf_otherwise_');
    send(aBlockAssociationCollection, '_associationsDo_', [function(assoc) {
        send(send(send(send(assoc, '_key'), '_value'), '=', [self]), '_ifTrue_', [function() {
            __context.value = send(send(assoc, '_value'), '_value');
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(aBlock, '_value');
};
Object.prototype['_class'] = function()
{
    var self = this;
    console.log('_class');
    var _primitive = primitives.primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
Object.prototype['_isKindOf_'] = function(aClass)
{
    var self = this;
    var __context = {};
    console.log('_isKindOf_');
    send(send(send(self, '_class'), '==', [aClass]), '_ifTrue_ifFalse_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(send(self, '_class'), '_inheritsFrom_', [aClass]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_isMemberOf_'] = function(aClass)
{
    var self = this;
    console.log('_isMemberOf_');
    return send(send(self, '_class'), '==', [aClass]);
};
Object.prototype['_respondsTo_'] = function(aSymbol)
{
    var self = this;
    console.log('_respondsTo_');
    return send(send(self, '_class'), '_canUnderstand_', [aSymbol]);
};
Object.prototype['_xxxClass'] = function()
{
    var self = this;
    console.log('_xxxClass');
    return send(self, '_class');
};
Object.prototype['_closeTo_'] = function(anObject)
{
    var self = this;
    console.log('_closeTo_');
    return send(function() {
        send(self, '=', [anObject]);
    }
    , '_ifError_', [function() {
        false;
    }
    ]);
};
Object.prototype['_hash'] = function()
{
    var self = this;
    console.log('_hash');
    return send(self, '_identityHash');
};
Object.prototype['_identityHashPrintString'] = function()
{
    var self = this;
    console.log('_identityHashPrintString');
    return send(send('(', ',', [send(send(self, '_identityHash'), '_printString')]), ',', [')']);
};
Object.prototype['_literalEqual_'] = function(other)
{
    var self = this;
    console.log('_literalEqual_');
    return send(send(send(self, '_class'), '==', [send(other, '_class')]), '_and_', [function() {
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
Object.prototype['_adaptToFloat_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToFloat_andCompare_');
    return send(self, '_adaptToFloat_andSend_', [rcvr, selector]);
};
Object.prototype['_adaptToFloat_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToFloat_andSend_');
    return send(self, '_adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['_adaptToFraction_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToFraction_andCompare_');
    return send(self, '_adaptToFraction_andSend_', [rcvr, selector]);
};
Object.prototype['_adaptToFraction_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToFraction_andSend_');
    return send(self, '_adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['_adaptToInteger_andCompare_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToInteger_andCompare_');
    return send(self, '_adaptToInteger_andSend_', [rcvr, selector]);
};
Object.prototype['_adaptToInteger_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToInteger_andSend_');
    return send(self, '_adaptToNumber_andSend_', [rcvr, selector]);
};
Object.prototype['_asActionSequence'] = function()
{
    var self = this;
    console.log('_asActionSequence');
    return send(WeakActionSequence.classPrototype, '_with_', [self]);
};
Object.prototype['_asActionSequenceTrappingErrors'] = function()
{
    var self = this;
    console.log('_asActionSequenceTrappingErrors');
    return send(WeakActionSequenceTrappingErrors.classPrototype, '_with_', [self]);
};
Object.prototype['_asLink'] = function()
{
    var self = this;
    console.log('_asLink');
    return send(ValueLink.classPrototype, '_value_', [self]);
};
Object.prototype['_asOrderedCollection'] = function()
{
    var self = this;
    console.log('_asOrderedCollection');
    return send(OrderedCollection.classPrototype, '_with_', [self]);
};
Object.prototype['_asSetElement'] = function()
{
    var self = this;
    console.log('_asSetElement');
};
Object.prototype['_asString'] = function()
{
    var self = this;
    console.log('_asString');
    return send(self, '_printString');
};
Object.prototype['_asStringOrText'] = function()
{
    var self = this;
    console.log('_asStringOrText');
    return send(self, '_printString');
};
Object.prototype['_as_'] = function(aSimilarClass)
{
    var self = this;
    console.log('_as_');
    return send(aSimilarClass, '_newFrom_', [self]);
};
Object.prototype['_complexContents'] = function()
{
    var self = this;
    console.log('_complexContents');
    return self;
};
Object.prototype['_mustBeBoolean'] = function()
{
    var self = this;
    console.log('_mustBeBoolean');
    return send(self, '_mustBeBooleanIn_', [send(thisContext, '_sender')]);
};
Object.prototype['_mustBeBooleanIn_'] = function(context)
{
    var self = this;
    console.log('_mustBeBooleanIn_');
    var proceedValue = null
    send(context, '_skipBackBeforeJump');
    proceedValue = send((function () {var _aux = send(send(NonBooleanReceiver.classPrototype, '_new'), '_object_', [self]);return _aux;})(), '_signal_', ['proceed for truth.']);
    return send(proceedValue, '~~', [false]);
};
Object.prototype['_withoutListWrapper'] = function()
{
    var self = this;
    console.log('_withoutListWrapper');
    return self;
};
Object.prototype['_copy'] = function()
{
    var self = this;
    console.log('_copy');
    return send(send(self, '_shallowCopy'), '_postCopy');
};
Object.prototype['_copyFrom_'] = function(anotherObject)
{
    var self = this;
    var __context = {};
    console.log('_copyFrom_');
    var mine = null
    var his = null
    var _primitive = primitives.primitive168(self, anotherObject);
    if (_primitive) return _primitive.value;
    ;
    mine = send(send(self, '_class'), '_allInstVarNames');
    his = send(send(anotherObject, '_class'), '_allInstVarNames');
    send(1, '_to_do_', [send(send(mine, '_size'), '_min_', [send(his, '_size')]), function(ind) {
        send(send(send(mine, '_at_', [ind]), '=', [send(his, '_at_', [ind])]), '_ifTrue_', [function() {
            send(self, '_instVarAt_put_', [ind, send(anotherObject, '_instVarAt_', [ind])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, '_class'), '_isVariable'), '&', [send(send(anotherObject, '_class'), '_isVariable')]), '_ifTrue_', [function() {
        send(1, '_to_do_', [send(send(self, '_basicSize'), '_min_', [send(anotherObject, '_basicSize')]), function(ind) {
            send(self, '_basicAt_put_', [ind, send(anotherObject, '_basicAt_', [ind])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_copySameFrom_'] = function(otherObject)
{
    var self = this;
    var __context = {};
    console.log('_copySameFrom_');
    var myInstVars = null
    var otherInstVars = null
    myInstVars = send(send(self, '_class'), '_allInstVarNames');
    otherInstVars = send(send(otherObject, '_class'), '_allInstVarNames');
    send(myInstVars, '_doWithIndex_', [function(each, index) {
        var match = null;
        send(send(match = send(otherInstVars, '_indexOf_', [each]), '>', [0]), '_ifTrue_', [function() {
            send(self, '_instVarAt_put_', [index, send(otherObject, '_instVarAt_', [match])]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [send(send(self, '_basicSize'), '_min_', [send(otherObject, '_basicSize')]), function(i) {
        send(self, '_basicAt_put_', [i, send(otherObject, '_basicAt_', [i])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_copyTwoLevel'] = function()
{
    var self = this;
    var __context = {};
    console.log('_copyTwoLevel');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = send(self, '_class');
    newObject = send(self, '_shallowCopy');
    send(send(newObject, '==', [self]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(__class__, '_isVariable'), '_ifTrue_', [function() {
        index = send(self, '_basicSize');
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , '_whileTrue_', [function() {
            send(newObject, '_basicAt_put_', [index, send(send(self, '_basicAt_', [index]), '_shallowCopy')]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, '_instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , '_whileTrue_', [function() {
        send(newObject, '_instVarAt_put_', [index, send(send(self, '_instVarAt_', [index]), '_shallowCopy')]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['_deepCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('_deepCopy');
    var newObject = null
    var __class__ = null
    var index = null
    __class__ = send(self, '_class');
    send(send(__class__, '==', [Object]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(__class__, '_isVariable'), '_ifTrue_ifFalse_', [function() {
        index = send(self, '_basicSize');
        newObject = send(__class__, '_basicNew_', [index]);
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , '_whileTrue_', [function() {
            send(newObject, '_basicAt_put_', [index, send(send(self, '_basicAt_', [index]), '_deepCopy')]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        newObject = send(__class__, '_basicNew');
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, '_instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , '_whileTrue_', [function() {
        send(newObject, '_instVarAt_put_', [index, send(send(self, '_instVarAt_', [index]), '_deepCopy')]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['_postCopy'] = function()
{
    var self = this;
    console.log('_postCopy');
    return self;
};
Object.prototype['_shallowCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('_shallowCopy');
    var __class__ = null
    var newObject = null
    var index = null
    var _primitive = primitives.primitive148(self);
    if (_primitive) return _primitive.value;
    ;
    __class__ = send(self, '_class');
    send(send(__class__, '_isVariable'), '_ifTrue_ifFalse_', [function() {
        index = send(self, '_basicSize');
        newObject = send(__class__, '_basicNew_', [index]);
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , '_whileTrue_', [function() {
            send(newObject, '_basicAt_put_', [index, send(self, '_basicAt_', [index])]);
            if (__context.return) return __context.value;
            index = send(index, '-', [1]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        newObject = send(__class__, '_basicNew');
    }
    ]);
    if (__context.return) return __context.value;
    index = send(__class__, '_instSize');
    send(function() {
        send(index, '>', [0]);
        if (__context.return) return __context.value;
    }
    , '_whileTrue_', [function() {
        send(newObject, '_instVarAt_put_', [index, send(self, '_instVarAt_', [index])]);
        if (__context.return) return __context.value;
        index = send(index, '-', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    return newObject;
};
Object.prototype['_veryDeepCopy'] = function()
{
    var self = this;
    var __context = {};
    console.log('_veryDeepCopy');
    var copier = null
    var __new__ = null
    copier = send(send(DeepCopier.classPrototype, '_new'), '_initialize_', [4096]);
    __new__ = send(self, '_veryDeepCopyWith_', [copier]);
    send(send(copier, '_references'), '_associationsDo_', [function(assoc) {
        send(send(assoc, '_value'), '_veryDeepFixupWith_', [copier]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(copier, '_fixDependents');
    if (__context.return) return __context.value;
    return __new__;
};
Object.prototype['_veryDeepCopyUsing_'] = function(copier)
{
    var self = this;
    var __context = {};
    console.log('_veryDeepCopyUsing_');
    var __new__ = null
    var refs = null
    __new__ = send(self, '_veryDeepCopyWith_', [copier]);
    send(send(copier, '_references'), '_associationsDo_', [function(assoc) {
        send(send(assoc, '_value'), '_veryDeepFixupWith_', [copier]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    refs = send(copier, '_references');
    send(DependentsFields.classPrototype, '_associationsDo_', [function(pair) {
        send(send(pair, '_value'), '_do_', [function(dep) {
            var newModel = null;
            var newDep = null;
            send(newDep = send(refs, '_at_ifAbsent_', [dep, function() {
                nil;
            }
            ]), '_ifNotNil_', [function() {
                newModel = send(refs, '_at_ifAbsent_', [send(pair, '_key'), function() {
                    send(pair, '_key');
                    if (__context.return) return __context.value;
                }
                ]);
                send(newModel, '_addDependent_', [newDep]);
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
Object.prototype['_veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    var __context = {};
    console.log('_veryDeepCopyWith_');
    var __class__ = null
    var index = null
    var sub = null
    var subAss = null
    var __new__ = null
    var sup = null
    var has = null
    var mine = null
    send(send(deepCopier, '_references'), '_at_ifPresent_', [self, function(newer) {
        __context.value = newer;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    __class__ = send(self, '_class');
    send(send(__class__, '_isMeta'), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    __new__ = send(self, '_shallowCopy');
    send(send(deepCopier, '_references'), '_at_put_', [self, __new__]);
    if (__context.return) return __context.value;
    send(send(send(__class__, '_isVariable'), '_and_', [function() {
        send(__class__, '_isPointers');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        index = send(self, '_basicSize');
        send(function() {
            send(index, '>', [0]);
            if (__context.return) return __context.value;
        }
        , '_whileTrue_', [function() {
            sub = send(self, '_basicAt_', [index]);
            send(subAss = send(send(deepCopier, '_references'), '_associationAt_ifAbsent_', [sub, function() {
                nil;
            }
            ]), '_ifNil_ifNotNil_', [function() {
                send(__new__, '_basicAt_put_', [index, send(sub, '_veryDeepCopyWith_', [deepCopier])]);
                if (__context.return) return __context.value;
            }
            , function() {
                send(__new__, '_basicAt_put_', [index, send(subAss, '_value')]);
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
    send(__new__, '_veryDeepInner_', [deepCopier]);
    if (__context.return) return __context.value;
    sup = __class__;
    index = send(__class__, '_instSize');
    send(function() {
        has = send(sup, '_compiledMethodAt_ifAbsent_', ['veryDeepInner:', function() {
            nil;
        }
        ]);
        has = send(has, '_ifNil_ifNotNil_', [function() {
            false;
        }
        , function() {
            true;
        }
        ]);
        mine = send(sup, '_instVarNames');
        send(has, '_ifTrue_ifFalse_', [function() {
            index = send(index, '-', [send(mine, '_size')]);
        }
        , function() {
            send(1, '_to_do_', [send(mine, '_size'), function(xx) {
                sub = send(self, '_instVarAt_', [index]);
                send(subAss = send(send(deepCopier, '_references'), '_associationAt_ifAbsent_', [sub, function() {
                    nil;
                }
                ]), '_ifNil_ifNotNil_', [function() {
                    send(__new__, '_instVarAt_put_', [index, send(sub, '_veryDeepCopyWith_', [deepCopier])]);
                    if (__context.return) return __context.value;
                }
                , function() {
                    send(__new__, '_instVarAt_put_', [index, send(subAss, '_value')]);
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
        send(sup = send(sup, '_superclass'), '==', [nil]);
        if (__context.return) return __context.value;
    }
    , '_whileFalse');
    if (__context.return) return __context.value;
    send(__new__, '_rehash');
    if (__context.return) return __context.value;
    return __new__;
};
Object.prototype['_veryDeepFixupWith_'] = function(deepCopier)
{
    var self = this;
    console.log('_veryDeepFixupWith_');
};
Object.prototype['_veryDeepInner_'] = function(deepCopier)
{
    var self = this;
    console.log('_veryDeepInner_');
};
Object.prototype['_haltIf_'] = function(condition)
{
    var self = this;
    var __context = {};
    console.log('_haltIf_');
    var cntxt = null
    send(send(condition, '_isSymbol'), '_ifTrue_', [function() {
        cntxt = thisContext;
        send(function() {
            send(send(cntxt, '_sender'), '_isNil');
            if (__context.return) return __context.value;
        }
        , '_whileFalse_', [function() {
            cntxt = send(cntxt, '_sender');
            send(send(send(cntxt, '_selector'), '=', [condition]), '_ifTrue_', [function() {
                send(Halt.classPrototype, '_signal');
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
    send(send(send(condition, '_isBlock'), '_ifTrue_ifFalse_', [function() {
        send(condition, '_cull_', [self]);
        if (__context.return) return __context.value;
    }
    , function() {
        condition;
    }
    ]), '_ifTrue_', [function() {
        send(Halt.classPrototype, '_signal');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_needsWork'] = function()
{
    var self = this;
    console.log('_needsWork');
};
Object.prototype['_checkHaltCountExpired'] = function()
{
    var self = this;
    console.log('_checkHaltCountExpired');
    var counter = null
    counter = send(send(Smalltalk.classPrototype, '_globals'), '_at_ifAbsent_', ['HaltCount', function() {
        0;
    }
    ]);
    return send(counter, '=', [0]);
};
Object.prototype['_clearHaltOnce'] = function()
{
    var self = this;
    console.log('_clearHaltOnce');
    send(send(Smalltalk.classPrototype, '_globals'), '_at_put_', ['HaltOnce', false]);
};
Object.prototype['_decrementAndCheckHaltCount'] = function()
{
    var self = this;
    console.log('_decrementAndCheckHaltCount');
    send(self, '_decrementHaltCount');
    return send(self, '_checkHaltCountExpired');
};
Object.prototype['_decrementHaltCount'] = function()
{
    var self = this;
    var __context = {};
    console.log('_decrementHaltCount');
    var counter = null
    counter = send(send(Smalltalk.classPrototype, '_globals'), '_at_ifAbsent_', ['HaltCount', function() {
        0;
    }
    ]);
    send(send(counter, '>', [0]), '_ifTrue_', [function() {
        counter = send(counter, '-', [1]);
        send(self, '_setHaltCountTo_', [counter]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_doExpiredHaltCount'] = function()
{
    var self = this;
    console.log('_doExpiredHaltCount');
    send(self, '_clearHaltOnce');
    send(self, '_removeHaltCount');
    send(self, '_halt');
};
Object.prototype['_doExpiredHaltCount_'] = function(aString)
{
    var self = this;
    console.log('_doExpiredHaltCount_');
    send(self, '_clearHaltOnce');
    send(self, '_removeHaltCount');
    send(self, '_halt_', [aString]);
};
Object.prototype['_halt_onCount_'] = function(aString, int)
{
    var self = this;
    var __context = {};
    console.log('_halt_onCount_');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(send(self, '_hasHaltCount'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_decrementAndCheckHaltCount'), '_ifTrue_', [function() {
                send(self, '_doExpiredHaltCount_', [aString]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), '_ifTrue_ifFalse_', [function() {
                send(self, '_doExpiredHaltCount_', [aString]);
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_setHaltCountTo_', [send(int, '-', [1])]);
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
Object.prototype['_haltOnCount_'] = function(int)
{
    var self = this;
    var __context = {};
    console.log('_haltOnCount_');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(send(self, '_hasHaltCount'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_decrementAndCheckHaltCount'), '_ifTrue_', [function() {
                send(self, '_doExpiredHaltCount');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            send(send(int, '=', [1]), '_ifTrue_ifFalse_', [function() {
                send(self, '_doExpiredHaltCount');
                if (__context.return) return __context.value;
            }
            , function() {
                send(self, '_setHaltCountTo_', [send(int, '-', [1])]);
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
Object.prototype['_haltOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('_haltOnce');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(self, '_clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, '_halt');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_haltOnce_'] = function(aString)
{
    var self = this;
    var __context = {};
    console.log('_haltOnce_');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_', [function() {
        send(self, '_clearHaltOnce');
        if (__context.return) return __context.value;
        __context.value = send(self, '_halt_', [aString]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_haltOnceEnabled'] = function()
{
    var self = this;
    console.log('_haltOnceEnabled');
    return send(send(Smalltalk.classPrototype, '_globals'), '_at_ifAbsent_', ['HaltOnce', function() {
        false;
    }
    ]);
};
Object.prototype['_hasHaltCount'] = function()
{
    var self = this;
    console.log('_hasHaltCount');
    return send(send(Smalltalk.classPrototype, '_globals'), '_includesKey_', ['HaltCount']);
};
Object.prototype['_removeHaltCount'] = function()
{
    var self = this;
    var __context = {};
    console.log('_removeHaltCount');
    send(send(send(Smalltalk.classPrototype, '_globals'), '_includesKey_', ['HaltCount']), '_ifTrue_', [function() {
        send(send(Smalltalk.classPrototype, '_globals'), '_removeKey_', ['HaltCount']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_setHaltCountTo_'] = function(int)
{
    var self = this;
    console.log('_setHaltCountTo_');
    send(send(Smalltalk.classPrototype, '_globals'), '_at_put_', ['HaltCount', int]);
};
Object.prototype['_setHaltOnce'] = function()
{
    var self = this;
    console.log('_setHaltOnce');
    send(send(Smalltalk.classPrototype, '_globals'), '_at_put_', ['HaltOnce', true]);
};
Object.prototype['_toggleHaltOnce'] = function()
{
    var self = this;
    var __context = {};
    console.log('_toggleHaltOnce');
    send(send(self, '_haltOnceEnabled'), '_ifTrue_ifFalse_', [function() {
        send(self, '_clearHaltOnce');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self, '_setHaltOnce');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_addDependent_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('_addDependent_');
    var dependents = null
    dependents = send(self, '_dependents');
    send(send(dependents, '_includes_', [anObject]), '_ifFalse_', [function() {
        send(self, '_myDependents_', [send(dependents, '_copyWithDependent_', [anObject])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return anObject;
};
Object.prototype['_breakDependents'] = function()
{
    var self = this;
    console.log('_breakDependents');
    send(self, '_myDependents_', [nil]);
};
Object.prototype['_canDiscardEdits'] = function()
{
    var self = this;
    var __context = {};
    console.log('_canDiscardEdits');
    send(send(self, '_dependents'), '_do_without_', [function(each) {
        send(send(each, '_canDiscardEdits'), '_ifFalse_', [function() {
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
Object.prototype['_dependents'] = function()
{
    var self = this;
    console.log('_dependents');
    return send(send(self, '_myDependents'), '_ifNil_', [function() {
        [];
    }
    ]);
};
Object.prototype['_hasUnacceptedEdits'] = function()
{
    var self = this;
    var __context = {};
    console.log('_hasUnacceptedEdits');
    send(send(self, '_dependents'), '_do_without_', [function(each) {
        send(send(each, '_hasUnacceptedEdits'), '_ifTrue_', [function() {
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
Object.prototype['_myDependents'] = function()
{
    var self = this;
    console.log('_myDependents');
    return send(DependentsFields.classPrototype, '_at_ifAbsent_', [self, function() {
    }
    ]);
};
Object.prototype['_myDependents_'] = function(aCollectionOrNil)
{
    var self = this;
    var __context = {};
    console.log('_myDependents_');
    send(aCollectionOrNil, '_ifNil_ifNotNil_', [function() {
        send(DependentsFields.classPrototype, '_removeKey_ifAbsent_', [self, function() {
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(DependentsFields.classPrototype, '_at_put_', [self, aCollectionOrNil]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_release'] = function()
{
    var self = this;
    console.log('_release');
    send(self, '_releaseActionMap');
};
Object.prototype['_removeDependent_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('_removeDependent_');
    var dependents = null
    dependents = send(send(self, '_dependents'), '_reject_', [function(each) {
        send(each, '==', [anObject]);
        if (__context.return) return __context.value;
    }
    ]);
    send(self, '_myDependents_', [send(send(dependents, '_isEmpty'), '_ifFalse_', [function() {
        dependents;
    }
    ])]);
    if (__context.return) return __context.value;
    return anObject;
};
Object.prototype['_acceptDroppingMorph_event_inMorph_'] = function(transferMorph, evt, dstListMorph)
{
    var self = this;
    console.log('_acceptDroppingMorph_event_inMorph_');
    return false;
};
Object.prototype['_dragPassengerFor_inMorph_'] = function(item, dragSource)
{
    var self = this;
    console.log('_dragPassengerFor_inMorph_');
    return item;
};
Object.prototype['_dragTransferType'] = function()
{
    var self = this;
    console.log('_dragTransferType');
    return nil;
};
Object.prototype['_dragTransferTypeForMorph_'] = function(dragSource)
{
    var self = this;
    console.log('_dragTransferTypeForMorph_');
    return nil;
};
Object.prototype['_wantsDroppedMorph_event_inMorph_'] = function(aMorph, anEvent, destinationLM)
{
    var self = this;
    console.log('_wantsDroppedMorph_event_inMorph_');
    return false;
};
Object.prototype['_assert_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('_assert_');
    send(send(aBlock, '_value'), '_ifFalse_', [function() {
        send(AssertionFailure.classPrototype, '_signal_', ['Assertion failed']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_assert_descriptionBlock_'] = function(aBlock, descriptionBlock)
{
    var self = this;
    var __context = {};
    console.log('_assert_descriptionBlock_');
    send(send(aBlock, '_value'), '_ifFalse_', [function() {
        send(AssertionFailure.classPrototype, '_signal_', [send(send(descriptionBlock, '_value'), '_asString')]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_assert_description_'] = function(aBlock, aString)
{
    var self = this;
    var __context = {};
    console.log('_assert_description_');
    send(send(aBlock, '_value'), '_ifFalse_', [function() {
        send(AssertionFailure.classPrototype, '_signal_', [aString]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_caseError'] = function()
{
    var self = this;
    console.log('_caseError');
    send(self, '_error_', [send(send('Case not found (', ',', [send(self, '_printString')]), ',', ['), and no otherwise clause'])]);
};
Object.prototype['_confirm_orCancel_'] = function(aString, cancelBlock)
{
    var self = this;
    console.log('_confirm_orCancel_');
    return send(send(UIManager.classPrototype, '_default'), '_confirm_orCancel_', [aString, cancelBlock]);
};
Object.prototype['_deprecated_'] = function(anExplanationString)
{
    var self = this;
    console.log('_deprecated_');
    send(send(Deprecation.classPrototype, '_method_explanation_on_in_', [send(send(thisContext, '_sender'), '_method'), anExplanationString, nil, nil]), '_signal');
};
Object.prototype['_deprecated_on_in_'] = function(anExplanationString, date, version)
{
    var self = this;
    console.log('_deprecated_on_in_');
    send(send(Deprecation.classPrototype, '_method_explanation_on_in_', [send(send(thisContext, '_sender'), '_method'), anExplanationString, date, version]), '_signal');
};
Object.prototype['_doesNotUnderstand_'] = function(aMessage)
{
    var self = this;
    console.log('_doesNotUnderstand_');
    var exception = null
    var resumeValue = null
    send((function () {var _aux = send(exception = send(MessageNotUnderstood.classPrototype, '_new'), '_message_', [aMessage]);return _aux;})(), '_receiver_', [self]);
    resumeValue = send(exception, '_signal');
    return send(send(exception, '_reachedDefaultHandler'), '_ifTrue_ifFalse_', [function() {
        send(aMessage, '_sentTo_', [self]);
    }
    , function() {
        resumeValue;
    }
    ]);
};
Object.prototype['_dpsTrace_'] = function(reportObject)
{
    var self = this;
    var __context = {};
    console.log('_dpsTrace_');
    send(send(send(Transcript.classPrototype, '_myDependents'), '_isNil'), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_dpsTrace_levels_withContext_', [reportObject, 1, thisContext]);
    if (__context.return) return __context.value;
};
Object.prototype['_dpsTrace_levels_'] = function(reportObject, anInt)
{
    var self = this;
    console.log('_dpsTrace_levels_');
    send(self, '_dpsTrace_levels_withContext_', [reportObject, anInt, thisContext]);
};
Object.prototype['_dpsTrace_levels_withContext_'] = function(reportObject, anInt, currentContext)
{
    var self = this;
    var __context = {};
    console.log('_dpsTrace_levels_withContext_');
    var reportString = null
    var context = null
    var displayCount = null
    reportString = send(send(reportObject, '_respondsTo_', ['asString']), '_ifTrue_ifFalse_', [function() {
        send(reportObject, '_asString');
        if (__context.return) return __context.value;
    }
    , function() {
        send(reportObject, '_printString');
        if (__context.return) return __context.value;
    }
    ]);
    send(send(send(Smalltalk.classPrototype, '_globals'), '_at_ifAbsent_', ['Decompiler', function() {
        nil;
    }
    ]), '_ifNil_ifNotNil_', [function() {
        send((function () {var _aux = send(Transcript.classPrototype, '_cr');return _aux;})(), '_show_', [reportString]);
        if (__context.return) return __context.value;
    }
    , function() {
        context = currentContext;
        displayCount = send(anInt, '>', [1]);
        send(1, '_to_do_', [anInt, function(count) {
            send(Transcript.classPrototype, '_cr');
            if (__context.return) return __context.value;
            send(displayCount, '_ifTrue_', [function() {
                send(Transcript.classPrototype, '_show_', [send(send(count, '_printString'), ',', [': '])]);
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
            send(send(reportString, '_notNil'), '_ifTrue_ifFalse_', [function() {
                send(Transcript.classPrototype, '_show_', [send(send(send(send(send(send(send(send(context, '_home'), '_class'), '_name'), ',', ['/']), ',', [send(send(context, '_sender'), '_selector')]), ',', [' (']), ',', [reportString]), ',', [')'])]);
                if (__context.return) return __context.value;
                context = send(context, '_sender');
                reportString = nil;
            }
            , function() {
                send(send(send(context, '_notNil'), '_and_', [function() {
                    send(context = send(context, '_sender'), '_notNil');
                    if (__context.return) return __context.value;
                }
                ]), '_ifTrue_', [function() {
                    send(Transcript.classPrototype, '_show_', [send(send(send(send(send(context, '_receiver'), '_class'), '_name'), ',', ['/']), ',', [send(context, '_selector')])]);
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
Object.prototype['_error'] = function()
{
    var self = this;
    console.log('_error');
    return send(self, '_error_', ['Error!']);
};
Object.prototype['_error_'] = function(aString)
{
    var self = this;
    console.log('_error_');
    return send(send(Error.classPrototype, '_new'), '_signal_', [aString]);
};
Object.prototype['_explicitRequirement'] = function()
{
    var self = this;
    console.log('_explicitRequirement');
    send(self, '_error_', ['Explicitly required method']);
};
Object.prototype['_halt'] = function()
{
    var self = this;
    console.log('_halt');
    send(Halt.classPrototype, '_signal');
};
Object.prototype['_halt_'] = function(aString)
{
    var self = this;
    console.log('_halt_');
    send(send(Halt.classPrototype, '_new'), '_signal_', [aString]);
};
Object.prototype['_haltIfShiftPressed'] = function()
{
    var self = this;
    var __context = {};
    console.log('_haltIfShiftPressed');
    send(self, '_haltIf_', [function() {
        send(Sensor.classPrototype, '_shiftPressed');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_handles_'] = function(exception)
{
    var self = this;
    console.log('_handles_');
    return false;
};
Object.prototype['_notify_'] = function(aString)
{
    var self = this;
    console.log('_notify_');
    send(Warning.classPrototype, '_signal_', [aString]);
};
Object.prototype['_notify_at_'] = function(aString, location)
{
    var self = this;
    console.log('_notify_at_');
    send(self, '_notify_', [aString]);
};
Object.prototype['_primitiveFail'] = function()
{
    var self = this;
    console.log('_primitiveFail');
    return send(self, '_primitiveFailed');
};
Object.prototype['_primitiveFailed'] = function()
{
    var self = this;
    console.log('_primitiveFailed');
    send(self, '_primitiveFailed_', [send(send(thisContext, '_sender'), '_selector')]);
};
Object.prototype['_primitiveFailed_'] = function(selector)
{
    var self = this;
    console.log('_primitiveFailed_');
    send(PrimitiveFailed.classPrototype, '_signalFor_', [selector]);
};
Object.prototype['_requirement'] = function()
{
    var self = this;
    console.log('_requirement');
    send(self, '_error_', ['Implicitly required method']);
};
Object.prototype['_shouldBeImplemented'] = function()
{
    var self = this;
    console.log('_shouldBeImplemented');
    send(ShouldBeImplemented.classPrototype, '_signalFor_', [send(send(thisContext, '_sender'), '_selector')]);
};
Object.prototype['_shouldNotImplement'] = function()
{
    var self = this;
    console.log('_shouldNotImplement');
    send(ShouldNotImplement.classPrototype, '_signalFor_', [send(send(thisContext, '_sender'), '_selector')]);
};
Object.prototype['_subclassResponsibility'] = function()
{
    var self = this;
    console.log('_subclassResponsibility');
    send(SubclassResponsibility.classPrototype, '_signalFor_', [send(send(thisContext, '_sender'), '_selector')]);
};
Object.prototype['_traitConflict'] = function()
{
    var self = this;
    console.log('_traitConflict');
    send(self, '_error_', ['A class or trait does not properly resolve a conflict between multiple traits it uses.']);
};
Object.prototype['_value'] = function()
{
    var self = this;
    console.log('_value');
    return self;
};
Object.prototype['_valueWithArguments_'] = function(aSequenceOfArguments)
{
    var self = this;
    console.log('_valueWithArguments_');
    return self;
};
Object.prototype['_actionForEvent_'] = function(anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_actionForEvent_');
    var actions = null
    actions = send(send(self, '_actionMap'), '_at_ifAbsent_', [send(anEventSelector, '_asSymbol'), function() {
        nil;
    }
    ]);
    send(actions, '_ifNil_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(actions, '_asMinimalRepresentation');
};
Object.prototype['_actionForEvent_ifAbsent_'] = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    var __context = {};
    console.log('_actionForEvent_ifAbsent_');
    var actions = null
    actions = send(send(self, '_actionMap'), '_at_ifAbsent_', [send(anEventSelector, '_asSymbol'), function() {
        nil;
    }
    ]);
    send(actions, '_ifNil_', [function() {
        __context.value = send(anExceptionBlock, '_value');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(actions, '_asMinimalRepresentation');
};
Object.prototype['_actionMap'] = function()
{
    var self = this;
    console.log('_actionMap');
    return send(EventManager.classPrototype, '_actionMapFor_', [self]);
};
Object.prototype['_actionSequenceForEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('_actionSequenceForEvent_');
    return send(send(send(self, '_actionMap'), '_at_ifAbsent_', [send(anEventSelector, '_asSymbol'), function() {
        __context.value = send(WeakActionSequence.classPrototype, '_new');
        __context.return = true;
        return __context.value;
    }
    ]), '_asActionSequence');
};
Object.prototype['_actionsDo_'] = function(aBlock)
{
    var self = this;
    console.log('_actionsDo_');
    send(send(self, '_actionMap'), '_do_', [aBlock]);
};
Object.prototype['_createActionMap'] = function()
{
    var self = this;
    console.log('_createActionMap');
    return send(IdentityDictionary.classPrototype, '_new');
};
Object.prototype['_hasActionForEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('_hasActionForEvent_');
    return send(send(self, '_actionForEvent_', [anEventSelector]), '_notNil');
};
Object.prototype['_hasActionsWithReceiver_'] = function(anObject)
{
    var self = this;
    console.log('_hasActionsWithReceiver_');
    return send(send(send(self, '_actionMap'), '_keys'), '_anySatisfy_', [function(eachEventSelector) {
        send(send(self, '_actionSequenceForEvent_', [eachEventSelector]), '_anySatisfy_', [function(anAction) {
            send(send(anAction, '_receiver'), '==', [anObject]);
        }
        ]);
    }
    ]);
};
Object.prototype['_setActionSequence_forEvent_'] = function(actionSequence, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_setActionSequence_forEvent_');
    var action = null
    action = send(actionSequence, '_asMinimalRepresentation');
    send(send(action, '==', [nil]), '_ifTrue_ifFalse_', [function() {
        send(self, '_removeActionsForEvent_', [anEventSelector]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(self, '_updateableActionMap'), '_at_put_', [send(anEventSelector, '_asSymbol'), action]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_updateableActionMap'] = function()
{
    var self = this;
    console.log('_updateableActionMap');
    return send(EventManager.classPrototype, '_updateableActionMapFor_', [self]);
};
Object.prototype['_when_evaluate_'] = function(anEventSelector, anAction)
{
    var self = this;
    var __context = {};
    console.log('_when_evaluate_');
    var actions = null
    actions = send(self, '_actionSequenceForEvent_', [anEventSelector]);
    send(send(actions, '_includes_', [anAction]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_setActionSequence_forEvent_', [send(actions, '_copyWith_', [anAction]), anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['_when_send_to_'] = function(anEventSelector, aMessageSelector, anObject)
{
    var self = this;
    console.log('_when_send_to_');
    send(self, '_when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, '_receiver_selector_', [anObject, aMessageSelector])]);
};
Object.prototype['_when_send_to_withArguments_'] = function(anEventSelector, aMessageSelector, anObject, anArgArray)
{
    var self = this;
    console.log('_when_send_to_withArguments_');
    send(self, '_when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, anArgArray])]);
};
Object.prototype['_when_send_to_with_'] = function(anEventSelector, aMessageSelector, anObject, anArg)
{
    var self = this;
    console.log('_when_send_to_with_');
    send(self, '_when_evaluate_', [anEventSelector, send(WeakMessageSend.classPrototype, '_receiver_selector_arguments_', [anObject, aMessageSelector, send(Array.classPrototype, '_with_', [anArg])])]);
};
Object.prototype['_releaseActionMap'] = function()
{
    var self = this;
    console.log('_releaseActionMap');
    send(EventManager.classPrototype, '_releaseActionMapFor_', [self]);
};
Object.prototype['_removeActionsForEvent_'] = function(anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_removeActionsForEvent_');
    var map = null
    map = send(self, '_actionMap');
    send(map, '_removeKey_ifAbsent_', [send(anEventSelector, '_asSymbol'), function() {
    }
    ]);
    if (__context.return) return __context.value;
    send(send(map, '_isEmpty'), '_ifTrue_', [function() {
        send(self, '_releaseActionMap');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_removeActionsSatisfying_'] = function(aBlock)
{
    var self = this;
    var __context = {};
    console.log('_removeActionsSatisfying_');
    send(send(send(self, '_actionMap'), '_keys'), '_do_', [function(eachEventSelector) {
        send(self, '_removeActionsSatisfying_forEvent_', [aBlock, eachEventSelector]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_removeActionsSatisfying_forEvent_'] = function(aOneArgBlock, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_removeActionsSatisfying_forEvent_');
    send(self, '_setActionSequence_forEvent_', [send(send(self, '_actionSequenceForEvent_', [anEventSelector]), '_reject_', [function(anAction) {
        send(aOneArgBlock, '_value_', [anAction]);
        if (__context.return) return __context.value;
    }
    ]), anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['_removeActionsWithReceiver_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('_removeActionsWithReceiver_');
    send(send(send(self, '_actionMap'), '_copy'), '_keysDo_', [function(eachEventSelector) {
        send(self, '_removeActionsSatisfying_forEvent_', [function(anAction) {
            send(send(anAction, '_receiver'), '==', [anObject]);
            if (__context.return) return __context.value;
        }
        , eachEventSelector]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_removeActionsWithReceiver_forEvent_'] = function(anObject, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_removeActionsWithReceiver_forEvent_');
    send(self, '_removeActionsSatisfying_forEvent_', [function(anAction) {
        send(send(anAction, '_receiver'), '==', [anObject]);
        if (__context.return) return __context.value;
    }
    , anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['_removeAction_forEvent_'] = function(anAction, anEventSelector)
{
    var self = this;
    var __context = {};
    console.log('_removeAction_forEvent_');
    send(self, '_removeActionsSatisfying_forEvent_', [function(action) {
        send(action, '=', [anAction]);
        if (__context.return) return __context.value;
    }
    , anEventSelector]);
    if (__context.return) return __context.value;
};
Object.prototype['_triggerEvent_'] = function(anEventSelector)
{
    var self = this;
    console.log('_triggerEvent_');
    return send(send(self, '_actionForEvent_', [anEventSelector]), '_value');
};
Object.prototype['_triggerEvent_ifNotHandled_'] = function(anEventSelector, anExceptionBlock)
{
    var self = this;
    console.log('_triggerEvent_ifNotHandled_');
    return send(send(self, '_actionForEvent_ifAbsent_', [anEventSelector, function() {
        __context.value = send(anExceptionBlock, '_value');
        __context.return = true;
        return __context.value;
    }
    ]), '_value');
};
Object.prototype['_triggerEvent_withArguments_'] = function(anEventSelector, anArgumentList)
{
    var self = this;
    console.log('_triggerEvent_withArguments_');
    return send(send(self, '_actionForEvent_', [anEventSelector]), '_valueWithArguments_', [anArgumentList]);
};
Object.prototype['_triggerEvent_withArguments_ifNotHandled_'] = function(anEventSelector, anArgumentList, anExceptionBlock)
{
    var self = this;
    console.log('_triggerEvent_withArguments_ifNotHandled_');
    return send(send(self, '_actionForEvent_ifAbsent_', [anEventSelector, function() {
        __context.value = send(anExceptionBlock, '_value');
        __context.return = true;
        return __context.value;
    }
    ]), '_valueWithArguments_', [anArgumentList]);
};
Object.prototype['_triggerEvent_with_'] = function(anEventSelector, anObject)
{
    var self = this;
    console.log('_triggerEvent_with_');
    return send(self, '_triggerEvent_withArguments_', [anEventSelector, send(Array.classPrototype, '_with_', [anObject])]);
};
Object.prototype['_triggerEvent_with_ifNotHandled_'] = function(anEventSelector, anObject, anExceptionBlock)
{
    var self = this;
    console.log('_triggerEvent_with_ifNotHandled_');
    return send(self, '_triggerEvent_withArguments_ifNotHandled_', [anEventSelector, send(Array.classPrototype, '_with_', [anObject]), anExceptionBlock]);
};
Object.prototype['_drawOnCanvas_'] = function(aStream)
{
    var self = this;
    console.log('_drawOnCanvas_');
    send(self, '_flattenOnStream_', [aStream]);
};
Object.prototype['_elementSeparator'] = function()
{
    var self = this;
    console.log('_elementSeparator');
    return nil;
};
Object.prototype['_flattenOnStream_'] = function(aStream)
{
    var self = this;
    console.log('_flattenOnStream_');
    send(self, '_writeOnFilterStream_', [aStream]);
};
Object.prototype['_putOn_'] = function(aStream)
{
    var self = this;
    console.log('_putOn_');
    return send(aStream, '_nextPut_', [self]);
};
Object.prototype['_writeOnFilterStream_'] = function(aStream)
{
    var self = this;
    console.log('_writeOnFilterStream_');
    send(aStream, '_writeObject_', [self]);
};
Object.prototype['_actAsExecutor'] = function()
{
    var self = this;
    console.log('_actAsExecutor');
    send(self, '_breakDependents');
};
Object.prototype['_executor'] = function()
{
    var self = this;
    console.log('_executor');
    return send(send(self, '_shallowCopy'), '_actAsExecutor');
};
Object.prototype['_finalizationRegistry'] = function()
{
    var self = this;
    console.log('_finalizationRegistry');
    return send(WeakRegistry.classPrototype, '_default');
};
Object.prototype['_finalize'] = function()
{
    var self = this;
    console.log('_finalize');
};
Object.prototype['_hasMultipleExecutors'] = function()
{
    var self = this;
    console.log('_hasMultipleExecutors');
    return false;
};
Object.prototype['_retryWithGC_until_'] = function(execBlock, testBlock)
{
    var self = this;
    var __context = {};
    console.log('_retryWithGC_until_');
    var blockValue = null
    blockValue = send(execBlock, '_value');
    send(send(testBlock, '_value_', [blockValue]), '_ifTrue_', [function() {
        __context.value = blockValue;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Smalltalk.classPrototype, '_garbageCollectMost');
    if (__context.return) return __context.value;
    blockValue = send(execBlock, '_value');
    send(send(testBlock, '_value_', [blockValue]), '_ifTrue_', [function() {
        __context.value = blockValue;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Smalltalk.classPrototype, '_garbageCollect');
    if (__context.return) return __context.value;
    return send(execBlock, '_value');
};
Object.prototype['_toFinalizeSend_to_with_'] = function(aSelector, aFinalizer, aResourceHandle)
{
    var self = this;
    var __context = {};
    console.log('_toFinalizeSend_to_with_');
    send(send(self, '==', [aFinalizer]), '_ifTrue_', [function() {
        send(self, '_error_', ['I cannot finalize myself']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(self, '==', [aResourceHandle]), '_ifTrue_', [function() {
        send(self, '_error_', ['I cannot finalize myself']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_finalizationRegistry'), '_add_executor_', [self, send(send(ObjectFinalizer.classPrototype, '_new'), '_receiver_selector_argument_', [aFinalizer, aSelector, aResourceHandle])]);
};
Object.prototype['_isThisEverCalled'] = function()
{
    var self = this;
    console.log('_isThisEverCalled');
    return send(self, '_isThisEverCalled_', [send(send(thisContext, '_sender'), '_printString')]);
};
Object.prototype['_isThisEverCalled_'] = function(msg)
{
    var self = this;
    console.log('_isThisEverCalled_');
    send(self, '_halt_', [send('This is indeed called: ', ',', [send(msg, '_printString')])]);
};
Object.prototype['_logEntry'] = function()
{
    var self = this;
    console.log('_logEntry');
    send((function () {var _aux = send(Transcript.classPrototype, '_show_', [send('Entered ', ',', [send(send(thisContext, '_sender'), '_printString')])]);return _aux;})(), '_cr');
};
Object.prototype['_logExecution'] = function()
{
    var self = this;
    console.log('_logExecution');
    send((function () {var _aux = send(Transcript.classPrototype, '_show_', [send('Executing ', ',', [send(send(thisContext, '_sender'), '_printString')])]);return _aux;})(), '_cr');
};
Object.prototype['_logExit'] = function()
{
    var self = this;
    console.log('_logExit');
    send((function () {var _aux = send(Transcript.classPrototype, '_show_', [send('Exited ', ',', [send(send(thisContext, '_sender'), '_printString')])]);return _aux;})(), '_cr');
};
Object.prototype['_crLog_'] = function(aString)
{
    var self = this;
    console.log('_crLog_');
    send((function () {var _aux = send(Transcript.classPrototype, '_cr');return _aux;})(), '_show_', [aString]);
};
Object.prototype['_log_'] = function(aString)
{
    var self = this;
    console.log('_log_');
    send(Transcript.classPrototype, '_show_', [aString]);
};
Object.prototype['_logCr_'] = function(aString)
{
    var self = this;
    console.log('_logCr_');
    send((function () {var _aux = send(Transcript.classPrototype, '_show_', [aString]);return _aux;})(), '_cr');
};
Object.prototype['_logCrTab_'] = function(aString)
{
    var self = this;
    console.log('_logCrTab_');
    send((function () {var _aux = send((function () {var _aux = send(Transcript.classPrototype, '_show_', [aString]);return _aux;})(), '_cr');return _aux;})(), '_tab');
};
Object.prototype['_contentsChanged'] = function()
{
    var self = this;
    console.log('_contentsChanged');
    send(self, '_changed_', ['contents']);
};
Object.prototype['_flash'] = function()
{
    var self = this;
    console.log('_flash');
};
Object.prototype['_refusesToAcceptCode'] = function()
{
    var self = this;
    console.log('_refusesToAcceptCode');
    return false;
};
Object.prototype['_sizeInMemory'] = function()
{
    var self = this;
    var __context = {};
    console.log('_sizeInMemory');
    var isCompact = null
    var headerBytes = null
    var contentBytes = null
    contentBytes = send(send(send(self, '_class'), '_instSize'), '*', [send(Smalltalk.classPrototype, '_wordSize')]);
    send(send(send(self, '_class'), '_isVariable'), '_ifTrue_', [function() {
        var bytesPerElement = null;
        bytesPerElement = send(send(send(self, '_class'), '_isBytes'), '_ifTrue_ifFalse_', [function() {
            1;
        }
        , function() {
            4;
        }
        ]);
        contentBytes = send(contentBytes, '+', [send(send(self, '_basicSize'), '*', [bytesPerElement])]);
    }
    ]);
    if (__context.return) return __context.value;
    isCompact = send(send(send(self, '_class'), '_indexIfCompact'), '>', [0]);
    headerBytes = send(send(contentBytes, '>', [255]), '_ifTrue_ifFalse_', [function() {
        send(3, '*', [send(Smalltalk.classPrototype, '_wordSize')]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(isCompact, '_ifTrue_ifFalse_', [function() {
            send(Smalltalk.classPrototype, '_wordSize');
            if (__context.return) return __context.value;
        }
        , function() {
            send(2, '*', [send(Smalltalk.classPrototype, '_wordSize')]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    return send(headerBytes, '+', [contentBytes]);
};
Object.prototype['_perform_'] = function(aSymbol)
{
    var self = this;
    console.log('_perform_');
    var _primitive = primitives.primitive83(self, aSymbol);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_perform_withArguments_', [aSymbol, send(Array.classPrototype, '_new_', [0])]);
};
Object.prototype['_perform_orSendTo_'] = function(selector, otherTarget)
{
    var self = this;
    console.log('_perform_orSendTo_');
    return send(send(self, '_respondsTo_', [selector]), '_ifTrue_ifFalse_', [function() {
        send(self, '_perform_', [selector]);
    }
    , function() {
        send(otherTarget, '_perform_', [selector]);
    }
    ]);
};
Object.prototype['_perform_withArguments_'] = function(selector, argArray)
{
    var self = this;
    console.log('_perform_withArguments_');
    var _primitive = primitives.primitive84(self, selector, argArray);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_perform_withArguments_inSuperclass_', [selector, argArray, send(self, '_class')]);
};
Object.prototype['_perform_withArguments_inSuperclass_'] = function(selector, argArray, lookupClass)
{
    var self = this;
    var __context = {};
    console.log('_perform_withArguments_inSuperclass_');
    var _primitive = primitives.primitive100(self, selector, argArray, lookupClass);
    if (_primitive) return _primitive.value;
    ;
    send(send(selector, '_isSymbol'), '_ifFalse_', [function() {
        __context.value = send(self, '_error_', ['selector argument must be a Symbol']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(selector, '_numArgs'), '=', [send(argArray, '_size')]), '_ifFalse_', [function() {
        __context.value = send(self, '_error_', ['incorrect number of arguments']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, '_class'), '==', [lookupClass]), '_or_', [function() {
        send(send(self, '_class'), '_inheritsFrom_', [lookupClass]);
        if (__context.return) return __context.value;
    }
    ]), '_ifFalse_', [function() {
        __context.value = send(self, '_error_', ['lookupClass is not in my inheritance chain']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_primitiveFailed');
    if (__context.return) return __context.value;
};
Object.prototype['_perform_withEnoughArguments_'] = function(selector, anArray)
{
    var self = this;
    var __context = {};
    console.log('_perform_withEnoughArguments_');
    var numArgs = null
    var args = null
    numArgs = send(selector, '_numArgs');
    send(send(send(anArray, '_size'), '==', [numArgs]), '_ifTrue_', [function() {
        __context.value = send(self, '_perform_withArguments_', [selector, send(anArray, '_asArray')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    args = send(Array.classPrototype, '_new_', [numArgs]);
    send(args, '_replaceFrom_to_with_startingAt_', [1, send(send(anArray, '_size'), '_min_', [send(args, '_size')]), anArray, 1]);
    if (__context.return) return __context.value;
    return send(self, '_perform_withArguments_', [selector, args]);
};
Object.prototype['_perform_with_'] = function(aSymbol, anObject)
{
    var self = this;
    console.log('_perform_with_');
    var _primitive = primitives.primitive83(self, aSymbol, anObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_perform_withArguments_', [aSymbol, send(Array.classPrototype, '_with_', [anObject])]);
};
Object.prototype['_perform_with_with_'] = function(aSymbol, firstObject, secondObject)
{
    var self = this;
    console.log('_perform_with_with_');
    var _primitive = primitives.primitive83(self, aSymbol, firstObject, secondObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_perform_withArguments_', [aSymbol, send(Array.classPrototype, '_with_with_', [firstObject, secondObject])]);
};
Object.prototype['_perform_with_with_with_'] = function(aSymbol, firstObject, secondObject, thirdObject)
{
    var self = this;
    console.log('_perform_with_with_with_');
    var _primitive = primitives.primitive83(self, aSymbol, firstObject, secondObject, thirdObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_perform_withArguments_', [aSymbol, send(Array.classPrototype, '_with_with_with_', [firstObject, secondObject, thirdObject])]);
};
Object.prototype['_fullPrintString'] = function()
{
    var self = this;
    console.log('_fullPrintString');
    return send(String.classPrototype, '_streamContents_', [function(s) {
        send(self, '_printOn_', [s]);
    }
    ]);
};
Object.prototype['_isLiteral'] = function()
{
    var self = this;
    console.log('_isLiteral');
    return false;
};
Object.prototype['_longPrintOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('_longPrintOn_');
    send(send(send(self, '_class'), '_allInstVarNames'), '_doWithIndex_', [function(title, index) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, '_nextPutAll_', [title]);return _aux;})(), '_nextPut_', [':']);return _aux;})(), '_space');return _aux;})(), '_tab');return _aux;})(), '_print_', [send(self, '_instVarAt_', [index])]);return _aux;})(), '_cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_longPrintOn_limitedTo_indent_'] = function(aStream, sizeLimit, indent)
{
    var self = this;
    var __context = {};
    console.log('_longPrintOn_limitedTo_indent_');
    send(send(send(self, '_class'), '_allInstVarNames'), '_doWithIndex_', [function(title, index) {
        send(indent, '_timesRepeat_', [function() {
            send(aStream, '_tab');
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, '_nextPutAll_', [title]);return _aux;})(), '_nextPut_', [':']);return _aux;})(), '_space');return _aux;})(), '_tab');return _aux;})(), '_nextPutAll_', [send(send(self, '_instVarAt_', [index]), '_printStringLimitedTo_', [send(send(send(sizeLimit, '-', [3]), '-', [send(title, '_size')]), '_max_', [1])])]);return _aux;})(), '_cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_longPrintString'] = function()
{
    var self = this;
    console.log('_longPrintString');
    var str = null
    str = send(String.classPrototype, '_streamContents_', [function(aStream) {
        send(self, '_longPrintOn_', [aStream]);
    }
    ]);
    return send(send(str, '_isEmpty'), '_ifTrue_ifFalse_', [function() {
        send(send(self, '_printString'), ',', [send(String.classPrototype, '_cr')]);
    }
    , function() {
        str;
    }
    ]);
};
Object.prototype['_longPrintStringLimitedTo_'] = function(aLimitValue)
{
    var self = this;
    console.log('_longPrintStringLimitedTo_');
    var str = null
    str = send(String.classPrototype, '_streamContents_', [function(aStream) {
        send(self, '_longPrintOn_limitedTo_indent_', [aStream, aLimitValue, 0]);
    }
    ]);
    return send(send(str, '_isEmpty'), '_ifTrue_ifFalse_', [function() {
        send(send(self, '_printString'), ',', [send(String.classPrototype, '_cr')]);
    }
    , function() {
        str;
    }
    ]);
};
Object.prototype['_nominallyUnsent_'] = function(aSelectorSymbol)
{
    var self = this;
    var __context = {};
    console.log('_nominallyUnsent_');
    send(false, '_ifTrue_', [function() {
        send(self, '_flag_', ['nominallyUnsent:']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_printOn_'] = function(t1)
{
    var self = this;
    console.log('_printOn_');
    var t2 = null
    t2 = send(send(self, '_class'), '_name');
    send((function () {var _aux = send(t1, '_nextPutAll_', [send(send(send(t2, '_first'), '_isVowel'), '_ifTrue_ifFalse_', [function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ])]);return _aux;})(), '_nextPutAll_', [t2]);
};
Object.prototype['_printString'] = function()
{
    var self = this;
    console.log('_printString');
    return send(self, '_printStringLimitedTo_', [50000]);
};
Object.prototype['_printStringLimitedTo_'] = function(limit)
{
    var self = this;
    var __context = {};
    console.log('_printStringLimitedTo_');
    var limitedString = null
    limitedString = send(String.classPrototype, '_streamContents_limitedTo_', [function(s) {
        send(self, '_printOn_', [s]);
        if (__context.return) return __context.value;
    }
    , limit]);
    send(send(send(limitedString, '_size'), '<', [limit]), '_ifTrue_', [function() {
        __context.value = limitedString;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(limitedString, ',', ['...etc...']);
};
Object.prototype['_printWithClosureAnalysisOn_'] = function(aStream)
{
    var self = this;
    console.log('_printWithClosureAnalysisOn_');
    var title = null
    title = send(send(self, '_class'), '_name');
    send((function () {var _aux = send(aStream, '_nextPutAll_', [send(send(send(title, '_first'), '_isVowel'), '_ifTrue_ifFalse_', [function() {
        'an ';
    }
    , function() {
        'a ';
    }
    ])]);return _aux;})(), '_nextPutAll_', [title]);
};
Object.prototype['_storeOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('_storeOn_');
    send(aStream, '_nextPut_', ['(']);
    if (__context.return) return __context.value;
    send(send(send(self, '_class'), '_isVariable'), '_ifTrue_ifFalse_', [function() {
        send((function () {var _aux = send((function () {var _aux = send(aStream, '_nextPutAll_', [send(send('(', ',', [send(send(self, '_class'), '_name')]), ',', [' basicNew: '])]);return _aux;})(), '_store_', [send(self, '_basicSize')]);return _aux;})(), '_nextPutAll_', [') ']);
        if (__context.return) return __context.value;
    }
    , function() {
        send(aStream, '_nextPutAll_', [send(send(send(self, '_class'), '_name'), ',', [' basicNew'])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [send(send(self, '_class'), '_instSize'), function(i) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, '_nextPutAll_', [' instVarAt: ']);return _aux;})(), '_store_', [i]);return _aux;})(), '_nextPutAll_', [' put: ']);return _aux;})(), '_store_', [send(self, '_instVarAt_', [i])]);return _aux;})(), '_nextPut_', [';']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(1, '_to_do_', [send(self, '_basicSize'), function(i) {
        send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send((function () {var _aux = send(aStream, '_nextPutAll_', [' basicAt: ']);return _aux;})(), '_store_', [i]);return _aux;})(), '_nextPutAll_', [' put: ']);return _aux;})(), '_store_', [send(self, '_basicAt_', [i])]);return _aux;})(), '_nextPut_', [';']);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, '_nextPutAll_', [' yourself)']);
    if (__context.return) return __context.value;
};
Object.prototype['_storeString'] = function()
{
    var self = this;
    console.log('_storeString');
    return send(String.classPrototype, '_streamContents_', [function(s) {
        send(self, '_storeOn_', [s]);
    }
    ]);
};
Object.prototype['_isSelfEvaluating'] = function()
{
    var self = this;
    console.log('_isSelfEvaluating');
    return send(self, '_isLiteral');
};
Object.prototype['_appendTo_'] = function(aCollection)
{
    var self = this;
    console.log('_appendTo_');
    return send(aCollection, '_addLast_', [self]);
};
Object.prototype['_join_'] = function(aSequenceableCollection)
{
    var self = this;
    console.log('_join_');
    return send(send(Array.classPrototype, '_with_', [self]), '_join_', [aSequenceableCollection]);
};
Object.prototype['_joinTo_'] = function(stream)
{
    var self = this;
    console.log('_joinTo_');
    return send(stream, '_nextPut_', [self]);
};
Object.prototype['_split_'] = function(aSequenceableCollection)
{
    var self = this;
    console.log('_split_');
    return send(send(Array.classPrototype, '_with_', [self]), '_split_', [aSequenceableCollection]);
};
Object.prototype['_becomeForward_'] = function(otherObject)
{
    var self = this;
    console.log('_becomeForward_');
    send(send(Array.classPrototype, '_with_', [self]), '_elementsForwardIdentityTo_', [send(Array.classPrototype, '_with_', [otherObject])]);
};
Object.prototype['_becomeForward_copyHash_'] = function(otherObject, copyHash)
{
    var self = this;
    console.log('_becomeForward_copyHash_');
    send(send(Array.classPrototype, '_with_', [self]), '_elementsForwardIdentityTo_copyHash_', [send(Array.classPrototype, '_with_', [otherObject]), copyHash]);
};
Object.prototype['_className'] = function()
{
    var self = this;
    console.log('_className');
    return send(send(send(self, '_class'), '_name'), '_asString');
};
Object.prototype['_instVarAt_'] = function(index)
{
    var self = this;
    console.log('_instVarAt_');
    var _primitive = primitives.primitive73(self, index);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_basicAt_', [send(index, '-', [send(send(self, '_class'), '_instSize')])]);
};
Object.prototype['_instVarAt_put_'] = function(anInteger, anObject)
{
    var self = this;
    console.log('_instVarAt_put_');
    var _primitive = primitives.primitive74(self, anInteger, anObject);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_basicAt_put_', [send(anInteger, '-', [send(send(self, '_class'), '_instSize')]), anObject]);
};
Object.prototype['_instVarNamed_'] = function(aString)
{
    var self = this;
    console.log('_instVarNamed_');
    return send(self, '_instVarAt_', [send(send(self, '_class'), '_instVarIndexFor_ifAbsent_', [send(aString, '_asString'), function() {
        send(self, '_error_', ['no such inst var']);
    }
    ])]);
};
Object.prototype['_instVarNamed_put_'] = function(aString, aValue)
{
    var self = this;
    console.log('_instVarNamed_put_');
    return send(self, '_instVarAt_put_', [send(send(self, '_class'), '_instVarIndexFor_ifAbsent_', [send(aString, '_asString'), function() {
        send(self, '_error_', ['no such inst var']);
    }
    ]), aValue]);
};
Object.prototype['_primitiveChangeClassTo_'] = function(anObject)
{
    var self = this;
    console.log('_primitiveChangeClassTo_');
    var _primitive = primitives.primitive115(self, anObject);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
Object.prototype['_someObject'] = function()
{
    var self = this;
    console.log('_someObject');
    var _primitive = primitives.primitive138(self);
    if (_primitive) return _primitive.value;
    ;
    send(self, '_primitiveFailed');
};
Object.prototype['_haltIfNil'] = function()
{
    var self = this;
    console.log('_haltIfNil');
};
Object.prototype['_hasLiteralSuchThat_'] = function(testBlock)
{
    var self = this;
    console.log('_hasLiteralSuchThat_');
    return false;
};
Object.prototype['_is_'] = function(t1)
{
    var self = this;
    console.log('_is_');
    return false;
};
Object.prototype['_isArray'] = function()
{
    var self = this;
    console.log('_isArray');
    return false;
};
Object.prototype['_isBehavior'] = function()
{
    var self = this;
    console.log('_isBehavior');
    return false;
};
Object.prototype['_isBlock'] = function()
{
    var self = this;
    console.log('_isBlock');
    return false;
};
Object.prototype['_isCharacter'] = function()
{
    var self = this;
    console.log('_isCharacter');
    return false;
};
Object.prototype['_isClosure'] = function()
{
    var self = this;
    console.log('_isClosure');
    return false;
};
Object.prototype['_isCollection'] = function()
{
    var self = this;
    console.log('_isCollection');
    return false;
};
Object.prototype['_isColor'] = function()
{
    var self = this;
    console.log('_isColor');
    return false;
};
Object.prototype['_isColorForm'] = function()
{
    var self = this;
    console.log('_isColorForm');
    return false;
};
Object.prototype['_isCompiledMethod'] = function()
{
    var self = this;
    console.log('_isCompiledMethod');
    return false;
};
Object.prototype['_isComplex'] = function()
{
    var self = this;
    console.log('_isComplex');
    return false;
};
Object.prototype['_isContext'] = function()
{
    var self = this;
    console.log('_isContext');
    return false;
};
Object.prototype['_isDictionary'] = function()
{
    var self = this;
    console.log('_isDictionary');
    return false;
};
Object.prototype['_isFloat'] = function()
{
    var self = this;
    console.log('_isFloat');
    return false;
};
Object.prototype['_isForm'] = function()
{
    var self = this;
    console.log('_isForm');
    return false;
};
Object.prototype['_isFraction'] = function()
{
    var self = this;
    console.log('_isFraction');
    return false;
};
Object.prototype['_isHeap'] = function()
{
    var self = this;
    console.log('_isHeap');
    return false;
};
Object.prototype['_isInteger'] = function()
{
    var self = this;
    console.log('_isInteger');
    return false;
};
Object.prototype['_isInterval'] = function()
{
    var self = this;
    console.log('_isInterval');
    return false;
};
Object.prototype['_isMessageSend'] = function()
{
    var self = this;
    console.log('_isMessageSend');
    return false;
};
Object.prototype['_isMethodProperties'] = function()
{
    var self = this;
    console.log('_isMethodProperties');
    return false;
};
Object.prototype['_isMorph'] = function()
{
    var self = this;
    console.log('_isMorph');
    return false;
};
Object.prototype['_isMorphicEvent'] = function()
{
    var self = this;
    console.log('_isMorphicEvent');
    return false;
};
Object.prototype['_isMorphicModel'] = function()
{
    var self = this;
    console.log('_isMorphicModel');
    return false;
};
Object.prototype['_isNumber'] = function()
{
    var self = this;
    console.log('_isNumber');
    return false;
};
Object.prototype['_isPoint'] = function()
{
    var self = this;
    console.log('_isPoint');
    return false;
};
Object.prototype['_isPseudoContext'] = function()
{
    var self = this;
    console.log('_isPseudoContext');
    return false;
};
Object.prototype['_isRectangle'] = function()
{
    var self = this;
    console.log('_isRectangle');
    return false;
};
Object.prototype['_isStream'] = function()
{
    var self = this;
    console.log('_isStream');
    return false;
};
Object.prototype['_isString'] = function()
{
    var self = this;
    console.log('_isString');
    return false;
};
Object.prototype['_isSymbol'] = function()
{
    var self = this;
    console.log('_isSymbol');
    return false;
};
Object.prototype['_isSystemWindow'] = function()
{
    var self = this;
    console.log('_isSystemWindow');
    return false;
};
Object.prototype['_isText'] = function()
{
    var self = this;
    console.log('_isText');
    return false;
};
Object.prototype['_isTrait'] = function()
{
    var self = this;
    console.log('_isTrait');
    return false;
};
Object.prototype['_isVariableBinding'] = function()
{
    var self = this;
    console.log('_isVariableBinding');
    return false;
};
Object.prototype['_name'] = function()
{
    var self = this;
    console.log('_name');
    return send(self, '_printString');
};
Object.prototype['_notNil'] = function()
{
    var self = this;
    console.log('_notNil');
    return true;
};
Object.prototype['_refersToLiteral_'] = function(literal)
{
    var self = this;
    console.log('_refersToLiteral_');
    return false;
};
Object.prototype['_stepAt_in_'] = function(millisecondClockValue, aWindow)
{
    var self = this;
    console.log('_stepAt_in_');
    return send(self, '_stepIn_', [aWindow]);
};
Object.prototype['_stepIn_'] = function(aWindow)
{
    var self = this;
    console.log('_stepIn_');
    return send(self, '_step');
};
Object.prototype['_stepTime'] = function()
{
    var self = this;
    console.log('_stepTime');
    return 1000;
};
Object.prototype['_stepTimeIn_'] = function(aSystemWindow)
{
    var self = this;
    console.log('_stepTimeIn_');
    return 1000;
};
Object.prototype['_wantsDiffFeedback'] = function()
{
    var self = this;
    console.log('_wantsDiffFeedback');
    return false;
};
Object.prototype['_wantsSteps'] = function()
{
    var self = this;
    console.log('_wantsSteps');
    return false;
};
Object.prototype['_wantsStepsIn_'] = function(aSystemWindow)
{
    var self = this;
    console.log('_wantsStepsIn_');
    return send(self, '_wantsSteps');
};
Object.prototype['_changed'] = function()
{
    var self = this;
    console.log('_changed');
    send(self, '_changed_', [self]);
};
Object.prototype['_changed_'] = function(aParameter)
{
    var self = this;
    var __context = {};
    console.log('_changed_');
    send(send(self, '_dependents'), '_do_', [function(aDependent) {
        send(aDependent, '_update_', [aParameter]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_changed_with_'] = function(anAspect, anObject)
{
    var self = this;
    var __context = {};
    console.log('_changed_with_');
    send(send(self, '_dependents'), '_do_', [function(aDependent) {
        send(aDependent, '_update_with_', [anAspect, anObject]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Object.prototype['_noteSelectionIndex_for_'] = function(anInteger, aSymbol)
{
    var self = this;
    console.log('_noteSelectionIndex_for_');
};
Object.prototype['_okToChange'] = function()
{
    var self = this;
    console.log('_okToChange');
    return true;
};
Object.prototype['_update_'] = function(aParameter)
{
    var self = this;
    console.log('_update_');
    return self;
};
Object.prototype['_update_with_'] = function(anAspect, anObject)
{
    var self = this;
    console.log('_update_with_');
    return send(self, '_update_', [anAspect]);
};
Object.prototype['_windowIsClosing'] = function()
{
    var self = this;
    console.log('_windowIsClosing');
    return self;
};
Object.prototype['_addModelItemsToWindowMenu_'] = function(aMenu)
{
    var self = this;
    console.log('_addModelItemsToWindowMenu_');
};
Object.prototype['_addModelMenuItemsTo_forMorph_hand_'] = function(aCustomMenu, aMorph, aHandMorph)
{
    var self = this;
    console.log('_addModelMenuItemsTo_forMorph_hand_');
};
Object.prototype['_modelSleep'] = function()
{
    var self = this;
    console.log('_modelSleep');
};
Object.prototype['_modelWakeUp'] = function()
{
    var self = this;
    console.log('_modelWakeUp');
};
Object.prototype['_modelWakeUpIn_'] = function(aWindow)
{
    var self = this;
    console.log('_modelWakeUpIn_');
    send(self, '_modelWakeUp');
};
Object.prototype['_mouseUpBalk_'] = function(evt)
{
    var self = this;
    console.log('_mouseUpBalk_');
};
Object.prototype['_notYetImplemented'] = function()
{
    var self = this;
    console.log('_notYetImplemented');
    send(self, '_inform_', [send(send('Not yet implemented (', ',', [send(send(thisContext, '_sender'), '_printString')]), ',', [')'])]);
};
Object.prototype['_windowReqNewLabel_'] = function(labelString)
{
    var self = this;
    console.log('_windowReqNewLabel_');
    return true;
};
Object.prototype['_errorImproperStore'] = function()
{
    var self = this;
    console.log('_errorImproperStore');
    send(self, '_error_', ['Improper store into indexable object']);
};
Object.prototype['_errorNonIntegerIndex'] = function()
{
    var self = this;
    console.log('_errorNonIntegerIndex');
    send(self, '_error_', ['only integers should be used as indices']);
};
Object.prototype['_errorNotIndexable'] = function()
{
    var self = this;
    console.log('_errorNotIndexable');
    send(self, '_error_', [send(send('Instances of {1} are not indexable', '_translated'), '_format_', [[send(send(self, '_class'), '_name')]])]);
};
Object.prototype['_errorSubscriptBounds_'] = function(index)
{
    var self = this;
    console.log('_errorSubscriptBounds_');
    send(SubscriptOutOfBounds.classPrototype, '_signalFor_', [index]);
};
Object.prototype['_species'] = function()
{
    var self = this;
    console.log('_species');
    var _primitive = primitives.primitive111(self);
    if (_primitive) return _primitive.value;
    ;
    return send(self, '_class');
};
Object.prototype['_storeAt_inTempFrame_'] = function(offset, aContext)
{
    var self = this;
    console.log('_storeAt_inTempFrame_');
    return send(aContext, '_tempAt_put_', [offset, self]);
};
ObjectClass.prototype['_readFrom_'] = function(t1)
{
    var self = this;
    var __context = {};
    console.log('_readFrom_');
    var t2 = null
    send(send(Compiler.classPrototype, '_couldEvaluate_', [t1]), '_ifFalse_', [function() {
        __context.value = send(self, '_error_', ['expected String, Stream, or Text']);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    t2 = send(Compiler.classPrototype, '_evaluate_', [t1]);
    send(send(t2, '_isKindOf_', [self]), '_ifFalse_', [function() {
        send(self, '_error_', [send(send(self, '_name'), ',', [' expected'])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return t2;
};
ObjectClass.prototype['_taskbarIcon'] = function()
{
    var self = this;
    console.log('_taskbarIcon');
    return nil;
};
ObjectClass.prototype['_taskbarLabel'] = function()
{
    var self = this;
    console.log('_taskbarLabel');
    return nil;
};
ObjectClass.prototype['_registerToolsOn_'] = function(t1)
{
    var self = this;
    console.log('_registerToolsOn_');
    return self;
};
ObjectClass.prototype['_services'] = function()
{
    var self = this;
    console.log('_services');
    return [];
};
ObjectClass.prototype['_flushDependents'] = function()
{
    var self = this;
    var __context = {};
    console.log('_flushDependents');
    send(DependentsFields.classPrototype, '_keysAndValuesDo_', [function(key, dep) {
        send(key, '_ifNotNil_', [function() {
            send(key, '_removeDependent_', [nil]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(DependentsFields.classPrototype, '_finalizeValues');
    if (__context.return) return __context.value;
};
ObjectClass.prototype['_flushEvents'] = function()
{
    var self = this;
    console.log('_flushEvents');
    send(EventManager.classPrototype, '_flushEvents');
};
ObjectClass.prototype['_initialize'] = function()
{
    var self = this;
    var __context = {};
    console.log('_initialize');
    send(DependentsFields.classPrototype, '_ifNil_', [function() {
        send(self, '_initializeDependentsFields');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ObjectClass.prototype['_initializeDependentsFields'] = function()
{
    var self = this;
    console.log('_initializeDependentsFields');
    DependentsFields = send(WeakIdentityKeyDictionary.classPrototype, '_new');
};
ObjectClass.prototype['_reInitializeDependentsFields'] = function()
{
    var self = this;
    var __context = {};
    console.log('_reInitializeDependentsFields');
    var oldFields = null
    oldFields = DependentsFields;
    DependentsFields = send(WeakIdentityKeyDictionary.classPrototype, '_new');
    send(oldFields, '_keysAndValuesDo_', [function(obj, deps) {
        send(deps, '_do_', [function(d) {
            send(obj, '_addDependent_', [d]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
ObjectClass.prototype['_howToModifyPrimitives'] = function()
{
    var self = this;
    console.log('_howToModifyPrimitives');
    send(self, '_error_', ['comment only']);
};
ObjectClass.prototype['_whatIsAPrimitive'] = function()
{
    var self = this;
    console.log('_whatIsAPrimitive');
    send(self, '_error_', ['comment only']);
};
ObjectClass.prototype['_fileReaderServicesForDirectory_'] = function(aFileDirectory)
{
    var self = this;
    console.log('_fileReaderServicesForDirectory_');
    return [];
};
ObjectClass.prototype['_fileReaderServicesForFile_suffix_'] = function(fullName, suffix)
{
    var self = this;
    console.log('_fileReaderServicesForFile_suffix_');
    return [];
};
ObjectClass.prototype['_newFrom_'] = function(aSimilarObject)
{
    var self = this;
    console.log('_newFrom_');
    return send(send(send(self, '_isVariable'), '_ifTrue_ifFalse_', [function() {
        send(self, '_basicNew_', [send(aSimilarObject, '_basicSize')]);
    }
    , function() {
        send(self, '_basicNew');
    }
    ]), '_copySameFrom_', [aSimilarObject]);
};
ObjectClass.prototype['_createFrom_size_version_'] = function(aSmartRefStream, varsOnDisk, instVarList)
{
    var self = this;
    console.log('_createFrom_size_version_');
    return send(send(self, '_isVariable'), '_ifFalse_ifTrue_', [function() {
        send(self, '_basicNew');
    }
    , function() {
        send(self, '_basicNew_', [send(varsOnDisk, '-', [send(send(instVarList, '_size'), '-', [1])])]);
    }
    ]);
};
ObjectClass.prototype['_releaseExternalSettings'] = function()
{
    var self = this;
    console.log('_releaseExternalSettings');
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
MessageSend.prototype.receiver = null;
MessageSend.prototype.selector = null;
MessageSend.prototype.arguments = null;
MessageSendClass.__super = ObjectClass;
MessageSend.__super = Object;
MessageSend.prototype['_arguments'] = function()
{
    var self = this;
    console.log('_arguments');
    return self.arguments;
};
MessageSend.prototype['_arguments_'] = function(anArray)
{
    var self = this;
    console.log('_arguments_');
    self.arguments = anArray;
};
MessageSend.prototype['_numArgs'] = function()
{
    var self = this;
    console.log('_numArgs');
    return send(self.arguments, '_size');
};
MessageSend.prototype['_receiver'] = function()
{
    var self = this;
    console.log('_receiver');
    return self.receiver;
};
MessageSend.prototype['_receiver_'] = function(anObject)
{
    var self = this;
    console.log('_receiver_');
    self.receiver = anObject;
};
MessageSend.prototype['_selector'] = function()
{
    var self = this;
    console.log('_selector');
    return self.selector;
};
MessageSend.prototype['_selector_'] = function(aSymbol)
{
    var self = this;
    console.log('_selector_');
    self.selector = aSymbol;
};
MessageSend.prototype['='] = function(anObject)
{
    var self = this;
    console.log('=');
    return send(send(send(anObject, '_species'), '==', [send(self, '_species')]), '_and_', [function() {
        send(send(self.receiver, '==', [send(anObject, '_receiver')]), '_and_', [function() {
            send(send(self.selector, '==', [send(anObject, '_selector')]), '_and_', [function() {
                send(self.arguments, '=', [send(anObject, '_arguments')]);
            }
            ]);
        }
        ]);
    }
    ]);
};
MessageSend.prototype['_hash'] = function()
{
    var self = this;
    console.log('_hash');
    return send(send(self.receiver, '_hash'), '_bitXor_', [send(self.selector, '_hash')]);
};
MessageSend.prototype['_asMinimalRepresentation'] = function()
{
    var self = this;
    console.log('_asMinimalRepresentation');
    return self;
};
MessageSend.prototype['_asWeakMessageSend'] = function()
{
    var self = this;
    console.log('_asWeakMessageSend');
    return send(WeakMessageSend.classPrototype, '_receiver_selector_arguments_', [self.receiver, self.selector, send(self.arguments, '_copy')]);
};
MessageSend.prototype['_cull_'] = function(arg)
{
    var self = this;
    console.log('_cull_');
    return send(send(send(self.selector, '_numArgs'), '=', [0]), '_ifTrue_ifFalse_', [function() {
        send(self, '_value');
    }
    , function() {
        send(self, '_value_', [arg]);
    }
    ]);
};
MessageSend.prototype['_cull_cull_'] = function(arg1, arg2)
{
    var self = this;
    console.log('_cull_cull_');
    return send(send(send(self.selector, '_numArgs'), '<', [2]), '_ifTrue_ifFalse_', [function() {
        send(self, '_cull_', [arg1]);
    }
    , function() {
        send(self, '_value_value_', [arg1, arg2]);
    }
    ]);
};
MessageSend.prototype['_cull_cull_cull_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('_cull_cull_cull_');
    return send(send(send(self.selector, '_numArgs'), '<', [3]), '_ifTrue_ifFalse_', [function() {
        send(self, '_cull_cull_', [arg1, arg2]);
    }
    , function() {
        send(self, '_value_value_value_', [arg1, arg2, arg3]);
    }
    ]);
};
MessageSend.prototype['_value'] = function()
{
    var self = this;
    var __context = {};
    console.log('_value');
    send(self.arguments, '_ifNil_', [function() {
        __context.value = send(self.receiver, '_perform_', [self.selector]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(self.receiver, '_perform_withArguments_', [self.selector, send(self, '_collectArguments_', [self.arguments])]);
};
MessageSend.prototype['_value_'] = function(anObject)
{
    var self = this;
    console.log('_value_');
    return send(self.receiver, '_perform_with_', [self.selector, anObject]);
};
MessageSend.prototype['_value_value_'] = function(anObject1, anObject2)
{
    var self = this;
    console.log('_value_value_');
    return send(self.receiver, '_perform_with_with_', [self.selector, anObject1, anObject2]);
};
MessageSend.prototype['_value_value_value_'] = function(anObject1, anObject2, anObject3)
{
    var self = this;
    console.log('_value_value_value_');
    return send(self.receiver, '_perform_with_with_with_', [self.selector, anObject1, anObject2, anObject3]);
};
MessageSend.prototype['_valueWithArguments_'] = function(anArray)
{
    var self = this;
    console.log('_valueWithArguments_');
    return send(self.receiver, '_perform_withArguments_', [self.selector, send(self, '_collectArguments_', [anArray])]);
};
MessageSend.prototype['_valueWithEnoughArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('_valueWithEnoughArguments_');
    var args = null
    args = send(Array.classPrototype, '_new_', [send(self.selector, '_numArgs')]);
    send(args, '_replaceFrom_to_with_startingAt_', [1, send(send(self.arguments, '_size'), '_min_', [send(args, '_size')]), self.arguments, 1]);
    if (__context.return) return __context.value;
    send(send(send(args, '_size'), '>', [send(self.arguments, '_size')]), '_ifTrue_', [function() {
        send(args, '_replaceFrom_to_with_startingAt_', [send(send(self.arguments, '_size'), '+', [1]), send(send(send(self.arguments, '_size'), '+', [send(anArray, '_size')]), '_min_', [send(args, '_size')]), anArray, 1]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(self.receiver, '_perform_withArguments_', [self.selector, args]);
};
MessageSend.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send((function () {var _aux = send(aStream, '_nextPutAll_', [send(send(self, '_class'), '_name')]);return _aux;})(), '_nextPut_', ['(']);
    send(self.selector, '_printOn_', [aStream]);
    send(aStream, '_nextPutAll_', [' -> ']);
    send(self.receiver, '_printOn_', [aStream]);
    send(aStream, '_nextPut_', [')']);
};
MessageSend.prototype['_isMessageSend'] = function()
{
    var self = this;
    console.log('_isMessageSend');
    return true;
};
MessageSend.prototype['_isValid'] = function()
{
    var self = this;
    console.log('_isValid');
    return true;
};
MessageSend.prototype['_collectArguments_'] = function(anArgArray)
{
    var self = this;
    console.log('_collectArguments_');
    var staticArgs = null
    staticArgs = send(self, '_arguments');
    return send(send(send(anArgArray, '_size'), '=', [send(staticArgs, '_size')]), '_ifTrue_ifFalse_', [function() {
        anArgArray;
    }
    , function() {
        send(send(send(staticArgs, '_isEmpty'), '_ifTrue_ifFalse_', [function() {
            staticArgs = send(Array.classPrototype, '_new_', [send(self.selector, '_numArgs')]);
        }
        , function() {
            send(staticArgs, '_copy');
        }
        ]), '_replaceFrom_to_with_startingAt_', [1, send(send(anArgArray, '_size'), '_min_', [send(staticArgs, '_size')]), anArgArray, 1]);
    }
    ]);
};
MessageSendClass.prototype['_receiver_selector_'] = function(anObject, aSymbol)
{
    var self = this;
    console.log('_receiver_selector_');
    return send(self, '_receiver_selector_arguments_', [anObject, aSymbol, []]);
};
MessageSendClass.prototype['_receiver_selector_argument_'] = function(anObject, aSymbol, aParameter)
{
    var self = this;
    console.log('_receiver_selector_argument_');
    return send(self, '_receiver_selector_arguments_', [anObject, aSymbol, send(Array.classPrototype, '_with_', [aParameter])]);
};
MessageSendClass.prototype['_receiver_selector_arguments_'] = function(anObject, aSymbol, anArray)
{
    var self = this;
    console.log('_receiver_selector_arguments_');
    return send((function () {var _aux = send((function () {var _aux = send(send(self, '_new'), '_receiver_', [anObject]);return _aux;})(), '_selector_', [aSymbol]);return _aux;})(), '_arguments_', [anArray]);
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
UndefinedObject.prototype['_parserClass'] = function()
{
    var self = this;
    console.log('_parserClass');
    return send(Compiler.classPrototype, '_parserClass');
};
UndefinedObject.prototype['_canHandleSignal_'] = function(exception)
{
    var self = this;
    console.log('_canHandleSignal_');
    return false;
};
UndefinedObject.prototype['_handleSignal_'] = function(exception)
{
    var self = this;
    console.log('_handleSignal_');
    return send(exception, '_resumeUnchecked_', [send(exception, '_defaultAction')]);
};
UndefinedObject.prototype['_addSubclass_'] = function(aClass)
{
    var self = this;
    console.log('_addSubclass_');
};
UndefinedObject.prototype['_allSuperclassesDo_'] = function(aBlockContext)
{
    var self = this;
    console.log('_allSuperclassesDo_');
    send(self, '_shouldBeImplemented');
};
UndefinedObject.prototype['_environment'] = function()
{
    var self = this;
    console.log('_environment');
    return send(send(self, '_class'), '_environment');
};
UndefinedObject.prototype['_literalScannedAs_notifying_'] = function(scannedLiteral, requestor)
{
    var self = this;
    console.log('_literalScannedAs_notifying_');
    return scannedLiteral;
};
UndefinedObject.prototype['_removeObsoleteSubclass_'] = function(aClass)
{
    var self = this;
    console.log('_removeObsoleteSubclass_');
};
UndefinedObject.prototype['_removeSubclass_'] = function(aClass)
{
    var self = this;
    console.log('_removeSubclass_');
};
UndefinedObject.prototype['_subclassDefinerClass'] = function()
{
    var self = this;
    console.log('_subclassDefinerClass');
    return Compiler;
};
UndefinedObject.prototype['_subclasses'] = function()
{
    var self = this;
    var __context = {};
    console.log('_subclasses');
    var classList = null
    classList = send(send(Array.classPrototype, '_new'), '_writeStream');
    send(self, '_subclassesDo_', [function(clazz) {
        send(classList, '_nextPut_', [clazz]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(classList, '_contents');
};
UndefinedObject.prototype['_subclassesDo_'] = function(aBlock)
{
    var self = this;
    console.log('_subclassesDo_');
    return send(Class.classPrototype, '_subclassesDo_', [function(cl) {
        send(send(cl, '_isMeta'), '_ifTrue_', [function() {
            send(aBlock, '_value_', [send(cl, '_soleInstance')]);
        }
        ]);
    }
    ]);
};
UndefinedObject.prototype['_subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_'] = function(nameOfClass, instVarNames, classVarNames, poolDictnames, category)
{
    var self = this;
    console.log('_subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_');
    send(self, '_logCr_', [send(send('Attempt to create ', ',', [nameOfClass]), ',', [' as a subclass of nil.  Possibly a class is being loaded before its superclass.'])]);
    return send(ProtoObject.classPrototype, '_subclass_instanceVariableNames_classVariableNames_poolDictionaries_category_', [nameOfClass, instVarNames, classVarNames, poolDictnames, category]);
};
UndefinedObject.prototype['_typeOfClass'] = function()
{
    var self = this;
    console.log('_typeOfClass');
    return 'normal';
};
UndefinedObject.prototype['_deepCopy'] = function()
{
    var self = this;
    console.log('_deepCopy');
};
UndefinedObject.prototype['_shallowCopy'] = function()
{
    var self = this;
    console.log('_shallowCopy');
};
UndefinedObject.prototype['_veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('_veryDeepCopyWith_');
};
UndefinedObject.prototype['_addDependent_'] = function(ignored)
{
    var self = this;
    console.log('_addDependent_');
    send(self, '_error_', ['Nil should not have dependents']);
};
UndefinedObject.prototype['_release'] = function()
{
    var self = this;
    console.log('_release');
};
UndefinedObject.prototype['_suspend'] = function()
{
    var self = this;
    console.log('_suspend');
    send(Processor.classPrototype, '_terminateActive');
};
UndefinedObject.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send(aStream, '_nextPutAll_', ['nil']);
};
UndefinedObject.prototype['_storeOn_'] = function(aStream)
{
    var self = this;
    console.log('_storeOn_');
    send(aStream, '_nextPutAll_', ['nil']);
};
UndefinedObject.prototype['_asSetElement'] = function()
{
    var self = this;
    console.log('_asSetElement');
    return send(SetElement.classPrototype, '_withNil');
};
UndefinedObject.prototype['_haltIfNil'] = function()
{
    var self = this;
    console.log('_haltIfNil');
    send(self, '_halt');
};
UndefinedObject.prototype['_ifNil_'] = function(aBlock)
{
    var self = this;
    console.log('_ifNil_');
    return send(aBlock, '_value');
};
UndefinedObject.prototype['_ifNil_ifNotNilDo_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('_ifNil_ifNotNilDo_');
    return send(nilBlock, '_value');
};
UndefinedObject.prototype['_ifNil_ifNotNil_'] = function(nilBlock, ifNotNilBlock)
{
    var self = this;
    console.log('_ifNil_ifNotNil_');
    return send(nilBlock, '_value');
};
UndefinedObject.prototype['_ifNotNilDo_'] = function(aBlock)
{
    var self = this;
    console.log('_ifNotNilDo_');
    return self;
};
UndefinedObject.prototype['_ifNotNilDo_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('_ifNotNilDo_ifNil_');
    return send(nilBlock, '_value');
};
UndefinedObject.prototype['_ifNotNil_'] = function(aBlock)
{
    var self = this;
    console.log('_ifNotNil_');
    return self;
};
UndefinedObject.prototype['_ifNotNil_ifNil_'] = function(ifNotNilBlock, nilBlock)
{
    var self = this;
    console.log('_ifNotNil_ifNil_');
    return send(nilBlock, '_value');
};
UndefinedObject.prototype['_isEmptyOrNil'] = function()
{
    var self = this;
    console.log('_isEmptyOrNil');
    return true;
};
UndefinedObject.prototype['_isLiteral'] = function()
{
    var self = this;
    console.log('_isLiteral');
    return true;
};
UndefinedObject.prototype['_isNil'] = function()
{
    var self = this;
    console.log('_isNil');
    return true;
};
UndefinedObject.prototype['_notNil'] = function()
{
    var self = this;
    console.log('_notNil');
    return false;
};
UndefinedObjectClass.prototype['_allInstances'] = function()
{
    var self = this;
    console.log('_allInstances');
    return send(Array.classPrototype, '_with_', [nil]);
};
UndefinedObjectClass.prototype['_allInstancesDo_'] = function(aBlock)
{
    var self = this;
    console.log('_allInstancesDo_');
    send(aBlock, '_value_', [nil]);
};
UndefinedObjectClass.prototype['_new'] = function()
{
    var self = this;
    console.log('_new');
    send(self, '_error_', ['You may not create any more undefined objects--use nil']);
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
Boolean.prototype['_and_and_'] = function(block1, block2)
{
    var self = this;
    var __context = {};
    console.log('_and_and_');
    send(self, '_deprecated_', ['use and:']);
    if (__context.return) return __context.value;
    send(self, '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['_and_and_and_'] = function(block1, block2, block3)
{
    var self = this;
    var __context = {};
    console.log('_and_and_and_');
    send(self, '_deprecated_', ['Use and: instead']);
    if (__context.return) return __context.value;
    send(self, '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['_and_and_and_and_'] = function(block1, block2, block3, block4)
{
    var self = this;
    var __context = {};
    console.log('_and_and_and_and_');
    send(self, '_deprecated_', ['Use and: instead']);
    if (__context.return) return __context.value;
    send(self, '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block4, '_value'), '_ifFalse_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Boolean.prototype['_or_or_'] = function(block1, block2)
{
    var self = this;
    var __context = {};
    console.log('_or_or_');
    send(self, '_deprecated_', ['use a or:[b or:[c]] instead']);
    if (__context.return) return __context.value;
    send(self, '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['_or_or_or_'] = function(block1, block2, block3)
{
    var self = this;
    var __context = {};
    console.log('_or_or_or_');
    send(self, '_deprecated_', ['use a or:[b or:[c or:[d]]] instead']);
    if (__context.return) return __context.value;
    send(self, '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['_or_or_or_or_'] = function(block1, block2, block3, block4)
{
    var self = this;
    var __context = {};
    console.log('_or_or_or_or_');
    send(self, '_deprecated_', ['use a or:[b or:[c or:[d or:[e]]]] instead']);
    if (__context.return) return __context.value;
    send(self, '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block1, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block2, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block3, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(block4, '_value'), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Boolean.prototype['_and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_and_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifFalse_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('_ifFalse_ifTrue_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifTrue_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('_ifTrue_ifFalse_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_or_');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_deepCopy'] = function()
{
    var self = this;
    console.log('_deepCopy');
};
Boolean.prototype['_shallowCopy'] = function()
{
    var self = this;
    console.log('_shallowCopy');
};
Boolean.prototype['_veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('_veryDeepCopyWith_');
};
Boolean.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['==>'] = function(aBlock)
{
    var self = this;
    console.log('==>');
    return send(send(self, '_not'), '_or_', [function() {
        send(aBlock, '_value');
    }
    ]);
};
Boolean.prototype['_eqv_'] = function(aBoolean)
{
    var self = this;
    console.log('_eqv_');
    return send(self, '==', [aBoolean]);
};
Boolean.prototype['_not'] = function()
{
    var self = this;
    console.log('_not');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    send(self, '_subclassResponsibility');
};
Boolean.prototype['_isLiteral'] = function()
{
    var self = this;
    console.log('_isLiteral');
    return true;
};
Boolean.prototype['_storeOn_'] = function(aStream)
{
    var self = this;
    console.log('_storeOn_');
    send(self, '_printOn_', [aStream]);
};
Boolean.prototype['_isSelfEvaluating'] = function()
{
    var self = this;
    console.log('_isSelfEvaluating');
    return true;
};
BooleanClass.prototype['_settingInputWidgetForNode_'] = function(aSettingNode)
{
    var self = this;
    console.log('_settingInputWidgetForNode_');
    return send(aSettingNode, '_inputWidgetForBoolean');
};
BooleanClass.prototype['_new'] = function()
{
    var self = this;
    console.log('_new');
    send(self, '_error_', ['You may not create any more Booleans - this is two-valued logic']);
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
False.prototype['_and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_and_');
    return self;
};
False.prototype['_ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifFalse_');
    return send(alternativeBlock, '_value');
};
False.prototype['_ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('_ifFalse_ifTrue_');
    return send(falseAlternativeBlock, '_value');
};
False.prototype['_ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifTrue_');
    return nil;
};
False.prototype['_ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('_ifTrue_ifFalse_');
    return send(falseAlternativeBlock, '_value');
};
False.prototype['_or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_or_');
    return send(alternativeBlock, '_value');
};
False.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    return self;
};
False.prototype['_not'] = function()
{
    var self = this;
    console.log('_not');
    return true;
};
False.prototype['_xor_'] = function(aBoolean)
{
    var self = this;
    console.log('_xor_');
    return send(aBoolean, '_value');
};
False.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    return aBoolean;
};
False.prototype['_asBit'] = function()
{
    var self = this;
    console.log('_asBit');
    return 0;
};
False.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send(aStream, '_nextPutAll_', ['false']);
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
True.prototype['_and_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_and_');
    return send(alternativeBlock, '_value');
};
True.prototype['_ifFalse_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifFalse_');
    return nil;
};
True.prototype['_ifFalse_ifTrue_'] = function(falseAlternativeBlock, trueAlternativeBlock)
{
    var self = this;
    console.log('_ifFalse_ifTrue_');
    return send(trueAlternativeBlock, '_value');
};
True.prototype['_ifTrue_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_ifTrue_');
    return send(alternativeBlock, '_value');
};
True.prototype['_ifTrue_ifFalse_'] = function(trueAlternativeBlock, falseAlternativeBlock)
{
    var self = this;
    console.log('_ifTrue_ifFalse_');
    return send(trueAlternativeBlock, '_value');
};
True.prototype['_or_'] = function(alternativeBlock)
{
    var self = this;
    console.log('_or_');
    return self;
};
True.prototype['&'] = function(aBoolean)
{
    var self = this;
    console.log('&');
    return aBoolean;
};
True.prototype['_not'] = function()
{
    var self = this;
    console.log('_not');
    return false;
};
True.prototype['_xor_'] = function(aBoolean)
{
    var self = this;
    console.log('_xor_');
    return send(send(aBoolean, '_value'), '_not');
};
True.prototype['|'] = function(aBoolean)
{
    var self = this;
    console.log('|');
    return self;
};
True.prototype['_asBit'] = function()
{
    var self = this;
    console.log('_asBit');
    return 1;
};
True.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send(aStream, '_nextPutAll_', ['true']);
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
WeakMessageSend.prototype.selector = null;
WeakMessageSend.prototype.shouldBeNil = null;
WeakMessageSend.prototype.arguments = null;
WeakMessageSendClass.__super = ObjectClass;
WeakMessageSend.__super = Object;
WeakMessageSend.prototype['_arguments'] = function()
{
    var self = this;
    console.log('_arguments');
    return send(self.arguments, '_ifNil_', [function() {
        send(Array.classPrototype, '_new');
    }
    ]);
};
WeakMessageSend.prototype['_arguments_'] = function(anArray)
{
    var self = this;
    console.log('_arguments_');
    self.arguments = send(WeakArray.classPrototype, '_withAll_', [anArray]);
    self.shouldBeNil = send(Array.classPrototype, '_withAll_', [send(anArray, '_collect_', [function(ea) {
        send(ea, '_isNil');
    }
    ])]);
};
WeakMessageSend.prototype['_receiver'] = function()
{
    var self = this;
    console.log('_receiver');
    return send(self, '_at_', [1]);
};
WeakMessageSend.prototype['_receiver_'] = function(anObject)
{
    var self = this;
    console.log('_receiver_');
    send(self, '_at_put_', [1, anObject]);
};
WeakMessageSend.prototype['_selector'] = function()
{
    var self = this;
    console.log('_selector');
    return self.selector;
};
WeakMessageSend.prototype['_selector_'] = function(aSymbol)
{
    var self = this;
    console.log('_selector_');
    self.selector = aSymbol;
};
WeakMessageSend.prototype['='] = function(anObject)
{
    var self = this;
    console.log('=');
    return send(send(anObject, '_isMessageSend'), '_and_', [function() {
        send(send(send(self, '_receiver'), '==', [send(anObject, '_receiver')]), '_and_', [function() {
            send(send(self.selector, '==', [send(anObject, '_selector')]), '_and_', [function() {
                send(send(Array.classPrototype, '_withAll_', [self.arguments]), '=', [send(Array.classPrototype, '_withAll_', [send(anObject, '_arguments')])]);
            }
            ]);
        }
        ]);
    }
    ]);
};
WeakMessageSend.prototype['_hash'] = function()
{
    var self = this;
    console.log('_hash');
    return send(send(send(self, '_receiver'), '_hash'), '_bitXor_', [send(self.selector, '_hash')]);
};
WeakMessageSend.prototype['_asMessageSend'] = function()
{
    var self = this;
    console.log('_asMessageSend');
    return send(MessageSend.classPrototype, '_receiver_selector_arguments_', [send(self, '_receiver'), self.selector, send(Array.classPrototype, '_withAll_', [send(self, '_arguments')])]);
};
WeakMessageSend.prototype['_asMinimalRepresentation'] = function()
{
    var self = this;
    var __context = {};
    console.log('_asMinimalRepresentation');
    send(send(self, '_isReceiverOrAnyArgumentGarbage'), '_ifTrue_ifFalse_', [function() {
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
WeakMessageSend.prototype['_cull_'] = function(arg)
{
    var self = this;
    console.log('_cull_');
    return send(send(send(self.selector, '_numArgs'), '=', [0]), '_ifTrue_ifFalse_', [function() {
        send(self, '_value');
    }
    , function() {
        send(self, '_value_', [arg]);
    }
    ]);
};
WeakMessageSend.prototype['_cull_cull_'] = function(arg1, arg2)
{
    var self = this;
    console.log('_cull_cull_');
    return send(send(send(self.selector, '_numArgs'), '<', [2]), '_ifTrue_ifFalse_', [function() {
        send(self, '_cull_', [arg1]);
    }
    , function() {
        send(self, '_value_value_', [arg1, arg2]);
    }
    ]);
};
WeakMessageSend.prototype['_cull_cull_cull_'] = function(arg1, arg2, arg3)
{
    var self = this;
    console.log('_cull_cull_cull_');
    return send(send(send(self.selector, '_numArgs'), '<', [3]), '_ifTrue_ifFalse_', [function() {
        send(self, '_cull_cull_', [arg1, arg2]);
    }
    , function() {
        send(self, '_value_value_value_', [arg1, arg2, arg3]);
    }
    ]);
};
WeakMessageSend.prototype['_value'] = function()
{
    var self = this;
    console.log('_value');
    return send(send(self.arguments, '_isNil'), '_ifTrue_ifFalse_', [function() {
        send(send(self, '_ensureReceiver'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_receiver'), '_perform_', [self.selector]);
        }
        , function() {
        }
        ]);
    }
    , function() {
        send(send(self, '_ensureReceiverAndArguments'), '_ifTrue_ifFalse_', [function() {
            send(send(self, '_receiver'), '_perform_withArguments_', [self.selector, send(Array.classPrototype, '_withAll_', [self.arguments])]);
        }
        , function() {
        }
        ]);
    }
    ]);
};
WeakMessageSend.prototype['_value_'] = function(anObject)
{
    var self = this;
    var __context = {};
    console.log('_value_');
    send(send(self, '_ensureReceiver'), '_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_receiver'), '_perform_with_', [self.selector, anObject]);
};
WeakMessageSend.prototype['_value_value_'] = function(anObject1, anObject2)
{
    var self = this;
    var __context = {};
    console.log('_value_value_');
    send(send(self, '_ensureReceiver'), '_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_receiver'), '_perform_with_with_', [self.selector, anObject1, anObject2]);
};
WeakMessageSend.prototype['_value_value_value_'] = function(anObject1, anObject2, anObject3)
{
    var self = this;
    var __context = {};
    console.log('_value_value_value_');
    send(send(self, '_ensureReceiver'), '_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_receiver'), '_perform_with_with_with_', [self.selector, anObject1, anObject2, anObject3]);
};
WeakMessageSend.prototype['_valueWithArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('_valueWithArguments_');
    send(send(self, '_ensureReceiverAndArguments'), '_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_receiver'), '_perform_withArguments_', [self.selector, send(self, '_collectArguments_', [anArray])]);
};
WeakMessageSend.prototype['_valueWithEnoughArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('_valueWithEnoughArguments_');
    var args = null
    send(send(self, '_ensureReceiverAndArguments'), '_ifFalse_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    args = send(Array.classPrototype, '_new_', [send(self.selector, '_numArgs')]);
    send(args, '_replaceFrom_to_with_startingAt_', [1, send(send(self.arguments, '_size'), '_min_', [send(args, '_size')]), self.arguments, 1]);
    if (__context.return) return __context.value;
    send(send(send(args, '_size'), '>', [send(self.arguments, '_size')]), '_ifTrue_', [function() {
        send(args, '_replaceFrom_to_with_startingAt_', [send(send(self.arguments, '_size'), '+', [1]), send(send(send(self.arguments, '_size'), '+', [send(anArray, '_size')]), '_min_', [send(args, '_size')]), anArray, 1]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_receiver'), '_perform_withArguments_', [self.selector, args]);
};
WeakMessageSend.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send((function () {var _aux = send(aStream, '_nextPutAll_', [send(send(self, '_class'), '_name')]);return _aux;})(), '_nextPut_', ['(']);
    send(self.selector, '_printOn_', [aStream]);
    send(aStream, '_nextPutAll_', [' -> ']);
    send(send(self, '_receiver'), '_printOn_', [aStream]);
    send(aStream, '_nextPut_', [')']);
};
WeakMessageSend.prototype['_isMessageSend'] = function()
{
    var self = this;
    console.log('_isMessageSend');
    return true;
};
WeakMessageSend.prototype['_isValid'] = function()
{
    var self = this;
    console.log('_isValid');
    return send(send(self, '_isReceiverOrAnyArgumentGarbage'), '_not');
};
WeakMessageSend.prototype['_collectArguments_'] = function(anArgArray)
{
    var self = this;
    console.log('_collectArguments_');
    var staticArgs = null
    staticArgs = send(self, '_arguments');
    return send(send(send(anArgArray, '_size'), '=', [send(staticArgs, '_size')]), '_ifTrue_ifFalse_', [function() {
        anArgArray;
    }
    , function() {
        send(send(send(staticArgs, '_isEmpty'), '_ifTrue_ifFalse_', [function() {
            staticArgs = send(Array.classPrototype, '_new_', [send(self.selector, '_numArgs')]);
        }
        , function() {
            send(staticArgs, '_copy');
        }
        ]), '_replaceFrom_to_with_startingAt_', [1, send(send(anArgArray, '_size'), '_min_', [send(staticArgs, '_size')]), anArgArray, 1]);
    }
    ]);
};
WeakMessageSend.prototype['_ensureArguments'] = function()
{
    var self = this;
    var __context = {};
    console.log('_ensureArguments');
    send(self.arguments, '_ifNotNil_', [function() {
        send(self.arguments, '_with_do_', [self.shouldBeNil, function(arg, flag) {
            send(arg, '_ifNil_', [function() {
                send(flag, '_ifFalse_', [function() {
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
WeakMessageSend.prototype['_ensureReceiver'] = function()
{
    var self = this;
    console.log('_ensureReceiver');
    return send(send(self, '_receiver'), '_notNil');
};
WeakMessageSend.prototype['_ensureReceiverAndArguments'] = function()
{
    var self = this;
    var __context = {};
    console.log('_ensureReceiverAndArguments');
    send(send(self, '_receiver'), '_ifNil_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self.arguments, '_ifNotNil_', [function() {
        send(self.arguments, '_with_do_', [self.shouldBeNil, function(arg, flag) {
            send(arg, '_ifNil_', [function() {
                send(flag, '_ifFalse_', [function() {
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
WeakMessageSend.prototype['_isAnyArgumentGarbage'] = function()
{
    var self = this;
    var __context = {};
    console.log('_isAnyArgumentGarbage');
    send(self.arguments, '_ifNotNil_', [function() {
        send(self.arguments, '_with_do_', [self.shouldBeNil, function(arg, flag) {
            send(send(send(flag, '_not'), '_and_', [function() {
                send(arg, '_isNil');
                if (__context.return) return __context.value;
            }
            ]), '_ifTrue_', [function() {
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
WeakMessageSend.prototype['_isReceiverGarbage'] = function()
{
    var self = this;
    console.log('_isReceiverGarbage');
    return send(send(self, '_receiver'), '_isNil');
};
WeakMessageSend.prototype['_isReceiverOrAnyArgumentGarbage'] = function()
{
    var self = this;
    console.log('_isReceiverOrAnyArgumentGarbage');
    return send(send(self, '_isReceiverGarbage'), '_or_', [function() {
        send(self, '_isAnyArgumentGarbage');
    }
    ]);
};
WeakMessageSendClass.prototype['_new'] = function()
{
    var self = this;
    console.log('_new');
    return send(self, '_new_', [1]);
};
WeakMessageSendClass.prototype['_receiver_selector_'] = function(anObject, aSymbol)
{
    var self = this;
    console.log('_receiver_selector_');
    return send(self, '_receiver_selector_arguments_', [anObject, aSymbol, []]);
};
WeakMessageSendClass.prototype['_receiver_selector_argument_'] = function(anObject, aSymbol, aParameter)
{
    var self = this;
    console.log('_receiver_selector_argument_');
    return send(self, '_receiver_selector_arguments_', [anObject, aSymbol, send(Array.classPrototype, '_with_', [aParameter])]);
};
WeakMessageSendClass.prototype['_receiver_selector_arguments_'] = function(anObject, aSymbol, anArray)
{
    var self = this;
    console.log('_receiver_selector_arguments_');
    return send((function () {var _aux = send((function () {var _aux = send(send(self, '_new'), '_receiver_', [anObject]);return _aux;})(), '_selector_', [aSymbol]);return _aux;})(), '_arguments_', [anArray]);
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
WeakActionSequence.prototype['_asActionSequence'] = function()
{
    var self = this;
    console.log('_asActionSequence');
    return self;
};
WeakActionSequence.prototype['_asActionSequenceTrappingErrors'] = function()
{
    var self = this;
    console.log('_asActionSequenceTrappingErrors');
    return send(WeakActionSequenceTrappingErrors.classPrototype, '_withAll_', [self]);
};
WeakActionSequence.prototype['_asMinimalRepresentation'] = function()
{
    var self = this;
    var __context = {};
    console.log('_asMinimalRepresentation');
    var valid = null
    valid = send(self, '_select_', [function(e) {
        send(e, '_isValid');
        if (__context.return) return __context.value;
    }
    ]);
    send(send(send(valid, '_size'), '=', [0]), '_ifTrue_', [function() {
        __context.value = nil;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(valid, '_size'), '=', [1]), '_ifTrue_', [function() {
        __context.value = send(valid, '_first');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return valid;
};
WeakActionSequence.prototype['_value'] = function()
{
    var self = this;
    var __context = {};
    console.log('_value');
    var answer = null
    send(self, '_do_', [function(each) {
        send(send(each, '_isValid'), '_ifTrue_', [function() {
            answer = send(each, '_value');
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return answer;
};
WeakActionSequence.prototype['_valueWithArguments_'] = function(anArray)
{
    var self = this;
    var __context = {};
    console.log('_valueWithArguments_');
    var answer = null
    send(self, '_do_', [function(each) {
        send(send(each, '_isValid'), '_ifTrue_', [function() {
            answer = send(each, '_valueWithArguments_', [anArray]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return answer;
};
WeakActionSequence.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('_printOn_');
    send(send(send(self, '_size'), '<', [2]), '_ifTrue_', [function() {
        __context.value = sendSuper(self, WeakActionSequence, '_printOn_', [aStream]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, '_nextPutAll_', ['#(']);
    if (__context.return) return __context.value;
    send(self, '_do_separatedBy_', [function(each) {
        send(each, '_printOn_', [aStream]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(aStream, '_cr');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(aStream, '_nextPut_', [')']);
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
Point.prototype.x = null;
Point.prototype.y = null;
PointClass.__super = ObjectClass;
Point.__super = Object;
Point.prototype['_directionToLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('_directionToLineFrom_to_');
    return send(send(send(send(p2, '_x'), '-', [send(p1, '_x')]), '*', [send(send(self, '_y'), '-', [send(p1, '_y')])]), '-', [send(send(send(self, '_x'), '-', [send(p1, '_x')]), '*', [send(send(p2, '_y'), '-', [send(p1, '_y')])])]);
};
Point.prototype['_angle'] = function()
{
    var self = this;
    console.log('_angle');
    return send(send(self, '_y'), '_arcTan_', [send(self, '_x')]);
};
Point.prototype['_angleWith_'] = function(aPoint)
{
    var self = this;
    console.log('_angleWith_');
    var ar = null
    var ap = null
    ar = send(self, '_angle');
    ap = send(aPoint, '_angle');
    return send(send(ap, '>=', [ar]), '_ifTrue_ifFalse_', [function() {
        send(ap, '-', [ar]);
    }
    , function() {
        send(send(send(send(Float.classPrototype, '_pi'), '*', [2]), '-', [ar]), '+', [ap]);
    }
    ]);
};
Point.prototype['_max'] = function()
{
    var self = this;
    console.log('_max');
    return send(send(self, '_x'), '_max_', [send(self, '_y')]);
};
Point.prototype['_min'] = function()
{
    var self = this;
    console.log('_min');
    return send(send(self, '_x'), '_min_', [send(self, '_y')]);
};
Point.prototype['_reflectedAbout_'] = function(aPoint)
{
    var self = this;
    console.log('_reflectedAbout_');
    return send(send(send(self, '-', [aPoint]), '_negated'), '+', [aPoint]);
};
Point.prototype['_x'] = function()
{
    var self = this;
    console.log('_x');
    return self.x;
};
Point.prototype['_y'] = function()
{
    var self = this;
    console.log('_y');
    return self.y;
};
Point.prototype['*'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('*');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '*', [send(arg, '_x')]), '@', [send(self.y, '*', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '*']);
};
Point.prototype['+'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('+');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '+', [send(arg, '_x')]), '@', [send(self.y, '+', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '+']);
};
Point.prototype['-'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('-');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '-', [send(arg, '_x')]), '@', [send(self.y, '-', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '-']);
};
Point.prototype['/'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('/');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '/', [send(arg, '_x')]), '@', [send(self.y, '/', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '/']);
};
Point.prototype['//'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('//');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '//', [send(arg, '_x')]), '@', [send(self.y, '//', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '//']);
};
Point.prototype['\\'] = function(arg)
{
    var self = this;
    var __context = {};
    console.log('\\');
    send(send(arg, '_isPoint'), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '\\', [send(arg, '_x')]), '@', [send(self.y, '\\', [send(arg, '_y')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(arg, '_adaptToPoint_andSend_', [self, '\\']);
};
Point.prototype['_abs'] = function()
{
    var self = this;
    console.log('_abs');
    return send(send(self.x, '_abs'), '@', [send(self.y, '_abs')]);
};
Point.prototype['_reciprocal'] = function()
{
    var self = this;
    console.log('_reciprocal');
    return send(send(self.x, '_reciprocal'), '@', [send(self.y, '_reciprocal')]);
};
Point.prototype['<'] = function(aPoint)
{
    var self = this;
    console.log('<');
    return send(send(self.x, '<', [send(aPoint, '_x')]), '_and_', [function() {
        send(self.y, '<', [send(aPoint, '_y')]);
    }
    ]);
};
Point.prototype['<='] = function(aPoint)
{
    var self = this;
    console.log('<=');
    return send(send(self.x, '<=', [send(aPoint, '_x')]), '_and_', [function() {
        send(self.y, '<=', [send(aPoint, '_y')]);
    }
    ]);
};
Point.prototype['='] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('=');
    send(send(send(self, '_species'), '=', [send(aPoint, '_species')]), '_ifTrue_ifFalse_', [function() {
        __context.value = send(send(self.x, '=', [send(aPoint, '_x')]), '_and_', [function() {
            send(self.y, '=', [send(aPoint, '_y')]);
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
    return send(send(self.x, '>', [send(aPoint, '_x')]), '_and_', [function() {
        send(self.y, '>', [send(aPoint, '_y')]);
    }
    ]);
};
Point.prototype['>='] = function(aPoint)
{
    var self = this;
    console.log('>=');
    return send(send(self.x, '>=', [send(aPoint, '_x')]), '_and_', [function() {
        send(self.y, '>=', [send(aPoint, '_y')]);
    }
    ]);
};
Point.prototype['_closeTo_'] = function(aPoint)
{
    var self = this;
    console.log('_closeTo_');
    return send(send(self.x, '_closeTo_', [send(aPoint, '_x')]), '_and_', [function() {
        send(self.y, '_closeTo_', [send(aPoint, '_y')]);
    }
    ]);
};
Point.prototype['_hash'] = function()
{
    var self = this;
    console.log('_hash');
    return send(send(send(send(self.x, '_hash'), '_hashMultiply'), '+', [send(self.y, '_hash')]), '_hashMultiply');
};
Point.prototype['_max_'] = function(aPoint)
{
    var self = this;
    console.log('_max_');
    return send(send(self.x, '_max_', [send(aPoint, '_x')]), '@', [send(self.y, '_max_', [send(aPoint, '_y')])]);
};
Point.prototype['_min_'] = function(aPoint)
{
    var self = this;
    console.log('_min_');
    return send(send(self.x, '_min_', [send(aPoint, '_x')]), '@', [send(self.y, '_min_', [send(aPoint, '_y')])]);
};
Point.prototype['_min_max_'] = function(aMin, aMax)
{
    var self = this;
    console.log('_min_max_');
    return send(send(self, '_min_', [aMin]), '_max_', [aMax]);
};
Point.prototype['_adaptToCollection_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToCollection_andSend_');
    return send(rcvr, '_collect_', [function(element) {
        send(element, '_perform_with_', [selector, self]);
    }
    ]);
};
Point.prototype['_adaptToNumber_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToNumber_andSend_');
    return send(send(rcvr, '@', [rcvr]), '_perform_with_', [selector, self]);
};
Point.prototype['_adaptToString_andSend_'] = function(rcvr, selector)
{
    var self = this;
    console.log('_adaptToString_andSend_');
    return send(send(rcvr, '_asNumber'), '_perform_with_', [selector, self]);
};
Point.prototype['_asFloatPoint'] = function()
{
    var self = this;
    console.log('_asFloatPoint');
    return send(send(self.x, '_asFloat'), '@', [send(self.y, '_asFloat')]);
};
Point.prototype['_asIntegerPoint'] = function()
{
    var self = this;
    console.log('_asIntegerPoint');
    return send(send(self.x, '_asInteger'), '@', [send(self.y, '_asInteger')]);
};
Point.prototype['_asNonFractionalPoint'] = function()
{
    var self = this;
    var __context = {};
    console.log('_asNonFractionalPoint');
    send(send(send(self.x, '_isFraction'), '_or_', [function() {
        send(self.y, '_isFraction');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = send(send(self.x, '_asFloat'), '@', [send(self.y, '_asFloat')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['_asPoint'] = function()
{
    var self = this;
    console.log('_asPoint');
    return self;
};
Point.prototype['_corner_'] = function(aPoint)
{
    var self = this;
    console.log('_corner_');
    return send(Rectangle.classPrototype, '_origin_corner_', [self, aPoint]);
};
Point.prototype['_extent_'] = function(aPoint)
{
    var self = this;
    console.log('_extent_');
    return send(Rectangle.classPrototype, '_origin_extent_', [self, aPoint]);
};
Point.prototype['_isPoint'] = function()
{
    var self = this;
    console.log('_isPoint');
    return true;
};
Point.prototype['_rect_'] = function(aPoint)
{
    var self = this;
    console.log('_rect_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self, '_min_', [aPoint]), send(self, '_max_', [aPoint])]);
};
Point.prototype['_deepCopy'] = function()
{
    var self = this;
    console.log('_deepCopy');
    return send(send(self.x, '_deepCopy'), '@', [send(self.y, '_deepCopy')]);
};
Point.prototype['_veryDeepCopyWith_'] = function(deepCopier)
{
    var self = this;
    console.log('_veryDeepCopyWith_');
};
Point.prototype['_guarded'] = function()
{
    var self = this;
    console.log('_guarded');
    send(self, '_max_', [send(1, '@', [1])]);
};
Point.prototype['_scaleTo_'] = function(anExtent)
{
    var self = this;
    var __context = {};
    console.log('_scaleTo_');
    var factor = null
    var sX = null
    var sY = null
    factor = send(3, '_reciprocal');
    sX = send(send(anExtent, '_x'), '/', [send(send(self, '_x'), '_asFloat')]);
    sY = send(send(anExtent, '_y'), '/', [send(send(self, '_y'), '_asFloat')]);
    send(send(sX, '=', [sY]), '_ifTrue_', [function() {
        __context.value = send(sX, '@', [sY]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(sX, '<', [sY]), '_ifTrue_ifFalse_', [function() {
        send(sX, '@', [send(sX, '_max_', [send(sY, '*', [factor])])]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(sY, '_max_', [send(sX, '*', [factor])]), '@', [sY]);
        if (__context.return) return __context.value;
    }
    ]);
};
Point.prototype['_isInsideCircle_with_with_'] = function(a, b, c)
{
    var self = this;
    console.log('_isInsideCircle_with_with_');
    return send(send(send(send(send(send(a, '_dotProduct_', [a]), '*', [send(b, '_triangleArea_with_', [c, self])]), '-', [send(send(b, '_dotProduct_', [b]), '*', [send(a, '_triangleArea_with_', [c, self])])]), '+', [send(send(c, '_dotProduct_', [c]), '*', [send(a, '_triangleArea_with_', [b, self])])]), '-', [send(send(self, '_dotProduct_', [self]), '*', [send(a, '_triangleArea_with_', [b, c])])]), '>', [0]);
};
Point.prototype['_sideOf_'] = function(otherPoint)
{
    var self = this;
    console.log('_sideOf_');
    var side = null
    side = send(send(self, '_crossProduct_', [otherPoint]), '_sign');
    return send(['right', 'center', 'left'], '_at_', [send(side, '+', [2])]);
};
Point.prototype['_to_intersects_to_'] = function(end1, start2, end2)
{
    var self = this;
    var __context = {};
    console.log('_to_intersects_to_');
    var start1 = null
    var sideStart = null
    var sideEnd = null
    start1 = self;
    send(send(send(send(send(start1, '=', [start2]), '_or_', [function() {
        send(end1, '=', [end2]);
        if (__context.return) return __context.value;
    }
    ]), '_or_', [function() {
        send(start1, '=', [end2]);
        if (__context.return) return __context.value;
    }
    ]), '_or_', [function() {
        send(start2, '=', [end1]);
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = true;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    sideStart = send(start1, '_to_sideOf_', [end1, start2]);
    sideEnd = send(start1, '_to_sideOf_', [end1, end2]);
    send(send(sideStart, '=', [sideEnd]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    sideStart = send(start2, '_to_sideOf_', [end2, start1]);
    sideEnd = send(start2, '_to_sideOf_', [end2, end1]);
    send(send(sideStart, '=', [sideEnd]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Point.prototype['_to_sideOf_'] = function(end, otherPoint)
{
    var self = this;
    console.log('_to_sideOf_');
    return send(send(end, '-', [self]), '_sideOf_', [send(otherPoint, '-', [self])]);
};
Point.prototype['_triangleArea_with_'] = function(b, c)
{
    var self = this;
    console.log('_triangleArea_with_');
    return send(send(send(send(b, '_x'), '-', [send(self, '_x')]), '*', [send(send(c, '_y'), '-', [send(self, '_y')])]), '-', [send(send(send(b, '_y'), '-', [send(self, '_y')]), '*', [send(send(c, '_x'), '-', [send(self, '_x')])])]);
};
Point.prototype['_interpolateTo_at_'] = function(end, amountDone)
{
    var self = this;
    console.log('_interpolateTo_at_');
    return send(self, '+', [send(send(end, '-', [self]), '*', [amountDone])]);
};
Point.prototype['_bearingToPoint_'] = function(anotherPoint)
{
    var self = this;
    var __context = {};
    console.log('_bearingToPoint_');
    var deltaX = null
    var deltaY = null
    deltaX = send(send(anotherPoint, '_x'), '-', [self.x]);
    deltaY = send(send(anotherPoint, '_y'), '-', [self.y]);
    send(send(send(deltaX, '_abs'), '<', [0,001]), '_ifTrue_', [function() {
        __context.value = send(send(deltaY, '>', [0]), '_ifTrue_ifFalse_', [function() {
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
    return send(send(send(send(deltaX, '>=', [0]), '_ifTrue_ifFalse_', [function() {
        90;
    }
    , function() {
        270;
    }
    ]), '-', [send(send(send(send(deltaY, '/', [deltaX]), '_arcTan'), '_negated'), '_radiansToDegrees')]), '_rounded');
};
Point.prototype['_crossProduct_'] = function(aPoint)
{
    var self = this;
    console.log('_crossProduct_');
    return send(send(self.x, '*', [send(aPoint, '_y')]), '-', [send(self.y, '*', [send(aPoint, '_x')])]);
};
Point.prototype['_dist_'] = function(aPoint)
{
    var self = this;
    console.log('_dist_');
    var dx = null
    var dy = null
    dx = send(send(aPoint, '_x'), '-', [self.x]);
    dy = send(send(aPoint, '_y'), '-', [self.y]);
    return send(send(send(dx, '*', [dx]), '+', [send(dy, '*', [dy])]), '_sqrt');
};
Point.prototype['_dotProduct_'] = function(aPoint)
{
    var self = this;
    console.log('_dotProduct_');
    return send(send(self.x, '*', [send(aPoint, '_x')]), '+', [send(self.y, '*', [send(aPoint, '_y')])]);
};
Point.prototype['_eightNeighbors'] = function()
{
    var self = this;
    console.log('_eightNeighbors');
    return [send(self, '+', [send(1, '@', [0])]), send(self, '+', [send(1, '@', [1])]), send(self, '+', [send(0, '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [0])]), send(self, '+', [send(send(1, '-'), '@', [send(1, '-')])]), send(self, '+', [send(0, '@', [send(1, '-')])]), send(self, '+', [send(1, '@', [send(1, '-')])])];
};
Point.prototype['_flipBy_centerAt_'] = function(direction, c)
{
    var self = this;
    var __context = {};
    console.log('_flipBy_centerAt_');
    send(send(direction, '==', ['vertical']), '_ifTrue_', [function() {
        __context.value = send(self.x, '@', [send(send(send(c, '_y'), '*', [2]), '-', [self.y])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['horizontal']), '_ifTrue_', [function() {
        __context.value = send(send(send(send(c, '_x'), '*', [2]), '-', [self.x]), '@', [self.y]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_error_', ['unrecognizable direction']);
    if (__context.return) return __context.value;
};
Point.prototype['_fourDirections'] = function()
{
    var self = this;
    console.log('_fourDirections');
    return send(Array.classPrototype, '_with_with_with_with_', [send(self, '_leftRotated'), send(self, '_negated'), send(self, '_rightRotated'), self]);
};
Point.prototype['_fourNeighbors'] = function()
{
    var self = this;
    console.log('_fourNeighbors');
    return send(Array.classPrototype, '_with_with_with_with_', [send(self, '+', [send(1, '@', [0])]), send(self, '+', [send(0, '@', [1])]), send(self, '+', [send(send(1, '-'), '@', [0])]), send(self, '+', [send(0, '@', [send(1, '-')])])]);
};
Point.prototype['_grid_'] = function(aPoint)
{
    var self = this;
    console.log('_grid_');
    var newX = null
    var newY = null
    newX = send(send(self.x, '+', [send(send(aPoint, '_x'), '//', [2])]), '_truncateTo_', [send(aPoint, '_x')]);
    newY = send(send(self.y, '+', [send(send(aPoint, '_y'), '//', [2])]), '_truncateTo_', [send(aPoint, '_y')]);
    return send(newX, '@', [newY]);
};
Point.prototype['_insideTriangle_with_with_'] = function(p1, p2, p3)
{
    var self = this;
    var __context = {};
    console.log('_insideTriangle_with_with_');
    var p0 = null
    var b0 = null
    var b1 = null
    var b2 = null
    var b3 = null
    p0 = self;
    b0 = send(send(send(send(p2, '_x'), '-', [send(p1, '_x')]), '*', [send(send(p3, '_y'), '-', [send(p1, '_y')])]), '-', [send(send(send(p3, '_x'), '-', [send(p1, '_x')]), '*', [send(send(p2, '_y'), '-', [send(p1, '_y')])])]);
    send(send(b0, '_isZero'), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    b0 = send(1, '/', [b0]);
    b1 = send(send(send(send(send(p2, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p3, '_y'), '-', [send(p0, '_y')])]), '-', [send(send(send(p3, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p2, '_y'), '-', [send(p0, '_y')])])]), '*', [b0]);
    b2 = send(send(send(send(send(p3, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p1, '_y'), '-', [send(p0, '_y')])]), '-', [send(send(send(p1, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p3, '_y'), '-', [send(p0, '_y')])])]), '*', [b0]);
    b3 = send(send(send(send(send(p1, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p2, '_y'), '-', [send(p0, '_y')])]), '-', [send(send(send(p2, '_x'), '-', [send(p0, '_x')]), '*', [send(send(p1, '_y'), '-', [send(p0, '_y')])])]), '*', [b0]);
    send(send(b1, '<', [0]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(b2, '<', [0]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(b3, '<', [0]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Point.prototype['_leftRotated'] = function()
{
    var self = this;
    console.log('_leftRotated');
    return send(self.y, '@', [send(self.x, '_negated')]);
};
Point.prototype['_nearestPointAlongLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    var __context = {};
    console.log('_nearestPointAlongLineFrom_to_');
    var x21 = null
    var y21 = null
    var t = null
    var x1 = null
    var y1 = null
    send(send(send(p1, '_x'), '=', [send(p2, '_x')]), '_ifTrue_', [function() {
        __context.value = send(send(p1, '_x'), '@', [self.y]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(p1, '_y'), '=', [send(p2, '_y')]), '_ifTrue_', [function() {
        __context.value = send(self.x, '@', [send(p1, '_y')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    x1 = send(send(p1, '_x'), '_asFloat');
    y1 = send(send(p1, '_y'), '_asFloat');
    x21 = send(send(send(p2, '_x'), '_asFloat'), '-', [x1]);
    y21 = send(send(send(p2, '_y'), '_asFloat'), '-', [y1]);
    t = send(send(send(send(send(self.y, '_asFloat'), '-', [y1]), '/', [x21]), '+', [send(send(send(self.x, '_asFloat'), '-', [x1]), '/', [y21])]), '/', [send(send(x21, '/', [y21]), '+', [send(y21, '/', [x21])])]);
    return send(send(x1, '+', [send(t, '*', [x21])]), '@', [send(y1, '+', [send(t, '*', [y21])])]);
};
Point.prototype['_nearestPointOnLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('_nearestPointOnLineFrom_to_');
    return send(send(self, '_nearestPointAlongLineFrom_to_', [p1, p2]), '_adhereTo_', [send(p1, '_rect_', [p2])]);
};
Point.prototype['_normal'] = function()
{
    var self = this;
    var __context = {};
    console.log('_normal');
    var n = null
    var d = null
    n = send(send(self.y, '_negated'), '@', [self.x]);
    send(send(d = send(send(send(n, '_x'), '*', [send(n, '_x')]), '+', [send(send(n, '_y'), '*', [send(n, '_y')])]), '=', [0]), '_ifTrue_', [function() {
        __context.value = send(send(1, '-'), '@', [0]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(n, '/', [send(d, '_sqrt')]);
};
Point.prototype['_normalized'] = function()
{
    var self = this;
    console.log('_normalized');
    var r = null
    r = send(send(send(self.x, '*', [self.x]), '+', [send(self.y, '*', [self.y])]), '_sqrt');
    return send(send(self.x, '/', [r]), '@', [send(self.y, '/', [r])]);
};
Point.prototype['_octantOf_'] = function(otherPoint)
{
    var self = this;
    var __context = {};
    console.log('_octantOf_');
    var quad = null
    var moreHoriz = null
    send(send(send(self.x, '=', [send(otherPoint, '_x')]), '_and_', [function() {
        send(self.y, '>', [send(otherPoint, '_y')]);
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = 6;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self.y, '=', [send(otherPoint, '_y')]), '_and_', [function() {
        send(self.x, '<', [send(otherPoint, '_x')]);
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = 8;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    quad = send(self, '_quadrantOf_', [otherPoint]);
    moreHoriz = send(send(send(self.x, '-', [send(otherPoint, '_x')]), '_abs'), '>=', [send(send(self.y, '-', [send(otherPoint, '_y')]), '_abs')]);
    send(send(send(quad, '_even'), '_eqv_', [moreHoriz]), '_ifTrue_ifFalse_', [function() {
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
Point.prototype['_onLineFrom_to_'] = function(p1, p2)
{
    var self = this;
    console.log('_onLineFrom_to_');
    return send(self, '_onLineFrom_to_within_', [p1, p2, 2]);
};
Point.prototype['_onLineFrom_to_within_'] = function(p1, p2, epsilon)
{
    var self = this;
    var __context = {};
    console.log('_onLineFrom_to_within_');
    send(send(send(p1, '_x'), '<', [send(p2, '_x')]), '_ifTrue_ifFalse_', [function() {
        send(send(send(self.x, '<', [send(send(p1, '_x'), '-', [epsilon])]), '_or_', [function() {
            send(self.x, '>', [send(send(p2, '_x'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), '_ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(send(self.x, '<', [send(send(p2, '_x'), '-', [epsilon])]), '_or_', [function() {
            send(self.x, '>', [send(send(p1, '_x'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), '_ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(p1, '_y'), '<', [send(p2, '_y')]), '_ifTrue_ifFalse_', [function() {
        send(send(send(self.y, '<', [send(send(p1, '_y'), '-', [epsilon])]), '_or_', [function() {
            send(self.y, '>', [send(send(p2, '_y'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), '_ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        send(send(send(self.y, '<', [send(send(p2, '_y'), '-', [epsilon])]), '_or_', [function() {
            send(self.y, '>', [send(send(p1, '_y'), '+', [epsilon])]);
            if (__context.return) return __context.value;
        }
        ]), '_ifTrue_', [function() {
            __context.value = false;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self, '_dist_', [send(self, '_nearestPointAlongLineFrom_to_', [p1, p2])]), '<=', [epsilon]);
};
Point.prototype['_quadrantOf_'] = function(otherPoint)
{
    var self = this;
    console.log('_quadrantOf_');
    return send(send(self.x, '<=', [send(otherPoint, '_x')]), '_ifTrue_ifFalse_', [function() {
        send(send(self.y, '<', [send(otherPoint, '_y')]), '_ifTrue_ifFalse_', [function() {
            1;
        }
        , function() {
            4;
        }
        ]);
    }
    , function() {
        send(send(self.y, '<=', [send(otherPoint, '_y')]), '_ifTrue_ifFalse_', [function() {
            2;
        }
        , function() {
            3;
        }
        ]);
    }
    ]);
};
Point.prototype['_rightRotated'] = function()
{
    var self = this;
    console.log('_rightRotated');
    return send(send(self.y, '_negated'), '@', [self.x]);
};
Point.prototype['_rotateBy_centerAt_'] = function(direction, c)
{
    var self = this;
    var __context = {};
    console.log('_rotateBy_centerAt_');
    var offset = null
    offset = send(self, '-', [c]);
    send(send(direction, '==', ['right']), '_ifTrue_', [function() {
        __context.value = send(send(send(send(offset, '_y'), '_negated'), '@', [send(offset, '_x')]), '+', [c]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['left']), '_ifTrue_', [function() {
        __context.value = send(send(send(offset, '_y'), '@', [send(send(offset, '_x'), '_negated')]), '+', [c]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(direction, '==', ['pi']), '_ifTrue_', [function() {
        __context.value = send(c, '-', [offset]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self, '_error_', ['unrecognizable direction']);
    if (__context.return) return __context.value;
};
Point.prototype['_sign'] = function()
{
    var self = this;
    console.log('_sign');
    return send(send(self.x, '_sign'), '@', [send(self.y, '_sign')]);
};
Point.prototype['_sortsBefore_'] = function(otherPoint)
{
    var self = this;
    console.log('_sortsBefore_');
    return send(send(self.y, '=', [send(otherPoint, '_y')]), '_ifTrue_ifFalse_', [function() {
        send(self.x, '<=', [send(otherPoint, '_x')]);
    }
    , function() {
        send(self.y, '<=', [send(otherPoint, '_y')]);
    }
    ]);
};
Point.prototype['_squaredDistanceTo_'] = function(aPoint)
{
    var self = this;
    console.log('_squaredDistanceTo_');
    var delta = null
    delta = send(aPoint, '-', [self]);
    return send(delta, '_dotProduct_', [delta]);
};
Point.prototype['_transposed'] = function()
{
    var self = this;
    console.log('_transposed');
    return send(self.y, '@', [self.x]);
};
Point.prototype['_degrees'] = function()
{
    var self = this;
    var __context = {};
    console.log('_degrees');
    var tan = null
    var theta = null
    send(send(self.x, '=', [0]), '_ifTrue_ifFalse_', [function() {
        send(send(self.y, '>=', [0]), '_ifTrue_ifFalse_', [function() {
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
        tan = send(send(self.y, '_asFloat'), '/', [send(self.x, '_asFloat')]);
        theta = send(tan, '_arcTan');
        send(send(self.x, '>=', [0]), '_ifTrue_ifFalse_', [function() {
            send(send(self.y, '>=', [0]), '_ifTrue_ifFalse_', [function() {
                __context.value = send(theta, '_radiansToDegrees');
                __context.return = true;
                return __context.value;
            }
            , function() {
                __context.value = send(360, '+', [send(theta, '_radiansToDegrees')]);
                __context.return = true;
                return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            __context.value = send(180, '+', [send(theta, '_radiansToDegrees')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['_r'] = function()
{
    var self = this;
    console.log('_r');
    return send(send(self, '_dotProduct_', [self]), '_sqrt');
};
Point.prototype['_theta'] = function()
{
    var self = this;
    var __context = {};
    console.log('_theta');
    var tan = null
    var theta = null
    send(send(self.x, '=', [0]), '_ifTrue_ifFalse_', [function() {
        send(send(self.y, '>=', [0]), '_ifTrue_ifFalse_', [function() {
            __context.value = 1,5707963267949;
            __context.return = true;
            return __context.value;
        }
        , function() {
            __context.value = 4,71238898038469;
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        tan = send(send(self.y, '_asFloat'), '/', [send(self.x, '_asFloat')]);
        theta = send(tan, '_arcTan');
        send(send(self.x, '>=', [0]), '_ifTrue_ifFalse_', [function() {
            send(send(self.y, '>=', [0]), '_ifTrue_ifFalse_', [function() {
                __context.value = theta;
                __context.return = true;
                return __context.value;
            }
            , function() {
                __context.value = send(6,28318530717959, '+', [theta]);
                __context.return = true;
                return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        , function() {
            __context.value = send(3,14159265358979, '+', [theta]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Point.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    var __context = {};
    console.log('_printOn_');
    send(self.x, '_printOn_', [aStream]);
    if (__context.return) return __context.value;
    send(aStream, '_nextPut_', ['@']);
    if (__context.return) return __context.value;
    send(send(send(self.y, '_notNil'), '_and_', [function() {
        send(self.y, '_negative');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        send(aStream, '_space');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(self.y, '_printOn_', [aStream]);
    if (__context.return) return __context.value;
};
Point.prototype['_storeOn_'] = function(aStream)
{
    var self = this;
    console.log('_storeOn_');
    send(aStream, '_nextPut_', ['(']);
    send(self, '_printOn_', [aStream]);
    send(aStream, '_nextPut_', [')']);
};
Point.prototype['_isSelfEvaluating'] = function()
{
    var self = this;
    console.log('_isSelfEvaluating');
    return send(send(self, '_class'), '==', [Point]);
};
Point.prototype['_isZero'] = function()
{
    var self = this;
    console.log('_isZero');
    return send(send(self.x, '_isZero'), '_and_', [function() {
        send(self.y, '_isZero');
    }
    ]);
};
Point.prototype['_adhereTo_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_adhereTo_');
    send(send(aRectangle, '_containsPoint_', [self]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(send(self.x, '_max_', [send(aRectangle, '_left')]), '_min_', [send(aRectangle, '_right')]), '@', [send(send(self.y, '_max_', [send(aRectangle, '_top')]), '_min_', [send(aRectangle, '_bottom')])]);
};
Point.prototype['_negated'] = function()
{
    var self = this;
    console.log('_negated');
    return send(send(0, '-', [self.x]), '@', [send(0, '-', [self.y])]);
};
Point.prototype['_rotateBy_about_'] = function(angle, center)
{
    var self = this;
    console.log('_rotateBy_about_');
    var p = null
    var r = null
    var theta = null
    p = send(self, '-', [center]);
    r = send(p, '_r');
    theta = send(send(angle, '_asFloat'), '-', [send(p, '_theta')]);
    return send(send(send(send(center, '_x'), '_asFloat'), '+', [send(r, '*', [send(theta, '_cos')])]), '@', [send(send(send(center, '_y'), '_asFloat'), '-', [send(r, '*', [send(theta, '_sin')])])]);
};
Point.prototype['_scaleBy_'] = function(factor)
{
    var self = this;
    console.log('_scaleBy_');
    return send(send(send(factor, '_x'), '*', [self.x]), '@', [send(send(factor, '_y'), '*', [self.y])]);
};
Point.prototype['_scaleFrom_to_'] = function(rect1, rect2)
{
    var self = this;
    console.log('_scaleFrom_to_');
    return send(send(rect2, '_topLeft'), '+', [send(send(send(send(self.x, '-', [send(rect1, '_left')]), '*', [send(rect2, '_width')]), '//', [send(rect1, '_width')]), '@', [send(send(send(self.y, '-', [send(rect1, '_top')]), '*', [send(rect2, '_height')]), '//', [send(rect1, '_height')])])]);
};
Point.prototype['_translateBy_'] = function(delta)
{
    var self = this;
    console.log('_translateBy_');
    return send(send(send(delta, '_x'), '+', [self.x]), '@', [send(send(delta, '_y'), '+', [self.y])]);
};
Point.prototype['_rounded'] = function()
{
    var self = this;
    var __context = {};
    console.log('_rounded');
    send(send(send(self.x, '_isInteger'), '_and_', [function() {
        send(self.y, '_isInteger');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.x, '_rounded'), '@', [send(self.y, '_rounded')]);
};
Point.prototype['_roundTo_'] = function(grid)
{
    var self = this;
    console.log('_roundTo_');
    var gridPoint = null
    gridPoint = send(grid, '_asPoint');
    return send(send(self.x, '_roundTo_', [send(gridPoint, '_x')]), '@', [send(self.y, '_roundTo_', [send(gridPoint, '_y')])]);
};
Point.prototype['_truncateTo_'] = function(grid)
{
    var self = this;
    console.log('_truncateTo_');
    var gridPoint = null
    gridPoint = send(grid, '_asPoint');
    return send(send(self.x, '_truncateTo_', [send(gridPoint, '_x')]), '@', [send(self.y, '_truncateTo_', [send(gridPoint, '_y')])]);
};
Point.prototype['_truncated'] = function()
{
    var self = this;
    var __context = {};
    console.log('_truncated');
    send(send(send(self.x, '_isInteger'), '_and_', [function() {
        send(self.y, '_isInteger');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.x, '_truncated'), '@', [send(self.y, '_truncated')]);
};
Point.prototype['_ceiling'] = function()
{
    var self = this;
    var __context = {};
    console.log('_ceiling');
    send(send(send(self.x, '_isInteger'), '_and_', [function() {
        send(self.y, '_isInteger');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.x, '_ceiling'), '@', [send(self.y, '_ceiling')]);
};
Point.prototype['_floor'] = function()
{
    var self = this;
    var __context = {};
    console.log('_floor');
    send(send(send(self.x, '_isInteger'), '_and_', [function() {
        send(self.y, '_isInteger');
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.x, '_floor'), '@', [send(self.y, '_floor')]);
};
Point.prototype['_isIntegerPoint'] = function()
{
    var self = this;
    console.log('_isIntegerPoint');
    return send(send(self.x, '_isInteger'), '_and_', [function() {
        send(self.y, '_isInteger');
    }
    ]);
};
Point.prototype['_roundDownTo_'] = function(grid)
{
    var self = this;
    console.log('_roundDownTo_');
    var gridPoint = null
    gridPoint = send(grid, '_asPoint');
    return send(send(self.x, '_roundDownTo_', [send(gridPoint, '_x')]), '@', [send(self.y, '_roundDownTo_', [send(gridPoint, '_y')])]);
};
Point.prototype['_roundUpTo_'] = function(grid)
{
    var self = this;
    console.log('_roundUpTo_');
    var gridPoint = null
    gridPoint = send(grid, '_asPoint');
    return send(send(self.x, '_roundUpTo_', [send(gridPoint, '_x')]), '@', [send(self.y, '_roundUpTo_', [send(gridPoint, '_y')])]);
};
Point.prototype['_bitShiftPoint_'] = function(bits)
{
    var self = this;
    console.log('_bitShiftPoint_');
    self.x = send(self.x, '_bitShift_', [bits]);
    self.y = send(self.y, '_bitShift_', [bits]);
};
Point.prototype['_setR_degrees_'] = function(rho, degrees)
{
    var self = this;
    console.log('_setR_degrees_');
    var radians = null
    radians = send(send(degrees, '_asFloat'), '_degreesToRadians');
    self.x = send(send(rho, '_asFloat'), '*', [send(radians, '_cos')]);
    self.y = send(send(rho, '_asFloat'), '*', [send(radians, '_sin')]);
};
Point.prototype['_setX_setY_'] = function(xValue, yValue)
{
    var self = this;
    console.log('_setX_setY_');
    self.x = xValue;
    self.y = yValue;
};
PointClass.prototype['_settingInputWidgetForNode_'] = function(aSettingNode)
{
    var self = this;
    console.log('_settingInputWidgetForNode_');
    return send(aSettingNode, '_inputWidgetForPoint');
};
PointClass.prototype['_fromUser'] = function()
{
    var self = this;
    console.log('_fromUser');
    send(Sensor.classPrototype, '_waitNoButton');
    send(send(Cursor.classPrototype, '_crossHair'), '_show');
    send(Sensor.classPrototype, '_waitButton');
    send(send(Cursor.classPrototype, '_normal'), '_show');
    return send(Sensor.classPrototype, '_cursorPoint');
};
PointClass.prototype['_fromUserWithCursor_'] = function(aCursor)
{
    var self = this;
    var __context = {};
    console.log('_fromUserWithCursor_');
    send(Sensor.classPrototype, '_waitNoButton');
    if (__context.return) return __context.value;
    send(aCursor, '_showWhile_', [function() {
        send(Sensor.classPrototype, '_waitButton');
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Sensor.classPrototype, '_cursorPoint');
};
PointClass.prototype['_r_degrees_'] = function(rho, degrees)
{
    var self = this;
    console.log('_r_degrees_');
    return send(send(self, '_basicNew'), '_setR_degrees_', [rho, degrees]);
};
PointClass.prototype['_x_y_'] = function(xInteger, yInteger)
{
    var self = this;
    console.log('_x_y_');
    return send(send(self, '_basicNew'), '_setX_setY_', [xInteger, yInteger]);
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
Rectangle.prototype.origin = null;
Rectangle.prototype.corner = null;
RectangleClass.__super = ObjectClass;
Rectangle.__super = Object;
Rectangle.prototype['_aboveCenter'] = function()
{
    var self = this;
    console.log('_aboveCenter');
    return send(send(send(self, '_topLeft'), '+', [send(self, '_bottomRight')]), '//', [send(2, '@', [3])]);
};
Rectangle.prototype['_area'] = function()
{
    var self = this;
    var __context = {};
    console.log('_area');
    var w = null
    send(send(w = send(self, '_width'), '<=', [0]), '_ifTrue_', [function() {
        __context.value = 0;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(w, '*', [send(self, '_height')]), '_max_', [0]);
};
Rectangle.prototype['_bottom'] = function()
{
    var self = this;
    console.log('_bottom');
    return send(self.corner, '_y');
};
Rectangle.prototype['_bottom_'] = function(aNumber)
{
    var self = this;
    console.log('_bottom_');
    return send(self.origin, '_corner_', [send(send(self.corner, '_x'), '@', [aNumber])]);
};
Rectangle.prototype['_bottomCenter'] = function()
{
    var self = this;
    console.log('_bottomCenter');
    return send(send(send(self, '_center'), '_x'), '@', [send(self, '_bottom')]);
};
Rectangle.prototype['_bottomLeft'] = function()
{
    var self = this;
    console.log('_bottomLeft');
    return send(send(self.origin, '_x'), '@', [send(self.corner, '_y')]);
};
Rectangle.prototype['_bottomRight'] = function()
{
    var self = this;
    console.log('_bottomRight');
    return self.corner;
};
Rectangle.prototype['_boundingBox'] = function()
{
    var self = this;
    console.log('_boundingBox');
    return self;
};
Rectangle.prototype['_center'] = function()
{
    var self = this;
    console.log('_center');
    return send(send(send(self, '_topLeft'), '+', [send(self, '_bottomRight')]), '//', [2]);
};
Rectangle.prototype['_corner'] = function()
{
    var self = this;
    console.log('_corner');
    return self.corner;
};
Rectangle.prototype['_corners'] = function()
{
    var self = this;
    console.log('_corners');
    return send(Array.classPrototype, '_with_with_with_with_', [send(self, '_topLeft'), send(self, '_bottomLeft'), send(self, '_bottomRight'), send(self, '_topRight')]);
};
Rectangle.prototype['_extent'] = function()
{
    var self = this;
    console.log('_extent');
    return send(self.corner, '-', [self.origin]);
};
Rectangle.prototype['_height'] = function()
{
    var self = this;
    console.log('_height');
    return send(send(self.corner, '_y'), '-', [send(self.origin, '_y')]);
};
Rectangle.prototype['_innerCorners'] = function()
{
    var self = this;
    console.log('_innerCorners');
    var r1 = null
    r1 = send(send(self, '_topLeft'), '_corner_', [send(send(self, '_bottomRight'), '-', [send(1, '@', [1])])]);
    return send(Array.classPrototype, '_with_with_with_with_', [send(r1, '_topLeft'), send(r1, '_bottomLeft'), send(r1, '_bottomRight'), send(r1, '_topRight')]);
};
Rectangle.prototype['_left'] = function()
{
    var self = this;
    console.log('_left');
    return send(self.origin, '_x');
};
Rectangle.prototype['_left_'] = function(aNumber)
{
    var self = this;
    console.log('_left_');
    return send(send(aNumber, '@', [send(self.origin, '_y')]), '_corner_', [self.corner]);
};
Rectangle.prototype['_leftCenter'] = function()
{
    var self = this;
    console.log('_leftCenter');
    return send(send(self, '_left'), '@', [send(send(self, '_center'), '_y')]);
};
Rectangle.prototype['_origin'] = function()
{
    var self = this;
    console.log('_origin');
    return self.origin;
};
Rectangle.prototype['_pointAtSideOrCorner_'] = function(loc)
{
    var self = this;
    console.log('_pointAtSideOrCorner_');
    return send(self, '_perform_', [send(['topLeft', 'topCenter', 'topRight', 'rightCenter', 'bottomRight', 'bottomCenter', 'bottomLeft', 'leftCenter'], '_at_', [send(['topLeft', 'top', 'topRight', 'right', 'bottomRight', 'bottom', 'bottomLeft', 'left'], '_indexOf_', [loc])])]);
};
Rectangle.prototype['_right'] = function()
{
    var self = this;
    console.log('_right');
    return send(self.corner, '_x');
};
Rectangle.prototype['_right_'] = function(aNumber)
{
    var self = this;
    console.log('_right_');
    return send(self.origin, '_corner_', [send(aNumber, '@', [send(self.corner, '_y')])]);
};
Rectangle.prototype['_rightCenter'] = function()
{
    var self = this;
    console.log('_rightCenter');
    return send(send(self, '_right'), '@', [send(send(self, '_center'), '_y')]);
};
Rectangle.prototype['_top'] = function()
{
    var self = this;
    console.log('_top');
    return send(self.origin, '_y');
};
Rectangle.prototype['_top_'] = function(aNumber)
{
    var self = this;
    console.log('_top_');
    return send(send(send(self.origin, '_x'), '@', [aNumber]), '_corner_', [self.corner]);
};
Rectangle.prototype['_topCenter'] = function()
{
    var self = this;
    console.log('_topCenter');
    return send(send(send(self, '_center'), '_x'), '@', [send(self, '_top')]);
};
Rectangle.prototype['_topLeft'] = function()
{
    var self = this;
    console.log('_topLeft');
    return self.origin;
};
Rectangle.prototype['_topRight'] = function()
{
    var self = this;
    console.log('_topRight');
    return send(send(self.corner, '_x'), '@', [send(self.origin, '_y')]);
};
Rectangle.prototype['_width'] = function()
{
    var self = this;
    console.log('_width');
    return send(send(self.corner, '_x'), '-', [send(self.origin, '_x')]);
};
Rectangle.prototype['='] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('=');
    send(send(send(self, '_species'), '=', [send(aRectangle, '_species')]), '_ifTrue_ifFalse_', [function() {
        __context.value = send(send(self.origin, '=', [send(aRectangle, '_origin')]), '_and_', [function() {
            send(self.corner, '=', [send(aRectangle, '_corner')]);
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
Rectangle.prototype['_hash'] = function()
{
    var self = this;
    console.log('_hash');
    return send(send(self.origin, '_hash'), '_bitXor_', [send(self.corner, '_hash')]);
};
Rectangle.prototype['_deltaToEnsureInOrCentered_extra_'] = function(r, aNumber)
{
    var self = this;
    var __context = {};
    console.log('_deltaToEnsureInOrCentered_extra_');
    var dX = null
    var dY = null
    var halfXDiff = null
    var halfYDiff = null
    dX = dY = 0;
    halfXDiff = send(send(send(send(r, '_width'), '-', [send(self, '_width')]), '*', [aNumber]), '_truncated');
    halfYDiff = send(send(send(send(r, '_height'), '-', [send(self, '_height')]), '*', [aNumber]), '_truncated');
    send(send(send(self, '_left'), '<', [send(r, '_left')]), '_ifTrue_ifFalse_', [function() {
        dX = send(send(send(self, '_left'), '-', [send(r, '_left')]), '-', [halfXDiff]);
    }
    , function() {
        send(send(send(self, '_right'), '>', [send(r, '_right')]), '_ifTrue_', [function() {
            dX = send(send(send(self, '_right'), '-', [send(r, '_right')]), '+', [halfXDiff]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self, '_top'), '<', [send(r, '_top')]), '_ifTrue_ifFalse_', [function() {
        dY = send(send(send(self, '_top'), '-', [send(r, '_top')]), '-', [halfYDiff]);
    }
    , function() {
        send(send(send(self, '_bottom'), '>', [send(r, '_bottom')]), '_ifTrue_', [function() {
            dY = send(send(send(self, '_bottom'), '-', [send(r, '_bottom')]), '+', [halfYDiff]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(dX, '@', [dY]);
};
Rectangle.prototype['_printOn_'] = function(aStream)
{
    var self = this;
    console.log('_printOn_');
    send(self.origin, '_printOn_', [aStream]);
    send(aStream, '_nextPutAll_', [' corner: ']);
    send(self.corner, '_printOn_', [aStream]);
};
Rectangle.prototype['_storeOn_'] = function(aStream)
{
    var self = this;
    console.log('_storeOn_');
    send(aStream, '_nextPut_', ['(']);
    send(self, '_printOn_', [aStream]);
    send(aStream, '_nextPut_', [')']);
};
Rectangle.prototype['_adjustTo_along_'] = function(newRect, side)
{
    var self = this;
    var __context = {};
    console.log('_adjustTo_along_');
    send(send(side, '=', ['left']), '_ifTrue_', [function() {
        __context.value = send(self, '_withRight_', [send(newRect, '_left')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['right']), '_ifTrue_', [function() {
        __context.value = send(self, '_withLeft_', [send(newRect, '_right')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['top']), '_ifTrue_', [function() {
        __context.value = send(self, '_withBottom_', [send(newRect, '_top')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottom']), '_ifTrue_', [function() {
        __context.value = send(self, '_withTop_', [send(newRect, '_bottom')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_allAreasOutsideList_do_'] = function(aCollection, aBlock)
{
    var self = this;
    console.log('_allAreasOutsideList_do_');
    return send(self, '_allAreasOutsideList_startingAt_do_', [aCollection, 1, aBlock]);
};
Rectangle.prototype['_allAreasOutsideList_startingAt_do_'] = function(aCollection, startIndex, aBlock)
{
    var self = this;
    var __context = {};
    console.log('_allAreasOutsideList_startingAt_do_');
    var yOrigin = null
    var yCorner = null
    var aRectangle = null
    var index = null
    var rr = null
    index = startIndex;
    send(function() {
        send(send(index, '<=', [send(aCollection, '_size')]), '_ifFalse_', [function() {
            __context.value = send(aBlock, '_value_', [self]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        aRectangle = send(aCollection, '_at_', [index]);
        send(send(self.origin, '<=', [send(aRectangle, '_corner')]), '_and_', [function() {
            send(send(aRectangle, '_origin'), '<=', [self.corner]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , '_whileFalse_', [function() {
        index = send(index, '+', [1]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_origin'), '_y'), '>', [send(self.origin, '_y')]), '_ifTrue_ifFalse_', [function() {
        rr = send(self.origin, '_corner_', [send(send(self.corner, '_x'), '@', [yOrigin = send(send(aRectangle, '_origin'), '_y')])]);
        send(rr, '_allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    , function() {
        yOrigin = send(self.origin, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_corner'), '_y'), '<', [send(self.corner, '_y')]), '_ifTrue_ifFalse_', [function() {
        rr = send(send(send(self.origin, '_x'), '@', [yCorner = send(send(aRectangle, '_corner'), '_y')]), '_corner_', [self.corner]);
        send(rr, '_allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    , function() {
        yCorner = send(self.corner, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_origin'), '_x'), '>', [send(self.origin, '_x')]), '_ifTrue_', [function() {
        rr = send(send(send(self.origin, '_x'), '@', [yOrigin]), '_corner_', [send(send(send(aRectangle, '_origin'), '_x'), '@', [yCorner])]);
        send(rr, '_allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_corner'), '_x'), '<', [send(self.corner, '_x')]), '_ifTrue_', [function() {
        rr = send(send(send(send(aRectangle, '_corner'), '_x'), '@', [yOrigin]), '_corner_', [send(send(self.corner, '_x'), '@', [yCorner])]);
        send(rr, '_allAreasOutsideList_startingAt_do_', [aCollection, send(index, '+', [1]), aBlock]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_amountToTranslateWithin_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_amountToTranslateWithin_');
    var dx = null
    var dy = null
    dx = 0;
    dy = 0;
    send(send(send(self, '_right'), '>', [send(aRectangle, '_right')]), '_ifTrue_', [function() {
        dx = send(send(aRectangle, '_right'), '-', [send(self, '_right')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(self, '_bottom'), '>', [send(aRectangle, '_bottom')]), '_ifTrue_', [function() {
        dy = send(send(aRectangle, '_bottom'), '-', [send(self, '_bottom')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, '_left'), '+', [dx]), '<', [send(aRectangle, '_left')]), '_ifTrue_', [function() {
        dx = send(send(aRectangle, '_left'), '-', [send(self, '_left')]);
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(self, '_top'), '+', [dy]), '<', [send(aRectangle, '_top')]), '_ifTrue_', [function() {
        dy = send(send(aRectangle, '_top'), '-', [send(self, '_top')]);
    }
    ]);
    if (__context.return) return __context.value;
    return send(dx, '@', [dy]);
};
Rectangle.prototype['_areasOutside_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_areasOutside_');
    var areas = null
    var yOrigin = null
    var yCorner = null
    send(send(self, '_intersects_', [aRectangle]), '_ifFalse_', [function() {
        __context.value = send(Array.classPrototype, '_with_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    areas = send(OrderedCollection.classPrototype, '_new');
    send(send(send(send(aRectangle, '_origin'), '_y'), '>', [send(self.origin, '_y')]), '_ifTrue_ifFalse_', [function() {
        send(areas, '_addLast_', [send(self.origin, '_corner_', [send(send(self.corner, '_x'), '@', [yOrigin = send(send(aRectangle, '_origin'), '_y')])])]);
        if (__context.return) return __context.value;
    }
    , function() {
        yOrigin = send(self.origin, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_corner'), '_y'), '<', [send(self.corner, '_y')]), '_ifTrue_ifFalse_', [function() {
        send(areas, '_addLast_', [send(send(send(self.origin, '_x'), '@', [yCorner = send(send(aRectangle, '_corner'), '_y')]), '_corner_', [self.corner])]);
        if (__context.return) return __context.value;
    }
    , function() {
        yCorner = send(self.corner, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_origin'), '_x'), '>', [send(self.origin, '_x')]), '_ifTrue_', [function() {
        send(areas, '_addLast_', [send(send(send(self.origin, '_x'), '@', [yOrigin]), '_corner_', [send(send(send(aRectangle, '_origin'), '_x'), '@', [yCorner])])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(aRectangle, '_corner'), '_x'), '<', [send(self.corner, '_x')]), '_ifTrue_', [function() {
        send(areas, '_addLast_', [send(send(send(send(aRectangle, '_corner'), '_x'), '@', [yOrigin]), '_corner_', [send(send(self.corner, '_x'), '@', [yCorner])])]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return areas;
};
Rectangle.prototype['_bordersOn_along_'] = function(her, herSide)
{
    var self = this;
    var __context = {};
    console.log('_bordersOn_along_');
    send(send(send(send(herSide, '=', ['right']), '_and_', [function() {
        send(send(self, '_left'), '=', [send(her, '_right')]);
        if (__context.return) return __context.value;
    }
    ]), '|', [send(send(herSide, '=', ['left']), '_and_', [function() {
        send(send(self, '_right'), '=', [send(her, '_left')]);
        if (__context.return) return __context.value;
    }
    ])]), '_ifTrue_', [function() {
        __context.value = send(send(send(self, '_top'), '_max_', [send(her, '_top')]), '<', [send(send(self, '_bottom'), '_min_', [send(her, '_bottom')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(send(herSide, '=', ['bottom']), '_and_', [function() {
        send(send(self, '_top'), '=', [send(her, '_bottom')]);
        if (__context.return) return __context.value;
    }
    ]), '|', [send(send(herSide, '=', ['top']), '_and_', [function() {
        send(send(self, '_bottom'), '=', [send(her, '_top')]);
        if (__context.return) return __context.value;
    }
    ])]), '_ifTrue_', [function() {
        __context.value = send(send(send(self, '_left'), '_max_', [send(her, '_left')]), '<', [send(send(self, '_right'), '_min_', [send(her, '_right')])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return false;
};
Rectangle.prototype['_encompass_'] = function(aPoint)
{
    var self = this;
    console.log('_encompass_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_min_', [aPoint]), send(self.corner, '_max_', [aPoint])]);
};
Rectangle.prototype['_expandBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('_expandBy_');
    send(send(delta, '_isRectangle'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '-', [send(delta, '_origin')]), send(self.corner, '+', [send(delta, '_corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '-', [delta]), send(self.corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_extendBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('_extendBy_');
    send(send(delta, '_isRectangle'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [self.origin, send(self.corner, '+', [send(delta, '_corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [self.origin, send(self.corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_forPoint_closestSideDistLen_'] = function(aPoint, sideDistLenBlock)
{
    var self = this;
    var __context = {};
    console.log('_forPoint_closestSideDistLen_');
    var side = null
    side = send(self, '_sideNearestTo_', [aPoint]);
    send(send(side, '==', ['right']), '_ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, '_value_value_value_', [side, send(send(send(self, '_right'), '-', [send(aPoint, '_x')]), '_abs'), send(send(send(aPoint, '_y'), '_between_and_', [send(self, '_top'), send(self, '_bottom')]), '_ifTrue_ifFalse_', [function() {
            send(self, '_height');
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
    send(send(side, '==', ['left']), '_ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, '_value_value_value_', [side, send(send(send(self, '_left'), '-', [send(aPoint, '_x')]), '_abs'), send(send(send(aPoint, '_y'), '_between_and_', [send(self, '_top'), send(self, '_bottom')]), '_ifTrue_ifFalse_', [function() {
            send(self, '_height');
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
    send(send(side, '==', ['bottom']), '_ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, '_value_value_value_', [side, send(send(send(self, '_bottom'), '-', [send(aPoint, '_y')]), '_abs'), send(send(send(aPoint, '_x'), '_between_and_', [send(self, '_left'), send(self, '_right')]), '_ifTrue_ifFalse_', [function() {
            send(self, '_width');
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
    send(send(side, '==', ['top']), '_ifTrue_', [function() {
        __context.value = send(sideDistLenBlock, '_value_value_value_', [side, send(send(send(self, '_top'), '-', [send(aPoint, '_y')]), '_abs'), send(send(send(aPoint, '_x'), '_between_and_', [send(self, '_left'), send(self, '_right')]), '_ifTrue_ifFalse_', [function() {
            send(self, '_width');
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
Rectangle.prototype['_insetBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('_insetBy_');
    send(send(delta, '_isRectangle'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '+', [send(delta, '_origin')]), send(self.corner, '-', [send(delta, '_corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '+', [delta]), send(self.corner, '-', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_insetOriginBy_cornerBy_'] = function(originDeltaPoint, cornerDeltaPoint)
{
    var self = this;
    console.log('_insetOriginBy_cornerBy_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '+', [originDeltaPoint]), send(self.corner, '-', [cornerDeltaPoint])]);
};
Rectangle.prototype['_intersect_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_intersect_');
    var aPoint = null
    var left = null
    var right = null
    var top = null
    var bottom = null
    aPoint = send(aRectangle, '_origin');
    send(send(send(aPoint, '_x'), '>', [send(self.origin, '_x')]), '_ifTrue_ifFalse_', [function() {
        left = send(aPoint, '_x');
    }
    , function() {
        left = send(self.origin, '_x');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(aPoint, '_y'), '>', [send(self.origin, '_y')]), '_ifTrue_ifFalse_', [function() {
        top = send(aPoint, '_y');
    }
    , function() {
        top = send(self.origin, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    aPoint = send(aRectangle, '_corner');
    send(send(send(aPoint, '_x'), '<', [send(self.corner, '_x')]), '_ifTrue_ifFalse_', [function() {
        right = send(aPoint, '_x');
    }
    , function() {
        right = send(self.corner, '_x');
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(aPoint, '_y'), '<', [send(self.corner, '_y')]), '_ifTrue_ifFalse_', [function() {
        bottom = send(aPoint, '_y');
    }
    , function() {
        bottom = send(self.corner, '_y');
    }
    ]);
    if (__context.return) return __context.value;
    return send(Rectangle.classPrototype, '_origin_corner_', [send(left, '@', [top]), send(right, '@', [bottom])]);
};
Rectangle.prototype['_merge_'] = function(aRectangle)
{
    var self = this;
    console.log('_merge_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_min_', [send(aRectangle, '_origin')]), send(self.corner, '_max_', [send(aRectangle, '_corner')])]);
};
Rectangle.prototype['_outsetBy_'] = function(delta)
{
    var self = this;
    var __context = {};
    console.log('_outsetBy_');
    send(send(delta, '_isRectangle'), '_ifTrue_ifFalse_', [function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '-', [send(delta, '_origin')]), send(self.corner, '+', [send(delta, '_corner')])]);
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '-', [delta]), send(self.corner, '+', [delta])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_pointNearestTo_'] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('_pointNearestTo_');
    var side = null
    send(send(self, '_containsPoint_', [aPoint]), '_ifTrue_ifFalse_', [function() {
        side = send(self, '_sideNearestTo_', [aPoint]);
        send(send(side, '==', ['right']), '_ifTrue_', [function() {
            __context.value = send(send(self, '_right'), '@', [send(aPoint, '_y')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['left']), '_ifTrue_', [function() {
            __context.value = send(send(self, '_left'), '@', [send(aPoint, '_y')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['bottom']), '_ifTrue_', [function() {
            __context.value = send(send(aPoint, '_x'), '@', [send(self, '_bottom')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
        send(send(side, '==', ['top']), '_ifTrue_', [function() {
            __context.value = send(send(aPoint, '_x'), '@', [send(self, '_top')]);
            __context.return = true;
            return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    , function() {
        __context.value = send(aPoint, '_adhereTo_', [self]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_quickMerge_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_quickMerge_');
    var useRcvr = null
    var rOrigin = null
    var rCorner = null
    var minX = null
    var maxX = null
    var minY = null
    var maxY = null
    send(aRectangle, '_ifNil_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    useRcvr = true;
    rOrigin = send(aRectangle, '_topLeft');
    rCorner = send(aRectangle, '_bottomRight');
    minX = send(send(send(rOrigin, '_x'), '<', [send(self.origin, '_x')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rOrigin, '_x');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.origin, '_x');
        if (__context.return) return __context.value;
    }
    ]);
    maxX = send(send(send(rCorner, '_x'), '>', [send(self.corner, '_x')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rCorner, '_x');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.corner, '_x');
        if (__context.return) return __context.value;
    }
    ]);
    minY = send(send(send(rOrigin, '_y'), '<', [send(self.origin, '_y')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rOrigin, '_y');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.origin, '_y');
        if (__context.return) return __context.value;
    }
    ]);
    maxY = send(send(send(rCorner, '_y'), '>', [send(self.corner, '_y')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(rCorner, '_y');
        if (__context.return) return __context.value;
    }
    , function() {
        send(self.corner, '_y');
        if (__context.return) return __context.value;
    }
    ]);
    send(useRcvr, '_ifTrue_ifFalse_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    , function() {
        __context.value = send(Rectangle.classPrototype, '_origin_corner_', [send(minX, '@', [minY]), send(maxX, '@', [maxY])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_rectanglesAt_height_'] = function(y, ht)
{
    var self = this;
    var __context = {};
    console.log('_rectanglesAt_height_');
    send(send(send(y, '+', [ht]), '>', [send(self, '_bottom')]), '_ifTrue_', [function() {
        __context.value = send(Array.classPrototype, '_new');
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Array.classPrototype, '_with_', [send(send(send(self.origin, '_x'), '@', [y]), '_corner_', [send(send(self.corner, '_x'), '@', [send(y, '+', [ht])])])]);
};
Rectangle.prototype['_sideNearestTo_'] = function(aPoint)
{
    var self = this;
    var __context = {};
    console.log('_sideNearestTo_');
    var distToLeft = null
    var distToRight = null
    var distToTop = null
    var distToBottom = null
    var closest = null
    var side = null
    distToLeft = send(send(aPoint, '_x'), '-', [send(self, '_left')]);
    distToRight = send(send(self, '_right'), '-', [send(aPoint, '_x')]);
    distToTop = send(send(aPoint, '_y'), '-', [send(self, '_top')]);
    distToBottom = send(send(self, '_bottom'), '-', [send(aPoint, '_y')]);
    closest = distToLeft;
    side = 'left';
    send(send(distToRight, '<', [closest]), '_ifTrue_', [function() {
        closest = distToRight;
        side = 'right';
    }
    ]);
    if (__context.return) return __context.value;
    send(send(distToTop, '<', [closest]), '_ifTrue_', [function() {
        closest = distToTop;
        side = 'top';
    }
    ]);
    if (__context.return) return __context.value;
    send(send(distToBottom, '<', [closest]), '_ifTrue_', [function() {
        closest = distToBottom;
        side = 'bottom';
    }
    ]);
    if (__context.return) return __context.value;
    return side;
};
Rectangle.prototype['_translatedToBeWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('_translatedToBeWithin_');
    return send(self, '_translateBy_', [send(self, '_amountToTranslateWithin_', [aRectangle])]);
};
Rectangle.prototype['_withBottom_'] = function(y)
{
    var self = this;
    console.log('_withBottom_');
    return send(send(send(self.origin, '_x'), '@', [send(self.origin, '_y')]), '_corner_', [send(send(self.corner, '_x'), '@', [y])]);
};
Rectangle.prototype['_withHeight_'] = function(height)
{
    var self = this;
    console.log('_withHeight_');
    return send(self.origin, '_corner_', [send(send(self.corner, '_x'), '@', [send(send(self.origin, '_y'), '+', [height])])]);
};
Rectangle.prototype['_withLeft_'] = function(x)
{
    var self = this;
    console.log('_withLeft_');
    return send(send(x, '@', [send(self.origin, '_y')]), '_corner_', [send(send(self.corner, '_x'), '@', [send(self.corner, '_y')])]);
};
Rectangle.prototype['_withRight_'] = function(x)
{
    var self = this;
    console.log('_withRight_');
    return send(send(send(self.origin, '_x'), '@', [send(self.origin, '_y')]), '_corner_', [send(x, '@', [send(self.corner, '_y')])]);
};
Rectangle.prototype['_withSide_setTo_'] = function(side, value)
{
    var self = this;
    console.log('_withSide_setTo_');
    return send(self, '_perform_with_', [send(['withLeft:', 'withRight:', 'withTop:', 'withBottom:'], '_at_', [send(['left', 'right', 'top', 'bottom'], '_indexOf_', [side])]), value]);
};
Rectangle.prototype['_withSideOrCorner_setToPoint_'] = function(side, newPoint)
{
    var self = this;
    console.log('_withSideOrCorner_setToPoint_');
    return send(self, '_withSideOrCorner_setToPoint_minExtent_', [side, newPoint, send(0, '@', [0])]);
};
Rectangle.prototype['_withSideOrCorner_setToPoint_minExtent_'] = function(side, newPoint, minExtent)
{
    var self = this;
    console.log('_withSideOrCorner_setToPoint_minExtent_');
    return send(self, '_withSideOrCorner_setToPoint_minExtent_limit_', [side, newPoint, minExtent, send(send(['left', 'top'], '_includes_', [side]), '_ifTrue_ifFalse_', [function() {
        send(SmallInteger.classPrototype, '_minVal');
    }
    , function() {
        send(SmallInteger.classPrototype, '_maxVal');
    }
    ])]);
};
Rectangle.prototype['_withSideOrCorner_setToPoint_minExtent_limit_'] = function(side, newPoint, minExtent, limit)
{
    var self = this;
    var __context = {};
    console.log('_withSideOrCorner_setToPoint_minExtent_limit_');
    send(send(side, '=', ['top']), '_ifTrue_', [function() {
        __context.value = send(self, '_withTop_', [send(send(newPoint, '_y'), '_min_max_', [send(send(self.corner, '_y'), '-', [send(minExtent, '_y')]), send(limit, '+', [send(minExtent, '_y')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottom']), '_ifTrue_', [function() {
        __context.value = send(self, '_withBottom_', [send(send(newPoint, '_y'), '_min_max_', [send(limit, '-', [send(minExtent, '_y')]), send(send(self.origin, '_y'), '+', [send(minExtent, '_y')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['left']), '_ifTrue_', [function() {
        __context.value = send(self, '_withLeft_', [send(send(newPoint, '_x'), '_min_max_', [send(send(self.corner, '_x'), '-', [send(minExtent, '_x')]), send(limit, '+', [send(minExtent, '_x')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['right']), '_ifTrue_', [function() {
        __context.value = send(self, '_withRight_', [send(send(newPoint, '_x'), '_min_max_', [send(limit, '-', [send(minExtent, '_x')]), send(send(self.origin, '_x'), '+', [send(minExtent, '_x')])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['topLeft']), '_ifTrue_', [function() {
        __context.value = send(send(newPoint, '_min_', [send(self.corner, '-', [minExtent])]), '_corner_', [send(self, '_bottomRight')]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottomRight']), '_ifTrue_', [function() {
        __context.value = send(send(self, '_topLeft'), '_corner_', [send(newPoint, '_max_', [send(self.origin, '+', [minExtent])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['bottomLeft']), '_ifTrue_', [function() {
        __context.value = send(send(self, '_topRight'), '_rect_', [send(send(send(newPoint, '_x'), '_min_', [send(send(self.corner, '_x'), '-', [send(minExtent, '_x')])]), '@', [send(send(newPoint, '_y'), '_max_', [send(send(self.origin, '_y'), '+', [send(minExtent, '_y')])])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(side, '=', ['topRight']), '_ifTrue_', [function() {
        __context.value = send(send(self, '_bottomLeft'), '_rect_', [send(send(send(newPoint, '_x'), '_max_', [send(send(self.origin, '_x'), '+', [send(minExtent, '_x')])]), '@', [send(send(newPoint, '_y'), '_min_', [send(send(self.corner, '_y'), '-', [send(minExtent, '_y')])])])]);
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
};
Rectangle.prototype['_withTop_'] = function(y)
{
    var self = this;
    console.log('_withTop_');
    return send(send(send(self.origin, '_x'), '@', [y]), '_corner_', [send(send(self.corner, '_x'), '@', [send(self.corner, '_y')])]);
};
Rectangle.prototype['_withWidth_'] = function(width)
{
    var self = this;
    console.log('_withWidth_');
    return send(self.origin, '_corner_', [send(send(send(self.origin, '_x'), '+', [width]), '@', [send(self.corner, '_y')])]);
};
Rectangle.prototype['_isSelfEvaluating'] = function()
{
    var self = this;
    console.log('_isSelfEvaluating');
    return send(send(self, '_class'), '==', [Rectangle]);
};
Rectangle.prototype['_containsPoint_'] = function(aPoint)
{
    var self = this;
    console.log('_containsPoint_');
    return send(send(self.origin, '<=', [aPoint]), '_and_', [function() {
        send(aPoint, '<', [self.corner]);
    }
    ]);
};
Rectangle.prototype['_containsRect_'] = function(aRect)
{
    var self = this;
    console.log('_containsRect_');
    return send(send(send(aRect, '_origin'), '>=', [self.origin]), '_and_', [function() {
        send(send(aRect, '_corner'), '<=', [self.corner]);
    }
    ]);
};
Rectangle.prototype['_hasPositiveExtent'] = function()
{
    var self = this;
    console.log('_hasPositiveExtent');
    return send(send(send(self.corner, '_x'), '>', [send(self.origin, '_x')]), '_and_', [function() {
        send(send(self.corner, '_y'), '>', [send(self.origin, '_y')]);
    }
    ]);
};
Rectangle.prototype['_intersects_'] = function(aRectangle)
{
    var self = this;
    var __context = {};
    console.log('_intersects_');
    var rOrigin = null
    var rCorner = null
    rOrigin = send(aRectangle, '_origin');
    rCorner = send(aRectangle, '_corner');
    send(send(send(rCorner, '_x'), '<=', [send(self.origin, '_x')]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rCorner, '_y'), '<=', [send(self.origin, '_y')]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rOrigin, '_x'), '>=', [send(self.corner, '_x')]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(send(send(rOrigin, '_y'), '>=', [send(self.corner, '_y')]), '_ifTrue_', [function() {
        __context.value = false;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return true;
};
Rectangle.prototype['_isRectangle'] = function()
{
    var self = this;
    console.log('_isRectangle');
    return true;
};
Rectangle.prototype['_isTall'] = function()
{
    var self = this;
    console.log('_isTall');
    return send(send(self, '_height'), '>', [send(self, '_width')]);
};
Rectangle.prototype['_isWide'] = function()
{
    var self = this;
    console.log('_isWide');
    return send(send(self, '_width'), '>', [send(self, '_height')]);
};
Rectangle.prototype['_isZero'] = function()
{
    var self = this;
    console.log('_isZero');
    return send(send(self.origin, '_isZero'), '_and_', [function() {
        send(self.corner, '_isZero');
    }
    ]);
};
Rectangle.prototype['_align_with_'] = function(aPoint1, aPoint2)
{
    var self = this;
    console.log('_align_with_');
    return send(self, '_translateBy_', [send(aPoint2, '-', [aPoint1])]);
};
Rectangle.prototype['_centeredBeneath_'] = function(aRectangle)
{
    var self = this;
    console.log('_centeredBeneath_');
    return send(self, '_align_with_', [send(self, '_topCenter'), send(aRectangle, '_bottomCenter')]);
};
Rectangle.prototype['_flipBy_centerAt_'] = function(direction, aPoint)
{
    var self = this;
    console.log('_flipBy_centerAt_');
    return send(send(self.origin, '_flipBy_centerAt_', [direction, aPoint]), '_rect_', [send(self.corner, '_flipBy_centerAt_', [direction, aPoint])]);
};
Rectangle.prototype['_interpolateTo_at_'] = function(end, amountDone)
{
    var self = this;
    console.log('_interpolateTo_at_');
    return send(send(send(self, '_origin'), '_interpolateTo_at_', [send(end, '_origin'), amountDone]), '_corner_', [send(send(self, '_corner'), '_interpolateTo_at_', [send(end, '_corner'), amountDone])]);
};
Rectangle.prototype['_newRectButtonPressedDo_'] = function(newRectBlock)
{
    var self = this;
    var __context = {};
    console.log('_newRectButtonPressedDo_');
    var rect = null
    var newRect = null
    var buttonNow = null
    var delay = null
    delay = send(Delay.classPrototype, '_forMilliseconds_', [10]);
    buttonNow = send(Sensor.classPrototype, '_anyButtonPressed');
    rect = self;
    send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
    if (__context.return) return __context.value;
    send(function() {
        buttonNow;
    }
    , '_whileTrue_', [function() {
        send(delay, '_wait');
        if (__context.return) return __context.value;
        send(function() {
            send(send(Sensor.classPrototype, '_nextEvent'), '_isNil');
            if (__context.return) return __context.value;
        }
        , '_whileFalse');
        if (__context.return) return __context.value;
        buttonNow = send(Sensor.classPrototype, '_anyButtonPressed');
        newRect = send(newRectBlock, '_value_', [rect]);
        send(send(newRect, '=', [rect]), '_ifFalse_', [function() {
            send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
            if (__context.return) return __context.value;
            send(Display.classPrototype, '_border_width_rule_fillColor_', [newRect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
            if (__context.return) return __context.value;
            rect = newRect;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
    if (__context.return) return __context.value;
    send((function () {var _aux = send(send(World.classPrototype, '_activeHand'), '_newMouseFocus_', [nil]);return _aux;})(), '_showTemporaryCursor_', [nil]);
    if (__context.return) return __context.value;
    return rect;
};
Rectangle.prototype['_newRectFrom_'] = function(newRectBlock)
{
    var self = this;
    var __context = {};
    console.log('_newRectFrom_');
    var rect = null
    var newRect = null
    var buttonStart = null
    var buttonNow = null
    var delay = null
    delay = send(Delay.classPrototype, '_forMilliseconds_', [10]);
    buttonStart = buttonNow = send(Sensor.classPrototype, '_anyButtonPressed');
    rect = self;
    send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
    if (__context.return) return __context.value;
    send(function() {
        send(buttonNow, '==', [buttonStart]);
        if (__context.return) return __context.value;
    }
    , '_whileTrue_', [function() {
        send(delay, '_wait');
        if (__context.return) return __context.value;
        send(function() {
            send(send(Sensor.classPrototype, '_nextEvent'), '_isNil');
            if (__context.return) return __context.value;
        }
        , '_whileFalse');
        if (__context.return) return __context.value;
        buttonNow = send(Sensor.classPrototype, '_anyButtonPressed');
        newRect = send(newRectBlock, '_value_', [rect]);
        send(send(newRect, '=', [rect]), '_ifFalse_', [function() {
            send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
            if (__context.return) return __context.value;
            send(Display.classPrototype, '_border_width_rule_fillColor_', [newRect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
            if (__context.return) return __context.value;
            rect = newRect;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    send(Display.classPrototype, '_border_width_rule_fillColor_', [rect, 2, send(Form.classPrototype, '_reverse'), send(Color.classPrototype, '_gray')]);
    if (__context.return) return __context.value;
    send((function () {var _aux = send(send(World.classPrototype, '_activeHand'), '_newMouseFocus_', [nil]);return _aux;})(), '_showTemporaryCursor_', [nil]);
    if (__context.return) return __context.value;
    return rect;
};
Rectangle.prototype['_quickMergePoint_'] = function(aPoint)
{
    var self = this;
    console.log('_quickMergePoint_');
    var useRcvr = null
    var minX = null
    var maxX = null
    var minY = null
    var maxY = null
    useRcvr = true;
    minX = send(send(send(aPoint, '_x'), '<', [send(self.origin, '_x')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(aPoint, '_x');
    }
    , function() {
        send(self.origin, '_x');
    }
    ]);
    maxX = send(send(send(aPoint, '_x'), '>=', [send(self.corner, '_x')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(send(aPoint, '_x'), '+', [1]);
    }
    , function() {
        send(self.corner, '_x');
    }
    ]);
    minY = send(send(send(aPoint, '_y'), '<', [send(self.origin, '_y')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(aPoint, '_y');
    }
    , function() {
        send(self.origin, '_y');
    }
    ]);
    maxY = send(send(send(aPoint, '_y'), '>=', [send(self.corner, '_y')]), '_ifTrue_ifFalse_', [function() {
        useRcvr = false;
        send(send(aPoint, '_y'), '+', [1]);
    }
    , function() {
        send(self.corner, '_y');
    }
    ]);
    return send(useRcvr, '_ifTrue_ifFalse_', [function() {
        self;
    }
    , function() {
        send(send(minX, '@', [minY]), '_corner_', [send(maxX, '@', [maxY])]);
    }
    ]);
};
Rectangle.prototype['_rotateBy_centerAt_'] = function(direction, aPoint)
{
    var self = this;
    console.log('_rotateBy_centerAt_');
    return send(send(self.origin, '_rotateBy_centerAt_', [direction, aPoint]), '_rect_', [send(self.corner, '_rotateBy_centerAt_', [direction, aPoint])]);
};
Rectangle.prototype['_scaleBy_'] = function(scale)
{
    var self = this;
    console.log('_scaleBy_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '*', [scale]), send(self.corner, '*', [scale])]);
};
Rectangle.prototype['_scaleFrom_to_'] = function(rect1, rect2)
{
    var self = this;
    console.log('_scaleFrom_to_');
    return send(send(self.origin, '_scaleFrom_to_', [rect1, rect2]), '_corner_', [send(self.corner, '_scaleFrom_to_', [rect1, rect2])]);
};
Rectangle.prototype['_scaledAndCenteredIn_'] = function(aRect)
{
    var self = this;
    console.log('_scaledAndCenteredIn_');
    return send(send(send(send(self, '_width'), '/', [send(aRect, '_width')]), '>', [send(send(self, '_height'), '/', [send(aRect, '_height')])]), '_ifTrue_ifFalse_', [function() {
        send(send(send(aRect, '_left'), '@', [send(send(send(aRect, '_leftCenter'), '_y'), '-', [send(send(send(self, '_height'), '*', [send(send(aRect, '_width'), '/', [send(self, '_width')])]), '/', [2])])]), '_corner_', [send(send(aRect, '_right'), '@', [send(send(send(aRect, '_rightCenter'), '_y'), '+', [send(send(send(self, '_height'), '*', [send(send(aRect, '_width'), '/', [send(self, '_width')])]), '/', [2])])])]);
    }
    , function() {
        send(send(send(send(send(aRect, '_topCenter'), '_x'), '-', [send(send(send(self, '_width'), '*', [send(send(aRect, '_height'), '/', [send(self, '_height')])]), '/', [2])]), '@', [send(aRect, '_top')]), '_corner_', [send(send(send(send(aRect, '_topCenter'), '_x'), '+', [send(send(send(self, '_width'), '*', [send(send(aRect, '_height'), '/', [send(self, '_height')])]), '/', [2])]), '@', [send(aRect, '_bottom')])]);
    }
    ]);
};
Rectangle.prototype['_squishedWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('_squishedWithin_');
    return send(self.origin, '_corner_', [send(self.corner, '_min_', [send(aRectangle, '_bottomRight')])]);
};
Rectangle.prototype['_translateBy_'] = function(factor)
{
    var self = this;
    console.log('_translateBy_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '+', [factor]), send(self.corner, '+', [factor])]);
};
Rectangle.prototype['_translatedAndSquishedToBeWithin_'] = function(aRectangle)
{
    var self = this;
    console.log('_translatedAndSquishedToBeWithin_');
    return send(send(self, '_translatedToBeWithin_', [aRectangle]), '_squishedWithin_', [aRectangle]);
};
Rectangle.prototype['_rounded'] = function()
{
    var self = this;
    console.log('_rounded');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_rounded'), send(self.corner, '_rounded')]);
};
Rectangle.prototype['_truncateTo_'] = function(grid)
{
    var self = this;
    console.log('_truncateTo_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_truncateTo_', [grid]), send(self.corner, '_truncateTo_', [grid])]);
};
Rectangle.prototype['_truncated'] = function()
{
    var self = this;
    var __context = {};
    console.log('_truncated');
    send(send(send(send(self.origin, '_x'), '_isInteger'), '_and_', [function() {
        send(send(send(self.origin, '_y'), '_isInteger'), '_and_', [function() {
            send(send(send(self.corner, '_x'), '_isInteger'), '_and_', [function() {
                send(send(self.corner, '_y'), '_isInteger');
                if (__context.return) return __context.value;
            }
            ]);
            if (__context.return) return __context.value;
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_truncated'), send(self.corner, '_truncated')]);
};
Rectangle.prototype['_ceiling'] = function()
{
    var self = this;
    var __context = {};
    console.log('_ceiling');
    send(send(self, '_isIntegerRectangle'), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.origin, '_ceiling'), '_corner_', [send(self.corner, '_ceiling')]);
};
Rectangle.prototype['_compressTo_'] = function(grid)
{
    var self = this;
    console.log('_compressTo_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_roundUpTo_', [grid]), send(self.corner, '_roundDownTo_', [grid])]);
};
Rectangle.prototype['_compressed'] = function()
{
    var self = this;
    console.log('_compressed');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_ceiling'), send(self.corner, '_floor')]);
};
Rectangle.prototype['_expandTo_'] = function(grid)
{
    var self = this;
    console.log('_expandTo_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_roundDownTo_', [grid]), send(self.corner, '_roundUpTo_', [grid])]);
};
Rectangle.prototype['_expanded'] = function()
{
    var self = this;
    console.log('_expanded');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_floor'), send(self.corner, '_ceiling')]);
};
Rectangle.prototype['_floor'] = function()
{
    var self = this;
    var __context = {};
    console.log('_floor');
    send(send(self, '_isIntegerRectangle'), '_ifTrue_', [function() {
        __context.value = self;
        __context.return = true;
        return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(self.origin, '_floor'), '_corner_', [send(self.corner, '_floor')]);
};
Rectangle.prototype['_isIntegerRectangle'] = function()
{
    var self = this;
    console.log('_isIntegerRectangle');
    return send(send(self.origin, '_isIntegerPoint'), '_and_', [function() {
        send(self.corner, '_isIntegerPoint');
    }
    ]);
};
Rectangle.prototype['_roundTo_'] = function(grid)
{
    var self = this;
    console.log('_roundTo_');
    return send(Rectangle.classPrototype, '_origin_corner_', [send(self.origin, '_roundTo_', [grid]), send(self.corner, '_roundTo_', [grid])]);
};
Rectangle.prototype['_setOrigin_corner_'] = function(topLeft, bottomRight)
{
    var self = this;
    console.log('_setOrigin_corner_');
    self.origin = topLeft;
    self.corner = bottomRight;
};
RectangleClass.prototype['_fromUser'] = function()
{
    var self = this;
    console.log('_fromUser');
    return send(self, '_fromUser_', [send(1, '@', [1])]);
};
RectangleClass.prototype['_fromUser_'] = function(gridPoint)
{
    var self = this;
    console.log('_fromUser_');
    var originRect = null
    originRect = send(send(Cursor.classPrototype, '_origin'), '_showWhile_', [function() {
        send(send(send(send(Sensor.classPrototype, '_cursorPoint'), '_grid_', [gridPoint]), '_extent_', [send(0, '@', [0])]), '_newRectFrom_', [function(f) {
            send(send(send(Sensor.classPrototype, '_cursorPoint'), '_grid_', [gridPoint]), '_extent_', [send(0, '@', [0])]);
        }
        ]);
    }
    ]);
    return send(send(Cursor.classPrototype, '_corner'), '_showWhile_', [function() {
        send(originRect, '_newRectFrom_', [function(f) {
            send(send(f, '_origin'), '_corner_', [send(send(Sensor.classPrototype, '_cursorPoint'), '_grid_', [gridPoint])]);
        }
        ]);
    }
    ]);
};
RectangleClass.prototype['_originFromUser_'] = function(extentPoint)
{
    var self = this;
    console.log('_originFromUser_');
    return send(self, '_originFromUser_grid_', [extentPoint, send(1, '@', [1])]);
};
RectangleClass.prototype['_originFromUser_grid_'] = function(extentPoint, gridPoint)
{
    var self = this;
    console.log('_originFromUser_grid_');
    return send(send(Cursor.classPrototype, '_origin'), '_showWhile_', [function() {
        send(send(send(send(Sensor.classPrototype, '_cursorPoint'), '_grid_', [gridPoint]), '_extent_', [extentPoint]), '_newRectFrom_', [function(f) {
            send(send(send(Sensor.classPrototype, '_cursorPoint'), '_grid_', [gridPoint]), '_extent_', [extentPoint]);
        }
        ]);
    }
    ]);
};
RectangleClass.prototype['_center_extent_'] = function(centerPoint, extentPoint)
{
    var self = this;
    console.log('_center_extent_');
    return send(self, '_origin_extent_', [send(centerPoint, '-', [send(extentPoint, '//', [2])]), extentPoint]);
};
RectangleClass.prototype['_encompassing_'] = function(listOfPoints)
{
    var self = this;
    var __context = {};
    console.log('_encompassing_');
    var topLeft = null
    var bottomRight = null
    topLeft = bottomRight = nil;
    send(listOfPoints, '_do_', [function(p) {
        send(send(topLeft, '==', [nil]), '_ifTrue_ifFalse_', [function() {
            topLeft = bottomRight = p;
        }
        , function() {
            topLeft = send(topLeft, '_min_', [p]);
            bottomRight = send(bottomRight, '_max_', [p]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(topLeft, '_corner_', [bottomRight]);
};
RectangleClass.prototype['_left_right_top_bottom_'] = function(leftNumber, rightNumber, topNumber, bottomNumber)
{
    var self = this;
    console.log('_left_right_top_bottom_');
    return send(send(self, '_basicNew'), '_setOrigin_corner_', [send(leftNumber, '@', [topNumber]), send(rightNumber, '@', [bottomNumber])]);
};
RectangleClass.prototype['_merging_'] = function(listOfRects)
{
    var self = this;
    var __context = {};
    console.log('_merging_');
    var minX = null
    var minY = null
    var maxX = null
    var maxY = null
    send(listOfRects, '_do_', [function(r) {
        send(minX, '_ifNil_ifNotNil_', [function() {
            minX = send(send(r, '_topLeft'), '_x');
            minY = send(send(r, '_topLeft'), '_y');
            maxX = send(send(r, '_bottomRight'), '_x');
            maxY = send(send(r, '_bottomRight'), '_y');
        }
        , function() {
            minX = send(minX, '_min_', [send(send(r, '_topLeft'), '_x')]);
            minY = send(minY, '_min_', [send(send(r, '_topLeft'), '_y')]);
            maxX = send(maxX, '_max_', [send(send(r, '_bottomRight'), '_x')]);
            maxY = send(maxY, '_max_', [send(send(r, '_bottomRight'), '_y')]);
        }
        ]);
        if (__context.return) return __context.value;
    }
    ]);
    if (__context.return) return __context.value;
    return send(send(minX, '@', [minY]), '_corner_', [send(maxX, '@', [maxY])]);
};
RectangleClass.prototype['_origin_corner_'] = function(originPoint, cornerPoint)
{
    var self = this;
    console.log('_origin_corner_');
    return send(send(self, '_basicNew'), '_setOrigin_corner_', [originPoint, cornerPoint]);
};
RectangleClass.prototype['_origin_extent_'] = function(originPoint, extentPoint)
{
    var self = this;
    console.log('_origin_extent_');
    return send(send(self, '_basicNew'), '_setOrigin_corner_', [originPoint, send(originPoint, '+', [extentPoint])]);
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
HtmlCanvas.prototype.response = null;
HtmlCanvasClass.__super = ObjectClass;
HtmlCanvas.__super = Object;
HtmlCanvas.prototype['_write_'] = function(text)
{
    var self = this;
    console.log('_write_');
    send(self.response, '_write_', [text]);
};
HtmlCanvas.prototype['_h1_'] = function(content)
{
    var self = this;
    console.log('_h1_');
    send(self, '_write_', ['<h1>']);
    send(self, '_write_', [content]);
    send(self, '_write_', ['</h1>']);
};
HtmlCanvas.prototype['_image_'] = function(url)
{
    var self = this;
    console.log('_image_');
    send(self.response, '_write_', ['<img src="']);
    send(self.response, '_write_', [url]);
    send(self.response, '_write_', ['">']);
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
HtmlPage.prototype['_render_'] = function(html)
{
    var self = this;
    console.log('_render_');
    send(html, '_h1_', ['Hello, world']);
    send(html, '_image_', ['http://www.ajlopez.com/images/imagen.jpg']);
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
