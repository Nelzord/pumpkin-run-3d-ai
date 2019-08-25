using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    private CharacterController charController;
    private bool isJumping; 


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;
        charController.SimpleMove(forwardMovement + rightMovement);
        JumpInput();
    }

    private void JumpInput()
    {
       if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 45.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
        isJumping = false;

    }
}
