using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D BallRgb;

    [SerializeField]
    private float ImpulseForce = 1000f;

    [SerializeField]
    private Rotation ArrowRot;

    // Start is called before the first frame updateb
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Kick();
    }

    void Kick()
    {
        float x = ImpulseForce * ArrowRot.FilledArrowImg.fillAmount * Mathf.Cos(ArrowRot.ZRotation * Mathf.Deg2Rad);
        float y = ImpulseForce * ArrowRot.FilledArrowImg.fillAmount * Mathf.Sin(ArrowRot.ZRotation * Mathf.Deg2Rad);

        if (ArrowRot.CanKick)
        {
            BallRgb.AddForce(new Vector2(x, y) * Time.deltaTime, ForceMode2D.Impulse);
            ArrowRot.CanKick = false;
        }
    }
}
