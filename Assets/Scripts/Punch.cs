using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    GameManager gameManager;
    Vector3 defaultpos;
    Vector3 pressedPos = new Vector3(0,0,1.11f);
    Rigidbody rb;
    float zMax = 1f;
    [SerializeField] float punchForce = 5000;
    [SerializeField] KeyCode keyToActivate;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        defaultpos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.z > zMax || transform.localPosition.z < defaultpos.z)
        {
            rb.velocity *= 0;
            transform.localPosition = defaultpos;
            
        }

        if (Input.GetKeyDown(keyToActivate))
        {
            OnMouseDown();
        }
    }

    private void OnMouseDown()
    {
        rb.AddForce(Vector3.forward * punchForce, ForceMode.Impulse);
        gameManager.audioSource.PlayOneShot(gameManager.punch);
    }

    
}
