using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindText : MonoBehaviour
{
    public string Name;
    public GameObject Input;
    public GameObject Display;

    public void Find()
    {
        Name = Input.GetComponent<Text>().text;

        switch(Name)
        {
            case "Taylor":
                Display.GetComponent<Text>().text = "[ <color=green>Taylor</color> ] is found.";
                break;

            case "Crafter":
                Display.GetComponent<Text>().text = "[ <color=green>Crafter</color> ] is found.";
                break;

            case "Gibson":
                Display.GetComponent<Text>().text = "[ <color=green>Gibson</color> ] is found.";
                break;

            case "Paramount":
                Display.GetComponent<Text>().text = "[ <color=green>Paramount</color> ] is found.";
                break;

            case "Yamaha":
                Display.GetComponent<Text>().text = "[ <color=green>Yamaha</color> ] is found.";
                break;

            default:
                Display.GetComponent<Text>().text = "[ <color=Red>"+Name+"</color> ] is not found.";
                break;
        }
        
    }
}
