using HarmonyLib;
using UnityEngine;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using InnerNet;
using System.Collections.Generic;
using Hazel;
using Epic.OnlineServices;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements.UIR;
using Reactor.Extensions;
using Rewired.Utils.Platforms.Windows;
using JetBrains.Annotations;

namespace ChallengerLevel
{




    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    class HudUpdateManager
    {
        public static bool Polus = false;
        public static bool Mira = false;
        static void Postfix(HudManager __instance)
        {




            if (AmongUsClient.Instance.GameState != InnerNetClient.GameStates.Started)
            {



                if (PlayerControl.GameOptions.MapId == 0) //skeld
                {
                    Polus = false;
                    Mira = false;
                }
                if (PlayerControl.GameOptions.MapId == 1) //mira
                {
                    Polus = false;
                    Mira = true;
                }
                if (PlayerControl.GameOptions.MapId == 2) //polus
                {
                    Polus = true;
                    Mira = false;
                }
                if (PlayerControl.GameOptions.MapId == 3) //skeld2
                {
                    Polus = false;
                    Mira = false;
                }
                if (PlayerControl.GameOptions.MapId == 4) //airship
                {
                    Polus = false;
                    Mira = false;
                }
                if (PlayerControl.GameOptions.MapId == 5) //Submerged
                {
                    Polus = false;
                    Mira = false;
                }

                if (GameObject.Find("ChallengerMiraShip"))
                {
                    GameObject.Find("ChallengerMiraShip").gameObject.SetActive(true);
                    GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

                }
                if (GameObject.Find("ChallengerPolusShip"))
                {
                    GameObject.Find("ChallengerPolusShip").gameObject.SetActive(true);
                    GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("ChallengerPolusShipV2"))
                {
                    GameObject.Find("ChallengerPolusShipV2").gameObject.SetActive(true);
                    GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                }
                if (GameObject.Find("LobbyLevel_GameObject"))
                {
                    GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                if (GameObject.Find("LobbyLevel_GameObject2"))
                {
                    GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }




            }
            if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
            {

                if (ShipStatus.Instance.Type == ShipStatus.MapType.Pb)
                {




                    if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)// V2
                    {


                        if (GameObject.Find("ChallengerPolusShip"))
                        {
                            GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

                        }
                        if (GameObject.Find("ChallengerMiraShip"))
                        {
                            GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls"))
                        {
                            GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls").gameObject.SetActive(false);
                        }
                        if (GameObject.Find("PolusShip(Clone)").transform.FindChild("Electrical").transform.FindChild("Walls").gameObject)
                        {
                            GameObject.Find("PolusShip(Clone)").transform.FindChild("Electrical").transform.FindChild("Walls").gameObject.SetActive(false);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject"))
                        {
                            GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject2"))
                        {
                            GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }

                        if (ChallengerMod.Challenger.IsMapPolusV2) //START_V2
                        {
                            if (GameObject.Find("ChallengerPolusShipV2"))
                            {
                                GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            }
                            if (GameObject.Find("ChallengerPolusShip").transform.FindChild("LobbyLevel_TempWall").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShip").transform.FindChild("LobbyLevel_TempWall").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("ChallengerPolusShipSprite").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShipSprite").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("ChallengerPolusShipSprite2").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShipSprite2").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            }
                            if (GameObject.Find("LobbyLevel_GameObject"))
                            {
                                GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("LobbyLevel_GameObject2"))
                            {
                                GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                        }
                        else
                        {
                            if (GameObject.Find("ChallengerPolusShipV2"))
                            {
                                GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("ChallengerPolusShip").transform.FindChild("LobbyLevel_TempWall").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShip").transform.FindChild("LobbyLevel_TempWall").gameObject.transform.localScale = new Vector3(2.8f, 1.08f, 1f);
                            }
                            if (GameObject.Find("ChallengerPolusShipSprite").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShipSprite").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                            }
                            if (GameObject.Find("ChallengerPolusShipSprite2").gameObject)
                            {
                                GameObject.Find("ChallengerPolusShipSprite2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("LobbyLevel_GameObject"))
                            {
                                GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                            if (GameObject.Find("LobbyLevel_GameObject2"))
                            {
                                GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                            }
                        }

                    }
                    else // V0-V1
                    {

                        if (GameObject.Find("ChallengerPolusShip"))
                        {
                            GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("ChallengerMiraShip"))
                        {
                            GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls"))
                        {
                            GameObject.Find("PolusShip(Clone)").transform.FindChild("RightTube").transform.FindChild("Walls").gameObject.SetActive(true);
                        }
                        if (GameObject.Find("ChallengerPolusShipV2"))
                        {
                            GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject"))
                        {
                            GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject2"))
                        {
                            GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                    }



                }
                else if (ShipStatus.Instance.Type == ShipStatus.MapType.Hq)
                {
                    if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() == 1)// V2
                    {
                        if (GameObject.Find("ChallengerPolusShip"))
                        {
                            GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("ChallengerPolusShipV2"))
                        {
                            GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("ChallengerMiraShip"))
                        {
                            GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject"))
                        {
                            GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject2"))
                        {
                            GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        var Sprite = GameObject.Find("MiraShip(Clone)").transform.FindChild("LaunchPad").transform.FindChild("launch-front");
                        Sprite.GetComponent<SpriteRenderer>().sprite = TexBGMira;

                        if (GameObject.Find("MiraShip(Clone)/MedBay/medBayBed (1)"))
                        {
                            GameObject.Find("MiraShip(Clone)/MedBay/medBayBed (1)").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("MiraShip(Clone)/MedBay/medBayBed"))
                        {
                            GameObject.Find("MiraShip(Clone)/MedBay/medBayBed").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("MiraShip(Clone)/Comms/comms-top/SurvLogConsole"))
                        {
                            GameObject SurvLogObj = GameObject.Find("MiraShip(Clone)/Comms/comms-top/SurvLogConsole").gameObject;
                            BoxCollider2D SurvLogObjBoxCollider2D = SurvLogObj.GetComponent<BoxCollider2D>();
                            SurvLogObjBoxCollider2D.size = new Vector3(0f, 0f, 0f);
                        }
                    }
                    else // V0
                    {

                        if (GameObject.Find("ChallengerPolusShip"))
                        {
                            GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("ChallengerPolusShipV2"))
                        {
                            GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("ChallengerMiraShip"))
                        {
                            GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject"))
                        {
                            GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("LobbyLevel_GameObject2"))
                        {
                            GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }
                        if (GameObject.Find("panel_vitals(Clone)"))
                        {
                            GameObject.Find("panel_vitals(Clone)").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                        }

                    }
                }
                else
                {
                    if (GameObject.Find("ChallengerPolusShip"))
                    {
                        GameObject.Find("ChallengerPolusShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    if (GameObject.Find("ChallengerPolusShipV2"))
                    {
                        GameObject.Find("ChallengerPolusShipV2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    if (GameObject.Find("ChallengerMiraShip"))
                    {
                        GameObject.Find("ChallengerMiraShip").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    if (GameObject.Find("LobbyLevel_GameObject"))
                    {
                        GameObject.Find("LobbyLevel_GameObject").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                    if (GameObject.Find("LobbyLevel_GameObject2"))
                    {
                        GameObject.Find("LobbyLevel_GameObject2").gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
                    }
                }
            }
            /*  else
             {

             }
         }
        if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
         {

             if (Mira)
             {
                 if (ChallengerMod.HarmonyMain.BetterMapHQ.GetValue() == 0)// V1
                 {



             }
             else
             {

             }

         }*/













        }




    }
}
    



    

        
    
