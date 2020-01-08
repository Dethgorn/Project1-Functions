using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // The Coroutine
    public IEnumerator MyCoroutine()
    {
        // The coroutine will run until it reaches a yield statement.
        Debug.Log("Coroutine Line1");
        yield return null; // This yield will make the coroutine stop for this frame draw.  

        // Next frame draw, it will pick up here.
        Debug.Log("Coroutine Line2");

        // This waits for 5 seconds before the coroutine will move on!
        yield return new WaitForSeconds(5);
        Debug.Log("Coroutine Line3");

        // Note that this is an "infinite loop!" this is usually really bad, but...
        while (true)
        {
            // ... By "pausing" for the rest of this frame draw, the rest of our program keeps running!
            Debug.Log("Coroutine Line4");

            // We can still get new inputs (which happens every frame draw), wait for network data, load part of a file, or anything else while we wait!
            yield return null;

            // Without coroutines, this next line wouldn't work, because inputs are only read once per frame draw!
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // We can end our coroutine (and this this loop) by yielding back a break!
                yield break;
            }
        }
    }
}
