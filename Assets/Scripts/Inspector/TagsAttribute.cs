using UnityEditorInternal;

public class TagsAttribute : 
    StringEnumerationToPopupAttribute
{
    public TagsAttribute() :
        base(typeof(InternalEditorUtility), nameof(InternalEditorUtility.tags))
    {
    }
}
