using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bird : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    public Animator animator;
    new Collider2D collider;
    [Range(1, 5)]
    public int JumpForce = 1;
    bool inputEnabled = false;

    public string scoreTriggerTag;

    public ScoreData score;

    public GameEvent ScoreEvent;
    public GameEvent DeathEvent;
    public GameEvent FlapEvent;
    public GameEvent CollideEvent;
    public GameEvent OutOfBoundsEvent;
    public bool outOfBounds = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D> ();
        rigidbody = GetComponent<Rigidbody2D> ();

        Init ();
    }

    public void Init()
    {
        collider.enabled = true;
        score.Reset ();
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled)
        {
            if (Input.GetMouseButtonDown (0))
            {
                rigidbody.velocity = Vector2.up * JumpForce;
                animator.SetTrigger ("Fly");
                FlapEvent.RaiseEvent ();
            }
        }
        if (isDead)
        {
            if (!outOfBounds)
            {
                var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
                if (screenPoint.y < 0)
                {
                    OutOfBoundsEvent.RaiseEvent ();
                    outOfBounds = true;
                }
            }
        }
    }

    public void EnableInput()
    {
        inputEnabled = true;
        rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }


    public void DisableInput()
    {
        inputEnabled = false;
        rigidbody.constraints = RigidbodyConstraints2D.None;
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log ("Collision! " + collision.gameObject.name);
        if (!isDead)
        {
            DeathEvent.RaiseEvent ();
            DisableInput ();
        }
        CollideEvent.RaiseEvent ();
        ContactPoint2D contact = collision.GetContact (0);
        rigidbody.AddForce (contact.normal * UnityEngine.Random.Range (70, 200));
        rigidbody.AddTorque (UnityEngine.Random.Range (55, 75));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log ("Trigger! " + collision.gameObject.name);

        if (collision.gameObject.tag == scoreTriggerTag)
        {
            score.Increment (100);
            ScoreEvent.RaiseEvent ();
        }

    }

}
