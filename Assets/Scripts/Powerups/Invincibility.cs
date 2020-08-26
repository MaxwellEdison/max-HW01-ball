using UnityEngine;

public class Invincibility : PowerUpBase
{
    public float invulnDuration = 10f;

    protected override void PowerUp(Player player)
    {
        powerDur = invulnDuration;
        player.freezeHealth = true;
        invincible = true;
    }

    protected override void PowerDown(Player player)
    {
        Debug.Log("Unfreezing health");
        player.freezeHealth = false;
        gameObject.SetActive(false);
    }

}
