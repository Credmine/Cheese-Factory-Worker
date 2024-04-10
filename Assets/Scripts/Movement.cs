using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    private GameManager gameManager;
    float removalTime = 3f;
    BoxCollider bCollider;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bCollider = GetComponent<BoxCollider>();

        // if game object spawns at the right side, it will move to the left
        if ( transform.position.x > 0)
        {
            speed = speed * -1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Machine"))
        {
            if (gameObject.CompareTag("Cheese"))
            {
                gameManager.cheeseCounter++;
                gameManager.audioSource.PlayOneShot(gameManager.cheeseEntry);
            }
            else if (gameObject.CompareTag("Mouse"))
            {
                gameManager.gameOver = true;
                gameManager.audioSource.PlayOneShot(gameManager.mouseEntry);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Puncher"))
        {
            //speed = 0;

            StartCoroutine(Remove());
            bCollider.enabled = false;
        }

        if (collision.gameObject.CompareTag("Puncher") && gameObject.CompareTag("Cheese"))
        {
            gameManager.wasteCounter++;
        }

        if (collision.gameObject.CompareTag("Puncher") && gameObject.CompareTag("Mouse"))
        {
            gameManager.mouseCounter++;
        }
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(removalTime);
        Destroy(gameObject);
    }
}
