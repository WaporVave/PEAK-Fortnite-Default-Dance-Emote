using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using PEAKEmoteLib;

namespace FortniteDefaultDanceEmote;

[BepInDependency(PEAKEmoteLib.Plugin.Id)]
[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    private void Awake()
    {
        Log = Logger;

        AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WaporVave_fortnite_default_dance_bundle"));

        AnimationClip defaultDanceClip = assetBundle.LoadAsset<AnimationClip>("Assets/Fortnite_Default_Dance.anim");
        Texture2D iconTexture = assetBundle.LoadAsset<Texture2D>("Assets/default_dance_icon.png");

        Emote fortniteEmote = new Emote("WaporVave_FortniteDefaultDance", defaultDanceClip, iconTexture, type: Emote.EmoteType.OneShot, disableIK: true);
        fortniteEmote.AddLocalization("My Awesome Emote", LocalizedText.Language.English);

        this.RegisterEmote(fortniteEmote);

        Log.LogInfo($"Plugin {Name} is loaded!");
    }
}
