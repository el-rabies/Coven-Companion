using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class WizardManager : MonoBehaviour
{
    //Credits to https://www.youtube.com/watch?v=8ogyT842otg&t=312s
    //Variables
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public int selectedSkin = 0;
    public GameObject playerSkin;
    
    //Skin Selection Controls
    public void NextOption() {
        selectedSkin= selectedSkin + 1;
        if (selectedSkin == skins.Count) {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

     public void BackOption() {
        selectedSkin= selectedSkin - 1;
        if (selectedSkin < 0) {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame() {
        PrefabUtility.SaveAsPrefabAsset(playerSkin, @"Assets\SelectedWizard.prefab");
        SceneManager.LoadScene("WizScene");
    }
}
