using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public void Move(Vector3 loc)
    {
        Debug.Log($"Moving from {transform.position} to {loc}");
        var coroutine = MoveFromTo(transform.position, loc, 5f);
        StartCoroutine(coroutine);
    }

    IEnumerator MoveFromTo(Vector3 a, Vector3 b, float speed)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            transform.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        transform.position = b;
    }

}
