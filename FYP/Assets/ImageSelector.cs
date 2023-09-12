using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class ImageSelector : MonoBehaviour
{
    public GameObject customizationObject; // Reference to the 3D object you want to customize.
    public RawImage selectedImageDisplay; // UI element to display the selected image.

    private Material customMaterial; // Material to apply the selected image.

    void Start()
    {
        customMaterial = customizationObject.GetComponent<Renderer>().material;
    }

    public void SelectImage()
    {
        // Open a file selection dialog to choose an image.
        string imagePath = UnityEditor.EditorUtility.OpenFilePanel("Select Image", "", "png,jpg,jpeg,gif,bmp");
        
        // Check if a file was selected.
        if (!string.IsNullOrEmpty(imagePath))
        {
            // Load the selected image as a Texture.
            Texture2D selectedTexture = LoadTextureFromFile(imagePath);

            // Customize the 3D object's material with the selected image.
            customMaterial.mainTexture = selectedTexture;

            // Display the selected image in the UI.
            selectedImageDisplay.texture = selectedTexture;
        }
    }

    private Texture2D LoadTextureFromFile(string path)
    {
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return texture;
    }
}