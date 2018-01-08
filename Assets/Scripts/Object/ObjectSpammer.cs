using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpammer : MonoBehaviour {

    public ObjectPool pool;

    private List<PlaygroundObject>          _objects = new List<PlaygroundObject>();

    private int                             _objectCount = 6;

    public void Launch() {
        //Launch a bunch of playgroundObject with a specific pattern
        float velocity = Random.Range(2.0f, 4.0f);
        float timeOffset = Random.Range(0.1f, 0.3f);
        Debug.Log(velocity);
        for(int i = 0; i < _objectCount; ++i) {
            StartCoroutine(SpamObject(i*timeOffset, velocity));
        }
    }

    public void ClearAll() {
        //Remove all playgroundObject from the pattern
        foreach (var playgroundObject in _objects.ToArray()) {
            _objects.Remove(playgroundObject);
            pool.ReleaseObject(playgroundObject);
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
        playgroundObject.GetComponent<Rigidbody>().velocity = new Vector3(-velocity, 0.0f, 0.0f);

        _objects.Add(playgroundObject);
    }

    public void Activate() {
        foreach (var playgroundObject in _objects) {
            playgroundObject.Activate();
        }
    }

    public void FixedUpdate() {
        foreach (var playgroundObject in _objects.ToArray()) {
            if(playgroundObject.transform.localPosition.x < -12.0f)
            {
                _objects.Remove(playgroundObject);
                pool.ReleaseObject(playgroundObject);
            }
        }
    }

    public void Deactivate() {
        foreach (var playgroundObject in _objects) {
            playgroundObject.Deactivate();
        }
    }
}
