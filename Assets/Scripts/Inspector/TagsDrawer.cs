using UnityEditor;

[CustomPropertyDrawer(typeof(TagsAttribute))]
public class TagsDrawer : 
    StringEnumerationToPopupDrawer
{
}
