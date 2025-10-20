using Fusion;
using UnityEngine;
using Unity.Cinemachine;
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterController _cc;
    [SerializeField] private CharacterController _controller;
    private float speed = 5f;
    private float gravity = -9.81f;
    private float drag = 0.5f;

    private Vector3 velocity;
    private Vector3 moveDir;

    public Transform playerCameraRoot;
    public Animator animator;
    public NetworkMecanimAnimator networkAnimator;

    private int _animMoveHash;
    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
        _controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _animMoveHash = Animator.StringToHash("Move");
    }
    public override void FixedUpdateNetwork()
    {
        //if (Object.HasInputAuthority)
        //{
        //    applyGravity();
        //    if (GetInput(out NetworkInputData data))
        //    {
        //        bool isMoving = data.direction.sqrMagnitude > 0.001f; // for now am hard coding.
        //        networkAnimator.Animator.SetBool(_animMoveHash, isMoving);
        //        if (isMoving)
        //        {
        //            data.direction.Normalize();
        //            _cc.Move(data.direction * speed * Runner.DeltaTime);
        //        }
        //    }
        //    else
        //    {
        //        networkAnimator.Animator.SetBool(_animMoveHash, false);
        //    }
        //}

        if (GetInput(out NetworkInputData data))
        {
            moveDir = data.direction;
        }

        if(HasStateAuthority)
        {
            bool isMoving = moveDir.sqrMagnitude > 0.001f;
            if (isMoving) { 
                moveDir.Normalize();
                _cc.Move(moveDir * speed * Runner.DeltaTime);
            }
            networkAnimator.Animator.SetBool(_animMoveHash, isMoving);
        }
        if (HasInputAuthority) 
        {
            bool isMovingLocal = moveDir.sqrMagnitude > 0.001f;
            networkAnimator.Animator.SetBool(_animMoveHash, isMovingLocal);
        }

       
    }

    //public override void Spawned()
    //{
    //    if (HasInputAuthority)
    //    {
    //        _camera.GetComponent<getPlayerCameraFollow>().Target = playerCameraRoot;
    //    }
    //}
    private void applyGravity()
    {
        if (_controller.isGrounded)
        {
            velocity.y += gravity * Runner.DeltaTime;
        }
        else
        {
            velocity.y = Mathf.Max(-velocity.y, -1f);
        }
    }
}
