using System;
using System.Collections.Generic;
using System.Linq;

public interface IRefresher
{

    void Subscribe(String ChannelName, Action Event);
    void Unsubscribe(String ChannelName, Action Event);
    void CallRequestRefresh(String ChannelName);
}


public class Refresher : IRefresher
{
    private Dictionary<String, Action> Subscriptions { get; init; }

    public Refresher()
    {
        Subscriptions = new Dictionary<String, Action>();
    }

    public void CallRequestRefresh(String ChannelName)
    {
        Subscriptions[ChannelName]?.Invoke();
    }

    public void Subscribe(String ChannelName, Action Event)
    {

        //Create a new delegate if there is nothing on this channel yet. 
        if (!Subscriptions.ContainsKey(ChannelName))
            Subscriptions[ChannelName] = () => { };

        //Prevent multiple subscribtions by the same page...
        if (Subscriptions[ChannelName] == null ||
            !Subscriptions[ChannelName].GetInvocationList().Select(il => il.Method).Contains(Event.Method))
        {
            Subscriptions[ChannelName] += Event;
        }

        Subscriptions[ChannelName] += Event;
    }

    public void Unsubscribe(String ChannelName, Action Event)
    {
        Console.WriteLine("Removing subscription for " + ChannelName.ToString());

        //Preventing double un-subscription. 
        if (Subscriptions[ChannelName] != null)
        {
            Action eventMethod = (Action)Subscriptions[ChannelName]
                .GetInvocationList()
                .FirstOrDefault(il => il.Method == Event.Method);

            if (eventMethod != null)
            {
                Subscriptions[ChannelName] -= eventMethod;
            }
        }
    }
}