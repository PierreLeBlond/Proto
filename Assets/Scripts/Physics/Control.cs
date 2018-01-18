using UnityEngine;
using System.Collections;

public abstract class Control : MonoBehaviour {

    public Rigidbody         body;
    public BoxCollider       mouseCollider;

    public abstract void Init();
}
