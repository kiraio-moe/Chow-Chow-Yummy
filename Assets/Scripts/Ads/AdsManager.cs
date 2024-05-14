using UnityEngine;
using GoogleMobileAds.Api;

namespace Aili.Ads
{
	[AddComponentMenu("Aili/Ads/Ads Manager")]
	public class AdsManager : MonoBehaviour
	{
		void Awake()
		{
			MobileAds.Initialize(initStatus => { });
		}
	}
}
