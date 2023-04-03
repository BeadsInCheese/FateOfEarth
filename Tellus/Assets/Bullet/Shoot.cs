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
    public GameObject gun;
    public AudioClip shotGunSound;
    public AudioClip ReloadSound;
    public GameObject HandL;
    public GameObject HandR;
    public Transform body;
    private int MaxClip = 2;
    private int clip = 2;
    private int ammo = 2;
    private int MaxAmmo = 50;
    // Start is called before the first frame update
    void Start()
    {
        ammo = MaxAmmo;
    }
    public int getClip()
    {
        return clip;
    }
    public int getAmmo()
    {
        return ammo;
    }
    IEnumerator Reload()
    {

        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.playSoundAtPoint(ReloadSound, gun.transform.position);
        yield return new WaitForSeconds(0.1f);
        int amount = ammo - (ammo - (MaxClip-clip));
        ammo -= amount;
        clip = amount+clip;
    }
    // Update is called once per frame
    Plane plane = new Plane(Vector3.up, 0);
    Vector3 worldPosition;
    void Update()
    {

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), Camera.main.nearClipPlane));
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        Direction = worldPosition - input.transform.position;
        var dir = Direction.normalized;
        dir = dir.normalized;
        var target= transform.position - 5 * new Vector3(dir.x, 0, dir.z);
        gun.transform.LookAt(target); ;
        gun.transform.position = transform.position + new Vector3(dir.x, 2, dir.z)*0.6f;

        HandL.transform.position= gun.transform.position;
        HandR.transform.position = gun.transform.position;

        //hand.Rotate(new Vector3(0,0,1));
        //hand2.Rotate(new Vector3(0, 0, 1));
        if (input.actions["Shoot"].triggered && clip>0){
            clip--;
            if (clip <= 0)
            {
                StartCoroutine("Reload");
            }
            AudioManager.instance.playSoundAtPoint(shotGunSound,gun.transform.position);
            bullet=Instantiate(p_bullet).GetComponent<Bullet>();


            bullet.Dir=new Vector3(dir.x,0,dir.z);
            var bulletpos= transform.position + new Vector3(dir.x, 0, dir.z).normalized;
            bulletpos.y = gun.transform.position.y;
            bullet.transform.position = bulletpos;
            //Debug.Log("shoot "+Direction);
        }

    }
}
