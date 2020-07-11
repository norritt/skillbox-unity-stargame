using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private enum EvilState
    {
        Rotated,
        Offending,
        Turning,
    }

    private EvilState _state;
    private IReadOnlyDictionary<EvilState, HashSet<string>> _stateIgnorables;

    private void Start()
    {
        _state = EvilState.Offending;
        _stateIgnorables = new Dictionary<EvilState, HashSet<string>>
        { 
            { EvilState.Offending, new HashSet<string>(new[] { "asteroid", "enemy", "boundary" }, StringComparer.OrdinalIgnoreCase) },
            { EvilState.Turning, new HashSet<string>(new[] { "asteroid", "enemy", "boundary" }, StringComparer.OrdinalIgnoreCase) },
            { EvilState.Rotated, new HashSet<string>(new[] { "enemy", "boundary" }, StringComparer.OrdinalIgnoreCase) },
        };
    }

    internal HashSet<string> GetIgnorable()
    {
        return _stateIgnorables.TryGetValue(_state, out var set) ? set : new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    internal bool IsRotated()
    {
        return _state == EvilState.Rotated;
    }

    internal void SetRotated()
    {
        _state = EvilState.Rotated;
    }
}
