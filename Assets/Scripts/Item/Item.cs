using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public Collectable collectable;

    void Start() {
        Clean();
    }

    public void Spam() {
        collectable.gameObject.SetActive(true);
        Vector3 localPosition = transform.localPosition;
        localPosition.y = Random.Range(-6, 6)/2.0f;
        transform.localPosition = localPosition;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * -0.84f;
    }

    public void Clean() {
        collectable.gameObject.SetActive(false);
    }
}


