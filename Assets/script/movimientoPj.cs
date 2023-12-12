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



    // Agrega estas variables públicas para los sistemas de partículas
    public ParticleSystem GoodCoinParticles;
    public ParticleSystem badCoinParticles;



    public ParticleSystem gameOverParticles;
    public ParticleSystem victoryParticles;








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

    void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;
        Time.timeScale = 0;
        Instantiate(gameOverParticles);
    }

    void TuGanas ()
    {
        Debug.Log("You won!");
        isGameOver = true;
        Time.timeScale = 0;
        Instantiate(victoryParticles);

    }





    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.CompareTag("Good Coin"))
        {
            Destroy(other.gameObject);
            score += 5;
            Debug.Log("Good Coin collected! Score: " + score);

            // Activar el sistema de partículas para la moneda buena
            if (GoodCoinParticles != null)
            {
                GoodCoinParticles.transform.position = other.transform.position;
                GoodCoinParticles.Play();
            }

            if (score >= 50)
            {
                Invoke("TuGanas", 2);
            }
        }

        if (other.gameObject.CompareTag("Bad Coin"))
        {
            Destroy(other.gameObject);
            lives -= 1;
            Debug.Log("Bad Coin collected! Lives: " + lives);

            // Activar el sistema de partículas para la moneda mala
            if (badCoinParticles != null)
            {
                badCoinParticles.transform.position = other.transform.position;
                badCoinParticles.Play();
            }

            if (lives <= 0)
            {
             
           
               
                    Invoke("GameOver", 2);
                   
                
                
            }
        }
    }


    

    
       
    


























    
    

    

















    /*

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
                Time.timeScale = 0;

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
                Time.timeScale = 0;

            }
        }

        
    }
    */




}
