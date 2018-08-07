using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetupStack()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_WhenPushingNullValue_ReturnsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("a", 1)]
        public void Push_WhenPushingStrValue_CountOfStackIsCorrect(string val, int expectedResult)
        {
            _stack.Push(val);

            Assert.That(_stack.Count, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Count_EmptyStack_ReturnsZeroAsResult()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenPushedItems_ReturnsItemOnTop()
        {
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            Assert.That(_stack.Pop(), Is.EqualTo("C"));
        }

        [Test]
        public void Pop_WhenRemovedValue_StackIsEmpty()
        {
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_WhenStackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenPushedABC_ReturnsSameValue()
        {
            _stack.Push("abc");

            Assert.That(_stack.Peek(), Is.EqualTo("abc"));
        }

        [Test]
        public void Peek_WhenCalled_DoesNotUpdateStackCount()
        {
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");
            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
