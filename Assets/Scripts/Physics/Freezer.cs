using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour {

    public bool                  X;
    public bool                  Y;
    public bool                  Z;

    private float                _initialX;
    private float                _initialY;
    private float                _initialZ;

    public virtual void Start() {
        Vector3 localPosition = transform.localPosition;
        _initialX = localPosition.x;
        _initialY = localPosition.y;
        _initialZ = localPosition.z;
    }

    public virtual void FixedUpdate() {
        Vector3 localPosition = transform.localPosition;
        gameObject.transform.localPosition = new Vector3(X ? _initialX : localPosition.x,
                                            Y ? _initialY : localPosition.y,
                                            Z ? _initialZ : localPosition.z);
    }
}
