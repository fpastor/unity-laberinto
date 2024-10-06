using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private float translateSpeed = 5f;   // Velocidad de movimiento
    private float rotateSpeed = 100f;     // Velocidad de rotación
    private float rotacionVertical = 50f; // Ángulo de rotación vertical actual
    private float limiteRotacionVertical = 10f; // Límite de rotación vertical en grados

    void Start()
    {
        rotacionVertical = 0f; // Asegúrate de que comience en 0
    }

    void Update()
    {
        // Obtén el movimiento con el stick izquierdo (mover adelante/atrás y lateral)
        float avanceVertical = Input.GetAxis("Vertical") * translateSpeed * Time.deltaTime;  // Movimiento hacia adelante/atrás
        float avanceHorizontal = Input.GetAxis("Horizontal") * translateSpeed * Time.deltaTime;  // Movimiento lateral (izquierda/derecha)

        // Obtén la rotación con el stick derecho (rotación alrededor del eje Y)
        float rotacionHorizontal = Input.GetAxis("RightStickHorizontal") * rotateSpeed * Time.deltaTime;

        // Ajusta la rotación vertical con el stick derecho (invertir eje Y)
        float rotacionVerticalInput = -Input.GetAxis("RightStickVertical") * rotateSpeed * Time.deltaTime; // Multiplicamos por -1 para invertir el eje

        rotacionVertical += rotacionVerticalInput;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -limiteRotacionVertical, limiteRotacionVertical);
        Debug.Log("Rotacion vertical: " + rotacionVertical);

        // Mueve el personaje en su espacio local (adelante/atrás y lateral)
        transform.Translate(avanceHorizontal, 0, avanceVertical);

        // Rota el personaje alrededor del eje Y (horizontal)
        transform.Rotate(Vector3.up * rotacionHorizontal);

        // Aplica la rotación vertical a la cámara (hija del personaje)
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionVertical, Camera.main.transform.localRotation.eulerAngles.y, 0);
    }
}
