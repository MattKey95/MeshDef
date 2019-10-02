using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    Vector3 lastFramePos;
    List<GameObject> currentCollisions;
    // Start is called before the first frame update
    void Start()
    {
        currentCollisions = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var go in currentCollisions)
        {
            if(go.tag == "Player")
            {
                go.GetComponent<PlayerController>().Move(transform.position - lastFramePos);
                continue;
            }
            go.transform.position += transform.position - lastFramePos;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Added");
        currentCollisions.Add(collision.gameObject);
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("Removed");
        currentCollisions.Remove(collision.gameObject);
    }

}
