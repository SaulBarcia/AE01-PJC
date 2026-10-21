using UnityEngine;
//Ejemplo de interfaz con efectos en los distintos mandos
public interface IControllerFeedback
{
    void PlayJumpFeedback(); //Funciones internas de la clase
    void PlayDeathFeedback();
}

// 2. Implementación específica simulada para PS5 (por herencia)
public class PS5Adapter : IControllerFeedback
{
    public void PlayJumpFeedback()
    {
        // Simulación para el mando de la PS5 (la resistencia combina vibración del mando con los gatillos adaptativos)
        Debug.Log("[PS5] Activando resistencia háptica del DualSense al saltar.");
    }

    public void PlayDeathFeedback() { /* ... */ }
}

// 3. Implementación específica simulada para Xbox Series X (por herencia)
public class XboxAdapter : IControllerFeedback
{
    public void PlayJumpFeedback()
    {
        // Simulación para el mando de la Xbox series X 
        Debug.Log("[Xbox Series X] Activando vibración por impulsos en gatillos.");
    }

    public void PlayDeathFeedback() { /* ... */ }
}