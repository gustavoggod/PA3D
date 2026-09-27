using UnityEngine;
using UnityEngine.Playables;

public class IntroCinematicController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Behaviour firstPersonController;
    [SerializeField] private GameObject cinematicCameraObject;

    private void Awake()
    {
        // Bloquear al jugador al iniciar
        if (firstPersonController != null)
        {
            firstPersonController.enabled = false;
        }
    }

    private void Start()
    {
        if (director == null) return;

        director.stopped += OnCinematicFinished;
        director.Play();
    }

    private void OnCinematicFinished(PlayableDirector finishedDirector)
    {
        
        if (director != null)
        {
            director.Stop();
        }

        
        if (cinematicCameraObject != null)
        {
            cinematicCameraObject.SetActive(false);
        }

        
        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
        }

        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (director != null)
        {
            director.stopped -= OnCinematicFinished;
        }
    }
}