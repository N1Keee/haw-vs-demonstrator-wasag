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

    private int _i = 0;

    private void LoadInteraction(int i)
    {
        Debug.Log(_i);
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
        }
    }
    
    private void Start()
    {
        LoadInteraction(_i);
    }

    private void Update()
    {
        if (_i == 0)
        {
            interactionsDemo[_i].virtualCamera.GetComponent<DollyLogic>().Loop();
        }
        // + 
        if (interactionsDemo[_i].gameObject.Equals(geophone))
        {
            interactionsDemo[_i].gameObject.GetComponent<Elevator>().upwards = true;
            interactionsDemo[_i].gameObject.GetComponent<Elevator>().MoveAccordingly();
        }
        if (_i == 3)
        {
            interactionsDemo[_i].gameObject.GetComponent<Highlighter>().Highlight();
        }
        else
        {
            geophone.GetComponent<Elevator>().upwards = false;
            geophone.GetComponent<Elevator>().MoveAccordingly();
            debrisConcrete.GetComponent<Highlighter>().DeHighlight();
        }
    }
}
