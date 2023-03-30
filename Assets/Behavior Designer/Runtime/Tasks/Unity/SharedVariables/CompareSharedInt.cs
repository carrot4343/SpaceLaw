namespace BehaviorDesigner.Runtime.Tasks.Unity.SharedVariables
{
    [TaskCategory("Unity/SharedVariable")]
    [TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
    public class CompareSharedInt : Conditional
    {
        [Tooltip("The first variable to compare")]
        public SharedInt variable;
        [Tooltip("The variable to compare to")]
        public SharedInt compareTo;

        public override TaskStatus OnUpdate()
        {
            return variable.Value.Equals(compareTo.Value) ? TaskStatus.Failure : TaskStatus.Success;
        }

        public override void OnReset()
        {
            variable.SetValue(GetComponent<Behavior>().GetVariable("numAtk"));
            compareTo = 3;
        }
    }
}