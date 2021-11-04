using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public BackgroundData Data;
    public List<GameObject> Levels;
    private new Camera camera;
    private Vector2 screenViewport;

    private void Start()
    {
        camera = Camera.main;
        screenViewport = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

        foreach (GameObject gameObject in Data.Levels)
        {
            CreateBackground (gameObject);
        }
    }

    private void CreateBackground(GameObject gameObject)
    {
        GameObject backgroundLevel = new GameObject();
        backgroundLevel.transform.SetParent (this.transform);   
        Levels.Add (backgroundLevel);

        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        float backgroundWidth = renderer.bounds.size.x;
        int copies = (int) Mathf.Ceil(screenViewport.x * 2 / backgroundWidth);

        for (int i = 0; i <= copies; i++)
        {
            GameObject copy = Instantiate(gameObject, backgroundLevel.transform);
            copy.transform.position = new Vector3 (backgroundWidth * i, backgroundLevel.transform.position.y, gameObject.transform.position.z);
            copy.name += " " + i;
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            repositionChildren (Levels[i]);
        }
    }

    private void repositionChildren(GameObject gameObject)
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length-1].gameObject;
            float halfWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;

            if (transform.position.x + screenViewport.x > lastChild.transform.position.x + halfWidth)
            {
                firstChild.transform.SetAsLastSibling ();
                firstChild.transform.position = new Vector3 (lastChild.transform.position.x + halfWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
        }
    }
}
