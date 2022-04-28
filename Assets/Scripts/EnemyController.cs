using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private int contBulletP = 0;
    private int contBulletM = 0;
    private int contBulletG = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contBulletP == 5)
        {
            Destroy(this.gameObject);
        }
        if (contBulletM == 2)
        {
            Destroy(this.gameObject);
        }
        if (contBulletG == 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        

        if (tag == "Bullet")
        {
            Debug.Log((other.gameObject.transform.localScale.x).ToString());
            if ((other.gameObject.transform.localScale.x).ToString() == "0,05")
            {
                contBulletP++;
                Debug.Log(contBulletP);
            }

        }
    }

}
