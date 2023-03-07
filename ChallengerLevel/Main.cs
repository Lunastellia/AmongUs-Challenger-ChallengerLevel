using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Linq;
using System.Net;
using Reactor;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using UnityEngine;
using System.IO;
using Reactor.Extensions;
using UnhollowerBaseLib;
using System.Collections;
using ChallengerOS.Utils.Option;
using ChallengerMod.RPC;
using Hazel.Udp;
using System.Text.RegularExpressions;
using Hazel;
using InnerNet;
using System.Collections.Generic;
using BepInEx.Logging;
using System.Reflection;
using UnhollowerRuntimeLib;
using LevelPatcher;
using UnityEngine.SceneManagement;

namespace ChallengerLevel
{ 
    [BepInPlugin(Id, "Challenger_Level", VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInProcess("Among Us.exe")]

    public class HarmonyMain : BasePlugin
    {

        public const string VersionString = "5.2.0";
        
        public static System.Version Version = System.Version.Parse(VersionString);

        public const string Id = "Config.ChallengerLevel";
        public static HarmonyMain Instance { get; private set; }
        // static List<CooldownButton> impostorbuttons = new List<CooldownButton>();

        public Harmony Harmony { get; } = new Harmony(Id);

        public static ConfigEntry<bool> StreamerMode { get; set; }

        public static ConfigFile OPSettings { get; private set; }

        public static ManualLogSource Logger { get; private set; }

       



       
        public override void Load()
        {

            Instance = this;

            ClassInjector.RegisterTypeInIl2Cpp<VitalPatcher>();

            SceneManager.sceneLoaded += (Action<Scene, LoadSceneMode>)((scene, loadSceneMode) =>
            {
                ModManager.Instance.ShowModStamp();
            });
            //SpritePatches2.Patch();
            Harmony.PatchAll();
        }


    }
}
