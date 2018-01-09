using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class AlternateSpammer : ObjectSpammer {

    public override void Launch() {
        //Launch a bunch of playgroundObject with a specific pattern
        float velocity = Random.Range(2.0f, 4.0f);
        float xOffset = Random.Range(1.0f, 2.0f);
        for(int i = 0; i < _objectCount/3; ++i) {
            StartCoroutine(SpamObject(i, velocity, xOffset));
        }
    }

    private IEnumerator SpamObject(int index, float velocity, float xOffset) {
        yield return new WaitForSeconds(index*(xOffset/velocity)*0.28f);

        for(int i = 0; i < _objectCount/2; ++i) {
            //Spam one playgroundObject with a specific pattern
            PlaygroundObject playgroundObject = pool.GetObject();

            //playgroundObject.GetComponent<Gravity>().enabled = false;

            Transform objectTransform = playgroundObject.transform;
            objectTransform.SetParent(transform, false);
            objectTransform.localPosition = new Vector3(12.0f + (index/2 + i*2)*xOffset, 3.0f, 0.0f);

            playgroundObject.Activate();

            //playgroundObject.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right*100.0f);
            playgroundObject.GetComponent<Rigidbody>().velocity = -velocity*playgroundObject.transform.right;

            _objects.Add(playgroundObject);
        }
    }
}
