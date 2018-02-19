using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    public bool                     isEnabled = true;
    public Vector3                  direction;//Local direction of gravity
    public float                    strengh = -9.81f;

    private Rigidbody               _body;

    public virtual void Start() {
        _body = GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate() {
        if(isEnabled) {
            _body.AddRelativeForce(strengh*direction);
        }
    }
}
