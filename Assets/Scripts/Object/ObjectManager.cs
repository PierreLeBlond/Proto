using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
    public ObjectSpammer[]            spammers;

    private bool                        _spam = false;

    private List<IEnumerator>           _coroutines = new List<IEnumerator>();

    public void Launch() {
        _spam = true;
        IEnumerator coroutine = LaunchSpammer(6.0f);
        _coroutines.Add(coroutine);
        StartCoroutine(coroutine);
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
        foreach(var spammer in spammers) {
            spammer.Stop();
        }
        foreach(var coroutine in _coroutines.ToArray()) {
            StopCoroutine(coroutine);
            _coroutines.Remove(coroutine);
        }
    }

    public void Clear() {
        foreach(var spammer in spammers) {
            spammer.ClearAll();
        }
    }
}
