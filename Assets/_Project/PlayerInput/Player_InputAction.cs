// GENERATED AUTOMATICALLY FROM 'Assets/_Project/PlayerInput/Player_InputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_InputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_InputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_InputAction"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""578aff04-117e-4ad2-80ae-6f5d15eab02f"",
            ""actions"": [
                {
                    ""name"": ""OnDragStart"",
                    ""type"": ""Button"",
                    ""id"": ""9fd5514d-3f52-4637-b074-aaa674a01e6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""OnDragEnd"",
                    ""type"": ""Button"",
                    ""id"": ""6361aec1-5ac7-45ca-ba35-45e04bc386e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f867f18-e1ac-41ff-99c0-8a785d594357"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDragStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6070190-161b-4362-995c-f9b874160f5c"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDragStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e311525-0672-4414-be23-20c811f3e365"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDragEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8576c1f2-1543-4dc9-a949-7c1232a96307"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDragEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_OnDragStart = m_Gameplay.FindAction("OnDragStart", throwIfNotFound: true);
        m_Gameplay_OnDragEnd = m_Gameplay.FindAction("OnDragEnd", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_OnDragStart;
    private readonly InputAction m_Gameplay_OnDragEnd;
    public struct GameplayActions
    {
        private @Player_InputAction m_Wrapper;
        public GameplayActions(@Player_InputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnDragStart => m_Wrapper.m_Gameplay_OnDragStart;
        public InputAction @OnDragEnd => m_Wrapper.m_Gameplay_OnDragEnd;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @OnDragStart.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragStart;
                @OnDragStart.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragStart;
                @OnDragStart.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragStart;
                @OnDragEnd.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragEnd;
                @OnDragEnd.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragEnd;
                @OnDragEnd.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOnDragEnd;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnDragStart.started += instance.OnOnDragStart;
                @OnDragStart.performed += instance.OnOnDragStart;
                @OnDragStart.canceled += instance.OnOnDragStart;
                @OnDragEnd.started += instance.OnOnDragEnd;
                @OnDragEnd.performed += instance.OnOnDragEnd;
                @OnDragEnd.canceled += instance.OnOnDragEnd;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnOnDragStart(InputAction.CallbackContext context);
        void OnOnDragEnd(InputAction.CallbackContext context);
    }
}
