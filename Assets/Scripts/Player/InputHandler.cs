using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_Input;
    public bool LAttack_Input;
    public bool HAttack_Input;
    public bool rollFlag;
    public bool combatFlag;
    public bool isActing;
    public bool comboFlag;
    public bool isInteracting;
    public bool isNow=true;

    PlayerControl inputActions;
    CameraHandler cameraHandler;
    Player_Attacker playerAttacker;
    PlayerInventory playerInventory;
    AnimatorHandler animatorHandler;
    PlayerManager playerManager;
    PlayerStats playerStats;


    Vector2 movementInput;
    Vector2 cameraInput;

    private void Start()
    {
        cameraHandler = CameraHandler.singleton;
    }


    private void Awake()
    {
        playerAttacker = GetComponent<Player_Attacker>();
        playerStats = GetComponent<PlayerStats>();
        playerInventory = GetComponent<PlayerInventory>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        playerManager = GetComponentInChildren<PlayerManager>();
    
    }



    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (cameraHandler!= null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
        }
    }
    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControl();
            inputActions.PlayerSpaceMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerSpaceMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
       
        HandleCombatInput(delta);

        
     
        AttackInput(delta);
        
    }

    public void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    public void HandleRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
            rollFlag = true; 
        }
    }

    public void HandleCombatInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Combat.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {

            animatorHandler.PlayTargetAnimation("sheath", true);






        }


    }

    public void AttackInput(float delta)
    {
        inputActions.PlayerActions.Light_Attack.performed += i => LAttack_Input = true;
        inputActions.PlayerActions.Heavy_Attack.performed += i => HAttack_Input = true;

        if (LAttack_Input == true && combatFlag == true)
        {
            if (animatorHandler.anim.GetBool("Combo"))
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombo(playerInventory.rightWeaponItem);
                comboFlag = false;
            }
            else
            {
                playerAttacker.Handle_Light_Attack(playerInventory.rightWeaponItem);
            }
            
        }
        if (HAttack_Input == true && combatFlag == true)
        {

            
            playerAttacker.Handle_Heavy_Attack();
            animatorHandler.anim.SetBool("IsBlocking", true);
            playerStats.enabled = false;


        }
        if(HAttack_Input == false)
        {
            playerStats.enabled = true;
            animatorHandler.anim.SetBool("IsBlocking", false);
            
        }
    }


}
