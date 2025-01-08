using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Skin Variables
    [SerializeField] private Animator wizardAnimator;
    public GameObject selectedskinObj;
    public GameObject Wizard;
    public StatHandler statHandler;
    private Sprite playersprite;

    //Scene Manegement Functions
    public void GoToTodo() {
        SceneManager.LoadScene("TodoScene");
    }

    public void GoToWiz() {
        SceneManager.LoadScene("WizScene");
    }

    // Start is called (loads selected wizard)
    void Start()
    {
        statHandler.LoadStats();
        playersprite = selectedskinObj.GetComponent<SpriteRenderer>().sprite;
        Wizard.GetComponent<SpriteRenderer>().sprite = playersprite;

        string wizardType = Utilities.GetWizardType(playersprite.name);
        switch(wizardType) {
            case "air":
                wizardAnimator.SetInteger("WizardType", 0);
                statHandler.playerStats.wizard = "air";
                break;
            case "fire":
                wizardAnimator.SetInteger("WizardType", 1);
                statHandler.playerStats.wizard = "fire";
                break;
            case "water":
                wizardAnimator.SetInteger("WizardType", 2);
                statHandler.playerStats.wizard = "water";
                break;
        }
        statHandler.SaveStats();
    }
}
