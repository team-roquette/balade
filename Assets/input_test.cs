using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class input_test : MonoBehaviour
{

    public GameObject wheel;
    public GameObject tab;

    public Button[] wheelButtons;
    public Button[] tabButtons;

    public Text horizontalText;
    public Text verticalText;
    public Text angleText;
    public Image dialogImage;

    // Start is called before the first frame update
    void Start()
    {
        tab.SetActive(false);
        wheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DialogWheel"))
        {
            tab.SetActive(false);
            wheel.SetActive(!wheel.activeSelf);
        }

        if (Input.GetButtonDown("DialogTab"))
        {
            wheel.SetActive(false);
            tab.SetActive(!tab.activeSelf);
        }

        UpdateDialogWheel();

        UpdateDialogTab();


    }

    private void UpdateDialogWheel()
    {

        float horizontal = Input.GetAxis("HorizontalJoy");
        float vertical = Input.GetAxis("VerticalJoy");

        if (horizontal != 0 || vertical != 0)
        {
            float angle = Mathf.Atan2(Input.GetAxis("HorizontalJoy"), Input.GetAxis("VerticalJoy")) * Mathf.Rad2Deg;
            if (angle > -22.5f && angle < 22.5f)
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

    private void UpdateDialogTab()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            tabButtons[0].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            tabButtons[1].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            tabButtons[2].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            tabButtons[3].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            tabButtons[4].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            tabButtons[5].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            tabButtons[6].Select();
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            tabButtons[7].Select();
        }
    }

    public void OnWheelButtonClicked()
    {

         Debug.Log("current selected : " + EventSystem.current.currentSelectedGameObject);

        dialogImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;


        wheel.SetActive(false);

    }

}
