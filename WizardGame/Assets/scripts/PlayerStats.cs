using System;

[Serializable]
public class PlayerStats {
    public string wizard;
    public int health;
    public int maxHealth;
    public int sleep;
    public int maxSleep;

    public PlayerStats (string wiz, int hp, int mHp, int sp, int mSp) {
        wizard = wiz;
        health = hp;
        maxHealth = mHp;
        sleep = sp;
        maxSleep = mSp;
    }
}