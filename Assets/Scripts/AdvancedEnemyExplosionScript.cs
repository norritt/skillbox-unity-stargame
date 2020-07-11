using UnityEngine;

[RequireComponent(typeof(EnemyState))]
[RequireComponent(typeof(DestroyScript))]
public class AdvancedEnemyExplosionScript : MonoBehaviour
{
    private EnemyState _state;
    private DestroyScript _destroyable;

    // Start is called before the first frame update
    void Start()
    {
        _state = GetComponent<EnemyState>();
        _destroyable = GetComponent<DestroyScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var list = _state.GetIgnorable();
        if (list.Contains(other.gameObject.tag))
        {
            return;
        }
        var destroyable = other.GetComponentInParent<DestroyScript>();
        if (destroyable != null)
        {
            destroyable.Demolish();
        }
        _destroyable.Demolish();
    }
}
