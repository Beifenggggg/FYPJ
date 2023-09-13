using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SampleWebView : MonoBehaviour
{
    public string Url;
    public Text status;
    private WebViewObject webViewObject;

    IEnumerator Start()
    {
        // Create a new WebViewObject using the fully qualified name
        webViewObject = gameObject.AddComponent<WebViewObject>();

        // Configure the WebViewObject
        webViewObject.Init(
            cb: (msg) =>
            {
                Debug.Log(string.Format("CallFromJS[{0}]", msg));
                status.text = msg;
                status.GetComponent<Animation>().Play();
            },
            err: (msg) =>
            {
                Debug.Log(string.Format("CallOnError[{0}]", msg));
                status.text = msg;
                status.GetComponent<Animation>().Play();
            },
            started: (msg) =>
            {
                Debug.Log(string.Format("CallOnStarted[{0}]", msg));
            },
            ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
                
                // Evaluate JavaScript code after the web page is loaded
                webViewObject.EvaluateJS("Unity.call('ua=' + navigator.userAgent)");
            },
            enableWKWebView: true);

        // Set the margins and visibility of the WebViewObject
        webViewObject.SetMargins(5, 100, 5, Screen.height / 4);
        webViewObject.SetVisibility(true);

        // Load the URL or local file
        if (Url.StartsWith("http"))
        {
            webViewObject.LoadURL(Url);
        }
        else
        {
            webViewObject.LoadURL("file://" + Application.streamingAssetsPath + "/" + Url);
        }

        yield break;
    }
}