# What is it used for:
This is a custom Action class with its helper.
GameAction provides more secure Action usage.

# How to use:
GameAction declaration a little bit diffrent from default Action.
For example;

Action => public Action<int> OnCollectableTriggered;<br/>
GameAction => public GameAction<int> OnCollectableTriggered = new (nameof(OnCollectableTriggered), ref _onDestroy);<br/>
<br/>
As you can see left part is almost identical but GameAction has a need for constructor with 2 parameters.<br/>
First parammeter is the name of the GameAction for Logging purposes.<br/>
To secure static usage, Second parameter is an optional destroy trigger action to clear GameActions when given action is invoked.
