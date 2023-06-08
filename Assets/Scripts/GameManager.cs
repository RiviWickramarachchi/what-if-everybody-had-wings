using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private variables
    private int dayCount; //can be used to keep track of different levels

    //public variables
    public List<Todos> todoList;
    public static GameManager Instance;
    public static event Action<int> OnDayEnd;

    private void Awake() {
        if(Instance != null) {
            Debug.LogWarning("More than One Quest Manager Instance Present");
            Destroy(this.gameObject);
            return;
        }
        //dialogueVariables = new DialogueVariables(loadGlobalsJSON);
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        dayCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   //test
         if(Input.GetKeyDown(KeyCode.X)) {
            MarkTodoComplete(11);
        }
    }


    private void MarkTodoComplete(int todoId) {
        for(int i = 0; i<todoList.Count; i++) {
            if(todoList[i].todoID == todoId) {
                todoList[i].TaskCompleted();
            }
        }
        //TODO: Check the todo list for the ID of the specific task that was completed
        //TODO: If ID was found, mark that specific todo Item as done (Call the TaskCompleted method on Todos)
    }
    public void AddTodos(Todos todo) {
        //TODO
        //Add todos from the todo giver
        todoList.Add(todo);
    }

    //test script

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
            dayCount++;
            //Transition to the next level (scene)
            //OnDayEnd?.Invoke(dayCount);
            //TODO: Call SceneLoader.LoadNextLvl
        }
    }

    public void ClearTodos() {
        //Clear the todoList at the end of each level
        todoList.Clear();
    }
}
