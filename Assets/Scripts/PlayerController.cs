using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text collectedText;
    public static int collectedAmount = 0;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        myRigidBody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        collectedText.text = "Items Collected: " + collectedAmount;
        // Should probably remove updating text evert frame here --> maybe move it into the collection controller, or possibly a stand alone UI Controller
                        
    }
}
