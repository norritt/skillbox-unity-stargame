using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    public float Speed;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Mathf.Repeat(Time.time * Speed, 150);
        transform.position = _startPosition + Vector3.back * offset;
    }
}
