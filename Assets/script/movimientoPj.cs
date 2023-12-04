using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPj : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float boundaryX = 5f; 
    public float boundaryZ = 5f; 

    
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 

        
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime; 
        Vector3 newPos = transform.position + movement;

        
        newPos.x = Mathf.Clamp(newPos.x, -boundaryX, boundaryX);
        newPos.z = Mathf.Clamp(newPos.z, -boundaryZ, boundaryZ); 

        
        transform.position = newPos;
    }
}
