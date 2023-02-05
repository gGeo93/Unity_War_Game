using UnityEngine;
using TMPro;

public class UIManagerInstructions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goToInstructionsMessage;
    [SerializeField] private TextMeshProUGUI instructionMessage;
    bool isGotoMessageActive = true;
    bool isActualMessageActive = false;
    void Start()
    {
        goToInstructionsMessage.gameObject.SetActive(isGotoMessageActive);
        instructionMessage.gameObject.SetActive(isActualMessageActive);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isGotoMessageActive = !isGotoMessageActive;
            isActualMessageActive = !isActualMessageActive;
            goToInstructionsMessage.gameObject.SetActive(isGotoMessageActive);
            instructionMessage.gameObject.SetActive(isActualMessageActive);
        }
    }
}
