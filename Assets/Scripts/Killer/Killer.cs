using UnityEngine;

public class Killer : Enemy
{

    public override void PlayerImpact(Player player)
    {
        //base.PlayerImpact(player);
        player.Kill();
    }

}
