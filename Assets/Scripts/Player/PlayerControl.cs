// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""PlayerSpaceMovement"",
            ""id"": ""56c8aa8b-3dc7-48a0-9742-fee0294cb433"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""91be6fda-1c52-41a9-9869-97a50875d132"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a6362a33-cec0-4ebe-807a-b001a462459f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ef9e867c-ff74-49bc-9284-f28671411e97"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8b1d3ffe-25c9-4e1e-95ec-e6c6cc8c696a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe9f6c54-5dd4-44de-afc6-e5de66e09e35"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ca30741-cec9-412c-a779-043ce8407a84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""961d129c-0749-42b5-b628-6acc8705b717"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b4303595-5c1f-409e-821c-a16633a98190"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a2ad20b-88aa-4e4e-8896-c661c5694d6d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7cc1277-9645-4adb-be36-f37ae3335c0d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""78167c1e-fa5d-428c-bd7d-2b2b4e3d2505"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""48ad6e09-ba8a-4381-8094-d2c87aba9659"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combat"",
                    ""type"": ""Button"",
                    ""id"": ""edfb7c00-59bb-4529-b09c-948003c22739"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""0597e1c0-55d9-4436-b42f-59f386cd4a89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy_Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2b501576-ad05-49d2-8990-e7f3e41ec614"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""869c076f-9f72-42b5-874b-b234cbf570d8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63949c0d-1886-452f-ad43-ca13a948d4d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f606e6eb-1558-463b-80e2-63211d5e6bf7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc751253-4200-43d9-baab-4b6d79d265f6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95cc97a4-0712-4eda-9872-083a440a524d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9567eec8-fe5c-4a30-993b-f359420a575c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ff60d5a-68d7-4f6e-bcab-3497bca54692"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy_Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerSpaceMovement
        m_PlayerSpaceMovement = asset.FindActionMap("PlayerSpaceMovement", throwIfNotFound: true);
        m_PlayerSpaceMovement_Movement = m_PlayerSpaceMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerSpaceMovement_Camera = m_PlayerSpaceMovement.FindAction("Camera", throwIfNotFound: true);
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_Combat = m_PlayerActions.FindAction("Combat", throwIfNotFound: true);
        m_PlayerActions_Light_Attack = m_PlayerActions.FindAction("Light_Attack", throwIfNotFound: true);
        m_PlayerActions_Heavy_Attack = m_PlayerActions.FindAction("Heavy_Attack", throwIfNotFound: true);
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

    // PlayerSpaceMovement
    private readonly InputActionMap m_PlayerSpaceMovement;
    private IPlayerSpaceMovementActions m_PlayerSpaceMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerSpaceMovement_Movement;
    private readonly InputAction m_PlayerSpaceMovement_Camera;
    public struct PlayerSpaceMovementActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerSpaceMovementActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerSpaceMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerSpaceMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerSpaceMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSpaceMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSpaceMovementActions instance)
        {
            if (m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerSpaceMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerSpaceMovementActions @PlayerSpaceMovement => new PlayerSpaceMovementActions(this);

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_Combat;
    private readonly InputAction m_PlayerActions_Light_Attack;
    private readonly InputAction m_PlayerActions_Heavy_Attack;
    public struct PlayerActionsActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerActionsActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @Combat => m_Wrapper.m_PlayerActions_Combat;
        public InputAction @Light_Attack => m_Wrapper.m_PlayerActions_Light_Attack;
        public InputAction @Heavy_Attack => m_Wrapper.m_PlayerActions_Heavy_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Combat.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombat;
                @Combat.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombat;
                @Combat.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombat;
                @Light_Attack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLight_Attack;
                @Light_Attack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLight_Attack;
                @Light_Attack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLight_Attack;
                @Heavy_Attack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavy_Attack;
                @Heavy_Attack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavy_Attack;
                @Heavy_Attack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavy_Attack;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Combat.started += instance.OnCombat;
                @Combat.performed += instance.OnCombat;
                @Combat.canceled += instance.OnCombat;
                @Light_Attack.started += instance.OnLight_Attack;
                @Light_Attack.performed += instance.OnLight_Attack;
                @Light_Attack.canceled += instance.OnLight_Attack;
                @Heavy_Attack.started += instance.OnHeavy_Attack;
                @Heavy_Attack.performed += instance.OnHeavy_Attack;
                @Heavy_Attack.canceled += instance.OnHeavy_Attack;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerSpaceMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnCombat(InputAction.CallbackContext context);
        void OnLight_Attack(InputAction.CallbackContext context);
        void OnHeavy_Attack(InputAction.CallbackContext context);
    }
}
