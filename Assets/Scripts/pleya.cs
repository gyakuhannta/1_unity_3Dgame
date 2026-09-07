using UnityEngine;
using UnityEngine.InputSystem;

public class pleya : MonoBehaviour
{

    [SerializeField] float speedmax;
    PlayerInput PlayerInput;


    private void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        var movevec = PlayerInput.actions["Move"].ReadValue<Vector2>();


        var cameraDir = PlayerInput.camera.transform.forward;
        cameraDir.y = 0;
        cameraDir = cameraDir.normalized;

        var cameraRight = PlayerInput.camera.transform.right;

        var moveVec3D =
            cameraDir * movevec.y * speedmax
            + cameraRight * movevec.x * speedmax;
        transform.position = transform.position + moveVec3D * Time.deltaTime;

    }
}
