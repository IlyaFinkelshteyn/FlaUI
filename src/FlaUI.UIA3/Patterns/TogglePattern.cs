﻿using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class TogglePattern : PatternBaseWithInformation<UIA.IUIAutomationTogglePattern, TogglePatternInformation>, ITogglePattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TogglePatternId, "Toggle");
        public static readonly PropertyId ToggleStateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ToggleToggleStatePropertyId, "ToggleState");

        public TogglePattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTogglePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new TogglePatternProperties();
        }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Cached => Cached;

        public ITogglePatternProperties Properties { get; }

        ITogglePatternInformation IPatternWithInformation<ITogglePatternInformation>.Current => Current;

        protected override TogglePatternInformation CreateInformation(bool cached)
        {
            return new TogglePatternInformation(BasicAutomationElement, cached);
        }

        public void Toggle()
        {
            ComCallWrapper.Call(() => NativePattern.Toggle());
        }
    }

    public class TogglePatternInformation : InformationBase, ITogglePatternInformation
    {
        public TogglePatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public ToggleState ToggleState => Get<ToggleState>(TogglePattern.ToggleStateProperty);
    }

    public class TogglePatternProperties : ITogglePatternProperties
    {
        public PropertyId ToggleStateProperty => TogglePattern.ToggleStateProperty;
    }
}
