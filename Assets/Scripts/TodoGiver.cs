using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TodoGiver : MonoBehaviour
{

    [SerializeField] private List<Todos> todosDay1;
    [SerializeField] private List<Todos> todosDay2;
    [SerializeField] private List<Todos> todosDay3;

    //private list
    private List<Todos> todos;
    private void Awake() {
        todos = new List<Todos>();
        SetDayTasks();
        Assert.IsNotNull(todos);
        SetTaskStatus();
        SendDailyTasksToGameMgr();

    }

    private void SendDailyTasksToGameMgr() {
        Debug.Log("Starting To Send DailyTasks");
        if(GameManager.Instance.todoList.Count == 0) {
            foreach(Todos todo in todos) {
                Debug.Log("Task Added");
                GameManager.Instance.AddTodos(todo);
            }
        }
    }

    private void SetTaskStatus() {
        if(GameManager.Instance.todoList.Count == 0) {
            foreach(Todos todo in todos) {
                todo.todoState = Todos.TodoState.Not_Done;
            }
        }
    }

    private void SetDayTasks() {
        switch(GameManager.Instance.DayCount) {
            case 1:
                foreach(Todos todo in todosDay1) {
                    todos.Add(todo);
                }
                break;
            case 2:
                foreach(Todos todo in todosDay2) {
                    todos.Add(todo);
                }
                break;
            case 3:
                foreach(Todos todo in todosDay3) {
                    todos.Add(todo);
                }
                break;
        }
    }
}
