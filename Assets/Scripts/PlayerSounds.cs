using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource leftFoot;
    [SerializeField] private AudioSource rightFoot;
    private PlayerMovements movements;

    void Start() {
        movements = GetComponent<PlayerMovements>();
    }

    public void PlayLeftFootSound() {
        if(movements.IsGrounded()) {
            leftFoot.Play();
        }

    }
    public void PlayRightFootSound() {
        if(movements.IsGrounded()) {
            rightFoot.Play();
        }
    }

    // public void PlayJumpingSound() {

    // }
}
