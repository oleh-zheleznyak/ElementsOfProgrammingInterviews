using Problems.Chapter17_DynamicProgramming;
namespace Chapter17_DynamicProgramming
{
    public class LevensteinDistanceTests : LevensteinDistanceTestsBase
    {
        public override ILevensteinDistance CreateLevensteinDistance()=>new LevensteinDistance();
    }
}