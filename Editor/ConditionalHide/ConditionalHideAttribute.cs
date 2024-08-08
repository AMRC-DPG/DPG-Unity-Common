using UnityEngine;

namespace DPG_Unity_Common.Editor.ConditionalHide
{
    public class ConditionalHideAttribute : PropertyAttribute
    {
        public ConditionalHideAttribute(string conditionalSourceField, bool expectedValue, bool hideInInspector)
        {
            ConditionalSourceField = conditionalSourceField;
            ExpectedValue = expectedValue;
            HideInInspector = hideInInspector;
        }

        public string ConditionalSourceField { get; private set; }
        public bool ExpectedValue { get; private set; }
        public bool HideInInspector { get; private set; }
    }
}