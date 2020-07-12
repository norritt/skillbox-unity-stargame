using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum EvilState
    {
        Rotated,
        Offending,
    }

    [Tags]
    public string TurnedTag;

    private string _oldTag;

    private EvilState _state;
    internal EvilState State
    {
        get => _state;
        set
        {
            _state = value;
            switch (value)
            {
                case EvilState.Rotated:
                    gameObject.tag = TurnedTag;
                    break;
                case EvilState.Offending:
                    gameObject.tag = _oldTag;
                    break;
            }
        }
    }

    private void Start()
    {
        _oldTag = gameObject.tag;
        State = EvilState.Offending;
    }
}
