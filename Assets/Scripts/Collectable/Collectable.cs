using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    void Start() {
        tag = "Collectable";
    }

    public virtual void Activate(Player player) {

    }
}

