using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    
    [SerializeField] private UnityEvent OnCompleted;
    
    public bool InteractionsCompleted => _interactionIndex >= interactions.Count;
    private int _interactionIndex;
    private Interaction _currentInteraction;
        
    private int _errorCount;
    private int _helpCount;
        
    private void Awake() => _cam = Camera.main;
    
    void Start()
    {
        //errorCountLabel.text = "";
        //helpCountLabel.text = "";
    }
    void Update()
    {
        
    }

    void Test()
    {
        
    }
}
