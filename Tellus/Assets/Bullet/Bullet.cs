using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Dir;
    public float speed;
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody>();
        Destroy(gameObject,20);
    }

    // Update is called once per frame
    void Update()
    {
        body.MovePosition(transform.position+Dir*speed*Time.deltaTime);
    }
}
