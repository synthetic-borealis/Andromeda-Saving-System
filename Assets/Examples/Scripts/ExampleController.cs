using Andromeda.Saving;
using UnityEngine;

public class ExampleController : MonoBehaviour
{
    private const string SaveFile = "save00";

    public SavingSystem savingSystem;

    // Update is called once per frame
    void Update()
    {
        if (savingSystem == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            savingSystem.Save(SaveFile);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            savingSystem.Load(SaveFile);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
