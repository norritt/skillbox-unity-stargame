using System;
using System.Collections.Generic;
using UnityEngine;

public class ValueableObject : MonoBehaviour
{
    [Tags]
    public string[] AllowedToCollect;

    public int Points = 10;
    private HashSet<string> _allowedToCollect;

    private void Start()
    {
        _allowedToCollect = new HashSet<string>(AllowedToCollect, StringComparer.OrdinalIgnoreCase);
    }

    internal bool TryGetPoints(string tag, out int points)
    {
        var allowed = _allowedToCollect.Contains(tag);
        points = allowed ? Points : default;
        return allowed;
    }
}
