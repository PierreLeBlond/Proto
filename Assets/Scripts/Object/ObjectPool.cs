using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public PlaygroundObject                 objectPrefab;

    private Stack<PlaygroundObject>         _available = new Stack<PlaygroundObject>();
    private List<PlaygroundObject>          _inUse = new List<PlaygroundObject>();

    //TODO Set a maximum number of instances ?

    public PlaygroundObject GetObject() {
        PlaygroundObject objectInstance;
        if(_available.Count > 0) {
            objectInstance = _available.Pop();
        } else {
            objectInstance = InstantiateObject();
        }
        _inUse.Add(objectInstance);
        return objectInstance;
    }

    public void ReleaseObject(PlaygroundObject objectInstance) {
        //Make sure the object is within a stable state
        objectInstance.Reset();
        if(_inUse.Remove(objectInstance)) {
            _available.Push(objectInstance);
        }
    }

    private PlaygroundObject InstantiateObject() {
        PlaygroundObject playgroundObject = Instantiate(objectPrefab) as PlaygroundObject;
        return playgroundObject;
    }
}
