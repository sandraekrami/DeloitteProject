namespace DeliotteProject.UnitTests
{
    public abstract class Specification
    {
        protected Specification()
        {
            EstablishContext();
            InitialiseSubjectUnderTest();
            Because();
        }

        protected virtual void EstablishContext()
        {
        }

        protected virtual void InitialiseSubjectUnderTest()
        {
        }

        protected virtual void Because()
        {
        }

        public void Dispose()
        {
            DisposeContext();
        }

        protected virtual void DisposeContext()
        {
        }
    }
}