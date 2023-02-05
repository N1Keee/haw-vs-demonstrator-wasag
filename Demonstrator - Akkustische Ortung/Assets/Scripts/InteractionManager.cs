using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private List<Interaction> interactions;

    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    
    [SerializeField] private TextMeshProUGUI errorCountLabel = null;
    [SerializeField] private TextMeshProUGUI helpCountLabel = null;
    
    [SerializeField] private TextMeshProUGUI totalErrorCountLabel;
    [SerializeField] private TextMeshProUGUI totalHelpCountLabel;

    [SerializeField] private LayerMask layerMask;
    private Camera _cam;

    [SerializeField] private GameObject[] geophones;
    
    [SerializeField] private UnityEvent OnCompleted;
    
    public bool InteractionsCompleted => _interactionIndex >= interactions.Count;
    private int _interactionIndex;
    private Interaction _currentInteraction;
        
    private int _errorCount;
    private int _helpCount;
        
    private void Awake() => _cam = Camera.main;
    
    void Start()
    {
        helpLabel.SetText("");
        errorLabel.SetText("");
        helpCountLabel.SetText("Hilfen: " + _helpCount);
        errorCountLabel.SetText("Fehler: " + _errorCount);

        _currentInteraction = interactions[_interactionIndex];
        instructionLabel.SetText(_currentInteraction.Instruction);
        
        GenerateRandomGeoInteraction();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {
                CheckInteractionOrder(hit.transform.gameObject);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.H) && !InteractionsCompleted)
        {
            if (!_currentInteraction.HelpCounted)
            {
                _helpCount++;
                _currentInteraction.HelpCounted = true;
            }

            helpCountLabel.SetText("Hilfen: " + _helpCount);
                
            StopHelpAndErrorDisplay();
            StartCoroutine(DisplayForDuration(helpLabel, _currentInteraction.Help, 4));
        }
    }

    private void CheckInteractionOrder(GameObject selectedGameObject)
    {
        if (InteractionsCompleted)
            return;
        
        if (!selectedGameObject)
            return;

        if (selectedGameObject.Equals(_currentInteraction.GameObject))
        {
            StopHelpAndErrorDisplay();
            _currentInteraction.OnExecution.Invoke();
            _interactionIndex++;

            if (InteractionsCompleted)
            {
                return;
            }

            _currentInteraction = interactions[_interactionIndex];
            instructionLabel.SetText(_currentInteraction.Instruction);
        }
        else
        {
            StopHelpAndErrorDisplay();
            StartCoroutine(DisplayForDuration(errorLabel, _currentInteraction.Error, 4));
            _errorCount++;
            errorCountLabel.SetText("Fehler:    " + _errorCount);
        }
    }
    
    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        label.text = msg;
        yield return new WaitForSeconds(duration);
        label.text = "";
    }
        
    private void StopHelpAndErrorDisplay()
    {
        StopAllCoroutines();
        helpLabel.SetText("");
        errorLabel.SetText("");
    }
    
    private void GenerateRandomGeoInteraction()
    {
        string instruction = "Finde den Bodenschallaufnehmer bei dem der Pegel am höchsten war.";
        string error = "Das war nicht der Richtige Bodenschallaufnehmer...";
        string help = "Der Wahlschalter zeigt den Pegel von einzelnen Bodenschallaufnehmern an. Überprüfe diese nochmal.";
        Random rnd = new Random();
        int i = rnd.Next(6);
        Interaction randomInteraction = new Interaction(geophones[i], instruction, error, help);
        interactions.Add(randomInteraction);
    }
}
