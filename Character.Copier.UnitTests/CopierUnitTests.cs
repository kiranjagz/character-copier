namespace Character.Copier.UnitTests
{
    [TestFixture]
    public class Given_the_copier_class
    {
        public class When_calling_the_copy_method
        {
            private ICopier _copier;
            private Mock<ISource> _source;
            private Mock<IDestination> _destination;

            [OneTimeSetUp]
            public void OneTimeSetup()
            {
                _source = new Mock<ISource>();
                _destination = new Mock<IDestination>();
            }

            [TestCase('a')]
            [TestCase('b')]
            [TestCase('1')]
            [TestCase('2')]
            public void Should_call_readChar_when_copy_is_called(char readOutput)
            {
                _source.Setup(s => s.ReadChar()).Returns(readOutput);

                _copier = new Copier(_source.Object, _destination.Object);
                _copier.Copy();

                _source.Verify(mock => mock.ReadChar(), Times.AtLeastOnce());
            }

            [TestCase('a', 'a')]
            [TestCase('b', 'b')]
            [TestCase('1', '1')]
            [TestCase('2', '2')]
            public void Should_call_writeChar_when_copy_is_called(char readOutput, char writeInput)
            {
                _source.Setup(s => s.ReadChar()).Returns(readOutput);
                _destination.Setup(s => s.WriteChar(writeInput));

                _copier = new Copier(_source.Object, _destination.Object);
                _copier.Copy();

                _destination.Verify(mock => mock.WriteChar(writeInput), Times.AtLeastOnce());
            }

            [Test]
            public void Should_not_call_writeChar_when_a_newline_is_returned()
            {
                var newline = '\n';

                _source.Setup(s => s.ReadChar()).Returns(newline);

                _copier = new Copier(_source.Object, _destination.Object);
                _copier.Copy();

                _destination.Verify(mock => mock.WriteChar(newline), Times.Never());
            }


            [TestCase('a')]
            public void Should_have_same_char_for_readChar_and_writeChar(char readOutput)
            {
                _source.Setup(s => s.ReadChar()).Returns(readOutput);

                _copier = new Copier(_source.Object, _destination.Object);
                _copier.Copy();

                _destination.Verify(mock => mock.WriteChar(It.Is<char>(u => u == readOutput)));
            }
        }
    }
}