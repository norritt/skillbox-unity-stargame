using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var valObject = other.gameObject.GetComponent<ValueableObject>();
        if (valObject != null && valObject.TryGetPoints(gameObject.tag, out var points))
        {
            GameControllerScript.Instance.IncreaseScore(points);
        }
    }
}
