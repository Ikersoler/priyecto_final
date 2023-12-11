using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class movimientoPj : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float boundaryX = 5f; 
    public float boundaryZ = 5f;

    public int score = 0;
    public int lives = 3;
    public bool isGameOver = false;


    

    


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

    


    private void OnTriggerEnter (Collider other) 
    {
        if (other.gameObject.CompareTag ("Good Coin")) 
        {
            Destroy (other.gameObject);
            score += 5; 
            Debug.Log("Good Coin collected! Score: " + score);

            if (score >= 50)
            {
                Debug.Log("You won!");
                isGameOver = true;
               
            }
        }

        if (other.gameObject.CompareTag("Bad Coin"))
        {
            Destroy(other.gameObject);
            lives -= 1; 
            Debug.Log("Bad Coin collected! Lives: " + lives);

            if (lives <= 0)
            {
                Debug.Log("Game Over!");
                isGameOver = true;
                
            }
        }

        
    }

    



}
