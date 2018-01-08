using UnityEngine;
using System.Collections;

public class Coin : Collectable {

    public override void Activate(Player player)
    {
        player.AddPoint();
        gameObject.SetActive(false);
    }
}
