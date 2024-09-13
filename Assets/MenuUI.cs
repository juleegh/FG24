using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject canvasUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasUI.SetActive(false);
        resumeButton.onClick.AddListener(ResumeButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvasUI.SetActive(true);
        }
    }

    private void ResumeButtonClicked()
    {
        canvasUI.SetActive(false);
    }
}
