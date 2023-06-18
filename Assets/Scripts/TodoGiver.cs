using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TodoGiver : MonoBehaviour
{

    [SerializeField] private List<Todos> todos;
    private void Awake() {
        Assert.IsNotNull(todos);

    }
    void Start() {
        SetTaskStatus();
        SendDailyTasksToGameMgr();
    }
    private void SendDailyTasksToGameMgr() {
        if(GameManager.Instance.todoList.Count == 0) {
            foreach(Todos todo in todos) {
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
}
