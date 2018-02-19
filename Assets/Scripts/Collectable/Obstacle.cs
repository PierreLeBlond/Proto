using UnityEngine;
using System.Collections;

public class Obstacle : Collectable {

    public override void Activate(Player player)
    {
        player.LevelDown();
        //gameObject.SetActive(false);
    }
}
