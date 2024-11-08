namespace FizzBuzzNamespace
{

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

    public class SuffixBeforeBCompositionAction : SimpleCompositionAction
    {
        public SuffixBeforeBCompositionAction(int divisorExpected, string label) : base(divisorExpected, label) { }

        public override List<string> apply(List<string> currentLabelSet)
        {
            int? indexOfFirstB = null;
            for (int i = 0; i < currentLabelSet.Count; i++)
            {
                if (indexOfFirstB == null && currentLabelSet[i].StartsWith('B'))
                {
                    indexOfFirstB = i;
                }
            }

            currentLabelSet.Insert(indexOfFirstB ?? currentLabelSet.Count, Label);
            return currentLabelSet;
        }
    }

    public class ReverseAllCompositionAction : SimpleCompositionAction
    {
        public ReverseAllCompositionAction(int divisorExpected) : base(divisorExpected, "N/A") { }

        public override List<string> apply(List<string> currentLabelSet)
        {
            currentLabelSet.Reverse();
            return currentLabelSet;
        }
    }
}
