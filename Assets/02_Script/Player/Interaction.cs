using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private GameObject curInteractGameObject;
    private IInteractable curInteractable;
    private IExecute curExecute;

    public GameObject guideUI;

    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    //curInteractable = hit.collider.GetComponent<IInteractable>();

                    hit.collider.TryGetComponent<IInteractable>(out curInteractable);
                    hit.collider.TryGetComponent<IExecute>(out curExecute);

                    Debug.Log(curInteractGameObject);
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                curExecute = null;
            }
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
        }
    }

    public void OnExecute(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && curExecute != null)
        {
            curExecute.OnExecute();
            curExecute = null;
            curInteractGameObject = null;

            PlayerManager.Instance.Player.guideClear?.Invoke();
        }
    }

}
