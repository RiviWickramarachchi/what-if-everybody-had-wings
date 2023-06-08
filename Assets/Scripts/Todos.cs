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
        //TODO: Call the checkTodoCompletion Method in Game Mgr
        GameManager.Instance.CheckTodoCompletion();
   }
}
