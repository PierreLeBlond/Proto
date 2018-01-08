using UnityEngine;
using System;
using System.Collections;


public class Jetpack : Control {

    private float               _thrust = 20.0f;

    public Jetpack(Rigidbody body, BoxCollider mouseCollider) : base(body, mouseCollider){}

    public override void Init()
    {
        _body.GetComponent<Gravity>().enabled = true;
        _body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public override void Update() {
        if(Input.GetKey(Define.Key)) {
            _body.AddForce(_body.transform.up * _thrust);
        }
    }
}
