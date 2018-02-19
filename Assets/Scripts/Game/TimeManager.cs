using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public void SlowTime (float timeFactor, float timeLength) {
        Time.timeScale = timeFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        StartCoroutine(IncreaseTimeToNormal(timeLength));
    }

    public IEnumerator IncreaseTimeToNormal (float timeLength) {
        while(Time.timeScale < 1.0f) {
            yield return null;
            Time.timeScale += (1f / timeLength) * Time.unscaledDeltaTime;
        }
    }

    public void ResetTime () {
        Time.timeScale = 1.0f;
    }

    public void StopTime () {
        Time.timeScale = 0.0f;
    }

}
