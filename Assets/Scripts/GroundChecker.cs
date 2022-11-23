using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    PrayerMovement _player;

    void Awake()
    {
        _player = GameObject.Find("knight").GetComponent<PrayerMovement>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        _player.isGrounded = true;
        _player.anim.SetBool("Saltar", false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _player.isGrounded = false;
        _player.anim.SetBool("Saltar", true);
    }
}