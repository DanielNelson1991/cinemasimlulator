using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class CustomController : MonoBehaviour
{

    public TextMeshProUGUI interactionText;
    public GameObject _Player;
    public StarterAssets.StarterAssetsInputs _StandardAssestsInput;
    public StarterAssets.FirstPersonController _FirstPersonController;
    public CinemaMachineManager _MachineManager;

    private bool isViewingInteractiveItem = false;
    private string viewingItemName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If interactive item pressed, unlcok the cursor
        if(Input.GetKeyUp(KeyCode.E) && isViewingInteractiveItem)
        {
            Debug.Log("Interacting with: " + viewingItemName);
            _StandardAssestsInput.cursorLocked = false;
            _StandardAssestsInput.cursorInputForLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _FirstPersonController.enabled = false;
            _MachineManager.SwitchPriority();
        }

        // If we are currently viewing an item, and we press escape
        if(isViewingInteractiveItem && Input.GetKeyUp(KeyCode.Escape))
        {
            _StandardAssestsInput.cursorLocked = true;
            _StandardAssestsInput.cursorInputForLook = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _FirstPersonController.enabled = true;
            _MachineManager.SwitchPriority();
        }
    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {

            Debug.Log("Hitting GameObject with Tag : " + hit.transform.gameObject.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.green);

            if(hit.transform.gameObject.tag == "Interactive")
            {
                // Set Interactive Text
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press 'E' to Interact";

                // Set a boolean that says the user is viewing an item
                isViewingInteractiveItem = true;
                viewingItemName = hit.transform.gameObject.name;
            }

        } else
        {
            interactionText.gameObject.SetActive(false);
            viewingItemName = "";
            isViewingInteractiveItem = false;
        }
    }
}
