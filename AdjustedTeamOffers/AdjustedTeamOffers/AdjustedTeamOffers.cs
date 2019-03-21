using Harmony;
using System.Reflection;

namespace AdjustedTeamOffers
{
    public class AdjustedTeamOffers
    {
        public static void Init() {
            var harmony = HarmonyInstance.Create("de.morphyum.AdjustedTeamOffers");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
