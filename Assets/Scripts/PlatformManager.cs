using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //serializedFields
    [SerializeField] private GameObject stage2Platforms;
    [SerializeField] private GameObject stage3Platforms;
    [SerializeField] private GameObject foodObj;

    //private fields
    private int day;
    void Start()
    {
        day = GameManager.Instance.DayCount;

        switch(day) {
            case 1:
                stage2Platforms.gameObject.SetActive(false);
                stage3Platforms.gameObject.SetActive(false);
                break;
            case 2:
                stage2Platforms.gameObject.SetActive(true);
                stage3Platforms.gameObject.SetActive(false);
                break;
            case 3:
                stage2Platforms.gameObject.SetActive(false);
                stage3Platforms.gameObject.SetActive(true);
                break;
        }
    }
}
