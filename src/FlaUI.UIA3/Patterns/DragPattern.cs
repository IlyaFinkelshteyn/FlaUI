﻿using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Converters;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class DragPattern : PatternBaseWithInformation<UIA.IUIAutomationDragPattern, DragPatternInformation>, IDragPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_DragPatternId, "Drag");
        public static readonly PropertyId DropEffectProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragDropEffectPropertyId, "DropEffect");
        public static readonly PropertyId DropEffectsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragDropEffectsPropertyId, "DropEffects");
        public static readonly PropertyId IsGrabbedProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragIsGrabbedPropertyId, "IsGrabbed");
        public static readonly PropertyId GrabbedItemsProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_DragGrabbedItemsPropertyId, " GrabbedItems");
        public static readonly EventId DragCancelEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCancelEventId, "DragCancel");
        public static readonly EventId DragCompleteEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragCompleteEventId, "DragComplete");
        public static readonly EventId DragStartEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Drag_DragStartEventId, "DragStart");

        public DragPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationDragPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new DragPatternProperties();
            Events = new DragPatternEvents();
        }

        IDragPatternInformation IPatternWithInformation<IDragPatternInformation>.Cached => Cached;

        IDragPatternInformation IPatternWithInformation<IDragPatternInformation>.Current => Current;

        public IDragPatternProperties Properties { get; }
        public IDragPatternEvents Events { get; }

        protected override DragPatternInformation CreateInformation(bool cached)
        {
            return new DragPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class DragPatternInformation : InformationBase, IDragPatternInformation
    {
        public DragPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public string DropEffect => Get<string>(DragPattern.DropEffectProperty);

        public string[] DropEffects => Get<string[]>(DragPattern.DropEffectsProperty);

        public bool IsGrabbed => Get<bool>(DragPattern.IsGrabbedProperty);

        public AutomationElement[] GrabbedItems
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElementArray>(DragPattern.GrabbedItemsProperty);
                return ValueConverter.NativeArrayToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class DragPatternProperties : IDragPatternProperties
    {
        public PropertyId DropEffectProperty => DragPattern.DropEffectProperty;
        public PropertyId DropEffectsProperty => DragPattern.DropEffectsProperty;
        public PropertyId IsGrabbedProperty => DragPattern.IsGrabbedProperty;
        public PropertyId GrabbedItemsProperty => DragPattern.GrabbedItemsProperty;
    }

    public class DragPatternEvents : IDragPatternEvents
    {
        public EventId DragCancelEvent => DragPattern.DragCancelEvent;
        public EventId DragCompleteEvent => DragPattern.DragCompleteEvent;
        public EventId DragStartEvent => DragPattern.DragStartEvent;
    }
}
