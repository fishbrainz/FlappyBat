using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D> ();
        rigidbody.velocity = Vector2.left;
    }

    void Update()
    {
       var screenPoint = Camera.main.WorldToScreenPoint (this.transform.position);
        if (screenPoint.x < -Screen.width / 4)
        {
            DestroyImmediate (this.gameObject);
        }
    }

    public void StopObstacles()
    {
        rigidbody.velocity = Vector2.zero;
    }

}
