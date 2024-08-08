using UnityEditor;
using UnityEngine;

namespace DPG_Unity_Common.Editor.ConditionalHide
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var conditionalHideAttribute = attribute as ConditionalHideAttribute;
            var enabled = GetConditionalSourceField(property, conditionalHideAttribute);
            GUI.enabled = enabled;

            if (enabled)
                EditorGUI.PropertyField(position, property, label, true);
            else if (!conditionalHideAttribute!.HideInInspector)
                EditorGUI.PropertyField(position, property, label, false);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var conditionalHideAttribute = attribute as ConditionalHideAttribute;
            var enabled = GetConditionalSourceField(property, conditionalHideAttribute);

            if (enabled) return EditorGUI.GetPropertyHeight(property, label, true);

            if (!conditionalHideAttribute!.HideInInspector) return EditorGUI.GetPropertyHeight(property, label, false);

            return -EditorGUIUtility.standardVerticalSpacing;
        }

        private bool GetConditionalSourceField(SerializedProperty property,
            ConditionalHideAttribute conditionalHideAttribute)
        {
            var enabled = false;
            var propertyPath = property.propertyPath;
            var conditionalPath =
                propertyPath.Replace(property.name, conditionalHideAttribute.ConditionalSourceField);
            var sourcePropertyValue = property.serializedObject.FindProperty(conditionalPath);

            if (sourcePropertyValue is not null)
            {
                enabled = sourcePropertyValue.boolValue;
                enabled = enabled == conditionalHideAttribute.ExpectedValue;
            }
            else
            {
                // Super helpful error but not sure what else to put...
                Debug.LogError("ConditionalHide has issues");
            }

            return enabled;
        }
    }
}