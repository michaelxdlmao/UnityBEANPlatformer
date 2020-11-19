﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }

}
