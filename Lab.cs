using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
    // public float x;
    public float rotation;
    public float force;
    public float sinResultof30;
    public float cosResultof30;
    public Rigidbody2D rgb;


    // Start is called before the first frame update
    void Start()
    {
        sinResultof30 = 1 / 2 * 0.1f;
        cosResultof30 = (Mathf.Sqrt(3f) / 2) * 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float y = force * Mathf.Sin(rotation * Mathf.Rad2Deg);
        float x = force * Mathf.Cos(rotation * Mathf.Rad2Deg);

        if (Input.GetKey(KeyCode.Space))
            rgb.AddForce(new Vector2(x, y));
    }
}
