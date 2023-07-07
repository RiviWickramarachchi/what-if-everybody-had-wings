using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private variables
    private int dayCount;
    private bool isInMiniGame;

    //public variables
    public List<Todos> todoList;
    public static GameManager Instance;

    public int DayCount { get => dayCount; set => dayCount = value; }
    public bool IsInMiniGame { get => isInMiniGame; set => isInMiniGame = value; }

    public static event Action OnDayEnd;
     //can be used to keep track of different levels

    private void Awake() {
        if(Instance != null) {
            Debug.LogWarning("More than One Quest Manager Instance Present");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        DayCount = 1;
    }
    private void DeletePositionData() {
        PlayerPrefs.DeleteAll();
    }
    public void MarkTodoComplete(int todoId) {
        for(int i = 0; i<todoList.Count; i++) {
            if(todoList[i].todoID == todoId) {
                todoList[i].TaskCompleted();
            }
        }
    }
    public bool CheckTaskCompletion(int workId) {
        Debug.Log("WID:"+workId);
        for(int i = 0; i<todoList.Count; i++) {
            if(todoList[i].todoID == workId) {
                if(todoList[i].todoState == Todos.TodoState.Done) {
                    return true;
                }
            }
        }
        return false;

    }
    public void AddTodos(Todos todo) {
        //TODO
        //Add todos from the todo giver
        Debug.Log("Adding Task to Game Mgr");
        todoList.Add(todo);
    }

    public void CheckTodoCompletion() {
        //TODO: Get the todo list length
        //TODO: Check if the no of tasks completed = length of the list
        int completedTasks = 0;
        foreach(Todos todo in todoList) {
            if(todo.todoState == Todos.TodoState.Done) {
                completedTasks++;
            }
        }
        if(completedTasks == todoList.Count) {
            //TODO: Blackout Screen
            Debug.Log("Level Completed");
            ClearTodos();
            DeletePositionData();
            DayCount++;
            // if(DayCount >6) {
            //     //TODO: TRIGGER END GAME STUFF
            //     //TODO: Set All Scriptable assets to not done
            // }
        }
    }

    public void ClearTodos() {
        //Clear the todoList at the end of each level
        todoList.Clear();
    }
}
