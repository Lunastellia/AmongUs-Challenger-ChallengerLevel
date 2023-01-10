using HarmonyLib;
using Hazel;
using System;
using UnityEngine;
using static ChallengerMod.Unity;
using static ChallengerMod.Roles;
using static ChallengerMod.ColorTable;
using static ChallengerMod.Challenger;
using ChallengerMod;

namespace ChallengerLevel
{
        [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.ShowNormalMap))]
        class MapNormalOverlay
        {
            static void Postfix(MapBehaviour __instance)
            {
                if (__instance.IsOpen)
                {
                    if (HudUpdateManager.Polus)
                    {
                        if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)"))
                        {

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)
                        {
                            if (ChallengerMod.Challenger.IsMapPolusV2) //START_V2
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV3;

                            }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV2;

                            }

                        }
                        else
                        {
                            GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV1;
                        }
                        }
                    }
                    if (HudUpdateManager.Mira)
                    {
                        if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)"))
                        {

                            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() == 1)
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV2;

                            }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV1;
                            }
                        }
                    }


                }
            }
        }

        [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.ShowSabotageMap))]
        class MapInfectedOverlay
        {
        static void Postfix(MapBehaviour __instance)
        {
            if (__instance.IsOpen)
            {
                if (HudUpdateManager.Polus)
                {
                    if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)"))
                    {

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)
                        {
                            if (ChallengerMod.Challenger.IsMapPolusV2) //START_V2
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV3;

                            }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV2;

                            }
                        }
                        else
                        {
                            GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV1;
                        }
                    }
                }
                if (HudUpdateManager.Mira)
                {
                    if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)"))
                    {

                        if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() == 1)
                        {
                            GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV2;

                        }
                        else
                        {
                            GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV1;
                        }
                    }
                }


            }
        }
    }
        [HarmonyPatch(typeof(MapBehaviour), nameof(MapBehaviour.FixedUpdate))]
        class EngineerMapUpdate
        {
            static void Postfix(MapBehaviour __instance)
            {
                if (__instance.IsOpen)
                {
                    if (HudUpdateManager.Polus)
                    {
                        if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)"))
                        {

                            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapPL.getSelection() == 2)
                            {
                            if (ChallengerMod.Challenger.IsMapPolusV2) //START_V2
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV3;

                            }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV2;

                            }
                        }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("PbMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_PolusMapV1;
                            }
                        }
                    }
                    if (HudUpdateManager.Mira)
                    {
                        if (GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)"))
                        {

                            if (ChallengerOS.Utils.Option.CustomOptionHolder.BetterMapHQ.getSelection() == 1)
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV2;





                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("InfectedOverlay").transform.FindChild("Electrical").transform.localPosition = new Vector3(0.1785f, -1.8689f, -1f);
                            }
                            else
                            {
                                GameObject.Find("Main Camera").transform.FindChild("Hud").transform.FindChild("HqMap(Clone)").transform.FindChild("Background").GetComponent<SpriteRenderer>().sprite = LobbyLevel_MiraMapV1;
                            }
                        }
                    }


                }



            
        }
    }
}





            
        






          




