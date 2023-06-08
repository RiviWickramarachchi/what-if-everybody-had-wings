using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneTrigger : MonoBehaviour
{
    private bool playerInRange;
    public static event Action<string> OnSceneTriggered;
    void Awake() {
        playerInRange = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
    }
}
