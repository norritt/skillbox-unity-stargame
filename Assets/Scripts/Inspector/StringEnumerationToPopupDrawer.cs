using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(StringEnumerationToPopupAttribute))]
public class StringEnumerationToPopupDrawer :
    PropertyDrawer
{
    public override void OnGUI(
        Rect position, 
        SerializedProperty property, 
        GUIContent label)
    {
        if (!(attribute is StringEnumerationToPopupAttribute atb))
        {
            return;
        }

        var members = atb.Type.GetMember(atb.PropertyName, MemberTypes.Field | MemberTypes.Property, BindingFlags.Public | BindingFlags.Static);
        var member = members?.FirstOrDefault();
        if (member == null)
        {
            return;
        }

        var obj = member is PropertyInfo prop ? prop.GetValue(null) : (member is FieldInfo field ? field.GetValue(null) : null);
        if (!(obj is IEnumerable<string> stringList) || stringList == null || !stringList.Any())
        {
            EditorGUI.PropertyField(position, property, label);
            return;
        }
        var stringLst = stringList.ToList();
        var selectedIndex = stringLst.IndexOf(property.stringValue);
        selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex < 0 ? 0 : selectedIndex, stringLst.ToArray());
        property.stringValue = stringLst[selectedIndex];
    }
}
