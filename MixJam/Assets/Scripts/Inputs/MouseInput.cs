// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/MouseInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MouseInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseInput"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""513a614c-cec0-4fa8-bff8-519a0be52f70"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""a32a9e7a-a45b-4917-bdc0-76ddab72de0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""0e94725c-571d-4ddb-9cfe-bd640af7fe11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""ae531f68-c305-4503-804a-e0c22accdbab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c26d573c-f8c1-458e-8d78-f1a52c9b7ed7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a312642-df81-4952-ae9f-29c762f30864"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10a38c9d-6d7a-4041-b504-4029722c9da7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_LeftClick = m_General.FindAction("LeftClick", throwIfNotFound: true);
        m_General_MousePosition = m_General.FindAction("MousePosition", throwIfNotFound: true);
        m_General_RightClick = m_General.FindAction("RightClick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_LeftClick;
    private readonly InputAction m_General_MousePosition;
    private readonly InputAction m_General_RightClick;
    public struct GeneralActions
    {
        private @MouseInput m_Wrapper;
        public GeneralActions(@MouseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_General_LeftClick;
        public InputAction @MousePosition => m_Wrapper.m_General_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_General_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnLeftClick;
                @MousePosition.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMousePosition;
                @RightClick.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    public interface IGeneralActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
