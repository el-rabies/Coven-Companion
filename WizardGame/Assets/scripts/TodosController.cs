using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TodosController : MonoBehaviour
{
   [SerializeField] GameObject todoPrefab; //Preset to be filled in
   [SerializeField] GameObject wizardPrefab; // Selected Wizard
   [SerializeField] Transform todoWrapper; // Wrapper which holds the todo objects
   [SerializeField] string filename; // filename where the json which holds the todo's is stored
   [SerializeField] List<Sprite> completedSprites = new List<Sprite>(); // Sprites for the todo holder

   List<GameObject> uiElements = new List<GameObject> (); // List of objects in the todoWrapper

   private void UpdateUI (List<TodoElement> list) {
    for (int i = 0; i < list.Count; i++) {
        TodoElement todoElement = list[i];

        //Creates a todo object and fills renders proper, text, id and sprite
        var inst = Instantiate (todoPrefab, Vector3.zero, Quaternion.identity);
        inst.transform.SetParent(todoWrapper, false);
        uiElements.Add (inst);
        
        var text = uiElements[i].GetComponentInChildren<Text> ();
        var button = uiElements[i].GetComponentInChildren<Button> ();
        var id = button.GetComponentInChildren<Text> (true);

        button.onClick.AddListener( delegate{ToggleCompleteTodo(todoElement.id);} );
        
        text.text = todoElement.todoText;
        id.text = todoElement.id.ToString();

        if (todoElement.complete) {
            string spriteName = Utilities.GetWizardType(wizardPrefab.GetComponent<SpriteRenderer>().sprite.name);
            switch(spriteName) {
                case "air":
                    button.image.sprite = completedSprites[0];
                    break;
                case "fire":
                    button.image.sprite = completedSprites[1];
                    break;
                case "water":
                    button.image.sprite = completedSprites[2];
                    break;
                default:
                    break;
            }
        } else {
            button.image.sprite = completedSprites[3];
        }
    }
   }

    private void Start () {
        UpdateUI(FileHandler.ReadListFromJSON<TodoElement>(filename));
    }

    public void ReloadUI () {
        //Clear Children Before Reload
        foreach (var element in uiElements) {
            Destroy(element);
        }
        uiElements.Clear();

        //Update UI
        UpdateUI(FileHandler.ReadListFromJSON<TodoElement>(filename));
    }

    void ToggleCompleteTodo (int id) {
        //Fetch todo list from json along with index in list
        List<TodoElement> todoList = FileHandler.ReadListFromJSON<TodoElement>(filename);
        
        int i = 0;
        for (int j = 0; j < todoList.Count; j++) {
            if (todoList[j].id == id) {
                i = j;
            }
        }
        
        //Save todo and sort completed todos at the bottom
        todoList[i].complete = !todoList[i].complete;
        todoList = Utilities.SortTodos(todoList);

        //Save to JSON and reload the UI
        FileHandler.SaveToJSON<TodoElement>(todoList, filename);
        ReloadUI();
    }
}
