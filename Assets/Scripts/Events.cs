using UnityEngine;
using System.Collections;
using TinyMessenger;

public class Events {

	private static TinyMessengerHub instance = new TinyMessengerHub();

	public static TinyMessengerHub eventBus()
	{
		return instance;
	}
}

public class AppleEaten : ITinyMessage
{
	public object Sender {
		get {
			return null;
		}
	}
}
