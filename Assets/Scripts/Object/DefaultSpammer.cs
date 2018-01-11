using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class DefaultSpammer : ObjectSpammer {

    private List<IEnumerator>             _coroutines = new List<IEnumerator>();

    public override void Launch() {
        //Launch a bunch of playgroundObject with a specific pattern
        float velocity = Random.Range(2.0f, 4.0f);
        float timeOffset = Random.Range(0.1f, 0.3f);
        for(int i = 0; i < _objectCount; ++i) {
            IEnumerator coroutine = SpamObject(i*timeOffset, velocity);
            _coroutines.Add(coroutine);
            StartCoroutine(coroutine);
        }
    }

    public override void Stop() {
        foreach (var coroutine in _coroutines.ToArray()) {
            StopCoroutine(coroutine);
            _coroutines.Remove(coroutine);
        }
    }

    private IEnumerator SpamObject(float waitingTime, float velocity) {
        yield return new WaitForSeconds(waitingTime);

        //Spam one playgroundObject with a specific pattern
        PlaygroundObject playgroundObject = pool.GetObject();

        Transform objectTransform = playgroundObject.transform;
        objectTransform.SetParent(transform, false);
        objectTransform.localPosition = new Vector3(12.0f, 3.0f, 0.0f);

        playgroundObject.Activate();

        //playgroundObject.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.right*100.0f);
        playgroundObject.GetComponent<Rigidbody>().velocity = -velocity*playgroundObject.transform.right;

        _objects.Add(playgroundObject);
    }
}
