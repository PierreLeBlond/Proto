using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class SingleSpammer : ObjectSpammer {

    public override void Launch() {
        //Launch a bunch of playgroundObject with a specific pattern
        float velocity = Random.Range(2.0f, 4.0f);
        SpamObject(velocity);
    }

    public override void Stop() {
    }

    private void SpamObject(float velocity) {
        //Spam one playgroundObject with a specific pattern
        PlaygroundObject playgroundObject = pool.GetObject();

        Transform objectTransform = playgroundObject.transform;
        objectTransform.SetParent(transform, false);
        objectTransform.localPosition = new Vector3(12.0f, -4.0f, 0.0f);

        playgroundObject.Activate();

        //playgroundObject.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right*100.0f);
        playgroundObject.GetComponent<Rigidbody>().velocity = -velocity*playgroundObject.transform.right;

        _objects.Add(playgroundObject);
    }
}
