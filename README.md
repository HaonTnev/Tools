Welcome to Haon.Utils

This is my first attempt at making a package for unity. 
It is a first draft and will definitely grow over time.

If you have any feedback, questions, remarks etc. feel free to reach out to me

It includes:
    
    - Some c# extension Methods
        You can find them in the ExtensionMethods.cs
    
    - Singleton pattern for pure c# classes to inherit from. Making them a singleton instantly
        To use it just inherit from Singleton<T> where T is your class

    - Singleton pattern for MonoBehaviour classes to inherit from. Making them a MonoSingleton instantly.
        To use it simply inherit from MonoSingleton<T> where T is your own class. (insert sean bean meme here)

    - Simple Object Pooling pattern which works for prefabs and support searching the pool by tag.
        To use it simply put the ObjectPool component on a game object. 
        You can add as many pool objects as you like. 
        you can retrieve objects from it neatly from everywhere, since it inherits from MonoSingleton. 

    - Event system based on scriptable objects
        You can create new events by the create asset menu "Event/ScriptableObjectEvent"
        There is a EventListner and an EventInvoker component you can hook your events into. 
        The Event Invoker component adds a button onto the GameObject inside the 
        Hierearchy which will, if pressed, invoke all events stored in that instance. 

    - Save system to store your games progress
        NOTE: that the save system as of now will only Save MonoBehaviour data.
        To make use of it make a game oject and add the SaveDataManager to it, which inherits from MonoSingleton
        In order to save your own files implement the ISaveData interface in your scripts. 
        Then you have to extend the SaveData class by whatever you wish to store inside it. 
        Since it is a partial class you can do so quite easily. 
        To do so you need a Assembly reference to Haon.Utils in your project 
        Make sure you are extending it inside of the namespace Haon.Utils!!!

    - A Hierarchy highlight system 
        It lets you configure special icons to show up in the hierachy 
        on game objects with a component you specify. 
        To use it go to Tools-> Hierachy Highlight Settings
        There, specify which script you want to highlight and which icon you want the highlight to be.
        Some icons are provided by the package. But feel free to use your own. 
        
        NOTE: There will be an error saying "ScriptableSingleton already exists. Did you query the singleton in a constructor?"
            I do not know how to get rid of this. But it doesen't seem to impact the functionality. 
    
    - A component which lets you configure scene Icons in scene view
        To use it add the SceneIcon component to your game object

    - A DLL containing all of theabove mentioned

Thank you for existing & have a great day!