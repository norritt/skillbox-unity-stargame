using UnityEngine;

[RequireComponent(typeof(DestroyScript))]
[RequireComponent(typeof(TagListComponent))]
public class BasicEnemyExplosionScript : MonoBehaviour
{
    private DestroyScript _destroyable;
    private TagListComponent _targetTagsComponent;

    void Start()
    {
        _destroyable = GetComponent<DestroyScript>();
        _targetTagsComponent = GetComponent<TagListComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_targetTagsComponent.Contains(other.gameObject.tag))
        {
            return;
        }
        var hitObject = other.GetComponentInParent<HitScript>();
        if (hitObject != null)
        {
            hitObject.Hit();
        }
        else
        {
            var destroyable = other.GetComponentInParent<DestroyScript>();
            if (destroyable != null)
            {
                destroyable.Demolish();
            }
        }
        _destroyable.Demolish();
    }
}
