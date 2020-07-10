using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject Explosion;

    // Update is called once per frame
    public void Demolish()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
