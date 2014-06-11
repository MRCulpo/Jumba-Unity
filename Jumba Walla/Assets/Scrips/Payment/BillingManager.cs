using UnityEngine;
using System.Collections;

public class BillingManager {

	static BillingManager(){

#if UNITY_ANDROID
		string _key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkDWcF/KohRYKAtN/egO7gCm3yL8kHThrqFk0kDu7DaEWK9cfbbHCk3t9+S3x1SBNiDSDrWekMFLwtlkLcyjcfiROA3fHcw8s1yb5xhLhPpgE8bQcrBycmyZPUjj5ott1Ua+o/LCIcUtTzVM/dx8URKqGBDRe4e9Jz5PDOVI6OhQj9Vm0K7u66MJo9cgh15R4P++b6vkZxDHFg8pZU6bqJCzQFl7XVUD2g1mtinpxtlmCLYju5SNvf0rlVPysIv9umJuH3AWHEtQkOVGxZT1K/NlZh/NIPnMlKRgdcDkPj8FmwIIemIuTzCpfB3KSP+ZpaQcj+wCHVhPfqNKzu1aLYQIDAQAB";
		
		GoogleIAB.init(_key);
#endif
		
	}

	public static void get()
	{
	}

	public static void getItems(){

		string[] _idItems = new string[] {BillingItemsIDs.teeth_01, BillingItemsIDs.teeth_02, 
			BillingItemsIDs.teeth_03, BillingItemsIDs.teeth_04};

#if UNITY_ANDROID
		GoogleIAB.queryInventory(_idItems);
#elif UNITY_IPHONE
		StoreKitBinding.requestProductData(_idItems);
#endif

	}
	
	public static void buyItem(string itemID){

#if UNITY_ANDROID
		GoogleIAB.purchaseProduct(itemID);
#elif UNITY_IPHONE
		StoreKitBinding.purchaseProduct(itemID, 1);
#endif

	}

	public static void consumeItem(string itemID){

#if UNITY_ANDROID
		GoogleIAB.consumeProduct(itemID);
#endif
				
	}

}