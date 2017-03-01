using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
    void Start() {
        Camera.main.aspect = 1800.0f/1000.0f;
    }
}

