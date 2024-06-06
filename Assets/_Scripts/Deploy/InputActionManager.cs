using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionManager : MonoBehaviour
{
    [SerializeField] InputActionAsset asset;
    void Start()
    {
        asset.Enable();
    }

    void OnDestroy()
    {
        asset.Disable();
    }
}
