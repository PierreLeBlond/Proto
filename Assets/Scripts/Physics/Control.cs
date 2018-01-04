using UnityEngine;
using System.Collections;

public class Control {

    protected Rigidbody         _body;
    protected BoxCollider       _mouseCollider;

    public Control(Rigidbody body, BoxCollider mouseCollider)
    {
        _body = body;
        _mouseCollider = mouseCollider;
    }

    public virtual void Init() {
    }

    public virtual void Update() {
    }
}


