using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;
    }
}
