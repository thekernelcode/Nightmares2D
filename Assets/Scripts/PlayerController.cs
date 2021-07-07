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

    public GameObject bulletPrefab;

    public float bulletSpeed;

    private float lastFire;

    public float fireDelay;

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

        float shootHorizontal = Input.GetAxis("AttackHorizontal");
        float shootVertical = Input.GetAxis("AttackVertical");

        if ((shootHorizontal != 0 || shootVertical != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHorizontal, shootVertical);
            lastFire = Time.time;
        }




        myRigidBody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        collectedText.text = "Items Collected: " + collectedAmount;
        // Should probably remove updating text evert frame here --> maybe move it into the collection controller, or possibly a stand alone UI Controller
                        
    }

    void Shoot(float x, float y)
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 30f);
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z),
                            (rotation)) as GameObject;

        //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(RotateObject(bullet));
        bullet.transform.SetParent(transform);

        //TODO - Make sure bullet follows player.  need it transform.position to be equal to the parent.  //HACK Had to remove RB2D to achieve this.

    }

    public IEnumerator RotateObject(GameObject go)
    {
        float timer = 0f;
        while(timer <= go.GetComponent<BulletController>().lifeTime)
        {
            go.transform.Rotate(new Vector3(0, 0, 01) * bulletSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
            //TODO Make sure object destroys itself before coroutine ends
        }
    }
}
