using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, 
    enemy,
    button
}

public class Doors : Interactable 
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    

    private void Start()
    {
        doorSprite = GetCompnent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange)
            {
                //Does the player have a key?
                //If so, then call the open method
            }
        }
    }

    public void Open()
    {
        //Turn off the door's sprite renderer
        //set open to true
        //turn off the door's box collider
        
    }

   
    public void Close()
    {
        
    }
}
