using UnityEngine;
using System;
using System.Collections;


public class Jetpack : Control {

    public float                thrust = 20.0f;
    private bool                _activated;

    public override void Init()
    {
        _activated = false;
        body.GetComponent<Gravity>().enabled = true;
        body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void Update() {
        if(Input.GetKey(Define.Key)) {
            _activated = true;
        } else {
            _activated = false;
        }
    }

    public void FixedUpdate () {
        if(_activated) {
            body.AddForce(body.transform.up * thrust);
        }
    }
}
