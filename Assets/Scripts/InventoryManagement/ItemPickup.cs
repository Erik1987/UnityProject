﻿using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum PickupObject { COIN, HEART, MANA }

    public PickupObject currentObject;
    public int pickupQuantity;
    private GameObject playerObj = null;
    private Player player = null;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("pelaaja");

        player = playerObj.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (currentObject == PickupObject.COIN)
            {
                player.coins += pickupQuantity;
                Inventory.coins += pickupQuantity;
                FindObjectOfType<AudioManager>().Play("coinpickup");
            }
            else if (currentObject == PickupObject.HEART)
            {
                player.currentHealth += pickupQuantity;
                
            }
            else if (currentObject == PickupObject.MANA)
            {
                player.currentMana += pickupQuantity;
                FindObjectOfType<AudioManager>().Play("manapickup");
            }

            Destroy(gameObject);
        }
    }
}