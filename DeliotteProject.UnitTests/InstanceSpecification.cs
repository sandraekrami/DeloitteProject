namespace DeliotteProject.UnitTests
{
    public abstract class InstanceSpecification<TSubjectUnderTest> : Specification
    {
        /// <summary>
        /// Subject Under Test
        /// </summary>
        protected TSubjectUnderTest SUT { get; private set; }

        protected abstract TSubjectUnderTest CreateSubjectUnderTest();

        protected override void InitialiseSubjectUnderTest()
        {
            SUT = CreateSubjectUnderTest();
        }
    }
}
