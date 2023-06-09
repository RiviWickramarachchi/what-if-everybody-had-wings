using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoStateAssets : MonoBehaviour
{
    public static TodoStateAssets Instance { get; private set; }
    public Sprite taskNotDoneSprite;
    public Sprite taskDoneSprite;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        {
            Instance = this;
        }
    }
}
