using NUnit.Framework;
using ToDoBase.Core.Extensions;

namespace ToDoBase.Tests
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldNotContainDigits_Should_Work()
        {
            Assert.True("abc".ShouldNotContainDigits());
            Assert.True("i-dont_know_what_this_case_is".ShouldNotContainDigits());
            Assert.False("a1bc1".ShouldNotContainDigits());
            Assert.False("i-d343nt_know_what_this_case_is543".ShouldNotContainDigits());
        }

        [Test]
        public void ShouldContainDigits_Should_Work()
        {
            Assert.False("abc".ShouldContainDigits());
            Assert.False("i-dont_know_what_this_case_is".ShouldContainDigits());
            Assert.True("a1bc1".ShouldContainDigits());
            Assert.True("i-d343nt_know_what_this_case_is543".ShouldContainDigits());
        }
    }
}
