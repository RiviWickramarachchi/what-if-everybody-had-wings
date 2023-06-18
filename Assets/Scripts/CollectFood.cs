using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{

    private int workID;
    private bool playerInRange;
    public static event Action<bool> OnInteractionTrigger;
    // Start is called before the first frame update
    void Start()
    {
        //TODO : If the task is completed- SetVisibility to false
        //else visibility is true
        SetWorkID();
        SetGameObject();


    }
    void Update() {
        PickUpFood();
    }
    private void SetWorkID() {
        string taskId = "2"; //2 FOR GROCERY SHOPPING
        string wId = GetDayCount().ToString() + taskId;
        workID = Int32.Parse(wId);
        Debug.Log(workID);
    }

    private void SetGameObject() {
        if(GameManager.Instance.CheckTaskCompletion(workID)) {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
    private int GetDayCount() {
        return GameManager.Instance.DayCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            OnInteractionTrigger?.Invoke(playerInRange);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        OnInteractionTrigger?.Invoke(playerInRange);
    }

    private void PickUpFood() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(playerInRange) {
                //TODO: Invoke necessary scene in SceneLoader
                GameManager.Instance.MarkTodoComplete(workID);
                SetGameObject();
            }
        }
    }

}
