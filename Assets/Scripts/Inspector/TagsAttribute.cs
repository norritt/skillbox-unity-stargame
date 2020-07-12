public class TagsAttribute : 
    StringEnumerationToPopupAttribute
{
    public TagsAttribute() :
#if UNITY_EDITOR
        base(typeof(UnityEditorInternal.InternalEditorUtility), nameof(UnityEditorInternal.InternalEditorUtility.tags))
#else // UNITY_EDITOR
        base(typeof(object), string.Empty)
#endif // UNITY_EDITOR
    {
    }
}
