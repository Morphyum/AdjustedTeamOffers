using Harmony;
using MM2;
using TMPro;
using UnityEngine.UI;

namespace AdjustedTeamOffers {
    class Patches {

        [HarmonyPatch(typeof(TeamPrincipal), "canJoinTeam")]
        public static class TeamPrincipal_canJoinTeam_Patch {
            public static void Postfix(TeamPrincipal __instance, ref bool __result, Team inTeam) {
                __result = false;
                if (!Game.instance.player.IsUnemployed()) {
                    if (inTeam.teamStatistics.GetTeamStars() < Game.instance.player.team.teamStatistics.GetTeamStars()) {
                        __result = true;
                    }
                }
                else if (inTeam.teamStatistics.GetTeamStars() < Game.instance.player.careerHistory.previousTeam.teamStatistics.GetTeamStars()) {
                    __result = true;
                }
            }
        }

        [HarmonyPatch(typeof(SetUITextToVersionNumber), "Awake")]
        public static class SetUITextToVersionNumber_Awake_Patch {
            public static void Postfix(SetUITextToVersionNumber __instance) {
                Text component = __instance.GetComponent<Text>();
                if (component != null) {
                    component.text = component.text + " +ATO-0.1";
                }
                TextMeshProUGUI component2 = __instance.GetComponent<TextMeshProUGUI>();
                if (component2 != null) {
                    component2.text = component2.text + " +ATO-0.1";
                }
            }
        }
    }
}
