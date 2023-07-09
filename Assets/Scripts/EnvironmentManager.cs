using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnvironmentManager : MonoBehaviour
{
    //serialized fields
    [SerializeField] private GameObject trafficBeforeWings;
    [SerializeField] private GameObject trafficAfterWings;
    [SerializeField] private GameObject workBuildingBeforeWings;
    [SerializeField] private GameObject workBuildingAfterWings;
    [SerializeField] private GameObject bridgeBeforeWings;
    [SerializeField] private GameObject bridgeAfterWings;
    [SerializeField] private TMP_Text dayUI;

    //private fields
    private int day;

    void Start()
    {
        //add the background changes, sound changes here as well
        day = GameManager.Instance.DayCount;
        SetTrafficGameObjects();
        SetBridgeGameObjects();
        SetWorkBuildingGameObjects();
        dayUI.text = day.ToString("0");
    }

    private void SetTrafficGameObjects() {
        //the logic should be changed according to the game flow
        switch(day) {
            case 1:
                trafficBeforeWings.gameObject.SetActive(true);
                trafficAfterWings.gameObject.SetActive(false);
                break;
            case 2:
                trafficBeforeWings.gameObject.SetActive(false);
                trafficAfterWings.gameObject.SetActive(true);
                break;
            case 3:
                trafficBeforeWings.gameObject.SetActive(false);
                trafficAfterWings.gameObject.SetActive(true);
                break;
        }
    }

    private void SetWorkBuildingGameObjects() {
        switch(day) {
            case 1:
                workBuildingBeforeWings.gameObject.SetActive(true);
                workBuildingAfterWings.gameObject.SetActive(false);
                break;
            case 2:
                workBuildingBeforeWings.gameObject.SetActive(true);
                workBuildingAfterWings.gameObject.SetActive(false);
                break;
            case 3:
                workBuildingBeforeWings.gameObject.SetActive(false);
                workBuildingAfterWings.gameObject.SetActive(true);
                break;
        }
    }

    private void SetBridgeGameObjects() {
        switch(day) {
            case 1:
                bridgeBeforeWings.gameObject.SetActive(true);
                bridgeAfterWings.gameObject.SetActive(false);
                break;
            case 2:
                bridgeBeforeWings.gameObject.SetActive(false);
                bridgeAfterWings.gameObject.SetActive(true);
                break;
            case 3:
                bridgeBeforeWings.gameObject.SetActive(false);
                bridgeAfterWings.gameObject.SetActive(true);
                break;
        }
    }
}
