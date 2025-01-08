using System;

[Serializable]
public class TodoElement {
    public string todoText;
    public bool complete;
    public int id;

    public TodoElement (string text, bool done, int num) {
        todoText = text;
        this.complete = done;
        id = num;
    }
}
