using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemonstrationsManager : MonoBehaviour
{
    [SerializeField] private List<Demonstration> demonstrations;
    [SerializeField] private TextMeshProUGUI instructionLabel;

    private bool _demonstrationsCompleted;
    
    private int _i = 0;

    public void LoadDemonstation()
    {
        if (_demonstrationsCompleted)
        {
            return;
        }
        SetCamera(demonstrations[_i].VirtualCamera);
        instructionLabel.text = demonstrations[_i].Instruction;
        demonstrations[_i].OnExecute?.Invoke();
    }

    public void IncrementIndex()
    {
        if (_i == demonstrations.Count-1)
        {
            return;
        }
        _i++;
    }

    public void DecrementIndex()
    {
        if (_i == 0)
        {
            return;
        }
        _i--;
    }
    
    /*
    [SerializeField] private GameObject geophone;
    [SerializeField] private GameObject debrisConcrete;
    [SerializeField] private GameObject amp;
    [SerializeField] private GameObject cable;
    [SerializeField] private GameObject intercom;
    [SerializeField] private GameObject headphone;
    [SerializeField] private GameObject display;
    [SerializeField] private Button previousBtn;
    [SerializeField] private Button nextBtn;

    [SerializeField] private CinemachineVirtualCamera blendVirtualCamera;
    */

    /*
    private void LoadInteraction(int i)
    {
        if (i == demonstrations.Count)
        {
            // do nothing
        }
        if (i < 0)
        {
            // do nothing
        }
        else
        {
            foreach (Demonstration demonstration in demonstrations)
            {
                demonstration.virtualCamera.Priority = 0;
            }
            demonstrations[i].virtualCamera.Priority = 1;
            instructionText.SetText(demonstrations[i].instruction);
        }
    }
    
    public void NextInteraction()
    {
        if (_i + 1 == demonstrations.Count)
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
    */
    private void Start()
    {
        LoadDemonstation();
    }

    private void SetCamera(CinemachineVirtualCamera virtualCamera)
    {
        foreach (var demonstration in demonstrations)
        {
            demonstration.VirtualCamera.Priority = 0;
        }
        virtualCamera.Priority = 1;
    }

    private void Update()
    {
        /*
        switch (_i)
        {
            case 0:
                previousBtn.gameObject.SetActive(false);
                amp.GetComponent<AmpControler>().SelectChannel(0);
                demonstrations[_i].virtualCamera.GetComponent<DollyLogic>().Loop();
                geophone.GetComponent<Elevator>().upwards = false;
                break;
            case 1:
                previousBtn.gameObject.SetActive(true);
                geophone.GetComponent<Replacer>().PlaceAtEquipment();
                geophone.GetComponent<Elevator>().upwards = false;
                break;
            case 2:
                geophone.GetComponent<Elevator>().upwards = true;
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                break;
            case 3:
                cable.GetComponent<Cable>().HideLines();
                debrisConcrete.GetComponent<Highlighter>().Highlight();
                geophone.GetComponent<Replacer>().PlaceAtEquipment();
                break;
            case 4:
                geophone.GetComponent<Elevator>().upwards = false;
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                geophone.GetComponent<Replacer>().PlaceOnPile();
                cable.GetComponent<Cable>().DrawLines();
                break;
            case 5:
                amp.GetComponent<AmpControler>().TurnOff();
                display.GetComponent<DisplayTexture>().ChangeTexture(0);
                headphone.GetComponent<HeadphoneAnimation>().Reposition();
                break;
            case 6:
                amp.GetComponent<AmpControler>().TurnOn();
                headphone.GetComponent<HeadphoneAnimation>().UnequipHp();
                break;
            case 7:
                amp.GetComponent<AmpControler>().SelectChannel(0);
                amp.GetComponent<AmpControler>().TurnOn();
                headphone.GetComponent<HeadphoneAnimation>().ShowHide(true);
                headphone.GetComponent<HeadphoneAnimation>().EquipHp();
                break;
            case 8:
                headphone.GetComponent<HeadphoneAnimation>().ShowHide(false);
                amp.GetComponent<AmpControler>().TurnOn();
                amp.GetComponent<AmpControler>().SelectChannel(6);
                amp.GetComponent<AmpControler>().SwitchFilter(false);
                amp.GetComponent<AmpControler>().TurnHighPassOff();
                amp.GetComponent<AmpControler>().TurnLowPassOff();
                break;
            case 9:
                nextBtn.gameObject.SetActive(true);
                amp.GetComponent<AmpControler>().SwitchFilter(true);
                amp.GetComponent<AmpControler>().TurnHighPassOn();
                amp.GetComponent<AmpControler>().TurnLowPassOn();
                amp.GetComponent<AmpControler>().SelectChannel(1);
                intercom.GetComponent<IntercomMover>().ReDeploy();
                blendVirtualCamera.Priority = 0;
                break;
            case 10:
                nextBtn.gameObject.SetActive(false);
                intercom.GetComponent<IntercomMover>().Deploy();
                break;
            default:
                amp.GetComponent<AmpControler>().SelectChannel(0);
                geophone.GetComponent<Elevator>().upwards = false;
                debrisConcrete.GetComponent<Highlighter>().DeHighlight();
                amp.GetComponent<AmpControler>().SelectChannel(0);
                break;
            
        }
        */
    }
}
