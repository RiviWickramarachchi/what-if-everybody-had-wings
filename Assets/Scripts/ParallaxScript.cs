using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private GameObject cam;
    private Vector3 lastCamPosition;
    //private float textureUnitSizeX;
    //private float textureUnitSizeY;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        lastCamPosition = cam.transform.position;
        //Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //Texture2D texture = sprite.texture;
        //textureUnitSizeX = texture.width/sprite.pixelsPerUnit;
        //textureUnitSizeY = texture.height/sprite.pixelsPerUnit;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = cam.transform.position - lastCamPosition;
        transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y) ;
        lastCamPosition = cam.transform.position;

        //for inifinite parallax for horizontal movement
        // if(Mathf.Abs(cam.transform.position.x - transform.position.x) >= textureUnitSizeX) {
        //     float offsetPositionX = (cam.transform.position.x - transform.position.x) % textureUnitSizeX;
        //     transform.position = new Vector3(cam.transform.position.x + offsetPositionX, transform.position.y);
        // }

        //For infinite Parallax for vertical movement
        // if(Mathf.Abs(cam.transform.position.y - transform.position.y) >= textureUnitSizeY) {
        //     float offsetPositionY= (cam.transform.position.y - transform.position.y) % textureUnitSizeY;
        //     transform.position = new Vector3(transform.position.x,cam.transform.position.y + offsetPositionY);
        // }
    }
}
