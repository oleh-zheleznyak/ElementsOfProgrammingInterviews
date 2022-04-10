using Problems.Chapter17_DynamicProgramming;
namespace Chapter17_DynamicProgramming
{
    public class LevensteinDistanceByTheBookTests : LevensteinDistanceTestsBase
    {
        public override ILevensteinDistance CreateLevensteinDistance() => new LevensteinDistanceByTheBook();
    }
}