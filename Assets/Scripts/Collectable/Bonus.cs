using UnityEngine;
using System.Collections;

public class Bonus : Collectable {

    public override void Activate(Player player)
    {
        player.LevelUp();
        gameObject.SetActive(false);
    }
}

