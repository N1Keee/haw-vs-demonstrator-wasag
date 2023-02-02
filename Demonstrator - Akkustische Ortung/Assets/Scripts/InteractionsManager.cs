using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    [SerializeField] private List<Interaction> interactionsDemo;
    [SerializeField] private TextMeshProUGUI instructionText;
    //[SerializeField] private TextMeshProUGUI helpText;
    //[SerializeField] private TextMeshProUGUI errorText;

    //[SerializeField] private int errorCount;
    //[SerializeField] private int helpCount;

    [SerializeField] private GameObject geophone;
    [SerializeField] private GameObject debrisConcrete;
    [SerializeField] private GameObject amp;

    private int _i = 0;

    private void LoadInteraction(int i)
    {
        Debug.Log("Loading Interaction, _i: " + _i + " i: " + i);
        if (i == interactionsDemo.Count)
        {
            // do nothing
        }
        if (i < 0)
        {
            // do nothing
        }
        else
        {
            foreach (Interaction interaction in interactionsDemo)
            {
                interaction.virtualCamera.Priority = 0;
            }
            interactionsDemo[i].virtualCamera.Priority = 1;
            instructionText.SetText(interactionsDemo[i].instruction);
        }
    }
    
    public void NextInteraction()
    {
        if (_i + 1 == interactionsDemo.Count)
        {
            
        }
        else
        {
            LoadInteraction( _i + 1);
            _i += 1;
            Debug.Log("_i now: " + _i);
        }
    }

    public void PreviousInteraction()
    {
        if (_i - 1 < 0)
        {
            
        }
        else
        {
            LoadInteraction(_i - 1);
            _i -= 1;
            Debug.Log("_i now: " + _i);
        }
    }
    
    private void Start()
    {
        LoadInteraction(_i);
    }

    private void Update()
    {

        switch (_i)
        {
            case 0:
                amp.GetComponent<AmpControler>().SelectChannel(0);
                interactionsDemo[_i].virtualCamera.GetComponent<DollyLogic>().Loop();
                geophone.GetComponent<Elevator>().upwards = false;
                break;
            case 1:
                geophone.GetComponent<Replacer>().PlaceAtEquipment();
                geophone.GetComponent<Elevator>().upwards = false;
                break;
            case 2:
                geophone.GetComponent<Elevator>().upwards = true;
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                break;
            case 3:
                debrisConcrete.GetComponent<Highlighter>().Highlight();
                geophone.GetComponent<Replacer>().PlaceAtEquipment();
                break;
            case 4:
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                geophone.GetComponent<Elevator>().upwards = false;
                geophone.GetComponent<Replacer>().PlaceOnPile();
                break;
            case 5:
                amp.GetComponent<AmpControler>().TurnOff();
                break;
            case 6:
                amp.GetComponent<AmpControler>().TurnOn();
                break;
            case 7:
                amp.GetComponent<AmpControler>().SelectChannel(0);
                break;
            case 8:
                amp.GetComponent<AmpControler>().SelectChannel(3);
                break;
            default:
                amp.GetComponent<AmpControler>().SelectChannel(0);
                geophone.GetComponent<Elevator>().upwards = false;
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                amp.GetComponent<AmpControler>().SelectChannel(0);
                break;
        }
    }
}
