using System;
using BepInEx;
using BepInEx.IL2CPP;
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
                var patcher = new GameObject("Vital Patcher");
                switch (__instance.Type)
                {
                    case ShipStatus.MapType.Hq:
                        patcher.AddComponent<VitalPatcher>();
                        break;
                }
            }
        }

        public class VitalPatcher : MonoBehaviour
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

            var vitalsObj = PolusMap.transform.Find("Office/panel_vitals").gameObject;
            //var CamObj = res2.transform.Find("Cafeteria/LowerDoor").gameObject;
            var ladderObj = AirshipMap.transform.Find("HallwayMain/ladder_electrical").gameObject;
            var CamObj = SkeldMap.transform.Find("Security/Ground/map_surveillance").gameObject;
            //var _CamObj = SkeldMap.transform.Find("AdminHallway/SurvCamera/").gameObject;


            // Ajouter les signaux vitaux
            var vitals = GameObject.Instantiate(vitalsObj);
                vitals.transform.position = new Vector3(16.4037f, 1.9716f, 1f); 
                vitals.transform.localScale = new Vector3(1f, 1f, 1f);

            var Ladder = GameObject.Instantiate(ladderObj);
            Ladder.transform.position = new Vector3(6.8018f, 16f, 1f);
            Ladder.transform.localScale = new Vector3(1f, 1f, 1f);
            SpriteRenderer laddersprite = Ladder.GetComponent<SpriteRenderer>();
            laddersprite.color = ChallengerMod.ColorTable.GhostColor;

            var CameraSurvConsole = GameObject.Instantiate(CamObj);
            CameraSurvConsole.transform.position = new Vector3(2.8746f, 19.3618f, 1f);

           /* var Cam = GameObject.Instantiate(_CamObj);
            Cam.name = "MiraCamera_1";
            SurvCamera SrvCam = Cam.GetComponent<SurvCamera>();
            SrvCam.CamName = "Camera_1";
            SrvCam.Offset = new Vector3(0f, 0f, SrvCam.Offset.z);
            SrvCam.transform.position = new Vector3(5f, 10f, 1f);
            SrvCam.gameObject.SetActive(true);
            ChallengerMod.Challenger.MiraCam.Add(SrvCam);
            ShipStatus.Instance.AllCameras.AddItem(SrvCam);

            var Cam2 = GameObject.Instantiate(_CamObj);
            Cam2.name = "MiraCamera_2";
            SurvCamera SrvCam2 = Cam2.GetComponent<SurvCamera>();
            SrvCam2.CamName = "Camera_2";
            SrvCam2.Offset = new Vector3(0f, 0f, SrvCam2.Offset.z);
            SrvCam2.transform.position = new Vector3(5f, 10f, 1f);
            SrvCam2.gameObject.SetActive(true);
            ChallengerMod.Challenger.MiraCam.Add(SrvCam2);
            ShipStatus.Instance.AllCameras.AddItem(SrvCam2);

            var Cam3 = GameObject.Instantiate(_CamObj);
            Cam3.name = "MiraCamera_3";
            SurvCamera SrvCam3 = Cam3.GetComponent<SurvCamera>();
            SrvCam3.CamName = "Camera_3";
            SrvCam3.Offset = new Vector3(0f, 0f, SrvCam3.Offset.z);
            SrvCam3.transform.position = new Vector3(5f, 10f, 1f);
            SrvCam3.gameObject.SetActive(true);
            ChallengerMod.Challenger.MiraCam.Add(SrvCam3);
            ShipStatus.Instance.AllCameras.AddItem(SrvCam3);

            var Cam4 = GameObject.Instantiate(_CamObj);
            Cam4.name = "MiraCamera_4";
            SurvCamera SrvCam4 = Cam4.GetComponent<SurvCamera>();
            SrvCam4.CamName = "Camera_4";
            SrvCam4.Offset = new Vector3(0f, 0f, SrvCam4.Offset.z);
            SrvCam4.transform.position = new Vector3(5f, 10f, 1f);
            SrvCam4.gameObject.SetActive(true);
            ChallengerMod.Challenger.MiraCam.Add(SrvCam4);
            ShipStatus.Instance.AllCameras.AddItem(SrvCam4);*/




            Destroy(this.gameObject);
            }
        }

       

       
}