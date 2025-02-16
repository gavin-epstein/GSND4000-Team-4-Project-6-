using Unity.VisualScripting;
using UnityEngine;
//from https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-create-own-custom-event-send-node.html
//Custom node to send the Event
[UnitTitle("Send Tick Event")]
[UnitCategory("Events\\MyEvents")]//Setting the path to find the node in the fuzzy finder as Events > My Events.
public class SendTickEvent : Unit
{
    [DoNotSerialize]// Mandatory attribute, to make sure we don’t serialize data that should never be serialized.
    [PortLabelHidden]// Hide the port label, as we normally hide the label for default Input and Output triggers.
    public ControlInput inputTrigger { get; private set; }
   // [DoNotSerialize]
   // public ValueInput myValue;
    [DoNotSerialize]
    [PortLabelHidden]// Hide the port label, as we normally hide the label for default Input and Output triggers.
    public ControlOutput outputTrigger { get; private set; }

    protected override void Definition()
    {

        inputTrigger = ControlInput(nameof(inputTrigger), Trigger);
      //  myValue = ValueInput<int>(nameof(myValue), 1);
        outputTrigger = ControlOutput(nameof(outputTrigger));
        Succession(inputTrigger, outputTrigger);
    }

    //Send the Event MyCustomEvent with the integer value from the ValueInput port myValueA.
    private ControlOutput Trigger(Flow flow)
    {
        //EventBus.Trigger(EventNames.TickEvent, flow.GetValue<int>(myValue));
        EventBus.Trigger(EventNames.TickEvent,0);
        return outputTrigger;
    }
}