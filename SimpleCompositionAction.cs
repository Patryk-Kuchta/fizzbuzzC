using FizzBuzzNamespace;
using System.Reflection.Emit;

//{ 3, CompositionActions.AppendFizz },
//                { 5, CompositionActions.AppendBuzz },
//                { 7, CompositionActions.AppendBang },
//                { 11, CompositionActions.ReplaceEverythingWithBong },
//                { 13, CompositionActions.SuffixWithFezz },
//                { 17, CompositionActions.ReverseAll }

namespace FizzBuzzNamespace
{
    // order of the action matters, they must be applied in this order
    public enum CompositionActions
    {
        AppendFizz,
        AppendBuzz,
        AppendBang,
        ReplaceEverythingWithBong,
        SuffixWithFezz,
        ReverseAll
    }

    public class SimpleCompositionAction
    {
        private int DivisorExpected;
        protected string Label;

        public SimpleCompositionAction(int divisorExpected, string label)
        {
            DivisorExpected = divisorExpected;
            Label = label;
        }

        public virtual List<string> apply(List<string> currentLabelSet)
        {
            currentLabelSet.Add(Label);
            return currentLabelSet;
        }

        public bool isMeetingActionCondition(int input)
        {
            return input % DivisorExpected == 0;
        }
    }

    public class ReplacerCompositionAction : SimpleCompositionAction
    {
        public ReplacerCompositionAction(int divisorExpected, string label): base(divisorExpected, label) {}

        public override List<string> apply(List<string> currentLabelSet)
        {
            return new List<string> { base.Label };
        }
    }
}
