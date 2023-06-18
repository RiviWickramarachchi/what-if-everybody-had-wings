using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneTrigger : MonoBehaviour
{
    private bool playerInRange;
    public static event Action<string> OnSceneTriggered;
    public static event Action<bool> OnInteractionTrigger;
    void Awake() {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    private void ChangeScene() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Debug.Log(playerInRange);
            if(playerInRange) {
                //TODO: Invoke necessary scene in SceneLoader
                OnSceneTriggered?.Invoke(this.gameObject.tag.ToString());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            OnInteractionTrigger?.Invoke(playerInRange);

        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         playerInRange = true;

    //     }
    // }
     private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        OnInteractionTrigger?.Invoke(playerInRange);
    }
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     playerInRange = false;
    // }
}
