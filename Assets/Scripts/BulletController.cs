using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().Death();
            //TODO If we want to destroy the swiping hand at this point.
            // Destroy(gameObject);
        }
    }
}
