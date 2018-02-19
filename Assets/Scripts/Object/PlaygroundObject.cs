using UnityEngine;
using System.Collections;

public class PlaygroundObject : MonoBehaviour {

    public GameObject               child;

    private Rigidbody               _body;

    void Start() {
        _body = GetComponent<Rigidbody>();
    }

    public void Reset() {
        transform.parent = null;
        transform.position = Vector3.zero;
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
        _body.velocity = new Vector3(0, 0, 0);
        Deactivate();
    }

    public void Activate() {
        child.SetActive(true);
    }

    public void Deactivate() {
        child.SetActive(false);
    }
}
