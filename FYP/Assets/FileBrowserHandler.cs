using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using AnotherFileBrowser.Windows;

public class FileBrowserHandler : MonoBehaviour
{
    public RawImage rawImage;

    // Add a reference to your 3D button GameObject
    public GameObject threeDButton;

    private void Update()
    {
        // Check for raycast hit when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform raycast
            if (Physics.Raycast(ray, out hit))
            {
                if (threeDButton != null && hit.collider.CompareTag("3DButton"))
                {
                    // The 3D button was clicked, trigger the file browser
                    OpenFileBrowser();
                }
            }
        }
    }

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            // Load image from local path with UWR
            StartCoroutine(LoadImage(path));
        });
    }

    IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = uwrTexture;
            }
        }
    }
}