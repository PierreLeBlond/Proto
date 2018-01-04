using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public float                width;
    public float                height;

    void Start() {
        GetComponent<Camera>().aspect = width/height;
    }
}

