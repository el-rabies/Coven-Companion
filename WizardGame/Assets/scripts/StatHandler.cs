using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    public PlayerStats playerStats =  new PlayerStats("air", 1, 1, 1, 1);
    public string filename = "stats.json";

    //Stat Management Functions
    public void LoadStats() {
        playerStats = FileHandler.ReadFromJSON<PlayerStats>(filename);
        if (playerStats == null) {
            playerStats = new PlayerStats("air", 1, 1, 1, 1);
            SaveStats();
            LoadStats();
        }
    }

    public void SaveStats() {
        FileHandler.SaveToJSON<PlayerStats>(playerStats, filename);
    }

    //Initalize Stats
    void Start()
    {
        LoadStats();
    }
}
