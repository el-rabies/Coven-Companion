using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoHandler : MonoBehaviour
{
    List<TodoElement> todoList = new List<TodoElement> ();
    [SerializeField] string filename;
    [SerializeField] GameObject panel;

    public void OpenClosePanelI() {
        panel.SetActive(!panel.active);
    }

    private void Start() {
        LoadTodos();
        panel.SetActive(false);
    }

    private void LoadTodos() {
        todoList = FileHandler.ReadListFromJSON<TodoElement>(filename);
        todoList = Utilities.SortTodos(todoList);
    }

    private void SaveTodos() {
        todoList = Utilities.SortTodos(todoList);
        FileHandler.SaveToJSON<TodoElement>(todoList, filename);
    }

    public void AddTodo(string todoText) {
        if (todoText != "") {
            todoList.Insert(0, new TodoElement(todoText, false, todoList.Count));
        }
        SaveTodos();
    }
}
