using System;
using System.Collections.Generic;
using UnityEngine;

public class TagListComponent : MonoBehaviour
{
    [Tags]
    public string[] Tags;

    private HashSet<string> _set;

    private void Start()
    {
        _set = new HashSet<string>(Tags, StringComparer.OrdinalIgnoreCase);
    }

    internal bool Contains(string tag)
    {
        return _set.Contains(tag);
    }
}
