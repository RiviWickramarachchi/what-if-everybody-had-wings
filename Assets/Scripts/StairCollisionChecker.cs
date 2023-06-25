using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairCollisionChecker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Collider2D stair;
    private bool isOnCollider;

    void Update() {
        if(isOnCollider) {
            stair.enabled = true;
        }
        else {
            stair.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("eNTERED");
        if(other.CompareTag("Player"))
        {
            isOnCollider = !isOnCollider;
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         isOnCollider = false;
    //     }
    // }
}
