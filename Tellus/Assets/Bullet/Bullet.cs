using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Dir;
    public float speed;
    public AudioClip hitSound;
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
        body.MovePosition(transform.position+Dir*speed);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        AudioManager.instance.playSoundAtPoint(hitSound, this.transform.position);
        Destroy(this.gameObject);
    }
}
