using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public HealthBar healthBar;
    public StatHandler statHandler;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(statHandler.playerStats.maxHealth);
        healthBar.SetHealth(statHandler.playerStats.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
