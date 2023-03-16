using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public PlayerInput input;
    Vector3 Direction;
    public GameObject p_bullet;
    Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    Plane plane = new Plane(Vector3.up, 0);
    Vector3 worldPosition;
    void Update()
    {
        float distance;
        if(input.actions["Shoot"].triggered){
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.ReadValue(),Mouse.current.position.y.ReadValue(),Camera.main.nearClipPlane));
                if (plane.Raycast(ray, out distance))
    {
         worldPosition = ray.GetPoint(distance);
    }
            Direction=worldPosition-input.transform.position;
            bullet=Instantiate(p_bullet).GetComponent<Bullet>();

            var dir=Direction.normalized;
            dir=dir.normalized;
            bullet.Dir=new Vector3(dir.x,0,dir.z);;
            bullet.transform.position=transform.position+new Vector3(dir.x,0,dir.z);
            Debug.Log("shoot "+Direction);
        }

    }
}
