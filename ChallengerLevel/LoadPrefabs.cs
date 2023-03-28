using System;
using BepInEx;
using BepInEx.IL2CPP;
using Epic.OnlineServices;
using HarmonyLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using static Rewired.UI.ControlMapper.ControlMapper;
using static ShipStatus;

namespace LevelPatcher
{
    

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Start))]
        public static class ShipStatusAwakePatch
        {
            public static void Prefix(ShipStatus __instance)
            {
                var patcher = new GameObject("Prefabs Patcher");
                switch (__instance.Type)
                {
                    case ShipStatus.MapType.Hq:
                        patcher.AddComponent<PrefabsPatcher>();
                        break;
                }
            }
        }

        public class PrefabsPatcher : MonoBehaviour
    {
        private void FixedUpdate()
            {


            
           


            var client = AmongUsClient.Instance;

                // On charge Polus 
            var PolusMap = Addressables.LoadAssetAsync<GameObject>(client.ShipPrefabs[(Index)(int)ShipStatus.MapType.Pb]).Result;
            if (!PolusMap)
                return;

            var AirshipMap = Addressables.LoadAssetAsync<GameObject>(client.ShipPrefabs[(Index)(int)4]).Result;
            if (!AirshipMap)
                return;

            var SkeldMap = Addressables.LoadAssetAsync<GameObject>(client.ShipPrefabs[(Index)(int)ShipStatus.MapType.Ship]).Result;
            if (!SkeldMap)
                return;

            var MiraMap = Addressables.LoadAssetAsync<GameObject>(client.ShipPrefabs[(Index)(int)ShipStatus.MapType.Hq]).Result;
            if (!MiraMap)
                return;

            var vitalsObj = PolusMap.transform.Find("Office/panel_vitals").gameObject;
            //var CamObj = res2.transform.Find("Cafeteria/LowerDoor").gameObject;
            var ladderObj = AirshipMap.transform.Find("HallwayMain/ladder_electrical").gameObject;
            var CamObj = SkeldMap.transform.Find("Security/Ground/map_surveillance").gameObject;
            var FenceObj = MiraMap.transform.Find("Balcony/balconyFence").gameObject;
            //var _CamObj = SkeldMap.transform.Find("AdminHallway/SurvCamera/").gameObject;

            
            // Ajouter les signaux vitaux
            var vitals = GameObject.Instantiate(vitalsObj);
                vitals.transform.position = new Vector3(16.4037f, 1.9716f, 1f);
            vitals.transform.localScale = new Vector3(1f, 1f, 1f);

           

            var LadderSRV = GameObject.Instantiate(ladderObj);
            LadderSRV.transform.position = new Vector3(6.8018f, 16f, 1f);
            LadderSRV.transform.localScale = new Vector3(1f, 1f, 1f);
            SpriteRenderer ladderSRVsprite = LadderSRV.GetComponent<SpriteRenderer>();
            ladderSRVsprite.color = ChallengerMod.ColorTable.GhostColor;

            var CameraSurvConsole = GameObject.Instantiate(CamObj);
            CameraSurvConsole.transform.position = new Vector3(2.8746f, 19.3618f, 1f);

            var LadderTubeRight = GameObject.Instantiate(ladderObj);
            LadderTubeRight.transform.position = new Vector3(18.1f, -3.608f, 1.2f);
            LadderTubeRight.transform.localScale = new Vector3(1.1f, 0f, 1f);
            LadderTubeRight.transform.name = "MiraTube";
            GameObject LadderTubeLeft = LadderTubeRight.transform.FindChild("LadderBottom").gameObject;
            LadderTubeLeft.transform.localPosition = new Vector3(-0.8709f, 0f, 0.1f);

            var LadderBal = GameObject.Instantiate(ladderObj);
            LadderBal.transform.position = new Vector3(12.4153f, -2.4996f, 1f);
            LadderBal.transform.localScale = new Vector3(1f, 0.4422f, 1f);
            LadderBal.transform.name = "Ladder_Balcony";

            var LadderTel = GameObject.Instantiate(ladderObj);
            LadderTel.transform.position = new Vector3(6.7458f, 19.143f, 2f);
            LadderTel.transform.localScale = new Vector3(1f, 0f, 1f);
            LadderTel.transform.name = "TF_Security";
            GameObject DestroyBottom = LadderTel.transform.FindChild("LadderBottom").gameObject;
            DestroyBottom.transform.localPosition = new Vector3(6.536f, -23.86f, 1f);
            DestroyBottom.SetActive(false);
            DestroyBottom.active = false;

            var Fence = GameObject.Instantiate(FenceObj);
            Fence.transform.position = new Vector3(16.0059f, -3.7166f, -36f);
            Fence.name = "BalconyFence2";

            Destroy(this.gameObject);
            }
        }

       

       
}