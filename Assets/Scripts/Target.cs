using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;

    public float lifeTime = 2f;
    public int points;
    public GameObject explosioinParticle;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Destroy(gameObject, lifeTime); // el objeto se destruirá en 2 segundos
    }
    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        { 
                if (gameObject.CompareTag("Bad"))
                {
                    gameManager.isGameOver = true;
                }
                else if (gameObject.CompareTag("Good"))
                {
                    gameManager.UpdateScore(points);
                }
            Instantiate(explosioinParticle, transform.position, explosioinParticle.transform.rotation);
            Destroy(gameObject); // cuendo pulses el boton del raton se destruirá el objeto clickado
        }
        
    }
    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.
        Remove(transform.position);
    }
}
