using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TodoItem", menuName ="ScriptableObjects/TodoItem")]
public class Todos : ScriptableObject
{
    public int todoID;
    public string todoDescription;
    public enum TodoState {Done, Not_Done};
    public TodoState todoState = TodoState.Not_Done;

   public void TaskCompleted() {
        todoState = TodoState.Done;
        Debug.Log("Task completed");
   }

   public Sprite GetTaskStateSprite() {
        switch (todoState)
        {
            default:
            case TodoState.Not_Done:
                return TodoStateAssets.Instance.taskNotDoneSprite;
            case TodoState.Done:
                return TodoStateAssets.Instance.taskDoneSprite;
        }
   }
}
