using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetUp : NetworkBehaviour
{
    [SerializeField]
    public Component[] Components;

    public Camera cam;
    private GameObject mainCam;

    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (var c in Components)
                Destroy(c);
            Destroy(cam);
            return;
        }
        mainCam = Camera.main.gameObject;

        if (mainCam != null)
            mainCam.SetActive(false);
    }

    private void OnDisable()
    {
        if (mainCam != null)
            mainCam.SetActive(true);
    }

}
