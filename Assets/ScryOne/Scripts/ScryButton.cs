
using System.Text;
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class ScryButton : UdonSharpBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextUI;
    [SerializeField]
    private VRCUrl URL;

    public override void Interact()
    {
        VRCStringDownloader.LoadUrl(URL, (IUdonEventReceiver)this);
    }

    public override void OnStringLoadSuccess(IVRCStringDownload result)
    {
        string resultAsUTF8 = result.Result;
        byte[] resultAsBytes = result.ResultBytes;
        string resultAsASCII = Encoding.ASCII.GetString(resultAsBytes);
        Debug.Log($"UTF8: {resultAsUTF8}");
        Debug.Log($"ASCII: {resultAsASCII}");
        TextUI.text = resultAsUTF8;
    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        Debug.LogError($"Error loading string: {result.ErrorCode} - {result.Error}");
    }
}
