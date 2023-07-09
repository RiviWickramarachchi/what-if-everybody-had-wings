using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //private variables
    private float horizontal;
    private bool isFacingRight = true;
    private Vector3 respawnPoint;

    //playerPositions
    private float playerXPos;
    private float playerYPos;
    private float playerZPos;


    //Serialized Fields
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject interactImg;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 5f;

    //States
    public PlayerStates currentState;
	public enum PlayerStates
    {
		IDLE,
		WALK
    }

    PlayerStates CurrentState
    {
		set
        {
			currentState = value;

			switch(currentState)
            {
				case PlayerStates.IDLE:
					anim.Play("Idle");
                    break;
				case PlayerStates.WALK:
					anim.Play("Run");
					break;
			}
        }
    }

    void OnEnable() {
        CollectFood.OnInteractionTrigger += DisplayInteract;
        SceneTrigger.OnInteractionTrigger += DisplayInteract;
        SceneLoader.OnSceneChange += SavePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!GameManager.Instance.IsInMiniGame) {
            LoadPosition();
            respawnPoint = new Vector3(15.91f, -2.6947f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Flip();
    }
    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private void Movement() {
         horizontal = Input.GetAxisRaw("Horizontal");
         if(horizontal != 0) {
            CurrentState = PlayerStates.WALK;
         }
         else {
            CurrentState = PlayerStates.IDLE;
         }

         if(Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
         }

         if(Input.GetKeyDown(KeyCode.Return)) {
            RespawnPlayer();
         }
    }

    public bool IsGrounded() {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip() {
        if((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0)) {
            isFacingRight = !isFacingRight;
            Vector3 newLScale = transform.localScale;
            newLScale.x = newLScale.x * -1f;
            transform.localScale = newLScale;
        }
    }

    private void RespawnPlayer() {
        playerTransform.position = respawnPoint;
    }

    private void LoadPosition() {
        Debug.Log("lOADING");
        playerXPos = PlayerPrefs.GetFloat("x");
        playerYPos = PlayerPrefs.GetFloat("y");
        playerZPos = PlayerPrefs.GetFloat("z");
        Vector3 playerPosition = new Vector3(playerXPos,playerYPos,playerZPos);
        playerTransform.position = playerPosition;
    }

    private void SavePosition() {
        Debug.Log("Saving");
        PlayerPrefs.SetFloat("x",playerTransform.position.x);
        PlayerPrefs.SetFloat("y",playerTransform.position.y);
        PlayerPrefs.SetFloat("z",playerTransform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Water") {
            //TODO: Respawn the player left of the river
            RespawnPlayer();
        }
    }

    public void DisplayInteract(bool interactionStatus) {
        interactImg.SetActive(interactionStatus);
    }

    void OnDisable() {
        CollectFood.OnInteractionTrigger -= DisplayInteract;
        SceneTrigger.OnInteractionTrigger -= DisplayInteract;
        SceneLoader.OnSceneChange -= SavePosition;
    }
}
