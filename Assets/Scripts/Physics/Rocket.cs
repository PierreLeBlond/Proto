using UnityEngine;
using System;
using System.Collections;

public class Rocket : Control {

    public float            slope = 10.0f;
    public float            drag = -5.0f;

    private Vector2         _target;

    public override void Init()
    {
        body.GetComponent<Gravity>().enabled = false;
        body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        _target = new Vector3(0.0f, 0.0f, 0.0f);
        body.transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    public void Update() {
        if(Input.GetKey(Define.Key))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(mouseCollider.Raycast(ray, out raycastHit, 100.0f)) {
                Vector3 impact = raycastHit.point;
                Vector3 center = mouseCollider.transform.position;
                Vector3 offset = impact - center;
                float y = offset.y / mouseCollider.transform.lossyScale.y;
                _target = new Vector3(body.transform.localPosition.x, y, body.transform.localPosition.z);
            }
        }

    }

    public void FixedUpdate () {
        float distance = _target.y - body.transform.localPosition.y;
        float thrust = slope * distance;
        //Physics is awesome !
        body.AddForce(body.transform.right * -thrust);
        body.AddForce(drag * body.velocity);
    }
}
