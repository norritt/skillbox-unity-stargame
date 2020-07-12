#if UNITY_EDITOR
using UnityEditor;

[CustomPropertyDrawer(typeof(TagsAttribute))]
public class TagsDrawer : 
    StringEnumerationToPopupDrawer
{
}
#endif // UNITY_EDITOR