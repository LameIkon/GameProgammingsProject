using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputChanger : MonoBehaviour
{
    private InputsManager inputs;

    private TextMeshProUGUI tmp;

    private Button button;

    void Start() 
    {
        //inputs = GameObject.FindWithTag("Player2").GetComponent<Inputs>();
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();


        SetText(inputs.Jump().ToString());

    }


    private void SetText(string text) 
    {
        tmp.text = text;    
    }

    public void ChangeKeyInput() 
    {

        SetText("Awaiting Input");

        while (true)
        {

            Debug.Log(Input.anyKeyDown);

            if (Input.anyKeyDown)
            {
                string input = Input.inputString;


                inputs.SetJump(KeyCode.N);
                SetText(inputs.Jump().ToString());
                break;
            }


        }
    
    }

    private void Update()
    {

        //Debug.Log(Input.inputString);
    }

    


}
