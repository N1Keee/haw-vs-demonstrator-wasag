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

    [SerializeField] private float completionCallbackDelay;

    [SerializeField] private LayerMask layerMask;
    private Camera _cam;

    [SerializeField] private GameObject[] geophones;
    
    [SerializeField] private UnityEvent OnCompleted;
    
    public bool InteractionsCompleted => _interactionIndex >= interactions.Count;
    private int _interactionIndex;
    private Interaction _currentInteraction;
        
    private int _errorCount;
    private int _helpCount;
    
    // end screen...
    private int _geoIndex;
        
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
            _currentInteraction.OnExecution?.Invoke();
            _interactionIndex++;

            if (InteractionsCompleted)
            {
                StartCoroutine(DelayedTrainingCompletionCallback());
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
    
    private IEnumerator DelayedTrainingCompletionCallback()
    {
        totalErrorCountLabel.SetText("Fehler: " + _errorCount);
        totalHelpCountLabel.SetText("Hilfen: " + _helpCount);
        yield return new WaitForSeconds(completionCallbackDelay);
        OnCompleted?.Invoke();
    }
    
    private void GenerateRandomGeoInteraction()
    {
        string instruction = "Finden Sie den Bodenschallaufnehmer bei dem der Pegel am h??chsten ist.";
        string error = "Das ist nicht der richtige Bodenschallaufnehmer.";
        string help = "Der Wahlschalter zeigt den Pegel von einzelnen Bodenschallaufnehmern an. Z??hlen Sie ausgehend vom Verst??rker an der Geophonkette entlang.";
        Random rnd = new Random();
        int i = rnd.Next(6);
        _geoIndex = i;
        Interaction randomInteraction = new Interaction(geophones[i], instruction, error, help);
        interactions.Add(randomInteraction);
        
    }

    public Vector3 GetPos()
    {
        return geophones[_geoIndex].transform.position;
    }
    
    public GameObject GetGeophone()
    { 
        return geophones[_geoIndex];
    }
}
