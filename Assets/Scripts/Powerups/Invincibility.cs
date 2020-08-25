using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
/*    public float powerDur = 10f;
    private bool invincible;
    private float timeLeft;*/

    protected override void PowerUp(Player player)
    {
        player.freezeHealth = true;
        Debug.Log("thinga");
        float timeLeft = powerDur;
        invincible = true;
        Debug.Log("invincible =" + invincible);
    }

    private void FixedUpdate()
    {
        if (invincible == true)
        {
            float timeLeft = powerDur - Time.deltaTime;
            Debug.Log("time left =" + timeLeft);
            if (timeLeft <= 0)
            {
                invincible = false;
                Player player = GameObject.Find("PlayerBall").GetComponent<Player>();
                PowerDown(player);
                Debug.Log("powering down");
            }
        }
    }

    protected override void PowerDown(Player player)
    {
        player.freezeHealth = false;
    }

}
