using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMotor2D motor;
    private InputReader input;

    void Awake()
    {
        motor = GetComponent<CharacterMotor2D>();
        if (motor == null)
            Debug.LogError("Motor not found on Player!");

        input = FindFirstObjectByType<InputReader>();
        if (input == null)
            Debug.LogError("InputReader not found in scene!");
    }

    void OnEnable()
    {
        if (input != null)
            input.OnClick += HandleMove;
    }

    void OnDisable()
    {
        if (input != null)
            input.OnClick -= HandleMove;
    }

    private void HandleMove(Vector2 worldPosition)
    {
        Debug.Log("PlayerController received: " + worldPosition);
        if (motor != null)
            motor.SetTarget(worldPosition);
    }
}