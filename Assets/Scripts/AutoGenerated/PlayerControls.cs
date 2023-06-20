//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Utility/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""0c57cafa-953b-48c1-80e1-9c904ab85ce0"",
            ""actions"": [
                {
                    ""name"": ""UseRoboModSouth"",
                    ""type"": ""Button"",
                    ""id"": ""d436284c-8d40-40b6-82f8-9efcde091849"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRoboModNorth"",
                    ""type"": ""Button"",
                    ""id"": ""973ad0b3-5b04-4de7-8b3b-ac5e5138f45e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRoboModWest"",
                    ""type"": ""Button"",
                    ""id"": ""1c9e7044-640f-4040-b49c-e19546a2e922"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRoboModEast"",
                    ""type"": ""Button"",
                    ""id"": ""a637c687-689d-446d-99f1-ffa8b5d9af63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseSoftware"",
                    ""type"": ""Button"",
                    ""id"": ""3d4d391e-4df1-4c40-ac7b-b44febe3abf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7eed12e9-da78-4f4b-b652-1440d7a6a7d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""f3d37806-f10a-4276-ba8e-2c667e56b616"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26578529-2797-48a3-8957-f928e9cbd436"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""994bb7a9-650b-46f5-b9f6-f149dadbd2b7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9013485-c9fc-48cf-a4ac-915ace24c851"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f999911-8460-45da-8ad8-3520f06109a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""76ea5f51-ddab-414b-afd4-e077d0d97ca2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a404b2e-4af9-4740-a686-f903abb2cf98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dfa64b06-7843-497f-8dee-6ff5f2c366a8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfc53b9c-f8b8-4311-8778-010cf0ef5dbd"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""315d02a3-a465-4b01-bdc2-9b8e018d0d53"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97465018-2c9b-4bac-9fd2-3b5d3f9d1228"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27066a20-ac30-4d44-9061-7114faa14311"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c56b57d-5eb3-4588-99fd-c5be70f91d96"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bed9e9c-3e85-4553-b6a6-0a10cd3efa0b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7922d3a3-4f87-42f3-9f53-82baf2659dbd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModWest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""492265e0-ec6c-49ce-a0e5-641b6e47f0f9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModWest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18685feb-2828-4ae4-a869-bbe43b432737"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6571a451-e4a2-49dd-ac14-f8795f198172"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRoboModEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c17ed0c9-4236-4e37-ac4a-29c699d1756e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseSoftware"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a68bcb15-d294-4f58-b55f-2146c1cab566"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseSoftware"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1a6880d-b821-48e2-8648-6239b82b2845"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseSoftware"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIControls"",
            ""id"": ""5d0ce827-da4f-41b9-91b6-517f7ee7664d"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""e26e2e67-7369-42dc-b49d-ee553d949d1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c3dcb75-1b9e-4d2e-8aa7-60e97e940ffa"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_UseRoboModSouth = m_GameControls.FindAction("UseRoboModSouth", throwIfNotFound: true);
        m_GameControls_UseRoboModNorth = m_GameControls.FindAction("UseRoboModNorth", throwIfNotFound: true);
        m_GameControls_UseRoboModWest = m_GameControls.FindAction("UseRoboModWest", throwIfNotFound: true);
        m_GameControls_UseRoboModEast = m_GameControls.FindAction("UseRoboModEast", throwIfNotFound: true);
        m_GameControls_UseSoftware = m_GameControls.FindAction("UseSoftware", throwIfNotFound: true);
        m_GameControls_Move = m_GameControls.FindAction("Move", throwIfNotFound: true);
        m_GameControls_Look = m_GameControls.FindAction("Look", throwIfNotFound: true);
        // UIControls
        m_UIControls = asset.FindActionMap("UIControls", throwIfNotFound: true);
        m_UIControls_Newaction = m_UIControls.FindAction("New action", throwIfNotFound: true);
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

    // GameControls
    private readonly InputActionMap m_GameControls;
    private List<IGameControlsActions> m_GameControlsActionsCallbackInterfaces = new List<IGameControlsActions>();
    private readonly InputAction m_GameControls_UseRoboModSouth;
    private readonly InputAction m_GameControls_UseRoboModNorth;
    private readonly InputAction m_GameControls_UseRoboModWest;
    private readonly InputAction m_GameControls_UseRoboModEast;
    private readonly InputAction m_GameControls_UseSoftware;
    private readonly InputAction m_GameControls_Move;
    private readonly InputAction m_GameControls_Look;
    public struct GameControlsActions
    {
        private @PlayerControls m_Wrapper;
        public GameControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UseRoboModSouth => m_Wrapper.m_GameControls_UseRoboModSouth;
        public InputAction @UseRoboModNorth => m_Wrapper.m_GameControls_UseRoboModNorth;
        public InputAction @UseRoboModWest => m_Wrapper.m_GameControls_UseRoboModWest;
        public InputAction @UseRoboModEast => m_Wrapper.m_GameControls_UseRoboModEast;
        public InputAction @UseSoftware => m_Wrapper.m_GameControls_UseSoftware;
        public InputAction @Move => m_Wrapper.m_GameControls_Move;
        public InputAction @Look => m_Wrapper.m_GameControls_Look;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void AddCallbacks(IGameControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Add(instance);
            @UseRoboModSouth.started += instance.OnUseRoboModSouth;
            @UseRoboModSouth.performed += instance.OnUseRoboModSouth;
            @UseRoboModSouth.canceled += instance.OnUseRoboModSouth;
            @UseRoboModNorth.started += instance.OnUseRoboModNorth;
            @UseRoboModNorth.performed += instance.OnUseRoboModNorth;
            @UseRoboModNorth.canceled += instance.OnUseRoboModNorth;
            @UseRoboModWest.started += instance.OnUseRoboModWest;
            @UseRoboModWest.performed += instance.OnUseRoboModWest;
            @UseRoboModWest.canceled += instance.OnUseRoboModWest;
            @UseRoboModEast.started += instance.OnUseRoboModEast;
            @UseRoboModEast.performed += instance.OnUseRoboModEast;
            @UseRoboModEast.canceled += instance.OnUseRoboModEast;
            @UseSoftware.started += instance.OnUseSoftware;
            @UseSoftware.performed += instance.OnUseSoftware;
            @UseSoftware.canceled += instance.OnUseSoftware;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IGameControlsActions instance)
        {
            @UseRoboModSouth.started -= instance.OnUseRoboModSouth;
            @UseRoboModSouth.performed -= instance.OnUseRoboModSouth;
            @UseRoboModSouth.canceled -= instance.OnUseRoboModSouth;
            @UseRoboModNorth.started -= instance.OnUseRoboModNorth;
            @UseRoboModNorth.performed -= instance.OnUseRoboModNorth;
            @UseRoboModNorth.canceled -= instance.OnUseRoboModNorth;
            @UseRoboModWest.started -= instance.OnUseRoboModWest;
            @UseRoboModWest.performed -= instance.OnUseRoboModWest;
            @UseRoboModWest.canceled -= instance.OnUseRoboModWest;
            @UseRoboModEast.started -= instance.OnUseRoboModEast;
            @UseRoboModEast.performed -= instance.OnUseRoboModEast;
            @UseRoboModEast.canceled -= instance.OnUseRoboModEast;
            @UseSoftware.started -= instance.OnUseSoftware;
            @UseSoftware.performed -= instance.OnUseSoftware;
            @UseSoftware.canceled -= instance.OnUseSoftware;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);

    // UIControls
    private readonly InputActionMap m_UIControls;
    private List<IUIControlsActions> m_UIControlsActionsCallbackInterfaces = new List<IUIControlsActions>();
    private readonly InputAction m_UIControls_Newaction;
    public struct UIControlsActions
    {
        private @PlayerControls m_Wrapper;
        public UIControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UIControls_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UIControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIControlsActions set) { return set.Get(); }
        public void AddCallbacks(IUIControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_UIControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIControlsActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IUIControlsActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IUIControlsActions instance)
        {
            if (m_Wrapper.m_UIControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_UIControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIControlsActions @UIControls => new UIControlsActions(this);
    public interface IGameControlsActions
    {
        void OnUseRoboModSouth(InputAction.CallbackContext context);
        void OnUseRoboModNorth(InputAction.CallbackContext context);
        void OnUseRoboModWest(InputAction.CallbackContext context);
        void OnUseRoboModEast(InputAction.CallbackContext context);
        void OnUseSoftware(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IUIControlsActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
