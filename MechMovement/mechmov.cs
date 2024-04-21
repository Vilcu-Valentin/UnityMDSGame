using UnityEngine;

public class MechMovement : MonoBehaviour
{
    public MechModule baseModule; // Modulul de bază
    public MechModule[] additionalModules; // Module adiționale

    private Rigidbody rb;
    private float currentSpeed = 0;
    private float currentTurnSpeed = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float targetSpeed = baseModule.maxSpeed;
        float targetTurnSpeed = baseModule.turnSpeed;

        foreach (var module in additionalModules)
        {
            targetSpeed += module.maxSpeed;
            targetTurnSpeed += module.turnSpeed;
        }

        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculează viteza curentă și viteza de virare curentă
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed * forwardInput, baseModule.acceleration * Time.deltaTime);
        currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, targetTurnSpeed * horizontalInput, baseModule.turnAcceleration * Time.deltaTime);

        // Aplică mișcarea și rotația folosind Rigidbody pentru a interacționa corect cu fizica
        Vector3 moveVector = transform.forward * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, currentTurnSpeed * Time.deltaTime, 0));
    }
}
