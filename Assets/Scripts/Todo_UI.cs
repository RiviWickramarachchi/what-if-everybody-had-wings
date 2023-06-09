using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Todo_UI : MonoBehaviour
{
    private Transform todoSlotContainer;
    private Transform todoItemTemplate;

    private float todoItemSlotCellSize = 30f;
    private void Awake()
    {
        todoSlotContainer = transform.Find("TodoSlotContainer");
        todoItemTemplate = todoSlotContainer.Find("TodoItemTemplate");
    }
    void Start()
    {
        DisplayTodoList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Call this method if you are adding a show/hide button to the TODO list
    private void DisplayTodoList() {
        foreach (Transform child in todoSlotContainer)
        {
            if (child == todoItemTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);

        }
        int x = 0;
        int y = 0;
        //display the todo Items
        foreach(Todos todo in GameManager.Instance.todoList) {
            //Debug.Log(todo);
            RectTransform todoItemSlotRectTransform;
            TextMeshProUGUI todoItemName;
            Image image;
            todoItemSlotRectTransform = Instantiate(todoItemTemplate, todoSlotContainer).GetComponent<RectTransform>();
            todoItemSlotRectTransform.gameObject.SetActive(true);
            todoItemSlotRectTransform.anchoredPosition = new Vector2(0 * todoItemSlotCellSize, y * todoItemSlotCellSize);
            todoItemName = todoItemSlotRectTransform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            todoItemName.SetText(todo.todoDescription.ToString());
            image = todoItemSlotRectTransform.Find("Status").GetComponent<Image>();
            image.sprite = todo.GetTaskStateSprite();
            y--;
            x++;
            if (x > 1)
            {
                x = 0;
            }
        }
    }
}
