using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectSpammer : MonoBehaviour {

    public ObjectPool pool;

    protected List<PlaygroundObject>          _objects = new List<PlaygroundObject>();
    protected int                             _objectCount = 6;

    abstract public void Launch();

    abstract public void Stop();

    public void ClearAll() {
        foreach (var playgroundObject in _objects.ToArray()) {
            _objects.Remove(playgroundObject);
            pool.ReleaseObject(playgroundObject);
        }
    }

    public void Activate() {
        foreach (var playgroundObject in _objects) {
            playgroundObject.Activate();
        }
    }

    virtual public void FixedUpdate() {
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
