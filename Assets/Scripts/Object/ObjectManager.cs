using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
    public ObjectSpammer[]            spammers;

    private bool                    _spam = false;

    public void Launch() {
        _spam = true;
        StartCoroutine(LaunchSpammer(6.0f));
    }

    private IEnumerator LaunchSpammer(float waitingTime) {
        while(_spam) {
            spammers[Random.Range(0, spammers.Length)].Launch();
            float timeOffset = Random.Range(0.2f, 1.0f);
            yield return new WaitForSeconds(waitingTime*timeOffset);
        }
    }

    public void Stop() {
        _spam = false;
    }

    public void Clear() {
        foreach(var spammer in spammers) {
            spammer.ClearAll();
        }
    }
}
