using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlGameOver : MonoBehaviour
{
    public static ControlGameOver Instance; // Instancia �nica del ControlGameOver
    [SerializeField] private GameObject panelGameOver; // Panel de Game Over
    [SerializeField] private TMP_Text textoGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogWarning($"Otra instancia de ControlGameOver detectada en: {gameObject.name}. No se destruir� pero no ser� la instancia activa.");
            return;
        }

        // Verifica si el PanelGameOver est� asignado desde el inspector
        if (panelGameOver == null)
        {
            // Intenta encontrar el PanelGameOver autom�ticamente
            panelGameOver = transform.Find("PanelGameOver")?.gameObject;

            if (panelGameOver == null)
            {
                Debug.LogError("El PanelGameOver no est� asignado ni encontrado autom�ticamente.");
            }
        }

        OcultarGameOver();
        Debug.Log("PanelGameOver ocultado correctamente.");
    }

    public void MostrarGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
            textoGameOver.text = " "; // Cambia el texto a "Game Over"
            FindObjectOfType<MusicaFondo>()?.DetenerMusica(); // Detiene la m�sica si est� disponible
            Time.timeScale = 0; // Pausa el juego
            Debug.Log("Game Over mostrado.");
        }
        else
        {
            Debug.LogError("El PanelGameOver no est� asignado en el Inspector y no se puede mostrar.");
        }
    }

    // M�todo para mostrar el estado de Victoria
    public void MostrarVictoria()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
            textoGameOver.text = "�Victoria! Has completado el nivel."; // Cambia el texto a "Victoria"
            FindObjectOfType<MusicaFondo>()?.DetenerMusica(); // Detiene la m�sica si est� disponible
            Time.timeScale = 0; // Pausa el juego
            Debug.Log("Victoria mostrada.");
        }
        else
        {
            Debug.LogError("El PanelGameOver no est� asignado en el Inspector y no se puede mostrar.");
        }
    }

    public void OcultarGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
            Time.timeScale = 1; // Restaura el tiempo del juego
            Debug.Log("PanelGameOver ocultado correctamente.");
        }
        else
        {
            Debug.LogError("El PanelGameOver no est� asignado en el Inspector y no se puede ocultar.");
        }
    }

    public void ReiniciarJuego()
    {
        if (panelGameOver != null)
        {
            OcultarGameOver(); // Asegura que el panel est� oculto antes de reiniciar
        }

        Debug.Log("Reiniciando la escena...");
        Time.timeScale = 1; // Restaura el tiempo del juego antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
}
