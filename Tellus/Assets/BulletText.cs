using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletText : MonoBehaviour
{
    // Start is called before the first frame update
    public Shoot ammo;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ammo.getClip() + "   " + ammo.getAmmo();
    }
}
