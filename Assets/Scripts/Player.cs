using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private float translateSpeed = 5f;   // Velocidad de movimiento
    private float rotateSpeed = 100f;     // Velocidad de rotaci�n
    private float rotacionVertical = 50f; // �ngulo de rotaci�n vertical actual
    private float limiteRotacionVertical = 10f; // L�mite de rotaci�n vertical en grados

    void Start()
    {
        rotacionVertical = 0f; // Aseg�rate de que comience en 0
    }

    void Update()
    {
        // Obt�n el movimiento con el stick izquierdo (mover adelante/atr�s y lateral)
        float avanceVertical = Input.GetAxis("Vertical") * translateSpeed * Time.deltaTime;  // Movimiento hacia adelante/atr�s
        float avanceHorizontal = Input.GetAxis("Horizontal") * translateSpeed * Time.deltaTime;  // Movimiento lateral (izquierda/derecha)

        // Obt�n la rotaci�n con el stick derecho (rotaci�n alrededor del eje Y)
        float rotacionHorizontal = Input.GetAxis("RightStickHorizontal") * rotateSpeed * Time.deltaTime;

        // Ajusta la rotaci�n vertical con el stick derecho (invertir eje Y)
        float rotacionVerticalInput = -Input.GetAxis("RightStickVertical") * rotateSpeed * Time.deltaTime; // Multiplicamos por -1 para invertir el eje

        rotacionVertical += rotacionVerticalInput;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteRotacionVertical, limiteRotacionVertical);
        Debug.Log("Rotacion vertical: " + rotacionVertical);

        // Mueve el personaje en su espacio local (adelante/atr�s y lateral)
        transform.Translate(avanceHorizontal, 0, avanceVertical);

        // Rota el personaje alrededor del eje Y (horizontal)
        transform.Rotate(Vector3.up * rotacionHorizontal);

        // Aplica la rotaci�n vertical a la c�mara (hija del personaje)
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, Camera.main.transform.localRotation.eulerAngles.y, 0);
    }
}
