using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
	public class EventHelper
	{
#if UNITY_EDITOR
    #region Logger
		private static readonly List<string> EventLog = new List<string>(){"EVENT LOG"};
		public static void RecordEvent(string eventName) => EventLog.Add(eventName);

		public static void ShowEventLog()
		{
			string log = EventLog.Count > 1
				? string.Join("\n", EventLog)
				: "Event Log is empty.";
	    
			Debug.Log(log);
		}
    #endregion
    
	#region NameChecker
		private const string SubscriberFormat = "{0}Handler";
		private const string DenyMessage = "{0} of <color=#FF0000>\"{0}\"</color> to \"{1}\" event is failed. Allowed method name is <color=#00FF00>\"{2}\"</color>";
		private const string AcceptMessage = "<color=#00FF00>{0} of \"{0}\" to \"{1}\" event succeed.</color>";

		public static bool CheckNameFormatsMatching(string applicant, string target, bool isSub)
		{
			string operation = isSub ? "Subscription" : "Unsubscribe";

			string correctName = string.Format(SubscriberFormat, target);
			if (applicant == correctName)
			{
				Debug.Log(string.Format(AcceptMessage, operation, applicant, target, correctName));
				return true;
			}

			Debug.Log(string.Format(DenyMessage, operation, applicant, target, correctName));
			return false;
		}
	#endregion
#endif
	}
}

