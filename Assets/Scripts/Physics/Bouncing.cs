using UnityEngine;
using System.Collections;

public class Bouncing : MonoBehaviour {

    private Rigidbody         _body;

    public virtual void Start() {
        _body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block")) {
            Debug.Log("coucou");
            Vector3 velocity = _body.velocity;
            velocity.y = -velocity.y;
            _body.velocity = -_body.velocity;
        }
    }
}


