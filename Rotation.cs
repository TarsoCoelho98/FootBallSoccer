using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private Transform ArrowStartPosition;

    [SerializeField]
    private Image IdleArrowImg;

    public Image FilledArrowImg;

    public float ZRotation;

    [SerializeField]
    private bool CanRotate = false;
    public bool CanKick = false;

    private const float SensibilityArrowRotation = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetBallStartPosition();
        SetArrowStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        RotateInput();
        RotateArrow();
        LimitRotation();
        KickForceControl();
    }

    void SetArrowStartPosition()
    {
        IdleArrowImg.rectTransform.position = ArrowStartPosition.position;
    }

    void SetBallStartPosition()
    {
        this.gameObject.transform.position = ArrowStartPosition.position;
    }

    void RotateArrow()
    {
        IdleArrowImg.rectTransform.eulerAngles = new Vector3(0, 0, ZRotation);
    }

    void RotateInput()
    {
        if (CanRotate)
        {
            float yMouse = Input.GetAxis("Mouse Y");

            if (ZRotation > 0)
            {
                if (yMouse < 0)
                    ZRotation -= SensibilityArrowRotation;
            }

            if (ZRotation < 90)
            {
                if (yMouse > 0)
                    ZRotation += SensibilityArrowRotation;
            }
        }
    }

    void LimitRotation()
    {
        if (ZRotation > 90)
            ZRotation = 90;
        else if (ZRotation < 0)
            ZRotation = 0;
    }

    void OnMouseDown()
    {
        CanRotate = true;
        CanKick = false;
    }

    void OnMouseUp()
    {
        CanRotate = false;
        CanKick = true;
    }

    void KickForceControl()
    {
        float xMouse = Input.GetAxis("Mouse X");

        if (CanRotate)
        {
            if (xMouse < 0)
                FilledArrowImg.fillAmount += 1 * Time.deltaTime;
            else if (xMouse > 0)
                FilledArrowImg.fillAmount -= 1 * Time.deltaTime;
        }
    }
}
