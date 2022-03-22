// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearDynamicEntitiesTests.cs" company="Millmann.Biz">
//   (c) 2022 by Hans Ludwig Millmann
// </copyright>
// <summary>
//   Defines the ClearDynamicEntitiesTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicEntities.Test
{
    using Xunit;

    /// <summary>
    /// The clear dynamic entities tests.
    /// </summary>
    public class ClearDynamicEntitiesTests
    {
        /// <summary>
        /// The test clear dynamic entities.
        /// </summary>
        [Fact]
        public void TestClearDynamicEntities()
        {
            var directive = ClearDynamicEntities.Clear();

            Assert.NotNull(directive);
        }
    }
}
