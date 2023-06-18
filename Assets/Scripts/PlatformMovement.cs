using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //serializeFields
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;
    [SerializeField] private float speed = 0.5f;

    //private variables
    private float currentPos, targetPos;
    private Vector3 startingPos, endingPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = 1;
        startingPos = position1;
        endingPos = position2;
        transform.position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform() {
        if(transform.position == position2) {
            targetPos = 0;
        }
        if(transform.position == position1) {
            targetPos = 1;
        }
        currentPos = Mathf.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(startingPos, endingPos, curve.Evaluate(currentPos));
    }
}
