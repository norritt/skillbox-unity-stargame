using System;
using UnityEngine;

public class StringEnumerationToPopupAttribute :
    PropertyAttribute
{
    public Type Type { get; }
    public string PropertyName { get; }

    public StringEnumerationToPopupAttribute(
        Type type,
        string propertyName)
    {
        Type = type;
        PropertyName = propertyName;
    }
}
