using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            closeMenu();
        }
    }

    public void openMenu() {
        optionsMenu.SetActive(true);
    }

    public void closeMenu() {
        optionsMenu.SetActive(false);
    }
}
