﻿public class Treasure : CollectibleBase
{
    public int _treasureValue;
    protected override void Collect(Player player)
    {
        player.keepScore(_treasureValue);
    }
}
