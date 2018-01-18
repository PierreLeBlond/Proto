using UnityEngine;
using System;
using System.Collections;


public class God : Control {

    public Player           player;

    private float           slope = 10.0f;
    private float           drag = -2.0f;

    private Vector2         _target;

    public override void Init()
    {
        body.GetComponent<Gravity>().enabled = false;
        body.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        _target = new Vector3(0.0f, 0.0f, 0.0f);
        body.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void Update() {
        if(Input.GetKey(Define.Key))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(ray, out raycastHit);

            if(hasHit)
            {
                if(raycastHit.collider.CompareTag("Collectable")) {
                    raycastHit.collider.GetComponent<Collectable>().Activate(player);
                }
            }
        }
    }

    public void FixedUpdate () {
        float distance = _target.y - body.transform.localPosition.y;
        float thrust = slope * distance;
        //Physics is awesome !
        body.AddForce(body.transform.up * thrust);
        body.AddForce(drag * body.velocity);
    }
}
