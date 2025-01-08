using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {
    public static string GetWizardType(string spriteName) {
        if (spriteName.Contains("air")) {
            return "air";
        } else if (spriteName.Contains("fire")) {
            return "fire";
        } else if (spriteName.Contains("water")) {
            return "water";
        } else {
            return "";
        }
    }

    public static List<TodoElement> SortTodos(List<TodoElement> todoList) {
        List<TodoElement> incompleteTodos = new List<TodoElement>();
        List<TodoElement> completedTodos = new List<TodoElement>();

        foreach (TodoElement todo in todoList) {
            if (todo.complete) {
                completedTodos.Add(todo);
            } else {
                incompleteTodos.Add(todo);
            }
        }

        incompleteTodos.AddRange(completedTodos);

        return incompleteTodos;
    }
}