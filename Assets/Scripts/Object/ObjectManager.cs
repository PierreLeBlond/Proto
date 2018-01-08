using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
    public ObjectSpammer            spammer;

    private bool                    _spam = false;

    public void Launch() {
        _spam = true;
        StartCoroutine(LaunchSpammer(6.0f));
    }

    private IEnumerator LaunchSpammer(float waitingTime) {
        while(_spam) {
            spammer.Launch();
            float timeOffset = Random.Range(0.2f, 1.0f);
            yield return new WaitForSeconds(waitingTime*timeOffset);
        }
    }

    public void Stop() {
        _spam = false;
    }

    public void Clear() {
        spammer.ClearAll();
    }
}
