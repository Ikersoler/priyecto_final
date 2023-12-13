using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
   


    
    public GameObject GoodCoinParticles;
    public GameObject badCoinParticles;



    public ParticleSystem gameOverParticles;
    public ParticleSystem victoryParticles;

    [SerializeField] private AudioSource Sound;
    [SerializeField] private AudioClip SoundBadCoin;
    [SerializeField] private AudioClip SoundGoodCoin;
    [SerializeField] private Animator BadCoinCollected;






    void Update()
    {
        if (isGameOver == false)
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

    void GameOver()
    {
       
            Debug.Log("Game Over!");
            isGameOver = true;
            Instantiate(gameOverParticles, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        
        
    }

    void TuGanas ()
    {
        
       
            Debug.Log("You won!");
            isGameOver = true;
            Instantiate(victoryParticles, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        

        

    }





    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.CompareTag("Good Coin"))
        {
            Destroy(other.gameObject);
            score += 5;
            Debug.Log("Good Coin collected! Score: " + score);
            Sound.PlayOneShot(SoundGoodCoin);

            if (GoodCoinParticles != null)
            {
                Instantiate(GoodCoinParticles, transform.position, Quaternion.identity);
                //GoodCoinParticles.transform.position = other.transform.position;
                //GoodCoinParticles.Play();
            }

            if (score >= 50)
            {

                Invoke("TuGanas", 0);
            }
        }

        if (other.gameObject.CompareTag("Bad Coin"))
        {
            Destroy(other.gameObject);
            lives -= 1;
            Debug.Log("Bad Coin collected! Lives: " + lives);
            Sound.PlayOneShot(SoundBadCoin);
            BadCoinCollected.SetTrigger("collectBad");
            // if (badCoinParticles != null)
            //{

            Instantiate(badCoinParticles, transform.position, Quaternion.identity);
                //badCoinParticles.transform.position = other.transform.position;
                //badCoinParticles.Play();
            //}

            if (lives <= 0)
            {

                


                    Invoke("GameOver", 0);



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
