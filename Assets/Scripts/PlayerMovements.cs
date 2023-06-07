using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    //Serialized Fields
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
    }
    private void Flip() {
        if((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0)) {
            isFacingRight = !isFacingRight;
            Vector3 newLScale = transform.localScale;
            newLScale.x = newLScale.x * -1f;
            transform.localScale = newLScale;
        }
    }
}
