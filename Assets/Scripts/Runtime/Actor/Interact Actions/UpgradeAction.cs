using Runtime.Resources;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public class UpgradeAction : InteractionAction
    {
        public override InteractionType Type => InteractionType.Upgrade;

        [SerializeField] private Requirement upgradeRequirement;

        protected override void Awake()
        {
            base.Awake();
            Callback += UpgradeRequirement;
        }

        private void UpgradeRequirement()
        {
            if (upgradeRequirement.AmountMet())
            {
                upgradeRequirement.Remove();
                GetComponent<Building>().SetBuilding();
                GetComponent<Building>().baseCircle.SetActive(false);
                GetComponent<Building>().built = true;
            }
        }
    }
}