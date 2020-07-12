using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject Explosion;

    public void Demolish()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
