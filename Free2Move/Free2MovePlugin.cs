/*
 * Copyright (c) 2024 Lordfirespeed.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace Free2Move;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public sealed class Free2MovePlugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static Free2MoveConfig BoundConfig { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;
        BoundConfig = new Free2MoveConfig(this);

        var managerGameObject = new GameObject("Free2Move") {
            hideFlags = HideFlags.HideAndDontSave,
        };
        managerGameObject.AddComponent<Free2MovePatcher>();
        DontDestroyOnLoad(managerGameObject);
    }
}
