using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class input_test : MonoBehaviour
{

    public GameObject wheel;

    public Button[] wheelButtons;

    public Text horizontalText;
    public Text verticalText;
    public Text angleText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DialogWheel"))
        {
            wheel.SetActive(!wheel.activeSelf);
        }

        float horizontal = Input.GetAxis("HorizontalJoy");
        float vertical = Input.GetAxis("VerticalJoy");

        if(horizontal != 0 || vertical != 0)
        {
            float angle = Mathf.Atan2(Input.GetAxis("HorizontalJoy"), Input.GetAxis("VerticalJoy")) * Mathf.Rad2Deg;
            if (angle>-22.5f && angle < 22.5f)
            {
                wheelButtons[0].Select();
            }
            if (angle > 22.5f && angle < 67.5f)
            {
                wheelButtons[1].Select();
            }
            if (angle > 67.5f && angle < 112.5f)
            {
                wheelButtons[2].Select();
            }
            if (angle > 112.5f && angle < 157.5f)
            {
                wheelButtons[3].Select();
            }
            if (angle > 157.5f || angle < -157.5f)
            {
                wheelButtons[4].Select();
            }
            if (angle > -157.5f && angle < -112.5f)
            {
                wheelButtons[5].Select();
            }
            if (angle > -112.5f && angle < -67.5f)
            {
                wheelButtons[6].Select();
            }
            if (angle > -67.5f && angle < -22.5f)
            {
                wheelButtons[7].Select();
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }


        horizontalText.text = "Horizontal : " + Input.GetAxis("HorizontalJoy");
        verticalText.text = "Vertical : " + Input.GetAxis("VerticalJoy");
        angleText.text = "Angle : " + Mathf.Atan2(Input.GetAxis("HorizontalJoy"), Input.GetAxis("VerticalJoy")) * Mathf.Rad2Deg;


    }
}
