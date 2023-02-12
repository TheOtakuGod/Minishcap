using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToPosition : MonoBehaviour
{
    [SerializeField] private Vector3 homePosition;
    
    public void ResetPosition()
    {
        transform.position = homePosition;
    }
}
