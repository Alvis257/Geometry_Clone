using UnityEngine;

namespace Assets
{
    public class PortalToFly : MonoBehaviour
    {
        public bool portalChcek;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Portal"))
            {
                if (!portalChcek)
                    portalChcek = true;
            }
            else if (coll.gameObject.CompareTag("PortalExit"))
                if (portalChcek)
                    portalChcek = false;
        }

        public void ResetValue()
        {
            portalChcek = false;
        }

        public bool GetValue()
        {
            return portalChcek;
        }
    }
}