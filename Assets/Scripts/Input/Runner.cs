//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Input/Runner.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Runner: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Runner()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Runner"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""555cc320-4377-4361-bfd5-e87602c92a09"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""c6c5a5e0-e682-443d-a412-87c27cfbb2c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""523c98fb-1b73-4207-9df4-ec95ed5a9213"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StartDrag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""692a6f00-b75e-45a8-a923-324ddadeb3b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReleaseDrag"",
                    ""type"": ""Button"",
                    ""id"": ""fbf0aef5-d3c2-483e-8067-292b8f5f7f26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""KeyboardInput"",
                    ""type"": ""Value"",
                    ""id"": ""dabc0f75-ab99-422c-b237-26b826aa4ed4"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1110d2a-ee06-44c3-b278-b409ddf143d2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer;Mobile"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1510c70-18bf-4431-9463-8f1aa78065fb"",
                    ""path"": ""<Touchscreen>/touch*/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d6bef91-9d12-4d68-8e22-46f0da575fe6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99a4745f-a624-4320-8deb-f6c98bf274aa"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4eee2dd-e4b6-4497-96d5-3e6986ede015"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""StartDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0affabe0-b399-480c-ad1d-3fe26a9be7a5"",
                    ""path"": ""<Touchscreen>/touch*/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""StartDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eb13db7-de16-4abd-9bfc-765bd10dd355"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""ReleaseDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c723e035-aaf7-4d04-a077-9c55ec50aecc"",
                    ""path"": ""<Touchscreen>/touch*/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""ReleaseDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c874f36-7981-4742-bfc4-ffe33b841251"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25a22ced-0ceb-4d5a-a821-91f79085c693"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa572099-d734-4c2c-b941-1a15c6152d15"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2889b4e3-ee1f-4c09-88ba-b6efd1e38250"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Computer"",
            ""bindingGroup"": ""Computer"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Tap = m_Gameplay.FindAction("Tap", throwIfNotFound: true);
        m_Gameplay_TouchPosition = m_Gameplay.FindAction("TouchPosition", throwIfNotFound: true);
        m_Gameplay_StartDrag = m_Gameplay.FindAction("StartDrag", throwIfNotFound: true);
        m_Gameplay_ReleaseDrag = m_Gameplay.FindAction("ReleaseDrag", throwIfNotFound: true);
        m_Gameplay_KeyboardInput = m_Gameplay.FindAction("KeyboardInput", throwIfNotFound: true);
    }

    ~@Runner()
    {
        UnityEngine.Debug.Assert(!m_Gameplay.enabled, "This will cause a leak and performance issues, Runner.Gameplay.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Tap;
    private readonly InputAction m_Gameplay_TouchPosition;
    private readonly InputAction m_Gameplay_StartDrag;
    private readonly InputAction m_Gameplay_ReleaseDrag;
    private readonly InputAction m_Gameplay_KeyboardInput;
    public struct GameplayActions
    {
        private @Runner m_Wrapper;
        public GameplayActions(@Runner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Gameplay_Tap;
        public InputAction @TouchPosition => m_Wrapper.m_Gameplay_TouchPosition;
        public InputAction @StartDrag => m_Wrapper.m_Gameplay_StartDrag;
        public InputAction @ReleaseDrag => m_Wrapper.m_Gameplay_ReleaseDrag;
        public InputAction @KeyboardInput => m_Wrapper.m_Gameplay_KeyboardInput;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Tap.started += instance.OnTap;
            @Tap.performed += instance.OnTap;
            @Tap.canceled += instance.OnTap;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
            @StartDrag.started += instance.OnStartDrag;
            @StartDrag.performed += instance.OnStartDrag;
            @StartDrag.canceled += instance.OnStartDrag;
            @ReleaseDrag.started += instance.OnReleaseDrag;
            @ReleaseDrag.performed += instance.OnReleaseDrag;
            @ReleaseDrag.canceled += instance.OnReleaseDrag;
            @KeyboardInput.started += instance.OnKeyboardInput;
            @KeyboardInput.performed += instance.OnKeyboardInput;
            @KeyboardInput.canceled += instance.OnKeyboardInput;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Tap.started -= instance.OnTap;
            @Tap.performed -= instance.OnTap;
            @Tap.canceled -= instance.OnTap;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
            @StartDrag.started -= instance.OnStartDrag;
            @StartDrag.performed -= instance.OnStartDrag;
            @StartDrag.canceled -= instance.OnStartDrag;
            @ReleaseDrag.started -= instance.OnReleaseDrag;
            @ReleaseDrag.performed -= instance.OnReleaseDrag;
            @ReleaseDrag.canceled -= instance.OnReleaseDrag;
            @KeyboardInput.started -= instance.OnKeyboardInput;
            @KeyboardInput.performed -= instance.OnKeyboardInput;
            @KeyboardInput.canceled -= instance.OnKeyboardInput;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_ComputerSchemeIndex = -1;
    public InputControlScheme ComputerScheme
    {
        get
        {
            if (m_ComputerSchemeIndex == -1) m_ComputerSchemeIndex = asset.FindControlSchemeIndex("Computer");
            return asset.controlSchemes[m_ComputerSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnStartDrag(InputAction.CallbackContext context);
        void OnReleaseDrag(InputAction.CallbackContext context);
        void OnKeyboardInput(InputAction.CallbackContext context);
    }
}
